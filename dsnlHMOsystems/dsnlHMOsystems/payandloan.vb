Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class payandloan
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    ' Dim textbx As New TextBox()
    Public gstring1 As String
    Public addnew As Boolean
    '  Public Sub PerformClick()
    Public CODE1ee As String
    Public descrrr As String
    Private Sub payandloan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        defaultgrid.EnableHeadersVisualStyles = False
        defaultgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        defaultgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        defaultgrid.ColumnHeadersHeight = 30
        defaultgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        loangrid.EnableHeadersVisualStyles = False
        loangrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        loangrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        loangrid.ColumnHeadersHeight = 30
        loangrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        Try
            Dim col3 As New CalendarColumn()
            col3.DataPropertyName = "dcolledcted"
            col3.HeaderText = "Date_Colledcted"
            Dim loc3 As Integer =
            loangrid.Columns.IndexOf(loangrid.Columns("dcolledcted"))
            loangrid.Columns.RemoveAt(loc3)
            loangrid.Columns.Insert(loc3, col3)
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try
        Try
            Dim col3 As New CalendarColumn()
            col3.DataPropertyName = "sdate"
            col3.HeaderText = "StartDate"
            Dim loc3 As Integer =
            loangrid.Columns.IndexOf(loangrid.Columns("sdate"))
            loangrid.Columns.RemoveAt(loc3)
            loangrid.Columns.Insert(loc3, col3)
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try

        '  Searchtool.SelectedIndex = -1
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
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "staffid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
        Defaultgrd()
        loangrd()




    End Sub
    Public Sub clearrec()

        grosstd.Text = 0.0
        taxtd.Text = 0.0
        fixedtax.Text = 0.0
        Dim T As Integer
        For T = T To defaultgrid.RowCount - 1
            defaultgrid.Rows.Clear()
        Next
        Dim T2 As Integer
        For T2 = T2 To loangrid.RowCount - 1
            loangrid.Rows.Clear()
        Next

        Me.Refresh()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        names.Text = ""
    End Sub
    Public Sub delrec()

        'SELECT itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM defaulttab WHERE" _
            & " staffid = '" & Me.staffid.Text & "'"
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
            Dim cSQL2 As String = "DELETE FROM loantab WHERE" _
                        & " staffid = '" & Me.staffid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for Payment Record for staffID : " + Trim(staffid.Text) + " In " + Me.Text)

                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Dim cSQL3 As String = "DELETE FROM summarytab WHERE" _
                                    & " staffid = '" & Me.staffid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL3
                    CCNN.Open()
                    Cd.ExecuteNonQuery()

                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        End If

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
            staffid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT staffid,names,fixedtax,grosstd,taxtd FROM summarytab WHERE" _
                & "  Rtrim(staffid) = '" & Trim(staffid.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.names.Text = r(1)
                    If Not r.IsDBNull(2) Then Me.fixedtax.Text = r(2)
                    If Not r.IsDBNull(3) Then Me.grosstd.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.taxtd.Text = r(4)
                    getdefault()
                    getloan()
                    names.Focus()
                    My.Settings.newrec = True
                Else
                    My.Settings.newrec = False
                    names.Focus()
                    '   MessageBox.Show("New")
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub getdefault()
        'SELECT staffid,pic,descr,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate FROM loantab
        'SELECT staffid,pic,amount,descr FROM defaulttab
        'SELECT staffid,names,fixedtax,grosstd,taxtd FROM summarytab
        Dim i2 As Integer
        For i2 = i2 To defaultgrid.RowCount - 1
            defaultgrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT staffid,pic,amount,descr FROM defaulttab where RTrim(staffid) = '" & Trim(staffid.Text) & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = defaultgrid.Rows.Add
                        defaultgrid.Rows(row).Cells(0).Value = RTrim(r(1))
                        defaultgrid.Rows(row).Cells(1).Value = RTrim(r(2))
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
    Sub getloan()
        'SELECT staffid,pic,descr,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate FROM loantab
        'SELECT staffid,pic,amount,descr FROM defaulttab
        'SELECT staffid,names,fixedtax,grosstd,taxtd FROM summarytab
        Dim i2 As Integer
        For i2 = i2 To loangrid.RowCount - 1
            loangrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT pic,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate,stopped FROM loantab where rTrim(staffid) = '" & Trim(staffid.Text) & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = loangrid.Rows.Add
                        loangrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        loangrid.Rows(row).Cells(1).Value = Val(r(1))
                        loangrid.Rows(row).Cells(2).Value = r(2)
                        loangrid.Rows(row).Cells(3).Value = r(3)
                        loangrid.Rows(row).Cells(4).Value = Val(r(4))
                        loangrid.Rows(row).Cells(5).Value = r(5)
                        loangrid.Rows(row).Cells(6).Value = RTrim(r(6))
                        loangrid.Rows(row).Cells(7).Value = Val(r(7))
                        loangrid.Rows(row).Cells(8).Value = r(8)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
            updatesum()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub updatesum()
        Dim gg2 As String = "SELECT staffid,names,fixedtax,grosstd,taxtd FROM summarytab where rTrim(staffid) = '" & Trim(staffid.Text) & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.names.Text = r(1)
                    If Not r.IsDBNull(2) Then Me.fixedtax.Text = r(2)
                    If Not r.IsDBNull(3) Then Me.grosstd.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.taxtd.Text = r(4)
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        delrec2()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount) SELECT                                                                                                                                                                                                   billcode,descr,invoicetopic,tdate,invoiceno,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM salesinvoice sinvoicegrid
                If loangrid.RowCount > 0 Then
                    For i = 0 To loangrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value
                        '  MessageBox.Show("loop 1")
                        If loangrid.Rows(i).Cells(1).Value > 0 Then
                            CheckCodestab.payitemsSearch(loangrid.Rows(i).Cells(0).Value)
                            Dim nna As String = CheckCodestab.descvar
                            '  MessageBox.Show(nna)
                            '   MessageBox.Show(loangrid.Rows(i).Cells(0).Value)
                            Cd3.CommandText = "INSERT INTO loantab(staffid,pic,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate,stopped,descr)" & _
                                              "VALUES('" & staffid.Text & "','" & loangrid.Rows(i).Cells(0).Value & "','" & Val(loangrid.Rows(i).Cells(1).Value) & "','" & loangrid.Rows(i).Cells(2).Value & "','" & loangrid.Rows(i).Cells(3).Value & "','" & Val(loangrid.Rows(i).Cells(4).Value) & "','" & loangrid.Rows(i).Cells(5).Value & "','" & loangrid.Rows(i).Cells(6).Value & "','" & Val(loangrid.Rows(i).Cells(7).Value) & "','" & loangrid.Rows(i).Cells(8).Value & "','" & nna & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update Default Values/Loan Records for staffid: " + Trim(staffid.Text) + " In " + Me.Text)
                Me.Refresh()

            End Using
            ' getgriddesc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Loan Table")
        End Try
        '  Default save
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If defaultgrid.RowCount > 0 Then
                    For i = 0 To defaultgrid.RowCount - 1
                        '  MessageBox.Show("loop 2")
                        If defaultgrid.Rows(i).Cells(1).Value > 0 Then
                            CheckCodestab.payitemsSearch(defaultgrid.Rows(i).Cells(0).Value)
                            Dim nna As String = CheckCodestab.descvar
                            '  MessageBox.Show(defaultgrid.Rows(i).Cells(0).Value)
                            Cd3.CommandText = "INSERT INTO defaulttab(staffid,pic,amount,descr)" & _
                              "VALUES('" & staffid.Text & "','" & defaultgrid.Rows(i).Cells(0).Value & "','" & Val(defaultgrid.Rows(i).Cells(1).Value) & "','" & nna & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                Me.Refresh()
                MessageBox.Show("Record Save/Update Sucessfully")
            End Using
            ' getgriddesc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in defaulttab Table")
        End Try
        '  Summarytab save 'SELECT staffid,names,fixedtax,grosstd,taxtd FROM summarytab
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Cd3.CommandText = "INSERT INTO summarytab(staffid,names,fixedtax,grosstd,taxtd)" & _
                              "VALUES('" & staffid.Text & "','" & names.Text & "','" & fixedtax.Text & "','" & grosstd.Text & "','" & taxtd.Text & "')"
                CCNN.Open()
                Cd3.ExecuteNonQuery()
                CCNN.Close()
            End Using
            ' getgriddesc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in summarytab Table")
        End Try
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

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
        names.Text = ""
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
    Sub Defaultgrd()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select itemcode,itemdescr from payitems where advance = '" & False & "'"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            pic.DataSource = ds.Tables(0)
            pic.ValueMember = "itemcode"
            pic.DisplayMember = "itemdescr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Sub loangrd()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select itemcode,itemdescr from payitems where advance = '" & True & "'"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            lpic.DataSource = ds.Tables(0)
            lpic.ValueMember = "itemcode"
            lpic.DisplayMember = "itemdescr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
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

    Private Sub staffid_ImeModeChanged(sender As Object, e As EventArgs) Handles staffid.ImeModeChanged

    End Sub

    Private Sub staffid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles staffid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not staffid.Text = String.Empty) Then
                CheckCodestab.stafftabname(Trim(staffid.Text))
                names.Text = CheckCodestab.descvar
                LoadRecord()
                names.Focus()
            End If
        End If
    End Sub

    Private Sub staffid_TextChanged(sender As Object, e As EventArgs) Handles staffid.TextChanged

    End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        staffid.Text = Searchtool.SelectedValue.ToString
        If (Not staffid.Text = String.Empty) Then
            CheckCodestab.stafftabname(Trim(staffid.Text))
            names.Text = CheckCodestab.descvar
            LoadRecord()
        End If

        staffid.Focus()

    End Sub
    Public Sub delrec2()

        'SELECT itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems


        cSQL = "DELETE FROM defaulttab WHERE" _
        & " staffid = '" & Me.staffid.Text & "'"
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
        Dim cSQL2 As String = "DELETE FROM loantab WHERE" _
                    & " staffid = '" & Me.staffid.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL2
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim cSQL3 As String = "DELETE FROM summarytab WHERE" _
                                & " staffid = '" & Me.staffid.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL3
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub loangrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles loangrid.CellEndEdit

    'End Sub

    'Private Sub loangrid_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles loangrid.CellLeave
    '    Try
    '        If (Not IsNumeric(loangrid.Rows(e.RowIndex).Cells(1).Value)) Then
    '            MessageBox.Show("Amount Collected -- Numeric Column only")
    '        End If
    '        If (Not IsNumeric(loangrid.Rows(e.RowIndex).Cells(4).Value)) Then
    '            MessageBox.Show("Monthly Payment -- Numeric Column only")
    '        End If
    '        If (Not IsNumeric(loangrid.Rows(e.RowIndex).Cells(5).Value)) Then
    '            MessageBox.Show("Payment Period -- Numeric Column only")
    '        End If
    '        If (Not IsNumeric(loangrid.Rows(e.RowIndex).Cells(6).Value)) Then
    '            MessageBox.Show("Period Remaining -- Numeric Column only")
    '        End If
    '        If (Not IsNumeric(loangrid.Rows(e.RowIndex).Cells(7).Value)) Then
    '            MessageBox.Show("Paidtodate -- Numeric Column only")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
End Class