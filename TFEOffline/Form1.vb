Imports System.ComponentModel
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ookii.Dialogs
Public Class Form1
    Private Const V As String = "• TFEOffline"
    Dim RawXMLData As String
    Dim MainDictionary As XElement
    Dim IsSaved As Boolean
#Disable Warning IDE0044 ' STOP BUGGING ME UGH
    Public CurrentEvent As New TFEEvent
#Enable Warning IDE0044
    Public Class TFEEvent
        Public Title As String
        Public Period As String
        Public City As String
        Public Address As String
        Public TotalTicketsSold As Integer
        Public TicketTypes As New List(Of TFETicketType)
        Public Tickets As New List(Of TFETicket)
    End Class
    Public Class TFETicketType
        Public ID As String
        Public Name As String
    End Class
    Public Class TFETicket
        Public ID As String
        Public FirstName As String
        Public LastName As String
        Public Email As String
        Public Type As String
        Public Used As Boolean
        Public TimeActivated As String
    End Class
    Private Sub OpenBtn_Click(sender As Object, e As EventArgs) Handles OpenBtn.Click
        Dim FileOpener As New OpenFileDialog
        With FileOpener
            .FileName = ""
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Title = "Импорт базы данных TFE"
            .Filter = "База данных TFE в XML|*.xml"
        End With
        If FileOpener.ShowDialog = DialogResult.OK Then
            Try
                RawXMLData = File.ReadAllText(FileOpener.FileName)
                MainDictionary = XElement.Parse(RawXMLData)
                'load main information
                CurrentEvent.Title = MainDictionary.Element("title")
                CurrentEvent.Period = MainDictionary.Element("period")
                CurrentEvent.City = MainDictionary.Element("location").Element("city")
                CurrentEvent.Address = MainDictionary.Element("location").Element("address")
                CurrentEvent.TotalTicketsSold = MainDictionary.Element("ticketing").Element("sold")
                CurrentEvent.TicketTypes.Clear()
                CurrentEvent.Tickets.Clear()
                'load ticket types
                For Each Types In MainDictionary.Element("ticketing").Element("types").Elements("type")
                    Dim NewType As New TFETicketType With {
                        .ID = Types.Element("id").Value,
                        .Name = Types.Element("name").Value
                    }
                    CurrentEvent.TicketTypes.Add(NewType)
                Next
                'load tickets
                For Each Tickets In MainDictionary.Element("ticketing").Element("tickets").Elements("ticket")
                    Dim NewTicket As New TFETicket With {
                        .ID = Tickets.Attribute("id"),
                        .Email = Tickets.Element("email"),
                        .FirstName = Tickets.Element("firstname"),
                        .LastName = Tickets.Element("lastname"),
                        .Type = "Не установлено",
                        .TimeActivated = "Не установлено"
                    }
                    For Each CheckType In CurrentEvent.TicketTypes
                        If CheckType.ID = Tickets.Element("typeId") Then NewTicket.Type = CheckType.Name
                    Next
                    If Tickets.Element("activity") = "ENTERED" Then NewTicket.Used = True
                    CurrentEvent.Tickets.Add(NewTicket)
                Next
                EventTitleLbl.Text = CurrentEvent.Title
                EventLocationLbl.Text = CurrentEvent.City & ", " & CurrentEvent.Address & ", " & CurrentEvent.Period
                StatusLbl.Text = "Отсканируйте билет..."
                TicketIDTxt.Focus()
                IsSaved = False
                Me.Text = "• TFEOffline"
                GenerateLog("Загружено " & CurrentEvent.TotalTicketsSold & " билетов")
            Catch ex As Exception
                MessageBox.Show("Файл не может быть открыт. Причина: " & ex.Message, "Извините!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        '    Dim TD As New Ookii.Dialogs.TaskDialog
        '    Dim Not_ready As New TaskDialogButton("Остаться в мнимом комфорте")
        '    Dim Ready As New TaskDialogButton("Я готов")
        '    With TD
        '    .WindowTitle = "Внимание!"
        '   .MainInstruction = "Сейчас вы можете изменить дальнейшее развитие событий."
        '   r .Content = "Вас ожидает неизвестность, обещающая большее количество денег и карьерное движение. Однако, возможно, вы будете поражены синдромом самозванца, а в худшем - будете обмануты." & vbCrLf & "Вы готовы начать новый путь?"
        '    .MainIcon = TaskDialogIcon.Information
        '
        '   .Buttons.Add(Ready)
        '
        '   .Buttons.Add(Not_ready)
        '   End With
        '   Dim result As TaskDialogButton = TD.ShowDialog()

    End Sub


    Private Sub TicketIDTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles TicketIDTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each i In CurrentEvent.Tickets
                If i.ID = TicketIDTxt.Text Then
                    'билет найден
                    NameSurnameLbl.Text = i.FirstName & " " & i.LastName
                    TicketTypeLbl.Text = i.Type
                    If i.Used = True Then
                        StatusLbl.Text = "Билет уже использован!"
                        GenerateLog(TicketIDTxt.Text & " " & NameSurnameLbl.Text & " " & "уже зашел, был отсканирован снова")
                        ChangeStatusRed()
                        Exit Sub
                    Else
                        i.Used = True
                        i.TimeActivated = DateToStirng()
                        My.Computer.Audio.Play(My.Resources.Right, AudioPlayMode.Background)
                        GenerateLog(TicketIDTxt.Text & " " & NameSurnameLbl.Text & " " & "зашел")
                        ChangeStatusGreen()
                        Exit Sub
                    End If
                End If
            Next
            NameSurnameLbl.Text = TicketIDTxt.Text
            GenerateLog(TicketIDTxt.Text & " " & "не найден")
            StatusLbl.Text = "Билет не найден!"
            ChangeStatusRed()
        End If
    End Sub

    Public Sub ChangeStatusWait()
        EntryStatusLbl.BackColor = Color.Teal
        EntryStatusLbl.Text = "🔵"
        NameSurnameLbl.Text = ""
        TicketTypeLbl.Text = ""
        StatusLbl.Text = "Отсканируйте билет..."
        TicketIDTxt.Text = ""
        TicketIDTxt.Focus()
    End Sub

    Public Sub ChangeStatusRed()
        EntryStatusLbl.BackColor = Color.Red
        EntryStatusLbl.Text = "❌"
        My.Computer.Audio.Play(My.Resources.turniket_new, AudioPlayMode.Background)
        Changeback.Enabled = True
    End Sub
    Public Sub ChangeStatusGreen()
        EntryStatusLbl.BackColor = Color.Green
        EntryStatusLbl.Text = "⬅️"
        StatusLbl.Text = "Проходите, пожалуйста!"
        Changeback.Enabled = True
        IsSaved = False
        Me.Text = "• TFEOffline"
    End Sub

    Private Sub Changeback_Tick(sender As Object, e As EventArgs) Handles Changeback.Tick
        ChangeStatusWait()
        Changeback.Enabled = False
    End Sub

    Private Sub TicketsListBtn_Click(sender As Object, e As EventArgs) Handles TicketsListBtn.Click
        ListForm.ShowDialog()
    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click, WriteLogBtn.Click
        Dim FileSaver As New SaveFileDialog
        With FileSaver
            .FileName = ""
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Title = "Сохранить результат..."
            .Filter = "Результат в CSV|*.csv"
        End With
        If FileSaver.ShowDialog = DialogResult.OK Then
            'make csv file
            Dim Everything As New List(Of String)
            Dim Description As String = CurrentEvent.Title & "; " & CurrentEvent.Period & "; " & CurrentEvent.City & " " & CurrentEvent.Address & "; продано билетов " & CurrentEvent.TotalTicketsSold
            Everything.Add(Description)
            Description = "ID, Имя, Фамилия, Электронная почта, Тип билета, Зашел?, Когда зашел"
            Everything.Add(Description)
            For Each a As TFETicket In CurrentEvent.Tickets
                Dim TicketString As String
                TicketString = a.ID & "," & a.FirstName & "," & a.LastName & "," & a.Email & "," & a.Type & "," & a.Used.ToString & "," & a.TimeActivated
                Everything.Add(TicketString)
            Next
            If Not System.IO.File.Exists(FileSaver.FileName) = True Then
                Dim file As System.IO.FileStream
                file = System.IO.File.Create(FileSaver.FileName)
                file.Close()
            End If
            My.Computer.FileSystem.WriteAllText(FileSaver.FileName, String.Join(vbCrLf, Everything.ToArray()), False)
            IsSaved = True
            Me.Text = "TFEOffline"
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IsSaved = False Then
            Dim result As DialogResult = MessageBox.Show("Сохранить результаты в файл?", "TFEOffline", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                'do nothing
            ElseIf result = DialogResult.Yes Then
                Dim FileSaver As New SaveFileDialog
                With FileSaver
                    .FileName = ""
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    .Title = "Сохранить результат..."
                    .Filter = "Результат в CSV|*.csv"
                End With
                If FileSaver.ShowDialog = DialogResult.OK Then
                    'make csv file
                    Dim Everything As New List(Of String)
                    Dim Description As String = CurrentEvent.Title & "; " & CurrentEvent.Period & "; " & CurrentEvent.City & " " & CurrentEvent.Address & "; продано билетов " & CurrentEvent.TotalTicketsSold
                    Everything.Add(Description)
                    Description = "ID, Имя, Фамилия, Электронная почта, Тип билета, Зашел?"
                    Everything.Add(Description)
                    For Each a As TFETicket In CurrentEvent.Tickets
                        Dim TicketString As String
                        TicketString = a.ID & "," & a.FirstName & "," & a.LastName & "," & a.Email & "," & a.Type & "," & a.Used.ToString
                        Everything.Add(TicketString)
                    Next
                    If Not System.IO.File.Exists(FileSaver.FileName) = True Then
                        Dim file As System.IO.FileStream
                        file = System.IO.File.Create(FileSaver.FileName)
                        file.Close()
                    End If
                    My.Computer.FileSystem.WriteAllText(FileSaver.FileName, String.Join(vbCrLf, Everything.ToArray()), False)
                    IsSaved = True
                    Me.Text = "TFEOffline"
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub CurrentTimeTimer_Tick(sender As Object, e As EventArgs) Handles CurrentTimeTimer.Tick
        CurrentTimeLbl.Text = DateTime.Now.ToLongTimeString
    End Sub

    Public Function DateToStirng()
        Dim a As String
        a = DateTime.Now.ToLongTimeString & " " & DateTime.Now.ToLongDateString
        Return a
    End Function

    Public Sub GenerateLog(e As String)
        Dim logstring As String
        logstring = DateToStirng() & ", " & e
        LogLbl.Text = logstring
    End Sub
End Class
