Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class Chartofaccount
    ' Public OPTRR As My.MySettings
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODETXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    ' Dim textbx As New TextBox()
    Public gstring1 As String
    Public addnew As Boolean
    '  Public Sub PerformClick()
    Public codeee As String
    Public descrrr As String
    Private Sub Chartofaccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        sql = "select accode,descriptn from accode order by accode"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            searchacct.DataSource = ds.Tables(0)
            searchacct.ValueMember = "accode"
            searchacct.DisplayMember = "descriptn"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
        'Label14.T
    End Sub

    Sub enablecontrol()
        descriptn.Enabled = True
    End Sub
    Sub disablecontrol()
        descriptn.Enabled = False
    End Sub
    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.accode.Focus()
        Me.descriptn.Text = ""
        OPENBAL.Text = 0.0
        Runingbalance.Text = 0.0
        Me.Refresh()
    End Sub
    Private Sub searchacct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles searchacct.SelectedIndexChanged
        accode.Text = searchacct.SelectedValue.ToString
        If (Not accode.Text = String.Empty) Then
            LoadRecord()
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
                InsertRecord()
            End If

            Me.Refresh()
            accode.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If

    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM accode WHERE" _
            & " accode = '" & Me.accode.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record code: " + Trim(accode.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    If result = vbNo Then
                        Me.Close()
                    End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()


        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT accode, DESCRIPTN, ACTYPE, post_ac, ACLEVEL, acactive, consolid, OPENBAL, ctype2, acctbalcat, Runingbalance FROM accode WHERE" _
                & " accode = '" & accode.Text & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.descriptn.Text = r(1)
                    If RTrim(r(2)) = "G" Then
                        genr.Checked = True
                    Else
                        delt.Checked = True
                    End If
                    If Not r.IsDBNull(3) Then Me.post_ac.SelectedValue = RTrim(r(3))

                    If RTrim(r(4)) = "B" Then
                        BS.Checked = True
                    Else
                        PL.Checked = True
                    End If
                    If r(5) = True Then
                        acactive.Checked = True
                    End If
                    If Not r.IsDBNull(6) Then Me.consolid.SelectedValue = RTrim(r(6))
                    If Not r.IsDBNull(7) Then Me.OPENBAL.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.ctype2.SelectedValue = RTrim(r(8))
                    If Not r.IsDBNull(10) Then Me.Runingbalance.Text = r(10)
                    If RTrim(r(9)) = "A" Then
                        AE.Checked = True
                    Else
                        LE.Checked = True
                    End If

                    My.Settings.newrec = True
                    enablecontrol()
                    descriptn.Focus()
                    '  MessageBox.Show("exist")
                Else
                    My.Settings.newrec = False
                    enablecontrol()
                    descriptn.Focus()
                    '   MessageBox.Show("New")
                End If
                populatecombos()
                popgroup()
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        ' MessageBox.Show("Insert")
        '                                                                                                                                                                             ACLEVEL,acactive,consolid,OPENBAL,ctype2                                                          ,acctbalcat,Runingbalance
        Try
            cSQL = "INSERT INTO accode(accode,DESCRIPTN,ACTYPE,post_ac,ACLEVEL,acactive,consolid,OPENBAL,ctype2,acctbalcat,Runingbalance)" & _
                "VALUES('" & Me.accode.Text & "','" & Me.descriptn.Text & "','" & IIf(genr.Checked = True, "G", "D") & "','" & Me.post_ac.SelectedValue & "','" & IIf(BS.Checked = True, "B", "P") & "','" & acactive.Checked & "','" & Me.consolid.SelectedValue & "','" & OPENBAL.Text & "','" & Me.ctype2.SelectedValue & "','" & IIf(AE.Checked = True, "A", "L") & "','" & CDec(Me.Runingbalance.Text) & "')"
        
            ','" & 0.0 & "'

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using

            saveaudit("Insert New record for code: " + Trim(accode.Text) + " In " + Me.Text)
            MessageBox.Show("Record Save Sucessfully")
            clearrec()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            '  MessageBox.Show("Record Save Sucessfully")
        End Try
    End Sub

    Public Sub UpdateRecord() '****This procedures updates a record from the Database by using the Sql statement

        cSQL = "UPDATE CODESTAB SET" _
        & " DESCRIPTN = '" & Me.descriptn.Text & "' , " & " ACTYPE = '" & IIf(genr.Checked = True, "G", "D") & "', " & " post_ac = '" & Me.post_ac.SelectedValue & "', " & " ACLEVEL = '" & IIf(BS.Checked = True, "B", "P") & "', " & " acactive = '" & acactive.Checked & "', " & " consolid = '" & Me.consolid.SelectedValue & "', " & " OPENBAL = '" & OPENBAL.Text & "', " & " ctype2 = '" & Me.ctype2.SelectedValue & "', " & " acctbalcat = '" & IIf(AE.Checked = True, "A", "L") & "', " & " Runingbalance = '" & CDec(Me.Runingbalance.Text) & "' " & " WHERE" & " rtrim(ACCODE) = '" & RTrim(Me.accode.Text) & "'"
               Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            saveaudit("Update record for code: " + Trim(accode.Text) + " In " + Me.Text)
            MessageBox.Show("Record Update Sucessfully")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        MessageBox.Show("Record Save Sucessfully")
    End Sub

    Private Sub accode_HandleDestroyed(sender As Object, e As EventArgs) Handles accode.HandleDestroyed

    End Sub

    Private Sub accode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles accode.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not accode.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        accode.Text = ""
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Try
    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd As SqlCommand = CCNN.CreateCommand

    '            Cd.CommandText = "SELECT accode, DESCRIPTN, ACTYPE, post_ac, ACLEVEL, acactive, consolid, OPENBAL, ctype2, acctbalcat, Runingbalance FROM accode "
    '            Cd.CommandType = CommandType.Text

    '            CCNN.Open()
    '            Dim r As SqlDataReader = Cd.ExecuteReader
    '            If r.HasRows = True Then
    '                While r.Read()
    '                    ' r.
    '                End While
    '            End If
    '            Me.Refresh()
    '            r.Close()
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim lrevar As New DownupWiz
        lrevar.gstring1 = "SELECT accode, DESCRIPTN, ACTYPE, post_ac  as Header_AcctID, ACLEVEL, acactive, consolid, OPENBAL, ctype2 as Account_Group, acctbalcat, Runingbalance FROM accode order by accode"
        lrevar.ltitle.Text = "Chart of Account Listing"
        lrevar.BindGrid()
        lrevar.Show()
    End Sub

    Sub popgroup()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F26" & "'"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ctype2.DataSource = ds.Tables(0)
            ctype2.ValueMember = "code1"
            ctype2.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Sub populatecombos()
        Dim OPTR2 As String
        OPTR2 = "G"
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select accode,descriptn from accode WHERE" _
                 & " ACTYPE = '" & OPTR2 & "'"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            post_ac.DataSource = ds.Tables(0)
            post_ac.ValueMember = "accode"
            post_ac.DisplayMember = "descriptn"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
        pup2()
    End Sub
    Sub pup2()

        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select accode,descriptn from accode order by accode"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            consolid.DataSource = ds.Tables(0)
            consolid.ValueMember = "accode"
            consolid.DisplayMember = "descriptn"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub accode_TextChanged(sender As Object, e As EventArgs) Handles accode.TextChanged

    End Sub

    Private Sub accode_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles accode.Validating
        If (Not accode.Text = String.Empty) Then
            LoadRecord()
        End If
    End Sub
End Class