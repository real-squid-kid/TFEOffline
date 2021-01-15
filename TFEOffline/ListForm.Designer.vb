<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotalLbl = New System.Windows.Forms.Label()
        Me.EnteredLbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.WaitingLbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EntriesLst = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchTxt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Всего"
        '
        'TotalLbl
        '
        Me.TotalLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLbl.Location = New System.Drawing.Point(12, 9)
        Me.TotalLbl.Name = "TotalLbl"
        Me.TotalLbl.Size = New System.Drawing.Size(99, 44)
        Me.TotalLbl.TabIndex = 1
        Me.TotalLbl.Text = "0000"
        Me.TotalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EnteredLbl
        '
        Me.EnteredLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnteredLbl.ForeColor = System.Drawing.Color.DarkRed
        Me.EnteredLbl.Location = New System.Drawing.Point(117, 9)
        Me.EnteredLbl.Name = "EnteredLbl"
        Me.EnteredLbl.Size = New System.Drawing.Size(215, 44)
        Me.EnteredLbl.TabIndex = 1
        Me.EnteredLbl.Text = "0000 / 000%"
        Me.EnteredLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(197, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Зашли"
        '
        'WaitingLbl
        '
        Me.WaitingLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WaitingLbl.ForeColor = System.Drawing.Color.DarkGreen
        Me.WaitingLbl.Location = New System.Drawing.Point(338, 9)
        Me.WaitingLbl.Name = "WaitingLbl"
        Me.WaitingLbl.Size = New System.Drawing.Size(99, 44)
        Me.WaitingLbl.TabIndex = 1
        Me.WaitingLbl.Text = "0000"
        Me.WaitingLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(368, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ждём"
        '
        'EntriesLst
        '
        Me.EntriesLst.FormattingEnabled = True
        Me.EntriesLst.Location = New System.Drawing.Point(13, 109)
        Me.EntriesLst.Name = "EntriesLst"
        Me.EntriesLst.Size = New System.Drawing.Size(437, 368)
        Me.EntriesLst.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Поиск:"
        '
        'SearchTxt
        '
        Me.SearchTxt.Location = New System.Drawing.Point(61, 83)
        Me.SearchTxt.Name = "SearchTxt"
        Me.SearchTxt.Size = New System.Drawing.Size(389, 20)
        Me.SearchTxt.TabIndex = 4
        '
        'ListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 491)
        Me.Controls.Add(Me.SearchTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EntriesLst)
        Me.Controls.Add(Me.EnteredLbl)
        Me.Controls.Add(Me.WaitingLbl)
        Me.Controls.Add(Me.TotalLbl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListForm"
        Me.Text = "Список"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TotalLbl As Label
    Friend WithEvents EnteredLbl As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents WaitingLbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EntriesLst As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SearchTxt As TextBox
End Class
