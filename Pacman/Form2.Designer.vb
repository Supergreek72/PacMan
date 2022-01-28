<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHighScore = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GhostOrange = New System.Windows.Forms.PictureBox()
        Me.Timer_Ghost = New System.Windows.Forms.Timer(Me.components)
        Me.ghostmove1 = New System.Windows.Forms.PictureBox()
        Me.ghostmove2 = New System.Windows.Forms.PictureBox()
        Me.ghostBlue = New System.Windows.Forms.PictureBox()
        Me.GhostRed = New System.Windows.Forms.PictureBox()
        Me.GhostPink = New System.Windows.Forms.PictureBox()
        Me.Pacman = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GhostOrange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ghostmove1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ghostmove2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ghostBlue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GhostRed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GhostPink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pacman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Power Clear", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.Red
        Me.btnStart.Location = New System.Drawing.Point(309, 405)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(266, 109)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.Pac_Man_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(94, 108)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(710, 217)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Power Clear", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(346, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 51)
        Me.Label2.TabIndex = 325
        Me.Label2.Text = "High Score"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHighScore
        '
        Me.lblHighScore.BackColor = System.Drawing.Color.Transparent
        Me.lblHighScore.Font = New System.Drawing.Font("Power Clear", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighScore.ForeColor = System.Drawing.Color.White
        Me.lblHighScore.Location = New System.Drawing.Point(408, 50)
        Me.lblHighScore.Name = "lblHighScore"
        Me.lblHighScore.Size = New System.Drawing.Size(79, 32)
        Me.lblHighScore.TabIndex = 326
        Me.lblHighScore.Text = "0"
        Me.lblHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Power Clear", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Red
        Me.btnClose.Location = New System.Drawing.Point(309, 558)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(266, 109)
        Me.btnClose.TabIndex = 327
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'GhostOrange
        '
        Me.GhostOrange.BackColor = System.Drawing.Color.Transparent
        Me.GhostOrange.Image = Global.WindowsApplication1.My.Resources.Resources.Ghost_Orange
        Me.GhostOrange.Location = New System.Drawing.Point(146, 356)
        Me.GhostOrange.Name = "GhostOrange"
        Me.GhostOrange.Size = New System.Drawing.Size(40, 40)
        Me.GhostOrange.TabIndex = 328
        Me.GhostOrange.TabStop = False
        '
        'Timer_Ghost
        '
        Me.Timer_Ghost.Enabled = True
        Me.Timer_Ghost.Interval = 1
        '
        'ghostmove1
        '
        Me.ghostmove1.BackColor = System.Drawing.Color.Transparent
        Me.ghostmove1.Location = New System.Drawing.Point(-32, 370)
        Me.ghostmove1.Name = "ghostmove1"
        Me.ghostmove1.Size = New System.Drawing.Size(18, 14)
        Me.ghostmove1.TabIndex = 329
        Me.ghostmove1.TabStop = False
        '
        'ghostmove2
        '
        Me.ghostmove2.BackColor = System.Drawing.Color.Transparent
        Me.ghostmove2.Location = New System.Drawing.Point(1070, 359)
        Me.ghostmove2.Name = "ghostmove2"
        Me.ghostmove2.Size = New System.Drawing.Size(111, 15)
        Me.ghostmove2.TabIndex = 330
        Me.ghostmove2.TabStop = False
        '
        'ghostBlue
        '
        Me.ghostBlue.BackColor = System.Drawing.Color.Transparent
        Me.ghostBlue.Image = Global.WindowsApplication1.My.Resources.Resources.Ghost_Blue
        Me.ghostBlue.Location = New System.Drawing.Point(54, 356)
        Me.ghostBlue.Name = "ghostBlue"
        Me.ghostBlue.Size = New System.Drawing.Size(40, 40)
        Me.ghostBlue.TabIndex = 332
        Me.ghostBlue.TabStop = False
        '
        'GhostRed
        '
        Me.GhostRed.BackColor = System.Drawing.Color.Transparent
        Me.GhostRed.Image = Global.WindowsApplication1.My.Resources.Resources.Ghost_Red
        Me.GhostRed.Location = New System.Drawing.Point(100, 356)
        Me.GhostRed.Name = "GhostRed"
        Me.GhostRed.Size = New System.Drawing.Size(40, 40)
        Me.GhostRed.TabIndex = 333
        Me.GhostRed.TabStop = False
        '
        'GhostPink
        '
        Me.GhostPink.BackColor = System.Drawing.Color.Transparent
        Me.GhostPink.Image = Global.WindowsApplication1.My.Resources.Resources.Ghost_Pink
        Me.GhostPink.Location = New System.Drawing.Point(192, 356)
        Me.GhostPink.Name = "GhostPink"
        Me.GhostPink.Size = New System.Drawing.Size(40, 40)
        Me.GhostPink.TabIndex = 334
        Me.GhostPink.TabStop = False
        '
        'Pacman
        '
        Me.Pacman.BackColor = System.Drawing.Color.Transparent
        Me.Pacman.Image = Global.WindowsApplication1.My.Resources.Resources.PacmanGif
        Me.Pacman.Location = New System.Drawing.Point(286, 359)
        Me.Pacman.Name = "Pacman"
        Me.Pacman.Size = New System.Drawing.Size(35, 35)
        Me.Pacman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pacman.TabIndex = 335
        Me.Pacman.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(897, 790)
        Me.Controls.Add(Me.Pacman)
        Me.Controls.Add(Me.GhostPink)
        Me.Controls.Add(Me.GhostRed)
        Me.Controls.Add(Me.ghostBlue)
        Me.Controls.Add(Me.ghostmove2)
        Me.Controls.Add(Me.ghostmove1)
        Me.Controls.Add(Me.GhostOrange)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblHighScore)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Pacman"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GhostOrange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ghostmove1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ghostmove2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ghostBlue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GhostRed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GhostPink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pacman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHighScore As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GhostOrange As System.Windows.Forms.PictureBox
    Friend WithEvents Timer_Ghost As System.Windows.Forms.Timer
    Friend WithEvents ghostmove1 As System.Windows.Forms.PictureBox
    Friend WithEvents ghostmove2 As System.Windows.Forms.PictureBox
    Friend WithEvents ghostBlue As System.Windows.Forms.PictureBox
    Friend WithEvents GhostRed As System.Windows.Forms.PictureBox
    Friend WithEvents GhostPink As System.Windows.Forms.PictureBox
    Friend WithEvents Pacman As System.Windows.Forms.PictureBox
End Class
