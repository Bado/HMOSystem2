Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class Asset_Register
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    ' Dim textbx As New TextBox()
    Public gstring1 As String
    Public addnew As Boolean
    '  Public Sub PerformClick() Dim ASSSD As String
    Public ASSSD As String
    Public descrrr As String
    Private Sub Asset_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Links dropdown menu to incident table in database
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        dephistory.EnableHeadersVisualStyles = False
        dephistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dephistory.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        dephistory.ColumnHeadersHeight = 30
        dephistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        loadsearch()
        disablecontrols()
        loadasserttcombo()
        loadstaffcombo()
        loadDEPTcombo()
        loadglcodetcombo()
        loadbranchcombo()
    End Sub
    'SELECT assertid,descr,asserttype,amount,model,assertmake,regnumber,glcode,allocated,allocstaff,dept,allocdate,assertstatus,purchasedate,regdate,mdepre,cdepre,rdepre,ldepre,networth,lupdated FROM asserttab
    'SELECT assertid,costassert,ldate,depreciation,networth FROM assertdepre assertid
    Sub loadsearch()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select assertid,descr from asserttab order by assertid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "assertid"
            Searchtool.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Public Sub clearrec()

        networth.Text = 0.0
        amount.Text = 0.0
        mdepre.Text = 0.0
        cdepre.Text = 0.0
        rdepre.Text = 0.0
        ldepre.Text = 0.0
        DESCR.Text = ""
        'asserttype.SelectedIndex = -1
        model.Text = ""
        assertmake.Text = ""
        regnumber.Text = ""
        'glcode.SelectedIndex = -1
        allocated.Checked = False
        'allocstaff.SelectedIndex = -1
        'dept.Text = ""
        allocdate.Value = Now
        assertstatusU.Checked = False
        assertstatusN.Checked = False
        purchasedate.Value = Now
        regdate.Value = Now
        lupdated.Value = Now
        Dim T As Integer
        For T = T To dephistory.RowCount - 1
            dephistory.Rows.Clear()
        Next
    End Sub
    Sub enablecontrols()
        assertid.Enabled = True
        networth.Enabled = True
        amount.Enabled = True
        mdepre.Enabled = True
        cdepre.Enabled = True
        rdepre.Enabled = True
        ldepre.Enabled = True
        DESCR.Enabled = True
        'asserttype.SelectedIndex = -1
        model.Enabled = True
        assertmake.Enabled = True
        regnumber.Enabled = True
        glcode.SelectedIndex = -1
        allocated.Enabled = True
        'allocstaff.SelectedIndex = -1
        branch.Enabled = True
        dept.Enabled = True
        allocdate.Enabled = True
        assertstatusU.Enabled = True
        assertstatusN.Enabled = True
        purchasedate.Enabled = True
        regdate.Enabled = True
        lupdated.Enabled = True
    End Sub
    Sub disablecontrols()
        branch.Enabled = False
        networth.Enabled = False
        amount.Enabled = False
        mdepre.Enabled = False
        cdepre.Enabled = False
        rdepre.Enabled = False
        ldepre.Enabled = False
        DESCR.Enabled = False
        model.Enabled = False
        assertmake.Enabled = False
        regnumber.Enabled = False
        allocated.Enabled = False
        dept.Enabled = False
        allocdate.Enabled = False
        assertstatusU.Enabled = False
        assertstatusN.Enabled = False
        purchasedate.Enabled = False
        regdate.Enabled = False
        lupdated.Enabled = False
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            'assertdepre assertid
            cSQL = "DELETE FROM asserttab WHERE" _
            & " assertid = '" & Me.assertid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Dim cSQL2 As String = "DELETE FROM assertdepre WHERE" _
                        & " assertid = '" & Me.assertid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for assertidID : " + Trim(assertid.Text) + " In " + Me.Text)

                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Sub saveaudit(ByVal SWMODE As String)
        Dim uidd2 As String = My.Settings.loginid
        Dim date11 As DateTime
        ' Dim SWMODE As String = "Login into the system"
        date11 = Now
        Dim sumStr As String = "INSERT INTO audittab(userid, action1, period) VALUES('" & uidd2 & "','" & SWMODE & "','" & date11 & "')"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumStr
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '   CCNN.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try
    End Sub
    Public Sub saverec()
        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            'RecordExist()
            If My.Settings.newrec = True Then
                InsertRecord()
            End If
            If My.Settings.newrec = False Then
                InsertRecord()
            End If
            Me.Refresh()
            assertid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        'clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT assertid,descr,asserttype,amount,model,assertmake,regnumber,glcode,allocated,allocstaff,dept,allocdate,assertstatus,purchasedate,regdate,mdepre,cdepre,rdepre,ldepre,networth,lupdated,branch FROM asserttab WHERE" _
                & "  Rtrim(assertid) = '" & Trim(assertid.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    'assertid,descr,asserttype,amount,model,assertmake,regnumber,glcode,
                    'allocated,allocstaff,dept,allocdate,assertstatus,purchasedate,regdate,mdepre,
                    'cdepre,rdepre,ldepre,networth,lupdated
                    If Not r.IsDBNull(1) Then Me.DESCR.Text = r(1)
                    If Not r.IsDBNull(2) Then Me.asserttype.SelectedValue = RTrim(r(2))
                    If Not r.IsDBNull(3) Then Me.amount.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.model.Text = r(4)
                    If Not r.IsDBNull(5) Then Me.assertmake.Text = r(5)
                    If Not r.IsDBNull(6) Then Me.regnumber.Text = r(6)
                    If Not r.IsDBNull(7) Then Me.glcode.SelectedValue = RTrim(r(7))
                    If Not r.IsDBNull(8) Then Me.allocated.Checked = r(8)
                    If Not r.IsDBNull(9) Then Me.allocstaff.SelectedValue = RTrim(r(9))
                    If Not r.IsDBNull(10) Then Me.dept.SelectedValue = RTrim(r(10))
                    If Not r.IsDBNull(11) Then Me.allocdate.Value = r(11)
                    If RTrim(r(12)) = "U" Then
                        Me.assertstatusU.Checked = True
                    End If
                    If RTrim(r(12)) = "N" Then
                        Me.assertstatusN.Checked = True
                    End If
                    If Not r.IsDBNull(13) Then Me.purchasedate.Value = r(13)
                    If Not r.IsDBNull(14) Then Me.regdate.Value = r(14)
                    If Not r.IsDBNull(15) Then Me.mdepre.Text = r(15)
                    If Not r.IsDBNull(16) Then Me.cdepre.Text = r(16)
                    If Not r.IsDBNull(17) Then Me.rdepre.Text = r(17)
                    If Not r.IsDBNull(18) Then Me.ldepre.Text = r(18)
                    If Not r.IsDBNull(19) Then Me.networth.Text = r(19)
                    If Not r.IsDBNull(21) Then Me.branch.SelectedValue = RTrim(r(21))

                    enablecontrols()
                    DESCR.Focus()
                    My.Settings.newrec = True
                    Me.Refresh()
                Else
                    My.Settings.newrec = False
                    DESCR.Focus()
                    enablecontrols()
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub getdephistory()
        Dim i2 As Integer
        For i2 = i2 To dephistory.RowCount - 1
            dephistory.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT costassert,ldate,depreciation,networth FROM assertdepre where rTrim(assertid) = '" & Trim(assertid.Text) & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = dephistory.Rows.Add
                        dephistory.Rows(row).Cells(0).Value = RTrim(r(0))
                        dephistory.Rows(row).Cells(1).Value = RTrim(r(1))
                        dephistory.Rows(row).Cells(2).Value = r(2)
                        dephistory.Rows(row).Cells(3).Value = r(3)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
  
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Public Sub delrec2()
        cSQL = "DELETE FROM asserttab WHERE" _
            & " assertid = '" & Me.assertid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Dim cSQL2 As String = "DELETE FROM assertdepre WHERE" _
                        & " assertid = '" & Me.assertid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for assertidID : " + Trim(assertid.Text) + " In " + Me.Text)

                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        delrec2()

        If assertstatusU.Checked = True Then
            ASSSD = "U"
        End If
        If assertstatusN.Checked = True Then
            ASSSD = "N"
        End If
        MessageBox.Show(Format(allocdate.Value, "yyyy-MM-dd"))
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                'SELECT assertid,descr,asserttype,amount,model,assertmake,regnumber,glcode,                                                                                                                                                                                                                                                 allocated,allocstaff,dept,allocdate,assertstatus,purchasedate,regdate,mdepre,cdepre,rdepre,ldepre,networth,lupdated FROM asserttab
                'SELECT assertid,costassert,ldate,depreciation,networth FROM assertdepre assertid
                Cd3.CommandText = "INSERT INTO asserttab(assertid,descr,asserttype,amount,model,assertmake,regnumber,glcode,allocated,allocstaff,dept,allocdate,assertstatus,purchasedate,regdate,mdepre,cdepre,rdepre,ldepre,networth,lupdated,branch)" & _
                                   "VALUES('" & assertid.Text & "','" & DESCR.Text & "','" & asserttype.SelectedValue & "','" & amount.Text & "','" & model.Text & "','" & assertmake.Text & "','" & regnumber.Text & "','" & glcode.SelectedValue & "','" & allocated.Checked & "','" & allocstaff.SelectedValue & "','" & dept.SelectedValue & "','" & Format(allocdate.Value, "yyyy-MM-dd") & "','" & ASSSD & "','" & Format(purchasedate.Value, "yyyy-MM-dd") & "','" & Format(regdate.Value, "yyyy-MM-dd") & "','" & mdepre.Text & "','" & cdepre.Text & "','" & rdepre.Text & "','" & ldepre.Text & "','" & networth.Text & "','" & Format(lupdated.Value, "yyyy-MM-dd") & "','" & branch.SelectedValue & "')"
                CCNN.Open()
                'Cd3.ExecuteNonQuery()
                If Cd3.ExecuteNonQuery = -1 Then
                    MessageBox.Show("Record Not Saved/Updated Successfully")
                Else
                    MessageBox.Show("Record Saved/Updated Successfully")
                    saveaudit("Save/Update AssertID : " + Trim(assertid.Text) + " In " + Me.Text)
                End If
                CCNN.Close()
                clearrec()
                'MessageBox.Show("Record Saved/Updated Successfully")
                Me.Refresh()
            End Using
            ' getgriddesc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in asserttab Table")
        End Try

        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd3 As SqlCommand = CCNN.CreateCommand
        '        Cd3.CommandType = CommandType.Text

        '        Dim i As Integer
        '        ' MsgBox(Payvalgrid.RowCount) SELECT                                                                                                                                                                                                   billcode,descr,invoicetopic,tdate,invoiceno,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM salesinvoice sinvoicegrid
        '        If dephistory.RowCount > 0 Then
        '            For i = 0 To dephistory.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value
        '                '  MessageBox.Show("loop 1")
        '                Cd3.CommandText = "INSERT INTO assertdepre(assertid,costassert,ldate,depreciation,networth)" & _
        '                                        "VALUES('" & staffid.Text & "','" & loangrid.Rows(i).Cells(0).Value & "','" & Val(loangrid.Rows(i).Cells(1).Value) & "','" & loangrid.Rows(i).Cells(2).Value & "','" & loangrid.Rows(i).Cells(3).Value & "','" & Val(loangrid.Rows(i).Cells(4).Value) & "','" & loangrid.Rows(i).Cells(5).Value & "','" & loangrid.Rows(i).Cells(6).Value & "','" & Val(loangrid.Rows(i).Cells(7).Value) & "','" & nna & "')"
        '                CCNN.Open()
        '                Cd3.ExecuteNonQuery()
        '                CCNN.Close()
        '            Next
        '        End If
        '        saveaudit("Save/Update Default Values/Loan Records for staffid: " + Trim(staffid.Text) + " In " + Me.Text)
        '        Me.Refresh()

        '    End Using
        '    ' getgriddesc()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in Loan Table")
        'End Try
        ''  Default save

    End Sub

    Private Sub assertid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles assertid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not assertid.Text = String.Empty) Then
                LoadRecord()
                DESCR.Focus()
            End If
        End If
    End Sub

    Private Sub ldepre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ldepre.Validating
        'mdepre,cdepre,rdepre,ldep  re,networth
        mdepre.Text = cdepre.Text - rdepre.Text / ldepre.Text
        If networth.Text = 0 Then
            networth.Text = cdepre.Text - mdepre.Text
        Else
            networth.Text = networth.Text - mdepre.Text
        End If

    End Sub
    Sub loadasserttcombo()
        ' Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F10" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            asserttype.DataSource = ds.Tables(0)
            asserttype.ValueMember = "code1"
            asserttype.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB glevel ! "
        End Try
    End Sub
    Sub loadglcodetcombo()
        ' Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select accode,descriptn,actype from accode order by accode"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            glcode.DataSource = ds.Tables(0)
            glcode.ValueMember = "accode"
            glcode.DisplayMember = "descriptn"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to accode  ! "
        End Try
    End Sub
    Sub loadstaffcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from stafftab where staffid != '" & "ADMIN" & "' order by staffid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            allocstaff.DataSource = ds.Tables(0)
            allocstaff.ValueMember = "staffid"
            allocstaff.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadDEPTcombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F3" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            dept.DataSource = ds.Tables(0)
            dept.ValueMember = "code1"
            dept.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB DEPT ! "
        End Try
    End Sub
    Sub loadbranchcombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F6" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            branch.DataSource = ds.Tables(0)
            branch.ValueMember = "code1"
            branch.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB DEPT ! "
        End Try
    End Sub
    Private Sub ldepre_TextChanged(sender As Object, e As EventArgs) Handles ldepre.TextChanged

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub



    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        saverec()
    End Sub

    Private Sub DeleteEnrolleeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteEnrolleeToolStripMenuItem.Click
        delrec()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
    End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        assertid.Text = Searchtool.SelectedValue
        If (Not assertid.Text = String.Empty) Then
            LoadRecord()
            DESCR.Focus()
        End If
    End Sub

    Private Sub assertid_TextChanged(sender As Object, e As EventArgs) Handles assertid.TextChanged

    End Sub

    Private Sub assertid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles assertid.Validating
        If (Not assertid.Text = String.Empty) Then
            LoadRecord()
            DESCR.Focus()
        End If
    End Sub
End Class