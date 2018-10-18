<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownupWiz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownupWiz))
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.listgrid = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.stafflist = New System.Windows.Forms.LinkLabel()
        Me.chartacct = New System.Windows.Forms.LinkLabel()
        Me.hcplist = New System.Windows.Forms.LinkLabel()
        Me.ogalist = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.enrolleelist = New System.Windows.Forms.LinkLabel()
        Me.ltitle = New System.Windows.Forms.Label()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.msglbl = New System.Windows.Forms.Label()
        Me.Filename33 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.exportexcel = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.FolderBD = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.listgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = CType(resources.GetObject("CloseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 616)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1190, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'listgrid
        '
        Me.listgrid.AllowUserToAddRows = False
        Me.listgrid.AllowUserToDeleteRows = False
        Me.listgrid.AllowUserToOrderColumns = True
        Me.listgrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listgrid.BackgroundColor = System.Drawing.Color.White
        Me.listgrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.listgrid.Location = New System.Drawing.Point(0, 0)
        Me.listgrid.Name = "listgrid"
        Me.listgrid.ReadOnly = True
        Me.listgrid.Size = New System.Drawing.Size(1190, 481)
        Me.listgrid.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.listgrid)
        Me.Panel2.Controls.Add(Me.StatusStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1190, 638)
        Me.Panel2.TabIndex = 0
        '
        'stafflist
        '
        Me.stafflist.AutoSize = True
        Me.stafflist.LinkColor = System.Drawing.Color.Black
        Me.stafflist.Location = New System.Drawing.Point(31, 222)
        Me.stafflist.Name = "stafflist"
        Me.stafflist.Size = New System.Drawing.Size(51, 13)
        Me.stafflist.TabIndex = 6
        Me.stafflist.TabStop = True
        Me.stafflist.Text = " Staff List"
        '
        'chartacct
        '
        Me.chartacct.AutoSize = True
        Me.chartacct.LinkColor = System.Drawing.Color.Black
        Me.chartacct.Location = New System.Drawing.Point(31, 256)
        Me.chartacct.Name = "chartacct"
        Me.chartacct.Size = New System.Drawing.Size(92, 13)
        Me.chartacct.TabIndex = 4
        Me.chartacct.TabStop = True
        Me.chartacct.Text = "Chart of Accounts"
        '
        'hcplist
        '
        Me.hcplist.AutoSize = True
        Me.hcplist.LinkColor = System.Drawing.Color.Black
        Me.hcplist.Location = New System.Drawing.Point(31, 185)
        Me.hcplist.Name = "hcplist"
        Me.hcplist.Size = New System.Drawing.Size(64, 13)
        Me.hcplist.TabIndex = 2
        Me.hcplist.TabStop = True
        Me.hcplist.Text = "Hospital List"
        '
        'ogalist
        '
        Me.ogalist.AutoSize = True
        Me.ogalist.LinkColor = System.Drawing.Color.Black
        Me.ogalist.Location = New System.Drawing.Point(31, 152)
        Me.ogalist.Name = "ogalist"
        Me.ogalist.Size = New System.Drawing.Size(85, 13)
        Me.ogalist.TabIndex = 1
        Me.ogalist.TabStop = True
        Me.ogalist.Text = "Organization List"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Task"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 95)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.enrolleelist)
        Me.SplitContainer1.Panel1.Controls.Add(Me.stafflist)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chartacct)
        Me.SplitContainer1.Panel1.Controls.Add(Me.hcplist)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ogalist)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1354, 638)
        Me.SplitContainer1.SplitterDistance = 160
        Me.SplitContainer1.TabIndex = 12
        '
        'enrolleelist
        '
        Me.enrolleelist.AutoSize = True
        Me.enrolleelist.LinkColor = System.Drawing.Color.Black
        Me.enrolleelist.Location = New System.Drawing.Point(31, 120)
        Me.enrolleelist.Name = "enrolleelist"
        Me.enrolleelist.Size = New System.Drawing.Size(64, 13)
        Me.enrolleelist.TabIndex = 7
        Me.enrolleelist.TabStop = True
        Me.enrolleelist.Text = "Enrollee List"
        '
        'ltitle
        '
        Me.ltitle.AutoSize = True
        Me.ltitle.Font = New System.Drawing.Font("Franklin Gothic Demi Cond", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ltitle.Location = New System.Drawing.Point(923, 9)
        Me.ltitle.Name = "ltitle"
        Me.ltitle.Size = New System.Drawing.Size(87, 25)
        Me.ltitle.TabIndex = 3
        Me.ltitle.Text = "List Title"
        '
        'txt_search
        '
        Me.txt_search.Location = New System.Drawing.Point(158, 13)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(192, 20)
        Me.txt_search.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(82, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search For:"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkKhaki
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.msglbl)
        Me.Panel1.Controls.Add(Me.Filename33)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.ltitle)
        Me.Panel1.Controls.Add(Me.txt_search)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1354, 46)
        Me.Panel1.TabIndex = 11
        '
        'msglbl
        '
        Me.msglbl.AutoSize = True
        Me.msglbl.Location = New System.Drawing.Point(356, 16)
        Me.msglbl.Name = "msglbl"
        Me.msglbl.Size = New System.Drawing.Size(13, 13)
        Me.msglbl.TabIndex = 9
        Me.msglbl.Text = ".."
        '
        'Filename33
        '
        Me.Filename33.Location = New System.Drawing.Point(1060, 14)
        Me.Filename33.Name = "Filename33"
        Me.Filename33.Size = New System.Drawing.Size(100, 20)
        Me.Filename33.TabIndex = 8
        Me.Filename33.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1266, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Clear Search"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1174, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 22)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"ID", "Name"})
        Me.ComboBox1.Location = New System.Drawing.Point(1053, 7)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 5
        Me.ComboBox1.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Silver
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripSeparator4, Me.ToolStripButton5, Me.ToolStripSeparator5, Me.ToolStripButton6, Me.exportexcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1354, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(56, 22)
        Me.ToolStripButton4.Text = "Close"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton5.Text = "Print"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripButton6.Text = "Referesh"
        '
        'exportexcel
        '
        Me.exportexcel.Image = CType(resources.GetObject("exportexcel.Image"), System.Drawing.Image)
        Me.exportexcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exportexcel.Name = "exportexcel"
        Me.exportexcel.Size = New System.Drawing.Size(103, 22)
        Me.exportexcel.Text = "Export to Excel"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1354, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PrintDocument1
        '
        '
        'DownupWiz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DownupWiz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Record Browser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.listgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents listgrid As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents stafflist As System.Windows.Forms.LinkLabel
    Friend WithEvents chartacct As System.Windows.Forms.LinkLabel
    Friend WithEvents hcplist As System.Windows.Forms.LinkLabel
    Friend WithEvents ogalist As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ltitle As System.Windows.Forms.Label
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents enrolleelist As System.Windows.Forms.LinkLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Filename33 As System.Windows.Forms.TextBox
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents exportexcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents FolderBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents msglbl As System.Windows.Forms.Label
End Class
