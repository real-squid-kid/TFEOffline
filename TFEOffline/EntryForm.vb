Imports MessagingToolkit.QRCode.Codec
Public Class EntryForm
    Dim CurrentEntry As Form1.TFETicket
    Private Sub EntryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentEntry = ListForm.CurrentEntry
        'fill all the fields
        FirstNameLbl.Text = CurrentEntry.FirstName
        LastNameLbl.Text = CurrentEntry.LastName
        TypeLbl.Text = CurrentEntry.Type
        IDLbl.Text = "ID: " & CurrentEntry.ID
        EmailLbl.Text = "Электронная почта: " & CurrentEntry.Email
        If CurrentEntry.Used = True Then
            Me.BackColor = Color.GreenYellow
            UsedLbl.Text = "Зашел: Да"
            TimeEnteredLbl.Text = "Когда зашел: " & CurrentEntry.TimeActivated
        Else
            Me.BackColor = Color.Khaki
            UsedLbl.Text = "Зашел: Нет"
            TimeEnteredLbl.Visible = False
        End If
        'generate qr code
        'library is too chunky so we leave the opportunity to not to include it
        Try
            Dim QREncoder As New QRCodeEncoder()
            Dim QRCode As Bitmap = QREncoder.Encode(CurrentEntry.ID)
            QRPBox.Image = QRCode
        Catch ex As Exception
            MessageBox.Show("Не удалось сгенерировать QR-код из-за отсутствия библиотеки MessagingToolkit.QRCode.", "Извините!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub EnteredNowBtn_Click(sender As Object, e As EventArgs) Handles EnteredNowBtn.Click
        'mark changes in the list
        For Each i As Form1.TFETicket In Form1.CurrentEvent.Tickets
            If i.ID = CurrentEntry.ID Then
                i.Used = True
                i.TimeActivated = Form1.DateToStirng()
                My.Computer.Audio.Play(My.Resources.Right, AudioPlayMode.Background)
                Form1.GenerateLog(CurrentEntry.ID & " " & CurrentEntry.FirstName & CurrentEntry.LastName & " " & "зашел через ручной выбор")
                'mark changes in the window
                Me.BackColor = Color.GreenYellow
                UsedLbl.Text = "Зашел: Да"
                TimeEnteredLbl.Text = "Когда зашел: " & Form1.DateToStirng()
                ListForm.Fresh()
                Exit For
            End If
        Next
    End Sub

    Private Sub NotEnteredBtn_Click(sender As Object, e As EventArgs) Handles NotEnteredBtn.Click
        'mark changes in the list
        For Each i As Form1.TFETicket In Form1.CurrentEvent.Tickets
            If i.ID = CurrentEntry.ID Then
                i.Used = False
                i.TimeActivated = "Не установлено"
                Form1.GenerateLog(CurrentEntry.ID & " " & CurrentEntry.FirstName & CurrentEntry.LastName & " " & "не заходил через ручной выбор")
                'mark changes in the window
                Me.BackColor = Color.Khaki
                UsedLbl.Text = "Зашел: Нет"
                TimeEnteredLbl.Visible = False
                ListForm.Fresh()
                Exit For
            End If
        Next
    End Sub
End Class