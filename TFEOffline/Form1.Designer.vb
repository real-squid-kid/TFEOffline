<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenBtn = New System.Windows.Forms.Button()
        Me.EntryStatusLbl = New System.Windows.Forms.Label()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.TicketsListBtn = New System.Windows.Forms.Button()
        Me.EventTitleLbl = New System.Windows.Forms.Label()
        Me.EventLocationLbl = New System.Windows.Forms.Label()
        Me.NameSurnameLbl = New System.Windows.Forms.Label()
        Me.TicketTypeLbl = New System.Windows.Forms.Label()
        Me.TicketIDTxt = New System.Windows.Forms.TextBox()
        Me.StatusLbl = New System.Windows.Forms.Label()
        Me.Changeback = New System.Windows.Forms.Timer(Me.components)
        Me.CurrentTimeLbl = New System.Windows.Forms.Label()
        Me.CurrentTimeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.WriteLogBtn = New System.Windows.Forms.Button()
        Me.LogLbl = New System.Windows.Forms.Label()
        Me.LockBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OpenBtn
        '
        Me.OpenBtn.Location = New System.Drawing.Point(89, 10)
        Me.OpenBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.OpenBtn.Name = "OpenBtn"
        Me.OpenBtn.Size = New System.Drawing.Size(82, 29)
        Me.OpenBtn.TabIndex = 0
        Me.OpenBtn.Text = "Импорт...."
        Me.OpenBtn.UseVisualStyleBackColor = True
        '
        'EntryStatusLbl
        '
        Me.EntryStatusLbl.BackColor = System.Drawing.Color.Teal
        Me.EntryStatusLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EntryStatusLbl.ForeColor = System.Drawing.Color.White
        Me.EntryStatusLbl.Location = New System.Drawing.Point(9, 7)
        Me.EntryStatusLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.EntryStatusLbl.Name = "EntryStatusLbl"
        Me.EntryStatusLbl.Size = New System.Drawing.Size(76, 351)
        Me.EntryStatusLbl.TabIndex = 1
        Me.EntryStatusLbl.Text = "🔵"
        Me.EntryStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(262, 10)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(82, 29)
        Me.SaveBtn.TabIndex = 0
        Me.SaveBtn.Text = "Сохранить..."
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'TicketsListBtn
        '
        Me.TicketsListBtn.Location = New System.Drawing.Point(176, 10)
        Me.TicketsListBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.TicketsListBtn.Name = "TicketsListBtn"
        Me.TicketsListBtn.Size = New System.Drawing.Size(82, 29)
        Me.TicketsListBtn.TabIndex = 0
        Me.TicketsListBtn.Text = "Список..."
        Me.TicketsListBtn.UseVisualStyleBackColor = True
        '
        'EventTitleLbl
        '
        Me.EventTitleLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventTitleLbl.Location = New System.Drawing.Point(89, 45)
        Me.EventTitleLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.EventTitleLbl.Name = "EventTitleLbl"
        Me.EventTitleLbl.Size = New System.Drawing.Size(502, 38)
        Me.EventTitleLbl.TabIndex = 2
        Me.EventTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EventLocationLbl
        '
        Me.EventLocationLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EventLocationLbl.Location = New System.Drawing.Point(89, 83)
        Me.EventLocationLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.EventLocationLbl.Name = "EventLocationLbl"
        Me.EventLocationLbl.Size = New System.Drawing.Size(502, 38)
        Me.EventLocationLbl.TabIndex = 2
        Me.EventLocationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NameSurnameLbl
        '
        Me.NameSurnameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameSurnameLbl.Location = New System.Drawing.Point(89, 158)
        Me.NameSurnameLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.NameSurnameLbl.Name = "NameSurnameLbl"
        Me.NameSurnameLbl.Size = New System.Drawing.Size(502, 58)
        Me.NameSurnameLbl.TabIndex = 2
        Me.NameSurnameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TicketTypeLbl
        '
        Me.TicketTypeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TicketTypeLbl.Location = New System.Drawing.Point(93, 217)
        Me.TicketTypeLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TicketTypeLbl.Name = "TicketTypeLbl"
        Me.TicketTypeLbl.Size = New System.Drawing.Size(502, 38)
        Me.TicketTypeLbl.TabIndex = 2
        Me.TicketTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TicketIDTxt
        '
        Me.TicketIDTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TicketIDTxt.Location = New System.Drawing.Point(190, 335)
        Me.TicketIDTxt.Margin = New System.Windows.Forms.Padding(2)
        Me.TicketIDTxt.Name = "TicketIDTxt"
        Me.TicketIDTxt.Size = New System.Drawing.Size(301, 26)
        Me.TicketIDTxt.TabIndex = 3
        '
        'StatusLbl
        '
        Me.StatusLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLbl.Location = New System.Drawing.Point(93, 299)
        Me.StatusLbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.StatusLbl.Name = "StatusLbl"
        Me.StatusLbl.Size = New System.Drawing.Size(502, 33)
        Me.StatusLbl.TabIndex = 2
        Me.StatusLbl.Text = "Откройте список..."
        Me.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Changeback
        '
        Me.Changeback.Interval = 3500
        '
        'CurrentTimeLbl
        '
        Me.CurrentTimeLbl.AutoSize = True
        Me.CurrentTimeLbl.Location = New System.Drawing.Point(522, 18)
        Me.CurrentTimeLbl.Name = "CurrentTimeLbl"
        Me.CurrentTimeLbl.Size = New System.Drawing.Size(69, 13)
        Me.CurrentTimeLbl.TabIndex = 4
        Me.CurrentTimeLbl.Text = "00:00:00 ДП"
        '
        'CurrentTimeTimer
        '
        Me.CurrentTimeTimer.Enabled = True
        Me.CurrentTimeTimer.Interval = 1000
        '
        'WriteLogBtn
        '
        Me.WriteLogBtn.Enabled = False
        Me.WriteLogBtn.Location = New System.Drawing.Point(348, 10)
        Me.WriteLogBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.WriteLogBtn.Name = "WriteLogBtn"
        Me.WriteLogBtn.Size = New System.Drawing.Size(82, 29)
        Me.WriteLogBtn.TabIndex = 0
        Me.WriteLogBtn.Text = "Писать лог..."
        Me.WriteLogBtn.UseVisualStyleBackColor = True
        '
        'LogLbl
        '
        Me.LogLbl.AutoSize = True
        Me.LogLbl.Location = New System.Drawing.Point(13, 362)
        Me.LogLbl.Name = "LogLbl"
        Me.LogLbl.Size = New System.Drawing.Size(68, 13)
        Me.LogLbl.TabIndex = 5
        Me.LogLbl.Text = "Жду список"
        '
        'LockBtn
        '
        Me.LockBtn.Location = New System.Drawing.Point(434, 10)
        Me.LockBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.LockBtn.Name = "LockBtn"
        Me.LockBtn.Size = New System.Drawing.Size(82, 29)
        Me.LockBtn.TabIndex = 0
        Me.LockBtn.Text = "🔒"
        Me.LockBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 381)
        Me.Controls.Add(Me.LogLbl)
        Me.Controls.Add(Me.CurrentTimeLbl)
        Me.Controls.Add(Me.TicketIDTxt)
        Me.Controls.Add(Me.EventLocationLbl)
        Me.Controls.Add(Me.NameSurnameLbl)
        Me.Controls.Add(Me.StatusLbl)
        Me.Controls.Add(Me.TicketTypeLbl)
        Me.Controls.Add(Me.EventTitleLbl)
        Me.Controls.Add(Me.EntryStatusLbl)
        Me.Controls.Add(Me.LockBtn)
        Me.Controls.Add(Me.WriteLogBtn)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.TicketsListBtn)
        Me.Controls.Add(Me.OpenBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "TFEOffline"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenBtn As Button
    Friend WithEvents EntryStatusLbl As Label
    Friend WithEvents SaveBtn As Button
    Friend WithEvents TicketsListBtn As Button
    Friend WithEvents EventTitleLbl As Label
    Friend WithEvents EventLocationLbl As Label
    Friend WithEvents NameSurnameLbl As Label
    Friend WithEvents TicketTypeLbl As Label
    Friend WithEvents TicketIDTxt As TextBox
    Friend WithEvents StatusLbl As Label
    Friend WithEvents Changeback As Timer
    Friend WithEvents CurrentTimeLbl As Label
    Friend WithEvents CurrentTimeTimer As Timer
    Friend WithEvents WriteLogBtn As Button
    Friend WithEvents LogLbl As Label
    Friend WithEvents LockBtn As Button
End Class
