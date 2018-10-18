<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gridlookup
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gridlookup))
        Me.answersheettab = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.answersheettab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'answersheettab
        '
        Me.answersheettab.AllowUserToAddRows = False
        Me.answersheettab.AllowUserToDeleteRows = False
        Me.answersheettab.AllowUserToOrderColumns = True
        Me.answersheettab.BackgroundColor = System.Drawing.Color.White
        Me.answersheettab.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.answersheettab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.answersheettab.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Code, Me.Descr, Me.tdate})
        Me.answersheettab.Location = New System.Drawing.Point(4, 1)
        Me.answersheettab.Name = "answersheettab"
        Me.answersheettab.ReadOnly = True
        Me.answersheettab.Size = New System.Drawing.Size(479, 123)
        Me.answersheettab.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(485, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(41, 124)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Code
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        Me.Code.DefaultCellStyle = DataGridViewCellStyle1
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        Me.Code.Width = 80
        '
        'Descr
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        Me.Descr.DefaultCellStyle = DataGridViewCellStyle2
        Me.Descr.HeaderText = "Description"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 190
        '
        'tdate
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Narrow", 8.0!)
        Me.tdate.DefaultCellStyle = DataGridViewCellStyle3
        Me.tdate.HeaderText = "Description 2"
        Me.tdate.Name = "tdate"
        Me.tdate.ReadOnly = True
        Me.tdate.Width = 160
        '
        'gridlookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(526, 124)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.answersheettab)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gridlookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lookup Tool"
        CType(Me.answersheettab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents answersheettab As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
