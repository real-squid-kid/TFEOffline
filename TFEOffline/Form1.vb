Imports System.ComponentModel
Imports System.IO
Imports System.Web.Script.Serialization
Public Class Form1
    Private Const V As String = "• TFEOffline"
    Dim RawXMLData As String
    Dim MainDictionary As XElement
    Dim IsSaved As Boolean
    Dim IsLocked As Boolean
    Dim TempStatus As String
#Disable Warning IDE0044 ' STOP BUGGING ME UGH
    Public CurrentEvent As New TFEEvent 'main variable we'll be working with
#Enable Warning IDE0044
    Public Class TFEEvent
        'class for the whole event
        Public Title As String
        Public Period As String
        Public City As String
        Public Address As String
        Public TotalTicketsSold As Integer
        Public TicketTypes As New List(Of TFETicketType)
        Public Tickets As New List(Of TFETicket)
    End Class
    Public Class TFETicketType
        'class for ticket types, used only once when generating CurrentEvent 
        Public ID As String
        Public Name As String
    End Class
    Public Class TFETicket
        'class for the ticket itself
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
                'prepare window for working with tickets
                EventTitleLbl.Text = CurrentEvent.Title
                EventLocationLbl.Text = CurrentEvent.City & ", " & CurrentEvent.Address & ", " & CurrentEvent.Period
                StatusLbl.Text = "Отсканируйте билет..."
                TicketIDTxt.Focus()
                IsSaved = False
                Me.Text = "• TFEOffline"
                GenerateLog("Загружено " & CurrentEvent.TotalTicketsSold & " билетов")
            Catch ex As Exception
                'just in case wrong xml was given
                MessageBox.Show("Файл не может быть открыт. Причина: " & ex.Message, "Извините!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub TicketIDTxt_KeyDown(sender As Object, e As KeyEventArgs) Handles TicketIDTxt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsLocked = True Then
                'password is 4154866 for testing purposes
                If TicketIDTxt.Text = "4154866" Then
                    Unlock()
                    GenerateLog("Разблокировано")
                    TicketIDTxt.Text = ""
                    TicketIDTxt.Focus()
                    Exit Sub
                Else
                    StatusLbl.Text = "Неверный пароль!"
                    GenerateLog("Неверно введен пароль = " & TicketIDTxt.Text)
                    My.Computer.Audio.Play(My.Resources.siren, AudioPlayMode.Background)
                    TicketIDTxt.SelectAll()
                    TicketIDTxt.Focus()
                    Exit Sub
                End If
            End If
            For Each i In CurrentEvent.Tickets
                If i.ID = TicketIDTxt.Text Then
                    'ticket found
                    NameSurnameLbl.Text = i.FirstName & " " & i.LastName
                    TicketTypeLbl.Text = i.Type
                    If i.Used = True Then
                        'ticket already used
                        StatusLbl.Text = "Билет уже использован!"
                        GenerateLog(TicketIDTxt.Text & " " & NameSurnameLbl.Text & " " & "уже зашел, был отсканирован снова")
                        ChangeStatusRed()
                        Exit Sub
                    Else
                        'ticket is fresh
                        i.Used = True
                        i.TimeActivated = DateToStirng()
                        My.Computer.Audio.Play(My.Resources.Right, AudioPlayMode.Background)
                        GenerateLog(TicketIDTxt.Text & " " & NameSurnameLbl.Text & " " & "зашел")
                        ChangeStatusGreen()
                        Exit Sub
                    End If
                End If
            Next
            'ticket not found
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
        My.Computer.Audio.Play(My.Resources.siren, AudioPlayMode.Background)
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

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
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
            'done with saving
            IsSaved = True
            Me.Text = "TFEOffline"
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If IsLocked = True Then
            'if locked, we won't allow for the app to close
            MessageBox.Show("Приложение нельзя закрыть, пока оно заблокировано.", "Извините!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
            Exit Sub
        End If
        If IsSaved = False Then
            Dim result As DialogResult = MessageBox.Show("Сохранить результаты в файл?", "TFEOffline", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then
                'getting back
                e.Cancel = True
            ElseIf result = DialogResult.No Then
                'let it close
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
                    'this was supposed to be a sub
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
        'to do - write log in a file
    End Sub

    Private Sub Lock()
        'basically just the gui parts 
        IsLocked = True
        OpenBtn.Visible = False
        TicketsListBtn.Visible = False
        SaveBtn.Visible = False
        WriteLogBtn.Visible = False
        LockBtn.Visible = False
        EventTitleLbl.Visible = False
        EventLocationLbl.Visible = False
        NameSurnameLbl.Visible = False
        TicketTypeLbl.Visible = False
        LogLbl.Visible = False
        TempStatus = StatusLbl.Text
        StatusLbl.Text = "Разблокируйте..."
        TicketIDTxt.UseSystemPasswordChar = True
    End Sub

    Private Sub Unlock()
        'same with the gui parts
        IsLocked = False
        OpenBtn.Visible = True
        TicketsListBtn.Visible = True
        SaveBtn.Visible = True
        WriteLogBtn.Visible = True
        LockBtn.Visible = True
        EventTitleLbl.Visible = True
        EventLocationLbl.Visible = True
        NameSurnameLbl.Visible = True
        TicketTypeLbl.Visible = True
        LogLbl.Visible = True
        StatusLbl.Text = TempStatus
        TicketIDTxt.UseSystemPasswordChar = False
    End Sub

    Private Sub LockBtn_Click(sender As Object, e As EventArgs) Handles LockBtn.Click
        Lock()
        GenerateLog("Заблокировано")
    End Sub
End Class
