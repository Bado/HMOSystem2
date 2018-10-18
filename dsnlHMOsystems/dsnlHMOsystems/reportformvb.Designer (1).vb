<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reportformvb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reportformvb))
        Me.Listreportname = New System.Windows.Forms.ListView()
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Code = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.assignfolder = New System.Windows.Forms.ComboBox()
        Me.lowtext = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.acc2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.acc1 = New System.Windows.Forms.TextBox()
        Me.Scode = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.codeidall2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Combosearch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Combotype = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.codeidall = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.range = New System.Windows.Forms.RadioButton()
        Me.all = New System.Windows.Forms.RadioButton()
        Me.edate = New System.Windows.Forms.DateTimePicker()
        Me.stoplbl = New System.Windows.Forms.Label()
        Me.sdate = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Reportcat = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.STAT2 = New System.Windows.Forms.Label()
        Me.Statusmsg = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Listreportname
        '
        Me.Listreportname.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Listreportname.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Description, Me.Code})
        Me.Listreportname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Listreportname.FullRowSelect = True
        Me.Listreportname.Location = New System.Drawing.Point(6, 37)
        Me.Listreportname.Name = "Listreportname"
        Me.Listreportname.Size = New System.Drawing.Size(266, 205)
        Me.Listreportname.TabIndex = 0
        Me.Listreportname.UseCompatibleStateImageBehavior = False
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 850
        '
        'Code
        '
        Me.Code.Text = "Report ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkKhaki
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.assignfolder)
        Me.GroupBox1.Controls.Add(Me.lowtext)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Scode)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(278, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 230)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(28, 182)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 100
        Me.Button9.Text = "Button9"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'assignfolder
        '
        Me.assignfolder.FormattingEnabled = True
        Me.assignfolder.Location = New System.Drawing.Point(387, 210)
        Me.assignfolder.Name = "assignfolder"
        Me.assignfolder.Size = New System.Drawing.Size(43, 21)
        Me.assignfolder.TabIndex = 90
        Me.assignfolder.Visible = False
        '
        'lowtext
        '
        Me.lowtext.Location = New System.Drawing.Point(376, 184)
        Me.lowtext.Name = "lowtext"
        Me.lowtext.Size = New System.Drawing.Size(37, 20)
        Me.lowtext.TabIndex = 99
        Me.lowtext.Visible = False
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(448, 223)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(22, 22)
        Me.Button6.TabIndex = 95
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button8)
        Me.Panel3.Controls.Add(Me.Button5)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Location = New System.Drawing.Point(127, 180)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(197, 42)
        Me.Panel3.TabIndex = 95
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Location = New System.Drawing.Point(129, 6)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(56, 31)
        Me.Button8.TabIndex = 102
        Me.Button8.Text = "Close"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Location = New System.Drawing.Point(68, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(56, 31)
        Me.Button5.TabIndex = 101
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Location = New System.Drawing.Point(4, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 31)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "Ok"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.acc2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.acc1)
        Me.Panel2.Location = New System.Drawing.Point(176, 228)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(212, 58)
        Me.Panel2.TabIndex = 94
        Me.Panel2.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(176, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 22)
        Me.Button2.TabIndex = 98
        Me.Button2.UseVisualStyleBackColor = True
        '
        'acc2
        '
        Me.acc2.Location = New System.Drawing.Point(80, 33)
        Me.acc2.Name = "acc2"
        Me.acc2.Size = New System.Drawing.Size(100, 20)
        Me.acc2.TabIndex = 97
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "To"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(178, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 95
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Account Code"
        '
        'acc1
        '
        Me.acc1.Location = New System.Drawing.Point(80, 6)
        Me.acc1.Name = "acc1"
        Me.acc1.Size = New System.Drawing.Size(100, 20)
        Me.acc1.TabIndex = 94
        '
        'Scode
        '
        Me.Scode.Location = New System.Drawing.Point(324, 250)
        Me.Scode.Name = "Scode"
        Me.Scode.Size = New System.Drawing.Size(128, 20)
        Me.Scode.TabIndex = 94
        Me.Scode.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.codeidall2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Combosearch)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Combotype)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.codeidall)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.edate)
        Me.Panel1.Controls.Add(Me.stoplbl)
        Me.Panel1.Controls.Add(Me.sdate)
        Me.Panel1.Location = New System.Drawing.Point(12, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(353, 154)
        Me.Panel1.TabIndex = 93
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(294, 13)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(22, 22)
        Me.Button7.TabIndex = 107
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(178, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "Code 2"
        '
        'codeidall2
        '
        Me.codeidall2.Location = New System.Drawing.Point(220, 14)
        Me.codeidall2.Name = "codeidall2"
        Me.codeidall2.Size = New System.Drawing.Size(76, 20)
        Me.codeidall2.TabIndex = 106
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Search Code"
        '
        'Combosearch
        '
        Me.Combosearch.FormattingEnabled = True
        Me.Combosearch.Location = New System.Drawing.Point(81, 90)
        Me.Combosearch.Name = "Combosearch"
        Me.Combosearch.Size = New System.Drawing.Size(234, 21)
        Me.Combosearch.TabIndex = 103
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Search Type"
        '
        'Combotype
        '
        Me.Combotype.FormattingEnabled = True
        Me.Combotype.Items.AddRange(New Object() {"LGA", "STATE", "SECTOR", "COUNTRY"})
        Me.Combotype.Location = New System.Drawing.Point(81, 61)
        Me.Combotype.Name = "Combotype"
        Me.Combotype.Size = New System.Drawing.Size(103, 21)
        Me.Combotype.TabIndex = 101
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(156, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 22)
        Me.Button4.TabIndex = 100
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Code"
        '
        'codeidall
        '
        Me.codeidall.Location = New System.Drawing.Point(82, 15)
        Me.codeidall.Name = "codeidall"
        Me.codeidall.Size = New System.Drawing.Size(77, 20)
        Me.codeidall.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(185, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "To"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.range)
        Me.GroupBox4.Controls.Add(Me.all)
        Me.GroupBox4.Location = New System.Drawing.Point(194, 44)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(122, 34)
        Me.GroupBox4.TabIndex = 92
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Print"
        '
        'range
        '
        Me.range.AutoSize = True
        Me.range.Location = New System.Drawing.Point(61, 10)
        Me.range.Name = "range"
        Me.range.Size = New System.Drawing.Size(57, 17)
        Me.range.TabIndex = 94
        Me.range.Text = "Range"
        Me.range.UseVisualStyleBackColor = True
        '
        'all
        '
        Me.all.AutoSize = True
        Me.all.Checked = True
        Me.all.Location = New System.Drawing.Point(26, 10)
        Me.all.Name = "all"
        Me.all.Size = New System.Drawing.Size(36, 17)
        Me.all.TabIndex = 93
        Me.all.TabStop = True
        Me.all.Text = "All"
        Me.all.UseVisualStyleBackColor = True
        '
        'edate
        '
        Me.edate.CustomFormat = "dd/MM/yyyy"
        Me.edate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.edate.Location = New System.Drawing.Point(215, 115)
        Me.edate.Name = "edate"
        Me.edate.Size = New System.Drawing.Size(101, 20)
        Me.edate.TabIndex = 27
        '
        'stoplbl
        '
        Me.stoplbl.AutoSize = True
        Me.stoplbl.Location = New System.Drawing.Point(25, 118)
        Me.stoplbl.Name = "stoplbl"
        Me.stoplbl.Size = New System.Drawing.Size(56, 13)
        Me.stoplbl.TabIndex = 26
        Me.stoplbl.Text = "Date From"
        '
        'sdate
        '
        Me.sdate.CustomFormat = "dd/MM/yyyy"
        Me.sdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.sdate.Location = New System.Drawing.Point(80, 115)
        Me.sdate.Name = "sdate"
        Me.sdate.Size = New System.Drawing.Size(101, 20)
        Me.sdate.TabIndex = 25
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(12, 13)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(71, 13)
        Me.Label37.TabIndex = 88
        Me.Label37.Text = "Report Group"
        '
        'Reportcat
        '
        Me.Reportcat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Reportcat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Reportcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Reportcat.FormattingEnabled = True
        Me.Reportcat.Items.AddRange(New Object() {"Medical (HMO) Reports", "Personel Reports", "Acount Reports"})
        Me.Reportcat.Location = New System.Drawing.Point(90, 10)
        Me.Reportcat.Name = "Reportcat"
        Me.Reportcat.Size = New System.Drawing.Size(162, 21)
        Me.Reportcat.TabIndex = 87
        '
        'Panel4
        '
        Me.Panel4.Location = New System.Drawing.Point(5, 218)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(266, 25)
        Me.Panel4.TabIndex = 90
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Statusmsg)
        Me.Panel5.Location = New System.Drawing.Point(6, 243)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(643, 25)
        Me.Panel5.TabIndex = 91
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.STAT2)
        Me.Panel6.Location = New System.Drawing.Point(274, -1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(368, 25)
        Me.Panel6.TabIndex = 92
        '
        'STAT2
        '
        Me.STAT2.AutoSize = True
        Me.STAT2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.STAT2.ForeColor = System.Drawing.Color.Red
        Me.STAT2.Location = New System.Drawing.Point(20, 6)
        Me.STAT2.Name = "STAT2"
        Me.STAT2.Size = New System.Drawing.Size(55, 13)
        Me.STAT2.TabIndex = 1
        Me.STAT2.Text = "Status..."
        '
        'Statusmsg
        '
        Me.Statusmsg.AutoSize = True
        Me.Statusmsg.Location = New System.Drawing.Point(6, 6)
        Me.Statusmsg.Name = "Statusmsg"
        Me.Statusmsg.Size = New System.Drawing.Size(46, 13)
        Me.Statusmsg.TabIndex = 0
        Me.Statusmsg.Text = "Status..."
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(28, 208)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 101
        Me.Button10.Text = "Button10"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'reportformvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(656, 268)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Reportcat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Listreportname)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "reportformvb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Dialogue Form"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Listreportname As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Reportcat As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents range As System.Windows.Forms.RadioButton
    Friend WithEvents all As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents edate As System.Windows.Forms.DateTimePicker
    Friend WithEvents stoplbl As System.Windows.Forms.Label
    Friend WithEvents sdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents acc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents acc1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Scode As System.Windows.Forms.TextBox
    Friend WithEvents lowtext As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents codeidall As System.Windows.Forms.TextBox
    Friend WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents Code As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents assignfolder As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Statusmsg As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents STAT2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combotype As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Combosearch As System.Windows.Forms.ComboBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents codeidall2 As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
End Class
