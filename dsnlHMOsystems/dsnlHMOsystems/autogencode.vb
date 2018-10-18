Imports System.Text
Imports System.Net.Sockets
Imports System.Text.StringBuilder
Imports System.Threading
Imports System.Collections
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Drawing.Printing
Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Configuration
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Globalization
Public Class autogencode
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Public coyid As String
    Public autocodeeid As String
    Private Sub autogencode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

       
       ' loadenrollees()
        getsettingcode()
        LOADHCP()

        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select code1,descr,amount from Ailmenttypedefault order by code1,descr desc"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            assignfolder.DataSource = ds.Tables(0)
            assignfolder.ValueMember = "code1"
            assignfolder.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try

    End Sub
    Sub LOADHCP()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select hcpid,rtrim(Names)  as names from Hcptab order by hcpid"

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
    End Sub
    Sub loadenrollees()

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
        sql = "select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from enrolleetab"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            enrolleeid.DataSource = ds.Tables(0)
            enrolleeid.ValueMember = "enrolleeid"
            enrolleeid.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Public Sub saverec()
        Dim result = MsgBox("Continue Saving Generated Code.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
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

            cSQL = "DELETE FROM Hcptab WHERE" _
            & " hcpid = '" & Me.hcpid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for code: " + Trim(hcpid.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    '  If result = vbNo Then
                    'Me.Close()
                    '   End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        '  
        ' enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,
        Dim gg2 As String = "SELECT codegen,gendate,smsto,enrolleeid,hcpname,email,reason FROM authorisgrid2 where" _
                            & " hcpid = '" & Me.hcpid.Text & "' AND gendate = '" & Format(gendate.Value, "yyyy-MM-dd") & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    If Not r.IsDBNull(6) Then Me.assignfolder.SelectedValue = RTrim(r(6))
                    reasontxt.Text = assignfolder.Text
                    My.Settings.newrec = True
                    enablecontrols()
                    hcpname.Focus()
                    gethcpdetails()
                Else

                    My.Settings.newrec = False
                    enablecontrols()
                    hcpname.Focus()
                    gethcpdetails()
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()

    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database                                                                                                                                                                                                                             dregister,active,NHIS,                                                      LGA,state,country,pmethod,tel,                                                                                                                  email,website,address,                                                                                              glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        'If (Not hcpid.Text = String.Empty) Then
        '    LoadRecord()
        '    loadenrollees()
        'End If

        If (Not hcpid.Text = String.Empty) Then
            MessageBox.Show(Format(gendate.Value, "yyyy-MM-dd"))

            Try
                cSQL = "INSERT INTO authorisgrid2(codegen,gendate,smsto,enrolleeid,hcpname,hcpid,email,reason) VALUES('" & codegen.Text.Trim & "','" & Format(gendate.Value, "yyyy-MM-dd") & "','" & smsto.Text & "','" & enrolleeid.SelectedValue & "','" & RTrim(hcpname.Text) & "','" & RTrim(hcpid.Text) & "','" & RTrim(email.Text) & "','" & RTrim(reasontxt.Text) & "');"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Generated new code for HCP code: " + RTrim(hcpid.Text) + " In " + Me.Text)
                    MessageBox.Show("Code Generated Sucessfully, You can now Send it by mail")
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            UpdategencodeRecord()
            ' clearrec()
        Else
            MessageBox.Show("Empty HCP Code")
        End If
    End Sub
    Public Sub UpdategencodeRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        '"select companyid,autocode from digitsettings
        Try
            Dim cSQL As String = "UPDATE digitsettings SET autocode = '" & Me.autoidd.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Record Save Sucessfully")
                '   saveaudit("record for generate code: " + Trim(hcpid.Text) + " In " + Me.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' clearrec()
    End Sub
    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.hcpid.Focus()
        Me.codegen.Text = ""
        Me.gendate.Value = Now
        Me.smsto.Text = ""
        Me.hcpname.Text = ""
        Me.email.Text = ""
    End Sub
    Private Sub enablecontrols()
        Me.codegen.Enabled = True
        Me.gendate.Enabled = True
        Me.smsto.Enabled = True
        Me.hcpid.Enabled = True
        Me.hcpname.Enabled = True
        Me.email.Enabled = True
    End Sub
    Private Sub disablecontrols()
        Me.codegen.Enabled = False
        Me.gendate.Enabled = False
        Me.smsto.Enabled = False
        Me.hcpid.Enabled = False
        Me.hcpname.Enabled = False
        Me.email.Enabled = False
    End Sub
    Private Sub CODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hcpid.KeyPress
        'If Asc(e.KeyChar) = Keys.Enter Then
        '    If (Not hcpid.Text = String.Empty) Then
        '        LoadRecord()
        '        loadenrollees()
        '    End If
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
            '   Me.statuspoint.Text = ex.Message digitsettings
        Finally
        End Try
    End Sub
    Sub getenrolleelist()

    End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged

        Try
            hcpid.Text = Searchtool.SelectedValue.ToString
            hcpid.Focus()
              loadenrollees()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (Not codegen.Text = String.Empty) Then
            OpenEmail(email.Text)
        End If

    End Sub
    Public Function OpenEmail(ByVal EmailAddress As String, _
    Optional ByVal Subject As String = "Code Generated :", _
    Optional ByVal Body As String = "") _
    As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & "Code Generated : '" & gstring1 & "' ' For Enrollee :' '" & enrolleeid.Text & "'"

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & "This is the Authorisation Code for enrollee '" '& enrolleeid.Text & "'"
        End If
        Try
            System.Diagnostics.Process.Start(sParams)
        Catch
            bAns = False
        End Try

        Return bAns

    End Function
    Sub getsettingcode()
        Dim gg2 As String = "select companyid,autocode from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    coyid = RTrim(r(0))
                    autocodeeid = RTrim(r(1))
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub gethcpdetails()
        Dim gg2 As String = "select hcpid,Names,email,tel from hcptab where" _
                                       & " hcpid = '" & Me.hcpid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    hcpname.Text = RTrim(r(1))
                    email.Text = r(2)
                    smsto.Text = r(3)
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    '061/040216/FCT/0271/S/4000.


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result = MsgBox("Continue .......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)

        If result = vbYes Then
            Try
                Dim currentDate As DateTime = DateTime.Now
                '  If currentDate.Month = 10 AndAlso currentDate.Day = 9 Then
                'MessageBox.Show(currentDate.Day + currentDate.Month + currentDate.Year)
                'MessageBox.Show(autocodeeid)
                Dim autocodeeid2 As String = Str(Val(autocodeeid) + 1)
                autoidd.Text = autocodeeid2
                ' MessageBox.Show("Code Auto Increment : " + autoidd.Text)
                gstring1 = coyid + "/" + LTrim(Str(currentDate.Day)) + LTrim(Str(currentDate.Month)) + LTrim(Str(currentDate.Year)) + "/" + RTrim(hcpid.Text.ToString) + "/" + IIf(pp.Checked, "P", "S") + "/" + LTrim(autocodeeid2)
                codegen.Text = coyid + "/" + LTrim(Str(currentDate.Day)) + LTrim(Str(currentDate.Month)) + LTrim(Str(currentDate.Year)) + "/" + RTrim(hcpid.Text.ToString) + "/" + IIf(pp.Checked, "P", "S") + "/" + LTrim(autocodeeid2)
                saverec()
            Catch ex As Exception
                MDIParent1.statusmsg.Text = ex.Message
            End Try
        End If

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        getsettingcode()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
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

    Private Sub hcpid_Validating(sender As Object, e As CancelEventArgs) Handles hcpid.Validating
  
    End Sub
    Sub loadcodegenhst()


        Dim i2 As Integer
        For i2 = i2 To authorisgrid.RowCount - 1
            authorisgrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT codegen,gendate,smsto,hcpid,email,enrolleeid,reason FROM authorisgrid2 where" _
                             & " gendate >= '" & Format(gendate2.Value, "yyyy-MM-dd") & "' and  gendate < = '" & Format(gendate3.Value, "yyyy-MM-dd") & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    '   MessageBox.Show("Has row")
                    While r.Read
                        Dim row As Integer = authorisgrid.Rows.Add
                        authorisgrid.Rows(row).Cells(0).Value = r(0)
                        authorisgrid.Rows(row).Cells(1).Value = r(1)
                        authorisgrid.Rows(row).Cells(2).Value = r(2)
                        authorisgrid.Rows(row).Cells(3).Value = r(3)
                        authorisgrid.Rows(row).Cells(4).Value = r(4)
                        authorisgrid.Rows(row).Cells(5).Value = r(5)
                        authorisgrid.Rows(row).Cells(6).Value = r(6)
                        authorisgrid.Refresh()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadcodegenhst()
    End Sub

    Private Sub enrolleeid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles enrolleeid.SelectedIndexChanged
       
    End Sub

    Private Sub hcpid_TextChanged(sender As Object, e As EventArgs) Handles hcpid.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        My.Settings.reportsqlstr = "PrintAuthocdeall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print Authourisation code "
        viewreport2.Show()
    End Sub

    Private Sub enrolleeid_Validating(sender As Object, e As CancelEventArgs) Handles enrolleeid.Validating
        If (Not hcpid.Text = String.Empty) Then
            LoadRecord()

        End If
        Dim gg32 As String = "SELECT codegen,gendate,smsto,enrolleeid,hcpname,email FROM authorisgrid2 where" _
                            & " hcpid = '" & Me.hcpid.Text & "' AND gendate = '" & Format(gendate.Value, "yyyy-MM-dd") & "' AND enrolleeid = '" & enrolleeid.SelectedValue.ToString & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg32
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    codegen.Text = r(0)
                    gstring1 = r(0)
                    stat2.Text = "This Code already generated for this enrollee this selected date"
                    hcpid.Text = ""
                Else
                    codegen.Text = ""
                    stat2.Text = ""
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub assignfolder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles assignfolder.SelectedIndexChanged
        reasontxt.Text = assignfolder.Text
    End Sub
End Class