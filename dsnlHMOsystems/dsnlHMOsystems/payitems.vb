Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class payitems
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
    'SELECT itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems
    Private Sub payitems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        Searchtool.SelectedItem = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "SELECT ITEMCODE,ITEMDESCR FROM PAYITEMS ORDER BY ITEMCODE"
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
            Searchtool.ValueMember = "ITEMCODE"
            Searchtool.DisplayMember = "ITEMDESCR"
            Searchtool.Refresh()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
        GLCODESET()
    End Sub
    Sub GLCODESET()
        glcode.SelectedItem = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
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
            glcode.DataSource = ds.Tables(0)
            glcode.ValueMember = "accode"
            glcode.DisplayMember = "descriptn"
            glcode.Refresh()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub

    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.itemcode.Focus()
        Me.itemdescr.Text = ""
        Me.allow.Checked = False
        Me.dedu.Checked = False
        Me.basic.Checked = False
        Me.advance.Checked = False
        Me.scheme.Checked = False
        Me.taxable.Checked = False
        Me.pay.Checked = False
        Me.dr.Checked = False
        Me.cr.Checked = False

        Me.glcode.SelectedItem = -1

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
            itemcode.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If

    End Sub
    Public Sub delrec()

        'SELECT itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM payitems WHERE" _
            & " itemcode = '" & Me.itemcode.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for Payitem code: " + Trim(itemcode.Text) + " In " + Me.Text)
                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception


            End Try
        End If

    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems WHERE" _
                & " itemcode = '" & itemcode.Text & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.itemdescr.Text = r(1)
                    If Not r.IsDBNull(2) Then
                        If Trim(r(2)) = "Basic" Then
                            basic.Checked = True
                        End If
                        If Trim(r(2)) = "Allow" Then
                            allow.Checked = True
                        End If
                        If Trim(r(2)) = "Dedu" Then
                            dedu.Checked = True
                        End If
                    End If
                    If r(3) = True Then
                        advance.Checked = True
                    End If
                    If r(4) = True Then
                        scheme.Checked = True
                    End If
                    If r(5) = True Then
                        taxable.Checked = True
                    End If
                    If Not r.IsDBNull(6) Then Me.glcode.SelectedValue = RTrim(r(6))
                    If Trim(r(7)) = "dr" Then
                        dr.Checked = True
                    End If
                    If Trim(r(7)) = "cr" Then
                        cr.Checked = True
                    End If
                    If r(8) = True Then
                        pay.Checked = True
                    End If
                    itemcode.Focus()
                    My.Settings.newrec = True
                Else
                    My.Settings.newrec = False
                    itemcode.Focus()
                    '   MessageBox.Show("New")
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
   
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        '  MessageBox.Show("Insert")
        Dim itype As String
        Dim acm As String
        If basic.Checked = True Then
            itype = "Basic"
        End If
        If allow.Checked = True Then
            itype = "Allow"
        End If
        If dedu.Checked = True Then
            itype = "Dedu"
        End If
        If dr.Checked = True Then
            acm = "dr"
        End If
        If cr.Checked = True Then
            acm = "cr"
        End If


        'itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems
        cSQL = "INSERT INTO payitems(itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay)" & _
                                "VALUES('" & Me.itemcode.Text & "','" & Me.itemdescr.Text & "','" & itype & "','" & advance.Checked & "','" & scheme.Checked & "','" & taxable.Checked & "','" & RTrim(glcode.SelectedValue) & "','" & acm & "','" & pay.Checked & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Insert new record for Pay Item code: " + Trim(itemcode.Text) + " In " + Me.Text)
                itemcode.Text = ""
                clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        Dim itype As String
        Dim acm As String
        If basic.Checked = True Then
            itype = "Basic"
        End If
        If allow.Checked = True Then
            itype = "Allow"
        End If
        If dedu.Checked = True Then
            itype = "Dedu"
        End If
        If dr.Checked = True Then
            acm = "dr"
        End If
        If cr.Checked = True Then
            acm = "cr"
        End If
        Try
            ' itemcode,itemdescr,itemtype,advance,scheme,taxable,glcode,acmode,pay FROM payitems
            cSQL = "UPDATE payitems SET" _
                   & " itemdescr = '" & Me.itemdescr.Text & "', " & " itemtype = '" & itype & "', " & " advance = '" & advance.Checked & "', " & " scheme = '" & Me.scheme.Checked & "', " & " taxable = '" & taxable.Checked & "', " & " glcode = '" & RTrim(glcode.SelectedValue) & "'," & " acmode = '" & acm & "', " & " pay = '" & pay.Checked & "' " & " WHERE" & " itemcode = '" & Me.itemcode.Text & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Update record for itemcode: " + Trim(itemcode.Text) + " In " + Me.Text)
                itemcode.Text = ""
                clearrec()
                ' DESCR.Text = ""
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'MessageBox.Show("Record Save Sucessfully")
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
    Private Sub itemcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles itemcode.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not itemcode.Text = String.Empty) Then
                LoadRecord()
                itemdescr.Focus()
            End If
        End If
    End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        Try
            itemcode.Text = Searchtool.SelectedValue.ToString
            itemdescr.Text = Searchtool.Text
            LoadRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub itemcode_TextChanged(sender As Object, e As EventArgs) Handles itemcode.TextChanged

    End Sub
End Class