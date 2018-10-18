Imports System.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Configuration
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Globalization
Imports System.Text
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel

Public Class useraccount
    Dim OPTR As New MDIParent1
    Dim optname As New MDIParent1
    Dim optname2 As String
    Public fsave As String
    Public OPTRR As String
    Public cSQL As String
    Public typee2 As String
    Public addnew As Boolean
    Dim TT As String
    ' Dim x(15) As Short
    Dim y As Short
    Public gstring1 As String
    Public deptcombo As String

    Private Sub useraccount_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
 
    End Sub
    Private Sub useraccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Codestabassigfolder.codestab' table. You can move, or remove it, as needed.
        '   Me.CodestabTableAdapter4.Fill(Me.Codestabassigfolder.codestab)

      
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

            Dim connetionString As String = Nothing
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter()
            Dim ds As New DataSet()
            Dim i As Integer = 0
            Dim sql As String = Nothing
            connetionString = My.Settings.cnnstring
            ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select STAFFID,RTRIM(SURNAME) + '  ' + firstname as Names from stafftab WHERE" _
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
                SLIST.DataSource = ds.Tables(0)
                SLIST.ValueMember = "staffid"
            SLIST.DisplayMember = "Names"

            Catch ex As Exception
                MDIParent1.statusmsg.Text = "Can not open connection ! "
            End Try



            'Dim connetionString2 As String = Nothing
            'Dim connection2 As SqlConnection
            'Dim command2 As SqlCommand
            'Dim adapter2 As New SqlDataAdapter()
            'Dim ds2 As New DataSet()
            'Dim ii As Integer = 0
            'Dim sql2 As String = Nothing
            'connetionString2 = My.Settings.cnnstring
            ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
            'sql2 = "select code1,descr from codestab where option1 = '" & "F2" & "'"
            'connection2 = New SqlConnection(connetionString2)
            'Try
            '    connection2.Open()
            '    command2 = New SqlCommand(sql2, connection2)
            '    adapter2.SelectCommand = command2
            '    adapter2.Fill(ds2)
            '    adapter2.Dispose()
            '    command2.Dispose()
            '    connection2.Close()
            '    scode.DataSource = ds2.Tables(0)
            '    scode.ValueMember = "code1"
            '    scode.DisplayMember = "descr"
            'Catch ex As Exception
            '    MDIParent1.statusmsg.Text = "Can not open connection ! "
            'End Try

            'Dim connetionString3 As String = Nothing
            'Dim connection3 As SqlConnection
            'Dim command3 As SqlCommand
            'Dim adapter3 As New SqlDataAdapter()
            'Dim ds3 As New DataSet()
            'Dim ii3 As Integer = 0
            'Dim sql3 As String = Nothing
            'connetionString3 = My.Settings.cnnstring
            '' connetionString3 = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
            'sql2 = "select code1,descr from codestab where option1 = '" & "F6" & "'"
            'connection3 = New SqlConnection(connetionString3)
            'Try
            '    connection3.Open()
            '    command3 = New SqlCommand(sql3, connection3)
            '    adapter3.SelectCommand = command3
            '    adapter3.Fill(ds3)
            '    adapter3.Dispose()
            '    command3.Dispose()
            '    connection3.Close()
            '    assignfolder.DataSource = ds3.Tables(0)
            '    assignfolder.ValueMember = "code1"
            '    assignfolder.DisplayMember = "descr"
            'Catch ex As Exception
            '    MDIParent1.statusmsg.Text = "Can not open connection ! "
            'End Try

        Userid.Focus()

            Dim i2 As Integer
            For i2 = i2 To answersheettab.RowCount - 1
                answersheettab.Rows.Clear()
            Next
            Dim gg2 As String = "SELECT menucode,menuname,available FROM menutable"

            Try
                Using ccnn As New SqlConnection(My.Settings.cnnstring)
                    Dim cd As SqlCommand = ccnn.CreateCommand

                    cd.CommandText = gg2
                    cd.CommandType = CommandType.Text
                    ccnn.Open()
                    Dim r As SqlDataReader = cd.ExecuteReader
                    If r.HasRows() Then
                        While r.Read
                            Dim row As Integer = answersheettab.Rows.Add
                            answersheettab.Rows(row).Cells(0).Value = r(0)
                            answersheettab.Rows(row).Cells(1).Value = r(1)
                            answersheettab.Rows(row).Cells(2).Value = r(2)
                        End While
                    End If
                    r.Close()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg.Text = ex.Message
            End Try
            Userid.Focus()

    End Sub



    Public Sub clearrec()
        admin.Checked = False
        Me.names.Text = ""
        Me.pass1.Text = ""
        Me.password.Text = ""
        staffpin.Text = ""
        Me.names.Enabled = False
        admin.Checked = False
        status.Checked = False
        appraise.Checked = False
        approve.Checked = False
        Dim I As Integer
        For I = I To answersheettab.RowCount - 1
            answersheettab.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT menucode,menuname,available FROM menutable"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                        answersheettab.Rows(row).Cells(2).Value = r(2)
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
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Userid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not Userid.Text = String.Empty) Then

                Me.Refresh()
                LoadRecord()
            End If
        End If
    End Sub
    Public Sub saverec()

        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)

        If result = vbYes Then
            'RecordExist()

            If My.Settings.newrec = True Then
                UpdateRecord()
            End If
            If My.Settings.newrec = False Then
                ' MessageBox.Show("New")
                InsertRecord()
            End If
            If My.Settings.newrec2 = True Then
                UpdateRecord2()
            End If
            If My.Settings.newrec2 = False Then
                '  MessageBox.Show("New")
                InsertRecord2()
            End If
            Me.Refresh()
            Userid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
        '   End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT userid,password,names,admin,status,appraise,approve,claimsinput,claimsvetting FROM useracct WHERE" _
                & " userid = '" & Userid.Text & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Me.names.Text = RTrim(r(2))
                    If r(3) = True Then admin.Checked = True
                    If r(3) = False Then admin.Checked = False

                    If r(4) = True Then status.Checked = True
                    If r(4) = False Then status.Checked = False

                    If r(5) = True Then appraise.Checked = True
                    If r(5) = False Then appraise.Checked = False

                    If r(6) = True Then approve.Checked = True
                    If r(6) = False Then approve.Checked = False

                    If r(7) = True Then claimsinput.Checked = True
                    If r(7) = False Then claimsinput.Checked = False
                    If r(8) = True Then claimsvetting.Checked = True
                    If r(8) = False Then claimsvetting.Checked = False

                    My.Settings.newrec = True
                    enablecontrols()
                    names.Focus()
                    checkgridexist()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    names.Focus()
                    names.Text = SLIST.Text.ToUpper
                    'MessageBox.Show(SLIST.Text.ToUpper)
                    checkuser()
                    checkgridexist()
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Sub checkuser()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "select STAFFID,RTRIM(SURNAME) + '  ' + firstname as Names from stafftab WHERE" _
                    & " staffid = '" & RTrim(Userid.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r4 As SqlDataReader = Cd.ExecuteReader
                If r4.HasRows = False Then
                    MessageBox.Show("User Not Registered")
                    Userid.Focus()
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub checkgridexist()

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT userid,menucode,menuname,available FROM usersmenu WHERE" _
                & " userid = '" & Userid.Text & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r4 As SqlDataReader = Cd.ExecuteReader
                If r4.HasRows = True Then
                    Dim I As Integer
                    For I = I To answersheettab.RowCount - 1
                        answersheettab.Rows.Clear()
                    Next
                    ' r4.Read()
                    While r4.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r4(1)
                        answersheettab.Rows(row).Cells(1).Value = r4(2)
                        answersheettab.Rows(row).Cells(2).Value = r4(3)
                    End While
                    My.Settings.newrec2 = True
                    enablecontrols()
                    names.Focus()
                Else
                    My.Settings.newrec2 = False
                End If
                Me.Refresh()
                CCNN.Close()
                r4.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub enablecontrols()
        Me.names.Enabled = True
    End Sub
    Sub savepass()

    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        '  MessageBox.Show("Insert")
        Dim hash As String = getMd5Hash(password.Text.ToString)
        Dim hash2 As String = getMd5Hash(staffpin.Text.ToString)
        Dim add As Boolean = admin.Checked
        Dim sta As Boolean = status.Checked
        Dim appra As Boolean = appraise.Checked
        Dim appro As Boolean = approve.Checked
        ' cSQL = "INSERT INTO companytab(CODE1,company,address,web,tel.email,picpath) VALUES('" & Me.code1.Text & "','" & Me.TextBox1.Text & "','" & Me.address.Text & "','" & Me.web.Text & "','" & Me.tel.Text & "','" & Me.email.Text & "','" & Me.picpath.Text & "')"
        typee2 = ""
        'If examiner.Checked = True Then
        '    typee2 = "EX"
        'End If
        'If User.Checked = True Then
        '    typee2 = "US"
        'End If
        cSQL = "INSERT INTO useracct(userid,names,password,admin,status,appraise,approve,staffpin,claimsinput,claimsvetting) VALUES('" & Me.Userid.Text & "','" & Me.names.Text & "','" & hash & "','" & admin.Checked & "','" & status.Checked & "','" & appraise.Checked & "','" & approve.Checked & "','" & hash2 & "','" & claimsinput.Checked & "','" & claimsvetting.Checked & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Create account for User id : " + Userid.Text)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            '  MessageBox.Show("Record Save Sucessfully")
        End Try


    End Sub

    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        '
        '   MessageBox.Show("Update")   typee2 = "                                           userid,names,email,dept,scode
        typee2 = ""
        Dim hash2 As String
        If approve.Checked = True Then
            hash2 = getMd5Hash(staffpin.Text.ToString)
        Else
            hash2 = ""
        End If

        cSQL = "UPDATE useracct SET" _
              & " admin = '" & admin.Checked & "', " & " staffpin = '" & hash2 & "', " & " status = '" & status.Checked & "', " & " appraise = '" & appraise.Checked & "', " & " approve = '" & approve.Checked & "', " & " claimsinput = '" & claimsinput.Checked & "', " & " claimsvetting = '" & claimsvetting.Checked & "' " & " WHERE" & " userid = '" & Me.Userid.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Update account of User id : " + Userid.Text)
                Userid.Focus()

                ' DESCR.Text = ""
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'MessageBox.Show("Record Save Sucessfully")
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            cSQL = "DELETE FROM useracct WHERE" _
            & " userid = '" & Me.Userid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete account of User id : " + Userid.Text)
                    ' clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


        Dim cSQLs As String = "DELETE FROM usersmenu WHERE" _
            & " userid = '" & Me.Userid.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQLs
                CCNN.Open()
                Cd.ExecuteNonQuery()
                '   saveaudit("Delete account of User id : " + Userid.Text)
                clearrec()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim i2 As Integer
        For i2 = i2 To answersheettab.RowCount - 1
            answersheettab.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT menucode,menuname,available FROM menutable"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                        answersheettab.Rows(row).Cells(2).Value = r(2)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Public Sub InsertRecord2()
        '   MessageBox.Show("insert")
        Try

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                CCNN.Open()
                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If answersheettab.RowCount > 0 Then
                    For i = 0 To answersheettab.RowCount - 1
                        Cd3.CommandText = "insert into usersmenu(userid,menucode,menuname,available) values('" & Userid.Text & "','" & answersheettab.Rows(i).Cells(0).Value & "','" & answersheettab.Rows(i).Cells(1).Value & "','" & answersheettab.Rows(i).Cells(2).Value & "')"
                        Cd3.ExecuteNonQuery()
                    Next
                End If
                Me.Refresh()
                clearrec()
                Userid.Text = ""
                Userid.Focus()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try
    End Sub
    Public Sub UpdateRecord2()
        '   MessageBox.Show("update")
        '   Try

        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            Dim Cd3 As SqlCommand = CCNN.CreateCommand
            Cd3.CommandType = CommandType.Text
            CCNN.Open()
            Dim i As Integer
            ' MsgBox(Payvalgrid.RowCount)
            If answersheettab.RowCount > 0 Then
                For i = 0 To answersheettab.RowCount - 1
                    'bcode,question,mark,marksectotal,allotedmark  userid,menucode,menuname,available
                    Cd3.CommandText = "UPDATE usersmenu SET" _
                                     & " userid = '" & Me.Userid.Text & "',  " & " menucode = '" & answersheettab.Rows(i).Cells(0).Value & "', " & " menuname = '" & answersheettab.Rows(i).Cells(1).Value & "', " & " available = '" & answersheettab.Rows(i).Cells(2).Value & "' " & " WHERE" & " userid = '" & Me.Userid.Text & "' AND Menucode = '" & answersheettab.Rows(i).Cells(0).Value & "'"
                    Cd3.ExecuteNonQuery()
                Next
            End If
            Me.Refresh()
            clearrec()
            Userid.Text = ""
            Userid.Focus()
        End Using
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        '    End Try

    End Sub


    Sub checkexist()

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "SELECT userid,names,password,admin FROM useracct WHERE" _
                & " userid = '" & Me.Userid.Text & "'"

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.Read = True Then
                    MDIParent1.statusmsg.Text = "Account already created, Change Password from Change assword Screen"
                End If

            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try

    End Sub
    ' Verify a hash against a string. 
    Function verifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input. 
        Dim hashOfInput As String = getMd5Hash(input)

        ' Create a StringComparer an compare the hashes. 
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function


    ' Hash an input string and return the hash as 
    ' a 32 character hexadecimal string. 
    Function getMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5CryptoServiceProvider object. 
        Dim md5Hasher As New MD5CryptoServiceProvider()

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function

    Private Sub password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles password.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not pass1.Text = String.Empty) Then
                If pass1.Text <> password.Text Then
                    MessageBox.Show("Password Not confirmed")

                End If
            End If
        End If
    End Sub
    Private Sub pass1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles pass1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not pass1.Text = String.Empty) Then
                password.Focus()
            End If
        End If
    End Sub

    Private Sub pass1_TextChanged(sender As Object, e As EventArgs) Handles pass1.TextChanged

    End Sub

    Private Sub password_Validating(sender As Object, e As CancelEventArgs) Handles password.Validating
        If (Not pass1.Text = String.Empty) Then
            If pass1.Text <> password.Text Then
                MessageBox.Show("Password Not confirmed")

            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'Dim strfilename As String = ""

        'Dim didwork As Integer = FolderBD.ShowDialog
        'If didwork <> DialogResult.Cancel Then
        '    strfilename = FolderBD.SelectedPath

        '    FolderBD.Reset()
        'End If
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
            '   Me.statuspoint.Text = ex.Message  saveaudit("Download excel files for data recapture :")
        Finally
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim dataAdapter As New SqlClient.SqlDataAdapter()
        Dim dataSet As New DataSet
        Dim command As New SqlClient.SqlCommand
        Dim datatableMain As New System.Data.DataTable()
        Dim connection As New SqlClient.SqlConnection

        'Assign your connection string to connection object
        connection.ConnectionString = My.Settings.cnnstring
        '    connection.ConnectionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        command.Connection = connection
        command.CommandType = CommandType.Text
        'You can use any command select
        command.CommandText = "SELECT userid,password,names,admin,status,appraise,approve FROM useracctr where userid != '" & "ADMIN" & "'"

        dataAdapter.SelectCommand = command


        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                'This section help you if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = _
                System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim dc As System.Data.DataColumn
                Dim dr As System.Data.DataRow
                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Fill data to datatable
                connection.Open()
                dataAdapter.Fill(datatableMain)
                connection.Close()


                'Export the Columns to excel file
                For Each dc In datatableMain.Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next

                'Export the rows to excel file
                For Each dr In datatableMain.Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In datatableMain.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next

                'Set final path
                ' Dim str2 As String = Filename33.Text.Trim + ".xls"
                '  Using sw As New IO.StreamWriter("C:\Downloads\" + str2)
                Dim fileName As String = "\Accounttable" + ".xls"
                'Dim fileName As String =
                Dim finalPath = f.SelectedPath + fileName
                '    Filename33.Text = finalPath
                oSheet.Columns.AutoFit()
                'Save file in final path
                oBook.SaveAs(finalPath, XlFileFormat.xlWorkbookNormal, Type.Missing, _
                Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

                'Release the objects
                ReleaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                'Some time Office application does not quit after automation: 
                'so i am calling GC.Collect method.
                GC.Collect()
                ' End Using
                MessageBox.Show("Export done successfully!")
                saveaudit("Download Account Management table :")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub Userid_TextChanged(sender As Object, e As EventArgs) Handles Userid.TextChanged

    End Sub

    


    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If (Not Userid.Text = String.Empty) Then
            saverec()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        If (Not Userid.Text = String.Empty) Then
            saverec()
        End If
    End Sub

    Private Sub DeleteEnrolleeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteEnrolleeToolStripMenuItem.Click
        delrec()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SLIST_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SLIST.SelectedIndexChanged
        Try
            Userid.Text = SLIST.SelectedValue
            names.Text = SLIST.SelectedText.ToUpper
            'If (Not Userid.Text = String.Empty) Then
            '    LoadRecord()
            'End If
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
            '    MessageBox.Show(ex.Message, "Load Data first", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub useraccount_MaximizedBoundsChanged(sender As Object, e As EventArgs) Handles Me.MaximizedBoundsChanged
       
    End Sub

    Private Sub approve_CheckedChanged(sender As Object, e As EventArgs)
        'If staffpin.Enabled = True Then
        '    staffpin.Enabled = False
        'Else
        '    staffpin.Enabled = True
        'End If
    End Sub

    Private Sub Userid_Validating(sender As Object, e As CancelEventArgs) Handles Userid.Validating

    End Sub
End Class