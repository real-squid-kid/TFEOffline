<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntryForm
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
        Me.FirstNameLbl = New System.Windows.Forms.Label()
        Me.LastNameLbl = New System.Windows.Forms.Label()
        Me.EmailLbl = New System.Windows.Forms.Label()
        Me.TypeLbl = New System.Windows.Forms.Label()
        Me.UsedLbl = New System.Windows.Forms.Label()
        Me.TimeEnteredLbl = New System.Windows.Forms.Label()
        Me.EnteredNowBtn = New System.Windows.Forms.Button()
        Me.NotEnteredBtn = New System.Windows.Forms.Button()
        Me.IDLbl = New System.Windows.Forms.Label()
        Me.QRPBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.QRPBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FirstNameLbl
        '
        Me.FirstNameLbl.AutoSize = True
        Me.FirstNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstNameLbl.Location = New System.Drawing.Point(82, 12)
        Me.FirstNameLbl.Name = "FirstNameLbl"
        Me.FirstNameLbl.Size = New System.Drawing.Size(68, 31)
        Me.FirstNameLbl.TabIndex = 1
        Me.FirstNameLbl.Text = "Имя"
        '
        'LastNameLbl
        '
        Me.LastNameLbl.AutoSize = True
        Me.LastNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastNameLbl.Location = New System.Drawing.Point(82, 43)
        Me.LastNameLbl.Name = "LastNameLbl"
        Me.LastNameLbl.Size = New System.Drawing.Size(131, 31)
        Me.LastNameLbl.TabIndex = 1
        Me.LastNameLbl.Text = "Фамилия"
        '
        'EmailLbl
        '
        Me.EmailLbl.AutoSize = True
        Me.EmailLbl.Location = New System.Drawing.Point(12, 156)
        Me.EmailLbl.Name = "EmailLbl"
        Me.EmailLbl.Size = New System.Drawing.Size(235, 13)
        Me.EmailLbl.TabIndex = 2
        Me.EmailLbl.Text = "Электронная почта: ivanivanov@example.com"
        '
        'TypeLbl
        '
        Me.TypeLbl.AutoSize = True
        Me.TypeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TypeLbl.Location = New System.Drawing.Point(6, 94)
        Me.TypeLbl.Name = "TypeLbl"
        Me.TypeLbl.Size = New System.Drawing.Size(155, 31)
        Me.TypeLbl.TabIndex = 1
        Me.TypeLbl.Text = "Тип билета"
        '
        'UsedLbl
        '
        Me.UsedLbl.AutoSize = True
        Me.UsedLbl.Location = New System.Drawing.Point(12, 180)
        Me.UsedLbl.Name = "UsedLbl"
        Me.UsedLbl.Size = New System.Drawing.Size(61, 13)
        Me.UsedLbl.TabIndex = 2
        Me.UsedLbl.Text = "Зашел: Да"
        '
        'TimeEnteredLbl
        '
        Me.TimeEnteredLbl.AutoSize = True
        Me.TimeEnteredLbl.Location = New System.Drawing.Point(12, 204)
        Me.TimeEnteredLbl.Name = "TimeEnteredLbl"
        Me.TimeEnteredLbl.Size = New System.Drawing.Size(195, 13)
        Me.TimeEnteredLbl.TabIndex = 2
        Me.TimeEnteredLbl.Text = "Когда зашел: 00:00:00 1 января 2021"
        '
        'EnteredNowBtn
        '
        Me.EnteredNowBtn.BackColor = System.Drawing.Color.GreenYellow
        Me.EnteredNowBtn.Location = New System.Drawing.Point(12, 230)
        Me.EnteredNowBtn.Name = "EnteredNowBtn"
        Me.EnteredNowBtn.Size = New System.Drawing.Size(104, 45)
        Me.EnteredNowBtn.TabIndex = 3
        Me.EnteredNowBtn.Text = "Зашел сейчас"
        Me.EnteredNowBtn.UseVisualStyleBackColor = False
        '
        'NotEnteredBtn
        '
        Me.NotEnteredBtn.BackColor = System.Drawing.Color.DarkSalmon
        Me.NotEnteredBtn.Location = New System.Drawing.Point(255, 230)
        Me.NotEnteredBtn.Name = "NotEnteredBtn"
        Me.NotEnteredBtn.Size = New System.Drawing.Size(104, 45)
        Me.NotEnteredBtn.TabIndex = 3
        Me.NotEnteredBtn.Text = "Не заходил"
        Me.NotEnteredBtn.UseVisualStyleBackColor = False
        '
        'IDLbl
        '
        Me.IDLbl.AutoSize = True
        Me.IDLbl.Location = New System.Drawing.Point(12, 134)
        Me.IDLbl.Name = "IDLbl"
        Me.IDLbl.Size = New System.Drawing.Size(120, 13)
        Me.IDLbl.TabIndex = 2
        Me.IDLbl.Text = "ID: 1234567890123456"
        '
        'QRPBox
        '
        Me.QRPBox.BackColor = System.Drawing.Color.White
        Me.QRPBox.Location = New System.Drawing.Point(88, 281)
        Me.QRPBox.Name = "QRPBox"
        Me.QRPBox.Size = New System.Drawing.Size(200, 200)
        Me.QRPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.QRPBox.TabIndex = 4
        Me.QRPBox.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TFEOffline.My.Resources.Resources.pfp
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'EntryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(371, 488)
        Me.Controls.Add(Me.QRPBox)
        Me.Controls.Add(Me.NotEnteredBtn)
        Me.Controls.Add(Me.EnteredNowBtn)
        Me.Controls.Add(Me.TimeEnteredLbl)
        Me.Controls.Add(Me.UsedLbl)
        Me.Controls.Add(Me.IDLbl)
        Me.Controls.Add(Me.EmailLbl)
        Me.Controls.Add(Me.TypeLbl)
        Me.Controls.Add(Me.LastNameLbl)
        Me.Controls.Add(Me.FirstNameLbl)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EntryForm"
        Me.Text = "Карточка билета"
        CType(Me.QRPBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents FirstNameLbl As Label
    Friend WithEvents LastNameLbl As Label
    Friend WithEvents EmailLbl As Label
    Friend WithEvents TypeLbl As Label
    Friend WithEvents UsedLbl As Label
    Friend WithEvents TimeEnteredLbl As Label
    Friend WithEvents EnteredNowBtn As Button
    Friend WithEvents NotEnteredBtn As Button
    Friend WithEvents IDLbl As Label
    Friend WithEvents QRPBox As PictureBox
End Class
