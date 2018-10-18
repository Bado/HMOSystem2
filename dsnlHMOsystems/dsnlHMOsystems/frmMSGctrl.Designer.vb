<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMSGctrl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMSGctrl))
        Me.Open_timer = New System.Windows.Forms.Timer(Me.components)
        Me.Close_timer = New System.Windows.Forms.Timer(Me.components)
        Me.proxy_timer = New System.Windows.Forms.Timer(Me.components)
        Me.main_pan_colour = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_text = New System.Windows.Forms.Label()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.left_pan_colour = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.main_pan_colour.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.left_pan_colour.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Open_timer
        '
        Me.Open_timer.Interval = 8
        '
        'Close_timer
        '
        Me.Close_timer.Interval = 5
        '
        'proxy_timer
        '
        Me.proxy_timer.Interval = 3000
        '
        'main_pan_colour
        '
        Me.main_pan_colour.BackColor = System.Drawing.Color.PowderBlue
        Me.main_pan_colour.BackgroundImage = CType(resources.GetObject("main_pan_colour.BackgroundImage"), System.Drawing.Image)
        Me.main_pan_colour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.main_pan_colour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.main_pan_colour.Controls.Add(Me.PictureBox1)
        Me.main_pan_colour.Controls.Add(Me.lbl_text)
        Me.main_pan_colour.Controls.Add(Me.lbl_title)
        Me.main_pan_colour.Controls.Add(Me.left_pan_colour)
        Me.main_pan_colour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.main_pan_colour.Location = New System.Drawing.Point(0, 0)
        Me.main_pan_colour.Name = "main_pan_colour"
        Me.main_pan_colour.Size = New System.Drawing.Size(395, 102)
        Me.main_pan_colour.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(377, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'lbl_text
        '
        Me.lbl_text.BackColor = System.Drawing.Color.Transparent
        Me.lbl_text.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_text.Location = New System.Drawing.Point(31, 38)
        Me.lbl_text.Name = "lbl_text"
        Me.lbl_text.Size = New System.Drawing.Size(359, 56)
        Me.lbl_text.TabIndex = 2
        Me.lbl_text.Text = "Label1"
        '
        'lbl_title
        '
        Me.lbl_title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_title.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(32, 10)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(234, 12)
        Me.lbl_title.TabIndex = 1
        Me.lbl_title.Text = "Label1"
        '
        'left_pan_colour
        '
        Me.left_pan_colour.BackColor = System.Drawing.Color.Navy
        Me.left_pan_colour.BackgroundImage = CType(resources.GetObject("left_pan_colour.BackgroundImage"), System.Drawing.Image)
        Me.left_pan_colour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.left_pan_colour.Controls.Add(Me.PictureBox2)
        Me.left_pan_colour.Dock = System.Windows.Forms.DockStyle.Left
        Me.left_pan_colour.Location = New System.Drawing.Point(0, 0)
        Me.left_pan_colour.Name = "left_pan_colour"
        Me.left_pan_colour.Size = New System.Drawing.Size(21, 100)
        Me.left_pan_colour.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.dsnlHMOsystems.My.Resources.Resources.data_sciences_logo
        Me.PictureBox2.Location = New System.Drawing.Point(-1, -9)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 110)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'frmMSGctrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(395, 102)
        Me.Controls.Add(Me.main_pan_colour)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMSGctrl"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Messasge Alert"
        Me.TopMost = True
        Me.main_pan_colour.ResumeLayout(False)
        Me.main_pan_colour.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.left_pan_colour.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents main_pan_colour As System.Windows.Forms.Panel
    Friend WithEvents left_pan_colour As System.Windows.Forms.Panel
    Friend WithEvents lbl_text As System.Windows.Forms.Label
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Open_timer As System.Windows.Forms.Timer
    Friend WithEvents Close_timer As System.Windows.Forms.Timer
    Friend WithEvents proxy_timer As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
