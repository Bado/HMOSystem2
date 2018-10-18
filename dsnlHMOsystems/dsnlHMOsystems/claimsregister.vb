Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Imports System.Web.UI.WebControls

Public Class claimsregister
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Public PREMI As String
    Private Sub claimsregister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        totall.Text = 0.0
        totall2.Text = 0
        resendcheck.Visible = False
        Dim gg2 As String = "SELECT userid,password,names,admin,status,appraise,approve,staffonline ,staffpin,claimsinput,claimsvetting FROM useracct WHERE" _
           & " userid != '" & "ADMIN" & "' and userid = '" & My.Settings.loginid & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    If r(9) = False Then
                        Dim tabPage As TabPage
                        For Each tabPage In TabControl1.TabPages
                            If tabPage.Text = "Claims Input Form" Then
                                tabPage.Enabled = False
                                tabPage.BackColor = Color.Black
                            End If
                        Next
                    End If
                    If r(10) = False Then
                        Dim tabPage As TabPage
                        For Each tabPage In TabControl1.TabPages
                            If tabPage.Text = "Claims Vetting" Then
                                tabPage.Enabled = False
                                tabPage.BackColor = Color.Black
                            End If
                        Next
                    Else
                        resendcheck.Visible = True
                    End If
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()


        Try
            'Me.CodestabTableAdapter.Fill(Me.Ailmentypedb.codestab)
            'Me.CodestabTableAdapter.Fill(Me.Ailmentypedb.codestab)
            MDIParent1.Panel4.Visible = False
            MDIParent1.Panel5.Visible = False
            MDIParent1.Backpanel1.Dock = DockStyle.Left
            MDIParent1.Backpanel1.Width = 130

            claimsinputegrid.EnableHeadersVisualStyles = False
            claimsinputegrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            claimsinputegrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            claimsinputegrid.ColumnHeadersHeight = 30
            claimsinputegrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

            claimgrid.EnableHeadersVisualStyles = False
            claimgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            claimgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            claimgrid.ColumnHeadersHeight = 30
            claimgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

            ailmentgrid.EnableHeadersVisualStyles = False
            ailmentgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            ailmentgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            ailmentgrid.ColumnHeadersHeight = 30
            ailmentgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim col As New CalendarColumn()
            col.DataPropertyName = "dtreated"
            col.HeaderText = "Date_Treated"
            Dim loc As Integer
            claimsinputegrid.Columns.IndexOf(claimsinputegrid.Columns("dtreated"))
            claimsinputegrid.Columns.RemoveAt(loc)
            claimsinputegrid.Columns.Insert(loc, col)

        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try

        '    disablecontrols()claimsinputegrid
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select hcpid,rtrim(Names)  as names from Hcptab where active = '" & False & "' order by hcpid"

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
            Searchtool.ValueMember = "hcpid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try
        loadailmentcodecombo()

        '  getsettingcode()
        loadenrollees2()
        loadapprovalstaff()
        loadenrol2searchcombo()
        loadailment2codecombo()
        getdrug()
        GetService2()
    End Sub
    Sub loadenrol2searchcombo2()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from enrolleetab order by enrolleeid"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            enrolleecode.DataSource = ds.Tables(0)
            enrolleecode.ValueMember = "enrolleeid"
            enrolleecode.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try  'enrolleeid2
    End Sub
    Public Sub clearrec()
        'MsgBox("CLEAR")hcpid,hcpname,tdate,batchcode,enrolleeid,names,ailmentcode,ailmentname ,authocode,dtreated ,ddischard ,posted ,postedto 
        Me.hcpid.Focus()
        '    Me.hcpname.Text = ""
        '  Me.tdate.Value = Now
        '   Me.batchcode1.Text = ""
        totall2.Text = 0
        totall.Text = 0.0
        Dim T As Integer
        For T = T To claimsinputegrid.RowCount - 1
            claimsinputegrid.Rows.Clear()
        Next

        Me.Refresh()
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
            hcpid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If

    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM claimsinputenew WHERE" _
            & " batchcode = '" & Me.batchcode1.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for batch code: " + Trim(batchcode1.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        ' clearrec()
        Dim sum As Decimal = 0
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT dtreated,ailmentcode,authocode,billamount,batchcode,hcpid,hcpname,tdate,enrolleeid,total,posted FROM claimsinputenew where rtrim(enrolleeid) = '" & RTrim(enrolleecode.SelectedValue) & "' and rtrim(hcpid) = '" & hcpid.Text.Trim & "' and tdate = '" & Format(tdate.Value, "yyyy-MM-dd") & "' and rtrim(batchcode) = '" & batchcode1.Text.Trim & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    ' MessageBox.Show("loadgriddata")
                    loadgriddata()
                    My.Settings.newrec = True
                    enablecontrols()
                    batchcode1.Focus()
                    totall.Text = FormatNumber(r(9), 2, True, True, True) 'FormatNumber(r(9), 2, TriState.True, TriState.True, TriState.True)
                Else
                    My.Settings.newrec = False
                    clearrec()
                    enablecontrols()
                    batchcode1.Focus()

                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Dim sum As Decimal = 0
        'If totalpayment.Text = 0 Then
        '    For Each row As DataGridViewRow In payinvoicegrid.Rows
        '        If row.Cells(6).Value = True Then
        '            row.Cells(5).Value = row.Cells(5).Value - row.Cells(4).Value
        '            sum += row.Cells(5).Value
        '        End If
        '    Next
        '    Me.totalpayment.Text = sum
        '    Me.totalpayment.Text = sum.ToString("0.00")
        '    payinvoicegrid.Columns(5).DefaultCellStyle.Format = ("0.00")
        'Else
        '    getrvalues()
        '    sum = 0.0
        '    Me.totalpayment.Text = 0.0
        'End If
    End Sub
    Sub enablecontrols()

        '   Me.hcpname.Enabled = True
        Me.tdate.Enabled = True
        Me.batchcode1.Enabled = True

    End Sub
    Sub disablecontrols()
        'Me.hcpname.Enabled = False
        'Me.tdate.Enabled = False
        'Me.batchcode1.Enabled = FalseDim gg2 As String = "SELECT dtreated,ailmentcode,authocode,billamount,batchcode,hcpid,hcpname,tdate,enrolleeid,posted FROM claimsinputenew where rtrim(enrolleeid) = '" & enrolleecode.Text & "' and rtrim(hcpid) = '" & hcpid.Text & "' and tdate = '" & tdate.Text & "' and rtrim(batchcode) = '" & batchcode1.Text.Trim & "'"
    End Sub
    Sub delfirst()
        Dim cSQL5 As String = "DELETE FROM claimsinputenew WHERE" _
            & " rtrim(batchcode) = '" & Me.batchcode1.Text.Trim & "' and rtrim(enrolleeid) = '" & RTrim(enrolleecode.SelectedValue) & "' and rtrim(hcpid) = '" & hcpid.Text & "' and tdate = '" & Format(tdate.Value, "yyyy-MM-dd") & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL5

                CCNN.Open()
                Cd.ExecuteNonQuery()

                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try
    End Sub
    Sub delemptyenrolle()
        '    Dim cSQL5 As String = "DELETE FROM claimsinpute WHERE" _
        '        & " enrolleeid = '" & String.Empty & "'"
        '    Try
        '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '            Dim Cd As SqlCommand = CCNN.CreateCommand
        '            Cd.CommandType = CommandType.Text
        '            Cd.CommandText = cSQL5
        '            CCNN.Open()
        '            Cd.ExecuteNonQuery()
        '            Me.Refresh()
        '        End Using
        '    Catch ex As Exception
        '        '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        '    End Try
    End Sub

    Public Sub InsertRecord()  'Subroutine to insert a record into the database  
        delfirst()

        Dim PREMI2 As String
        'Try
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            Dim Cd3 As SqlCommand = CCNN.CreateCommand
            Cd3.CommandType = CommandType.Text

            Dim i As Integer
            ' MsgBox(Payvalgrid.RowCount)
            If claimsinputegrid.RowCount > 0 Then
                For i = 0 To claimsinputegrid.RowCount - 1
                    If claimsinputegrid.Rows(i).Cells(4).Value > 0 Then
                        If (Not claimsinputegrid.Rows(i).Cells(1).Value = String.Empty) Then
                            CheckCodestab.Ailmenttypedefault(claimsinputegrid.Rows(i).Cells(1).Value)
                        End If
                        If (Not claimsinputegrid.Rows(i).Cells(2).Value = String.Empty) Then
                            CheckCodestab.Ailmenttypedefault(claimsinputegrid.Rows(i).Cells(2).Value)
                        End If
                        PREMI = CheckCodestab.descvar
                        MessageBox.Show(PREMI)
                        CheckCodestab.enrollname(RTrim(enrolleecode.SelectedValue))
                        PREMI2 = CheckCodestab.descvar
                        Cd3.CommandText = "INSERT INTO claimsinputenew(dtreated,ailmentcode,authocode,billamount,batchcode,hcpid,hcpname,tdate,enrolleeid,total,posted,descrtype,enrollname)" & _
                            "VALUES('" & claimsinputegrid.Rows(i).Cells(0).Value & "','" & IIf(claimsinputegrid.Rows(i).Cells(1).Value = String.Empty, claimsinputegrid.Rows(i).Cells(2).Value, claimsinputegrid.Rows(i).Cells(1).Value) & "','" & claimsinputegrid.Rows(i).Cells(3).Value & "','" & Val(claimsinputegrid.Rows(i).Cells(4).Value) & "','" & batchcode1.Text & "','" & hcpid.Text & "','" & hcpname.Text & "','" & Format(tdate.Value, "yyyy-MM-dd") & "','" & enrolleecode.SelectedValue & "','" & CDec(totall.Text) & "','" & False & "','" & PREMI & "','" & PREMI2 & "')"
                        CCNN.Open()
                        Cd3.ExecuteNonQuery()
                        CCNN.Close()
                    End If
                Next
            End If
            saveaudit("Save/Update Batch record for code: " + Trim(batchcode1.Text) + " In " + Me.Text)
            clearrec()

            Me.Refresh()
            MessageBox.Show("Batch Save/Update Sucessfully")
            ' clearrec()
        End Using

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        'End Try
    End Sub

    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        '    delfirst()
        '    Try
        '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '            Dim Cd3 As SqlCommand = CCNN.CreateCommand
        '            Cd3.CommandType = CommandType.Text

        '            Dim i As Integer
        '            ' MsgBox(Payvalgrid.RowCount)
        '            If claimsinputegrid.RowCount > 0 Then
        '                For i = 0 To claimsinputegrid.RowCount - 1 ''familygrid.Rows(i).Cells(0).Value
        '                    '   MessageBox.Show(claimsinputegrid.Rows(i).Cells(0).Value)
        '                    Cd3.CommandText = "INSERT INTO claimsinpute(hcpid,hcpname,tdate,batchcode,enrolleeid,ailmentcode,authocode,dtreated,ddischard,billamount,posted,approved,postedforapprove) VALUES('" & hcpid.Text & "','" & hcpname.Text & "','" & tdate.Value & "','" & batchcode1.Text & "','" & claimsinputegrid.Rows(i).Cells(0).Value & "','" & claimsinputegrid.Rows(i).Cells(1).Value & "','" & claimsinputegrid.Rows(i).Cells(2).Value & "','" & claimsinputegrid.Rows(i).Cells(3).Value & "','" & claimsinputegrid.Rows(i).Cells(4).Value & "','" & Val(claimsinputegrid.Rows(i).Cells(5).Value) & "','" & False & "','" & False & "','" & False & "')"
        '                    CCNN.Open()
        '                    Cd3.ExecuteNonQuery()
        '                    CCNN.Close()

        '                Next
        '            End If
        '            saveaudit("Save/Update Batch record for code: " + Trim(batchcode1.Text) + " In " + Me.Text)
        '            delemptyenrolle()
        '            Me.Refresh()
        '            MessageBox.Show("Batch Save/Update Sucessfully")
        '        End Using

        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        '    End Try
    End Sub

    Sub loadgriddata()
        Try
            Dim i2 As Integer
            For i2 = i2 To claimsinputegrid.RowCount - 1
                claimsinputegrid.Rows.Clear()
            Next
            Dim gg2 As String = "SELECT dtreated,ailmentcode,authocode,billamount,batchcode,hcpid,hcpname,tdate,enrolleeid,posted FROM claimsinputenew where rtrim(enrolleeid) = '" & RTrim(enrolleecode.SelectedValue) & "' and rtrim(hcpid) = '" & hcpid.Text.Trim & "' and tdate = '" & Format(tdate.Value, "yyyy-MM-dd") & "' and rtrim(batchcode) = '" & batchcode1.Text.Trim & "'"
            'Dim gg2 As String = "select ,enrolleeid from claimsinpute where rtrim(hcpid) ='" & hcpid.Text & "' and tdate = '" & tdate.Text & "' and rtrim(batchcode) = '" & batchcode1.Text.Trim & "'"

            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = claimsinputegrid.Rows.Add
                        claimsinputegrid.Rows(row).Cells(0).Value = r(0)
                        If RTrim(r(1)).Substring(0, 1) = "I" Then
                            claimsinputegrid.Rows(row).Cells(1).Value = RTrim(r(1))
                            'MessageBox.Show(RTrim(r(1)))
                        End If
                        If RTrim(r(1)).Substring(0, 1) = "N" Then
                            claimsinputegrid.Rows(row).Cells(2).Value = RTrim(r(1))
                            'MessageBox.Show(RTrim(r(1)))
                        End If
                        claimsinputegrid.Rows(row).Cells(3).Value = RTrim(r(2))
                        claimsinputegrid.Rows(row).Cells(4).Value = Val(r(3))
                    End While
                End If
                r.Close()
                Me.Refresh()

            End Using
            claimsinputegrid.Refresh()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
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

    Sub loadailmentcodecombo()
        'Dim connetionString As String = Nothing
        'Dim connection As SqlConnection
        'Dim command As SqlCommand
        'Dim adapter As New SqlDataAdapter()
        'Dim ds As New DataSet()
        'Dim i As Integer = 0
        'Dim sql As String = Nothing
        'connetionString = My.Settings.cnnstring
        ''If SERVICE.D
        'sql = "select code1,descr from Ailmenttypedefault order by code1" Then
        'connection = New SqlConnection(connetionString)
        'Try
        '    connection.Open()
        '    command = New SqlCommand(sql, connection)
        '    adapter.SelectCommand = command
        '    adapter.Fill(ds)
        '    adapter.Dispose()
        '    command.Dispose()
        '    connection.Close()
        '    ailmenttype.DataSource = ds.Tables(0)
        '    ailmenttype.ValueMember = "code1"
        '    ailmenttype.DisplayMember = "descr"
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = "Can not open connection ! "
        'End Try  'ailmentt2
    End Sub



    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        Try
            hcpid.Text = Searchtool.SelectedValue.ToString
            hcpname.Text = Searchtool.Text
            loadenrol2searchcombo2()
            batchcode1.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub batchcode1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles batchcode1.KeyPress

    End Sub

    Private Sub batchcode1_TextChanged(sender As Object, e As EventArgs) Handles batchcode1.TextChanged

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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            clearrec()
            'Dim i2 As Integer
            'For i2 = i2 To ailmentgrid.RowCount - 1
            '    ailmentgrid.Rows.Clear()
            'Next
            totall.Text = 0.0
            Dim i23 As Integer
            For i23 = i23 To claimgrid.RowCount - 1
                claimgrid.Rows.Clear()
            Next
            Dim i24 As Integer
            For i24 = i24 To claimsinputegrid.RowCount - 1
                claimsinputegrid.Rows.Clear()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub loadenrollees2()

        'MessageBox.Show("Loading Enrolles")
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from stafftab WHERE" _
            & " staffid != '" & "ADMIN" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            postedto.DataSource = ds.Tables(0)
            postedto.ValueMember = "staffid"
            postedto.DisplayMember = "names"

        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Private Sub claimsinputegrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles claimsinputegrid.CellEndEdit
        Try
            Dim tott2 As Double = 0.0
            Dim tott As Double = 0.0
            Dim tott3 As Double = 0.0
            For index As Integer = 0 To claimsinputegrid.RowCount - 1
                If claimsinputegrid.Rows.Count = 0 Then Exit Sub
                Dim Idx = e.RowIndex
                tott += Convert.ToDecimal(claimsinputegrid.Rows(index).Cells(4).Value)
                totall.Text = FormatNumber(tott, 2, True, True, True)
                If (Not claimsinputegrid.Rows(index).Cells(1).Value = String.Empty) And (Not claimsinputegrid.Rows(index).Cells(2).Value = String.Empty) Then
                    claimsinputegrid.Rows(index).Cells(1).Value = String.Empty
                    claimsinputegrid.Rows(index).Cells(2).Value = String.Empty
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub getdrug()
        '     MessageBox.Show("D")

        'SERVICE.DisplayMember = Nothing
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'If SERVICE.D
        sql = "select code1,descr from Ailmenttypedefault WHERE SUBSTRING(code1, 1,1) = 'I' order by descr"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            SERVICE.DataSource = ds.Tables(0)
            SERVICE.ValueMember = "code1"
            SERVICE.DisplayMember = "descr"
            SERVICE.Items.Add("")
            'SERVICE.Items.Insert(0, New ListItem("bgfddddddd", "IL9999"))
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try  'ailmentt2
    End Sub
    Sub GetService2()
        '  MessageBox.Show("S")
        'ailmenttype.DisplayMember = Nothing
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'If SERVICE.D
        sql = "select code1,descr from Ailmenttypedefault WHERE SUBSTRING(code1, 1,1) = 'N' order by descr"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ailmenttype.DataSource = ds.Tables(0)
            ailmenttype.ValueMember = "code1"
            ailmenttype.DisplayMember = "descr"
            ailmenttype.Items.Add("")
            'ailmenttype.Items.Insert(0, New ListItem("jhhhhhhhhhhhhhh", "NL9999"))
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try  'ailmentt2
    End Sub
    Private Sub claimsinputegrid_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles claimsinputegrid.CellValidated
        'For i = 0 To claimsinputegrid.RowCount - 1
        '    Dim x As String
        '    x = claimsinputegrid.Rows(0).Cells(0).Value
        '    If Not x = String.Empty Then
        '        claimsinputegrid.Rows(0).Cells(6).Value = x
        '    End If
        '    Dim il As String
        '    il = claimsinputegrid.Rows(0).Cells(1).Value
        '    If Not il = String.Empty Then
        '        claimsinputegrid.Rows(0).Cells(7).Value = il
        '    End If
        'Next
        'Dim row As DataGridViewRow
        'For Each row In Me.claimsinputegrid.Rows
        '    row.Cells(3).Value = DateTime.Now
        '    row.Cells(4).Value = DateTime.Now
        'Next row
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result = MsgBox("Post For Vetting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            If resendcheck.Checked = True Then
                If (Not batchcode1.Text = String.Empty) Then
                    resendforvetting()
                End If
                clearrec()
                batchcode1.Text = ""
                Me.Refresh()
            Else
                If (Not batchcode1.Text = String.Empty) Then
                    '       UpdategencodeRecord()
                    UPDATECLAIMACTINPUE()
                    sendforvetting()
                    lockbatch()
                    '  getsettingcode()
                End If
                clearrec()
                batchcode1.Text = ""
                Me.Refresh()
            End If
        End If
    End Sub
    Public Sub UPDATECLAIMACTINPUE()  'Subroutine to insert a record into the database  
        Try
            Dim sumSQL As String = "INSERT INTO claimsinpute(hcpid,hcpname,tdate,batchcode,enrolleeid,ailmentcode,authocode,dtreated,billamount,descrtype,enrollname)" & _
                                                     "select hcpid,hcpname,tdate,batchcode,enrolleeid,ailmentcode,authocode,dtreated,billamount,descrtype,enrollname FROM claimsinputenew where Rtrim(batchcode) = '" & RTrim(batchcode1.Text) & "' and posted = '" & False & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '  MessageBox.Show("Record Posted Successfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in UPDATE CLAIMACTINPUE Insert")
        End Try

    End Sub
    Sub lockbatch()
        ',0.00 as defaultamt,billamount,0.00 as variance,'" & False & "' as posted,"" as postedto ,'" & False & "' as approved,'" & False & "' as postedforapprove, "" as appsendto,'" & False & "' as allertstop 
        Try
            Dim cSQL As String = "UPDATE claimsinputenew SET posted = '" & True & "' Where rtrim(batchcode) = '" & batchcode1.Text.Trim & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub sendforvetting()
        ',0.00 as defaultamt,billamount,0.00 as variance,'" & False & "' as posted,"" as postedto ,'" & False & "' as approved,'" & False & "' as postedforapprove, "" as appsendto,'" & False & "' as allertstop 
        Try
            Dim cSQL As String = "UPDATE claimsinpute SET posted = '" & True & "',postedto = '" & RTrim(postedto.SelectedValue) & "',defaultamt = '" & 0.0 & "',variance = '" & 0.0 & "',approved = '" & False & "',postedforapprove = '" & False & "',appsendto = '" & Space(10) & "',allertstop = '" & False & "' Where  rtrim(batchcode) = '" & batchcode1.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Batch Posted Sucessfully")
                saveaudit("Posted Batch code: " + RTrim(batchcode1.Text) + " to :" + postedto.Text + " For Vetting " + " In " + Me.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub resendforvetting()
        ',0.00 as defaultamt,billamount,0.00 as variance,'" & False & "' as posted,"" as postedto ,'" & False & "' as approved,'" & False & "' as postedforapprove, "" as appsendto,'" & False & "' as allertstop 
        Try
            Dim cSQL As String = "UPDATE claimsinpute SET postedto = '" & RTrim(postedto.SelectedValue) & "' Where  rtrim(batchcode) = '" & RTrim(batchcode1.Text) & "' and posted = '" & True & "' and postedforapprove = '" & False & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Batch Re-Posted Sucessfully")
                saveaudit("Re-Posted Batch code: " + RTrim(batchcode1.Text) + " to :" + postedto.Text + " For Vetting " + " In " + Me.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    '***********************************  Grid2  Page 2 *********************************************************
    Sub loadailment2codecombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select code1,descr from Ailmenttypedefault order by code1"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ailmentt2.DataSource = ds.Tables(0)
            ailmentt2.ValueMember = "code1"
            ailmentt2.DisplayMember = "descr" 'ailmenttype
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try  'ailmentt2
    End Sub

    Sub loadenrol2searchcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from enrolleetab order by enrolleeid"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            enrolleeid2.DataSource = ds.Tables(0)
            enrolleeid2.ValueMember = "enrolleeid"
            enrolleeid2.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try  'enrolleeid2
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinputenew where posted = '" & False & "' order by tdate"
            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            batchcode1.Text = CODDY
            batchcode1.Refresh()
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'If (Not batchcode1.Text = String.Empty) Then
        '    LoadRecord()
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinpute WHERE" _
                    & " postedto = '" & My.Settings.loginid & "' and postedforapprove = '" & False & "' order by tdate"

            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            batchcode2.Text = CODDY
            batchcode2.Refresh()
            Me.Refresh()

            If (Not batchcode2.Text = String.Empty) Then
                batchcode2.Refresh()
                loadapprovedgriddata2()
                batchcode2.Refresh()
                calctotal()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub loadapprovedgriddata2()
        'MessageBox.Show("loaddeafult")
        Try
            Dim i2 As Integer
            For i2 = i2 To claimgrid.RowCount - 1
                claimgrid.Rows.Clear()
            Next

            Dim gg2 As String = "select hcpid,enrolleeid,dtreated,ailmentcode,0.00 as defamt,billamount,0.00 as varianceamt from claimsinpute where rtrim(batchcode) = '" & RTrim(batchcode2.Text) & "' and postedforapprove = '" & False & "'"


            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        hcpidsearch.Text = RTrim(r(0))
                        Dim row As Integer = claimgrid.Rows.Add
                        claimgrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        claimgrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        claimgrid.Rows(row).Cells(2).Value = r(2)
                        claimgrid.Rows(row).Cells(3).Value = RTrim(r(3))

                        claimgrid.Rows(row).Cells(4).Value = Val(r(4))
                        claimgrid.Rows(row).Cells(5).Value = Val(r(5))
                        claimgrid.Rows(row).Cells(6).Value = Val(r(6))
                        claimgrid.Rows(row).Cells(1).ReadOnly = True
                        claimgrid.Rows(row).Cells(4).ReadOnly = True
                    End While
                End If
                r.Close()

                Me.Refresh()
            End Using
            'MessageBox.Show("loaddeafult")
            loaddeafult()

        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub

   
    Sub loaddeafult()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                CCNN.Open()
                Dim i As Integer

                If claimgrid.RowCount > 0 Then
                    For i = 0 To claimgrid.RowCount - 1
                        Cd3.CommandText = "select code,descr,amount,hcpid FROM hcpailmenttab where rtrim(hcpid) = '" & claimgrid.Rows(i).Cells(0).Value & "' and rtrim(code) = '" & claimgrid.Rows(i).Cells(3).Value & "'"
                        Dim rr As SqlDataReader = Cd3.ExecuteReader
                        rr.Read()
                        claimgrid.Rows(i).Cells(4).Value = rr(2)
                        claimgrid.Rows(i).Cells(6).Value = claimgrid.Rows(i).Cells(5).Value - claimgrid.Rows(i).Cells(6).Value
                        rr.Close()
                    Next
                End If
                Me.Refresh()
            End Using
            claimgrid.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in loaddeafult price Table")
        End Try
    End Sub
    Sub Loadnewilnessgrid()
        '' MessageBox.Show("in")  ailmentgrid
        If (Not Searchtool.SelectedValue = String.Empty) Then


            Dim i2 As Integer
            For i2 = i2 To ailmentgrid.RowCount - 1
                ailmentgrid.Rows.Clear()
            Next
            Dim gg2 As String = "select code,descr,amount FROM hcpailmenttab where rtrim(hcpid) = '" & RTrim(Searchtool.SelectedValue) & "'"

            Try
                Using ccnn As New SqlConnection(My.Settings.cnnstring)
                    Dim cd As SqlCommand = ccnn.CreateCommand

                    cd.CommandText = gg2
                    cd.CommandType = CommandType.Text
                    ccnn.Open()
                    Dim r As SqlDataReader = cd.ExecuteReader
                    If r.HasRows() Then
                        While r.Read
                            Dim row As Integer = ailmentgrid.Rows.Add
                            ailmentgrid.Rows(row).Cells(0).Value = r(0)
                            ailmentgrid.Rows(row).Cells(1).Value = r(1)
                            ailmentgrid.Rows(row).Cells(2).Value = r(2)
                        End While
                    End If
                    r.Close()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg.Text = ex.Message
            End Try
            Me.Refresh()
        End If
    End Sub
    Sub loadapprovalstaff()

        'MessageBox.Show("Loading Enrolles")
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select userid,names from useracct WHERE" _
            & " userid != '" & "ADMIN" & "' and approve = '" & True & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            approvestaff.DataSource = ds.Tables(0)
            approvestaff.ValueMember = "userid"
            approvestaff.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        If claimgrid.RowCount > 0 Then
            For i = 0 To claimgrid.RowCount - 1
                If claimgrid.Rows(i).Cells(5).Value > claimgrid.Rows(i).Cells(4).Value Then
                    claimgrid.Rows(i).Cells(6).Value = Math.Abs(Val(claimgrid.Rows(i).Cells(4).Value) - Val(claimgrid.Rows(i).Cells(5).Value))
                    claimgrid.Rows(i).Cells(5).Value = claimgrid.Rows(i).Cells(4).Value
                    claimgrid.Rows(i).Cells(3).Style.BackColor = Color.Red
                    claimgrid.Rows(i).Cells(4).Style.BackColor = Color.Red
                    claimgrid.Rows(i).Cells(5).Style.BackColor = Color.Red
                    claimgrid.Rows(i).Cells(6).Style.BackColor = Color.Yellow
                Else
                    claimgrid.Rows(i).Cells(6).Value = 0.0
                End If
            Next
        End If
        Me.Refresh()
        claimgrid.Refresh()
        updatevetcolumns()
        caldtotal()
    End Sub
    Sub updatevetcolumns()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                If claimgrid.RowCount > 0 Then
                    For i = 0 To claimgrid.RowCount - 1
                        'MessageBox.Show(claimgrid.Rows(i).Cells(5).Value)
                        Cd3.CommandText = "UPDATE claimsinpute SET" _
                          & " billamount = '" & Val(claimgrid.Rows(i).Cells(5).Value) & "', " & " defaultamt = '" & Val(claimgrid.Rows(i).Cells(4).Value) & "', " & " variance = '" & Val(claimgrid.Rows(i).Cells(6).Value) & "', " & " approved = '" & claimgrid.Rows(i).Cells(7).Value & "' " & " WHERE" & " rtrim(hcpid) = '" & RTrim(claimgrid.Rows(i).Cells(0).Value) & "' and rtrim(batchcode) = '" & RTrim(Me.batchcode2.Text) & "'  and rtrim(ailmentcode) = '" & RTrim(claimgrid.Rows(i).Cells(3).Value) & "' and rtrim(enrolleeid) = '" & RTrim(claimgrid.Rows(i).Cells(1).Value) & "' "
                        CCNN.Open()
                        Cd3.ExecuteNonQuery()
                        CCNN.Close()
                    Next
                End If
                Me.Refresh()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try

    End Sub

    Sub postforapprovals2() ' and approved = '" & True & "'
        Dim sumSQL As String = "INSERT INTO claimsinputeApproved(hcpid,hcpname,tdate,batchcode,enrolleeid,ailmentcode,authocode,dtreated,defaultamt,billamount,variance,posted,postedto,approved,postedforapprove,appsendto,Mdapproves)" & _
            "                                             select hcpid,hcpname,tdate,batchcode,enrolleeid,ailmentcode,authocode,dtreated,defaultamt,billamount,variance,posted,postedto,approved,'" & True & "' as postedforapprove,'" & approvestaff.SelectedValue & "' as appsendto,'" & False & "' as Mdapproves FROM claimsinpute where Rtrim(batchcode) = '" & RTrim(batchcode2.Text) & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                MessageBox.Show("Record Posted Successfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in postforapprovals Insert")
        End Try
    End Sub
    Sub saveapprovedd()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If claimgrid.RowCount > 0 Then
                    For i = 0 To claimgrid.RowCount - 1
                        Cd3.CommandText = "UPDATE claimsinpute SET" _
                          & " approved = '" & claimgrid.Rows(i).Cells(7).Value & "', " & " postedforapprove = '" & True & "', " & " appsendto = '" & approvestaff.SelectedValue & "', " & " allertstop = '" & False & "' " & " WHERE" & " rtrim(hcpid) = '" & RTrim(claimgrid.Rows(i).Cells(0).Value) & "' and rtrim(batchcode) = '" & RTrim(Me.batchcode2.Text) & "'  and rtrim(ailmentcode) = '" & RTrim(claimgrid.Rows(i).Cells(3).Value) & "' and rtrim(enrolleeid) = '" & RTrim(claimgrid.Rows(i).Cells(1).Value) & "' "
                        CCNN.Open()
                        Cd3.ExecuteNonQuery()
                        CCNN.Close()
                    Next
                End If
                Me.Refresh()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in saveapprovedd")
        End Try
    End Sub
    Sub delfirstaMDapp()
        cSQL = "DELETE FROM claimsinputeApproved WHERE" _
           & " batchcode = '" & Me.batchcode2.Text & "'"
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
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (Not batchcode2.Text = String.Empty) Then
            saveapprovedd()
            delfirstaMDapp()
            postforapprovals2()
            '    UpdategencodeRecord()
            clearrec()
            'Dim i2 As Integer
            'For i2 = i2 To ailmentgrid.RowCount - 1
            '    ailmentgrid.Rows.Clear()
            'Next

            Dim i23 As Integer
            For i23 = i23 To claimgrid.RowCount - 1
                claimgrid.Rows.Clear()
            Next
            Dim i24 As Integer
            For i24 = i24 To claimsinputegrid.RowCount - 1
                claimsinputegrid.Rows.Clear()
            Next
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub batchcode2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles batchcode2.Validating
        If (Not batchcode2.Text = String.Empty) Then
            loadapprovedgriddata2()
        End If
    End Sub

    Private Sub batchcode1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles batchcode1.Validating
        'If (Not batchcode1.Text = String.Empty) Then
        '    loadapprovedgriddata2()
        'End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ColSum2 As Decimal
        For Each RR As DataGridViewRow In claimsinputegrid.Rows
            ColSum2 += RR.Cells(4).Value
            totall.Text = FormatNumber(ColSum2, 2, True, True, True)
        Next
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        postedto.Visible = True
        Label14.Visible = True
        Button1.Visible = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        postedto.Visible = False
        Label14.Visible = False
        Button1.Visible = False
    End Sub

    Private Sub enrolleecode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles enrolleecode.SelectedIndexChanged
        clearrec()
        'If (Not batchcode1.Text = String.Empty) Then
        '    batchcode1.Refresh()
        '    loadapprovedgriddata2()
        '    batchcode1.Refresh()
        'End If
        If (Not batchcode1.Text = String.Empty) Then
            LoadRecord()
        End If
    End Sub

    Private Sub claimgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles claimgrid.CellContentClick

    End Sub

    Private Sub claimgrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles claimgrid.CellEndEdit
        Try
            Dim tott2 As Double = 0.0
            Dim tott As Double = 0.0
            Dim tott3 As Double = 0.0
            For index As Integer = 0 To claimgrid.RowCount - 1
                If claimgrid.Rows.Count = 0 Then Exit Sub
                Dim Idx = e.RowIndex
                tott += Convert.ToDecimal(claimgrid.Rows(index).Cells(5).Value)
                totall2.Text = FormatNumber(tott, 2, True, True, True)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub caldtotal()
        Dim ColSum2 As Decimal
        For Each RR As DataGridViewRow In claimgrid.Rows
            ColSum2 += RR.Cells(5).Value
            totall2.Text = FormatNumber(ColSum2, 2, True, True, True)
        Next
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim ColSum2 As Decimal
        For Each RR As DataGridViewRow In claimgrid.Rows
            ColSum2 += RR.Cells(5).Value
            totall2.Text = FormatNumber(ColSum2, 2, True, True, True)
        Next
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        For Each RR As DataGridViewRow In claimgrid.Rows
            If RR.Cells(7).Value = True Then
                RR.Cells(7).Value = False
            Else
                RR.Cells(7).Value = True
            End If
        Next
    End Sub
    Sub calctotal()
        Dim ColSum2 As Decimal
        For Each RR As DataGridViewRow In claimgrid.Rows
            ColSum2 += RR.Cells(5).Value
            totall2.Text = FormatNumber(ColSum2, 2, True, True, True)
        Next
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinpute order by tdate"

            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            bcode2.Text = CODDY
            bcode2.Refresh()
            Me.Refresh()
            'If (Not bcode2.Text = String.Empty) Then
            '    printclaimsverted()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub printclaimsverted()
        If (Not bcode2.Text = String.Empty) Then
            rptrangecode = ""
            My.Settings.reportsqlstr = "printclaimsverted"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = bcode2.Text
            viewreport2.Text = "Print Verting claims Report"
            viewreport2.Show()
        End If
    End Sub
    Sub printclaimsverted2()
        If (Not bcode3.Text = String.Empty) Then
            rptrangecode = ""
            My.Settings.reportsqlstr = "printclaimsverted2"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = bcode3.Text
            viewreport2.Text = "Print claims Report"
            viewreport2.Show()
        End If
    End Sub





    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        printclaimsverted2()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        printclaimsverted()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinputenew where posted = '" & False & "' order by tdate"

            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            bcode3.Text = CODDY
            bcode3.Refresh()
            Me.Refresh()
            'If (Not bcode2.Text = String.Empty) Then
            '    printclaimsverted()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub UpdategencodeRecord() '****This procedures,updates,CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        Me.autobatch.Text = Str(Val(LTrim(autobatch.Text.Trim)) + 1)
        Try
            Dim cSQL As String = "UPDATE digitsettings SET claimbatchcode = '" & LTrim(Me.autobatch.Text) & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' clearrec()
    End Sub
    Sub getsettingcode()
        Dim gg2 As String = "select companyid,claimbatchcode from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    batchcode1.Text = RTrim(r(1)).Trim
                    autobatch.Text = RTrim(r(1)).Trim
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        getsettingcode()
        UpdategencodeRecord()
    End Sub


    Private Sub Searchtool_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Searchtool.Validating
        Loadnewilnessgrid()
    End Sub

    Private Sub claimsinputegrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles claimsinputegrid.CellContentClick

    End Sub

    Private Sub batchcode2_TextChanged(sender As Object, e As EventArgs) Handles batchcode2.TextChanged

    End Sub

    Private Sub hcpid_TextChanged(sender As Object, e As EventArgs) Handles hcpid.TextChanged

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles resendcheck.CheckedChanged
        postedto.Visible = True
        Label14.Visible = True
        Button1.Visible = True
    End Sub
End Class
