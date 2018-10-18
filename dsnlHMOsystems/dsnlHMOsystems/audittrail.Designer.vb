<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class audittrail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(audittrail))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.All = New System.Windows.Forms.RadioButton()
        Me.sg = New System.Windows.Forms.RadioButton()
        Me.Slist = New System.Windows.Forms.ComboBox()
        Me.UseracctBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.answersheettab = New System.Windows.Forms.DataGridView()
        Me.userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.period = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FB = New System.Windows.Forms.RadioButton()
        Me.DB = New System.Windows.Forms.RadioButton()
        Me.filepath = New System.Windows.Forms.TextBox()
        Me.PB = New System.Windows.Forms.RadioButton()
        Me.dto = New System.Windows.Forms.DateTimePicker()
        Me.dfrom = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Previewbtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        CType(Me.UseracctBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.answersheettab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkKhaki
        Me.Panel2.Controls.Add(Me.All)
        Me.Panel2.Controls.Add(Me.sg)
        Me.Panel2.Controls.Add(Me.Slist)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(399, 71)
        Me.Panel2.TabIndex = 10
        '
        'All
        '
        Me.All.AutoSize = True
        Me.All.Checked = True
        Me.All.Location = New System.Drawing.Point(124, 4)
        Me.All.Name = "All"
        Me.All.Size = New System.Drawing.Size(36, 17)
        Me.All.TabIndex = 11
        Me.All.TabStop = True
        Me.All.Text = "All"
        Me.All.UseVisualStyleBackColor = True
        '
        'sg
        '
        Me.sg.AutoSize = True
        Me.sg.Location = New System.Drawing.Point(65, 4)
        Me.sg.Name = "sg"
        Me.sg.Size = New System.Drawing.Size(54, 17)
        Me.sg.TabIndex = 10
        Me.sg.Text = "Single"
        Me.sg.UseVisualStyleBackColor = True
        '
        'Slist
        '
        Me.Slist.DataSource = Me.UseracctBindingSource
        Me.Slist.DisplayMember = "names"
        Me.Slist.FormattingEnabled = True
        Me.Slist.Location = New System.Drawing.Point(56, 30)
        Me.Slist.Name = "Slist"
        Me.Slist.Size = New System.Drawing.Size(262, 21)
        Me.Slist.TabIndex = 0
        Me.Slist.ValueMember = "userid"
        '
        'UseracctBindingSource
        '
        Me.UseracctBindingSource.DataMember = "useracct"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Code"
        '
        'answersheettab
        '
        Me.answersheettab.AllowUserToAddRows = False
        Me.answersheettab.AllowUserToDeleteRows = False
        Me.answersheettab.AllowUserToOrderColumns = True
        Me.answersheettab.BackgroundColor = System.Drawing.Color.White
        Me.answersheettab.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.answersheettab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.answersheettab.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userid, Me.action1, Me.period})
        Me.answersheettab.Location = New System.Drawing.Point(12, 106)
        Me.answersheettab.Name = "answersheettab"
        Me.answersheettab.ReadOnly = True
        Me.answersheettab.Size = New System.Drawing.Size(888, 275)
        Me.answersheettab.TabIndex = 3
        '
        'userid
        '
        Me.userid.HeaderText = "Userid"
        Me.userid.Name = "userid"
        Me.userid.ReadOnly = True
        '
        'action1
        '
        Me.action1.HeaderText = "Action"
        Me.action1.Name = "action1"
        Me.action1.ReadOnly = True
        Me.action1.Width = 500
        '
        'period
        '
        Me.period.HeaderText = "Period"
        Me.period.Name = "period"
        Me.period.ReadOnly = True
        Me.period.Width = 220
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Date from "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(688, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Filename"
        Me.Label3.Visible = False
        '
        'FB
        '
        Me.FB.AutoSize = True
        Me.FB.Location = New System.Drawing.Point(690, 14)
        Me.FB.Name = "FB"
        Me.FB.Size = New System.Drawing.Size(41, 17)
        Me.FB.TabIndex = 2
        Me.FB.Text = "File"
        Me.FB.UseVisualStyleBackColor = True
        Me.FB.Visible = False
        '
        'DB
        '
        Me.DB.AutoSize = True
        Me.DB.Location = New System.Drawing.Point(487, 25)
        Me.DB.Name = "DB"
        Me.DB.Size = New System.Drawing.Size(56, 17)
        Me.DB.TabIndex = 1
        Me.DB.Text = "Delete"
        Me.DB.UseVisualStyleBackColor = True
        '
        'filepath
        '
        Me.filepath.Location = New System.Drawing.Point(690, 48)
        Me.filepath.Name = "filepath"
        Me.filepath.Size = New System.Drawing.Size(173, 20)
        Me.filepath.TabIndex = 2
        Me.filepath.Visible = False
        '
        'PB
        '
        Me.PB.AutoSize = True
        Me.PB.Checked = True
        Me.PB.Location = New System.Drawing.Point(418, 24)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(63, 17)
        Me.PB.TabIndex = 0
        Me.PB.TabStop = True
        Me.PB.Text = "Preview"
        Me.PB.UseVisualStyleBackColor = True
        '
        'dto
        '
        Me.dto.CustomFormat = "dd/MM/yyyy"
        Me.dto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dto.Location = New System.Drawing.Point(72, 37)
        Me.dto.Name = "dto"
        Me.dto.Size = New System.Drawing.Size(101, 20)
        Me.dto.TabIndex = 1
        '
        'dfrom
        '
        Me.dfrom.CustomFormat = "dd/MM/yyyy"
        Me.dfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dfrom.Location = New System.Drawing.Point(72, 11)
        Me.dfrom.Name = "dfrom"
        Me.dfrom.Size = New System.Drawing.Size(101, 20)
        Me.dfrom.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(83, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 21)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Previewbtn)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.FB)
        Me.Panel3.Controls.Add(Me.DB)
        Me.Panel3.Controls.Add(Me.filepath)
        Me.Panel3.Controls.Add(Me.PB)
        Me.Panel3.Location = New System.Drawing.Point(193, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(673, 75)
        Me.Panel3.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DimGray
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(549, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Previewbtn
        '
        Me.Previewbtn.BackColor = System.Drawing.Color.DimGray
        Me.Previewbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Previewbtn.Location = New System.Drawing.Point(549, 5)
        Me.Previewbtn.Name = "Previewbtn"
        Me.Previewbtn.Size = New System.Drawing.Size(89, 32)
        Me.Previewbtn.TabIndex = 0
        Me.Previewbtn.Text = "Print/Preview"
        Me.Previewbtn.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkKhaki
        Me.Panel1.Controls.Add(Me.dto)
        Me.Panel1.Controls.Add(Me.dfrom)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(869, 88)
        Me.Panel1.TabIndex = 2
        '
        'audittrail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(923, 385)
        Me.Controls.Add(Me.answersheettab)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "audittrail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Audittrail Option"
        Me.TopMost = True
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.UseracctBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.answersheettab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents All As System.Windows.Forms.RadioButton
    Friend WithEvents sg As System.Windows.Forms.RadioButton
    Friend WithEvents Slist As System.Windows.Forms.ComboBox
    Friend WithEvents UseracctBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents answersheettab As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FB As System.Windows.Forms.RadioButton
    Friend WithEvents DB As System.Windows.Forms.RadioButton
    Friend WithEvents filepath As System.Windows.Forms.TextBox
    Friend WithEvents PB As System.Windows.Forms.RadioButton
    Friend WithEvents dto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Previewbtn As System.Windows.Forms.Button
    Friend WithEvents userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents action1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
