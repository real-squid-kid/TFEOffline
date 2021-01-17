Public Class ListForm

    Dim TotalTickets As String
    Dim Entered As String
    Dim Waiting As String
    Dim AllEntries As New List(Of String)
    Public CurrentEntry As Form1.TFETicket
    Private Sub ListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fresh()
    End Sub

    Public Sub Fresh()
        'full refresh
        'first we clean up everything
        AllEntries.Clear()
        EntriesLst.Items.Clear()
        TotalTickets = 0
        Entered = 0
        Waiting = 0
        'retrieving tickets list
        For Each a As Form1.TFETicket In Form1.CurrentEvent.Tickets
            TotalTickets += 1
            Dim NewString As String
            Dim EnteredStatus As String
            If a.Used = True Then
                EnteredStatus = "[✓] "
                Entered += 1
            Else
                EnteredStatus = "[⌚] "
                Waiting += 1
            End If
            NewString = EnteredStatus & a.ID & ", " & a.FirstName & " " & a.LastName
            EntriesLst.Items.Add(NewString)
            AllEntries.Add(NewString)
        Next
        'showing digits now
        TotalLbl.Text = TotalTickets
        Dim Percentage As Single
        Percentage = Int(Entered / TotalTickets * 100)
        EnteredLbl.Text = Entered & " / " & Percentage & "%"
        WaitingLbl.Text = Waiting
    End Sub

    Private Sub SearchTxt_TextChanged(sender As Object, e As EventArgs) Handles SearchTxt.TextChanged
        'we won't do stuff if only one character entered
        If SearchTxt.TextLength > 1 Then
            EntriesLst.Items.Clear()
            'searching in list
            Dim FoundEntries As New List(Of String)
            For Each a As String In AllEntries
                If a.Contains(SearchTxt.Text) Then
                    FoundEntries.Add(a)
                End If
            Next
            If FoundEntries.Count > 0 Then
                For Each a In FoundEntries
                    EntriesLst.Items.Add(a)
                Next
            Else
                EntriesLst.Items.Add("Ничего не найдено.")
            End If
        End If
        'if nothing is in search field, then we'll display everything
        If SearchTxt.TextLength = 0 Then
            EntriesLst.Items.Clear()
            For Each a In AllEntries
                EntriesLst.Items.Add(a)
            Next
        End If
    End Sub
    Private Sub EntriesLst_DoubleClick(sender As Object, e As EventArgs) Handles EntriesLst.DoubleClick
        'get current item
        Dim Selected As String = EntriesLst.Items(EntriesLst.SelectedIndex)
        'trim to get the id
        Dim SelectedID As String = Selected.Substring(4, 16)
        'search for the needed ticket and show it
        For Each i As Form1.TFETicket In Form1.CurrentEvent.Tickets
            If i.ID = SelectedID Then
                CurrentEntry = i
                EntryForm.ShowDialog()
                Exit For
            End If
        Next
    End Sub

End Class