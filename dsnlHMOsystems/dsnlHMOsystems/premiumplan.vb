

Imports System.Data.SqlClient

Public Class premiumplan
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
    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.CODE.Focus()
        Me.CODE.Text = ""
        amount.Text = "0.00"
        Me.DESCR.Text = ""
        DESCR.Enabled = False
        Me.Refresh()
    End Sub

    Private Sub Codesform_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.CODE.Focus()
    End Sub
    Private Sub Codesform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        amount.Text = "0.00"
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        DESCR.Enabled = False
        ' Me.Text = optname2
        '  Me.code.Text = ""
        Me.CODE.Focus()
        '   Me.descr.Text = ""
        Me.DESCR.Enabled = False
        Me.amount.Enabled = False


        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select code1,descr,amount from premiumplan "
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
        '  Label14.Text = "Saved: Plan "

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
            CODE.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If

    End Sub
    Public Sub delrec()


        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM premiumplan WHERE" _
            & " code1 = '" & Me.CODE.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record code: " + Trim(CODE.Text) + " In " + Me.Text)
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
        DESCR.Text = ""
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT code1, descr,amount,type FROM premiumplan WHERE" _
                & " code1 = '" & CODE.Text & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.Read = True Then
                    Me.DESCR.Text = r(1)
                    Me.amount.Text = FormatNumber(r(2), 2, , , TriState.False) ' r(2)
                    '  Me.type.SelectedText = r(3)
                    'Bank.ClearSelection()
                    'Bank.DataBind()
                    gstring1 = r(3)
                    ' MessageBox.Show(gstring1, "1")
                    Button2.PerformClick()
                    If Not r.IsDBNull(3) Then CheckCodestab.premiumplan(r(3))
                    Me.type.Text = CheckCodestab.descvar
                    type.Refresh()
                    '  If Not r.IsDBNull(3) Then type.Text = r(3)
                    My.Settings.newrec = True
                    enablecontrols()
                    DESCR.Focus()

                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    DESCR.Focus()
                    amount.Text = 0.0
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub enablecontrols()
        DESCR.Enabled = True
        amount.Enabled = True
    End Sub

    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        '   MessageBox.Show("Insert")


        cSQL = "INSERT INTO premiumplan(code1,descr,amount) VALUES('" & Me.CODE.Text & "','" & Me.DESCR.Text & "','" & CDec(amount.Text) & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Record Save Sucessfully")
            saveaudit("Insert New record for code: " + Trim(CODE.Text) + " In " + Me.Text)
            CODE.Text = ""
            DESCR.Text = ""
            amount.Text = 0.0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            '  MessageBox.Show("Record Save Sucessfully")
        End Try
    End Sub

    Public Sub UpdateRecord() '****This procedures updates a record from the Database by using the Sql statement

        '   MessageBox.Show("Update")

        cSQL = "UPDATE premiumplan SET" _
        & " descr = '" & Me.DESCR.Text & "'," & "  amount = '" & CDec(Me.amount.Text) & "'" & " WHERE" & " code1 = '" & Me.CODE.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Record Save Sucessfully")
            saveaudit("Update record for code: " + Trim(CODE.Text) + " In " + Me.Text)
            CODE.Text = ""
            DESCR.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'MessageBox.Show("Record Save Sucessfully")
    End Sub

    

    Private Sub code_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        ' If (Not code.Text = String.Empty) Then
        'LoadRecord()
        '  End If
    End Sub

    Private Sub code_TextChanged(sender As Object, e As EventArgs)
        ' If (Not code.Text = String.Empty) Then
        'LoadRecord()
        '    End If
    End Sub

    Private Sub CODE_GotFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub CODE_KeyPress1(sender As Object, e As KeyPressEventArgs)
       
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

    Private Sub assignfolder_SelectedIndexChanged(sender As Object, e As EventArgs)
        CODE.Text = assignfolder.SelectedValue
        If (Not CODE.Text = String.Empty) Then
            LoadRecord()
        End If
    End Sub

    
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
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

    Private Sub assignfolder_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles assignfolder.SelectedIndexChanged
        CODE.Text = assignfolder.SelectedValue
        If (Not CODE.Text = String.Empty) Then
            LoadRecord()
        End If
    End Sub

    Private Sub CODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CODE.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not CODE.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
    End Sub

    Private Sub CODE_RegionChanged(sender As Object, e As EventArgs) Handles CODE.RegionChanged
        If (Not CODE.Text = String.Empty) Then
            LoadRecord()
        End If
    End Sub

    Private Sub CODE_TextChanged_1(sender As Object, e As EventArgs) Handles CODE.TextChanged
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'My.Settings.searchsqlstm = ""
        gsql = ""
   
        OPTRR = publicvarmodule.OPT
        ' gsql2 = "SELECT Staffid,desc1 FROM codestab"

        gsql = "SELECT code1, descr,type,amount FROM premiumplan"

        Dim sfrm As New searchfrm
        sfrm.ShowDialog()
        CODE.Text = CODDY
        CODE.Refresh()
        Me.Refresh()

        ' Staffid.Text = Stringresult
        If (Not CODE.Text = String.Empty) Then
            CODE.Refresh()
            LoadRecord()
            CODE.Refresh()
        End If
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    MessageBox.Show(gstring1, "2")
    '    type.Text = gstring1
    'End Sub
End Class