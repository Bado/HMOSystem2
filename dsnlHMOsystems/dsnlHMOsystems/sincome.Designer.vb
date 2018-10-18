<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sincome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sincome))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.edate = New System.Windows.Forms.DateTimePicker()
        Me.stoplbl = New System.Windows.Forms.Label()
        Me.sdate = New System.Windows.Forms.DateTimePicker()
        Me.typedesc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button8)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.edate)
        Me.GroupBox6.Controls.Add(Me.stoplbl)
        Me.GroupBox6.Controls.Add(Me.sdate)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(444, 80)
        Me.GroupBox6.TabIndex = 109
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Period to print"
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.DarkKhaki
        Me.Button8.Location = New System.Drawing.Point(338, 26)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(84, 25)
        Me.Button8.TabIndex = 52
        Me.Button8.Text = "Print"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(171, 33)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 13)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "End Date"
        '
        'edate
        '
        Me.edate.CustomFormat = "dd/MM/yyyy"
        Me.edate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.edate.Location = New System.Drawing.Point(227, 29)
        Me.edate.Name = "edate"
        Me.edate.Size = New System.Drawing.Size(101, 20)
        Me.edate.TabIndex = 54
        '
        'stoplbl
        '
        Me.stoplbl.AutoSize = True
        Me.stoplbl.Location = New System.Drawing.Point(10, 33)
        Me.stoplbl.Name = "stoplbl"
        Me.stoplbl.Size = New System.Drawing.Size(58, 13)
        Me.stoplbl.TabIndex = 55
        Me.stoplbl.Text = "Start Date "
        '
        'sdate
        '
        Me.sdate.CustomFormat = "dd/MM/yyyy"
        Me.sdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.sdate.Location = New System.Drawing.Point(68, 30)
        Me.sdate.Name = "sdate"
        Me.sdate.Size = New System.Drawing.Size(101, 20)
        Me.sdate.TabIndex = 53
        '
        'typedesc
        '
        Me.typedesc.FormattingEnabled = True
        Me.typedesc.Items.AddRange(New Object() {"Statement of income - By Head Code", "Statement of income - By Account Code"})
        Me.typedesc.Location = New System.Drawing.Point(210, 10)
        Me.typedesc.Name = "typedesc"
        Me.typedesc.Size = New System.Drawing.Size(216, 21)
        Me.typedesc.TabIndex = 110
        Me.typedesc.Text = "Statement of income - By Head Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(173, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Type"
        '
        'sincome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 125)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.typedesc)
        Me.Controls.Add(Me.GroupBox6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "sincome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Income statement"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents edate As System.Windows.Forms.DateTimePicker
    Friend WithEvents stoplbl As System.Windows.Forms.Label
    Friend WithEvents sdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents typedesc As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
