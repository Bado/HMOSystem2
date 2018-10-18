Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Imports System.IO

'Imports System.Drawing.Image
'Imports System.Web.UI.WebControls
Public Class company
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

    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.code1.Focus()
        Me.TextBox1.Text = ""
        Me.address.Text = ""
        Me.address2.Text = ""
        Me.email.Text = ""
        Me.web.Text = ""
        Me.tel.Text = ""
        Me.picpath.Text = ""
        PictureBox1.Image = Nothing
        Me.TextBox1.Enabled = False
        Me.address.Enabled = False
        Me.address2.Enabled = False
        Me.web.Enabled = False
        Me.email.Enabled = False
        Me.tel.Enabled = False
        Me.Refresh()
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
            code1.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If

    End Sub
    Public Sub delrec()


        'Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        'If result = vbYes Then

        '    cSQL = "DELETE FROM companytab WHERE" _
        '    & " CODE1 = '" & Me.code1.Text & "'"
        '    Try
        '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '            Dim Cd As SqlCommand = CCNN.CreateCommand

        '            Cd.CommandType = CommandType.Text
        '            Cd.CommandText = cSQL

        '            CCNN.Open()
        '            Cd.ExecuteNonQuery()
        '            saveaudit("Delete record for code: " + Trim(code1.Text) + " In " + Me.Text)
        '            clearrec()
        '            '  If result = vbNo Then
        '            'Me.Close()
        '            '   End If
        '            Me.Refresh()
        '        End Using
        '    Catch ex As Exception


        '    End Try
        'End If
        MessageBox.Show("Update Data instead")
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT CODE1,company,address,web,tel,email,picpath,address2 FROM companytab WHERE" _
                & " CODE1 = '" & code1.Text & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Me.TextBox1.Text = r(1)
                    Me.address.Text = r(2)
                    Me.web.Text = r(3)
                    Me.email.Text = r(5)
                    Me.tel.Text = r(4)
                    'Me.picpath.Text = r(6)
                    Me.address2.Text = r(7)
                    '   PictureBox1.Image = Image.FromFile(Me.picpath.Text)
                    My.Settings.newrec = True
                    enablecontrols()
                    TextBox1.Focus()
                    MessageBox.Show("exist")
                    loadpictures()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    TextBox1.Focus()
                    '   MessageBox.Show("New")
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Sub loadpictures()
        MessageBox.Show("loading pix")
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)
                cn.Open()
                Dim sql As String = "Select * from companytab where code1 = " + code1.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    Dim data As Byte() = DirectCast(dr("picpath"), Byte())
                    Dim ms As New MemoryStream(data)
                    PictureBox1.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '  Me.statuspoint.Text = ex.Message
        Finally
        End Try
    End Sub
    Private Sub enablecontrols()
        Me.TextBox1.Enabled = True
        Me.address.Enabled = True
        Me.address2.Enabled = True
        Me.web.Enabled = True
        Me.email.Enabled = True
        Me.tel.Enabled = True

    End Sub

    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        '  MessageBox.Show("Insert")


        'cSQL = "INSERT INTO companytab(CODE1,company,address,web,tel.email,picpath) VALUES('" & Me.code1.Text & "','" & Me.TextBox1.Text & "','" & Me.address.Text & "','" & Me.web.Text & "','" & Me.tel.Text & "','" & Me.email.Text & "','" & Me.picpath.Text & "')"
        cSQL = "INSERT INTO companytab(code1,company,email,web,Address,tel) VALUES('" & Me.code1.Text & "','" & Me.TextBox1.Text & "','" & Me.email.Text & "','" & Me.web.Text & "','" & Me.address.Text & "','" & Me.tel.Text & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Insert new record for code: " + Trim(code1.Text) + " In " + Me.Text)
                updateimage()
                'clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MessageBox.Show("Record Save Sucessfully")
        End Try
    End Sub

    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        '
        '   MessageBox.Show("Update")
        Try

            cSQL = "UPDATE companytab SET" _
                   & " company = '" & Me.TextBox1.Text & "', " & " email = '" & Me.email.Text & "', " & " web = '" & Me.web.Text & "', " & " Address = '" & Me.address.Text & "', " & " Address2 = '" & Me.address2.Text & "'," & " tel = '" & Me.tel.Text & "' " & " WHERE" & " code1 = '" & Me.code1.Text & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Update record for code: " + Trim(code1.Text) + " In " + Me.Text)
                'code1.Text = ""
                'clearrec()
                ' DESCR.Text = ""
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        updateimage()
        'MessageBox.Show("Record Save Sucessfully")
    End Sub
    Sub updateimage()
        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)", " & " picpath = '" & Me.picpath.Text & "'
                Dim sql As String = "UPDATE companytab SET picpath = @picpath3 where code1 = '" & code1.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@picpath3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '   MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)", " & " picpath = '" & Me.picpath.Text & "'
                Dim sql As String = "UPDATE companytab SET backgroundimg = @backgroundimg3 where code1 = '" & code1.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@backgroundimg3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '   MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try



    End Sub
    Private Sub code1_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        
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

    Private Sub company_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub company_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130


    End Sub

    Private Sub SBUTTON_Click(sender As Object, e As EventArgs)

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

    Private Sub code1_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles code1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not code1.Text = String.Empty) Then

                LoadRecord()
            End If
        End If
    End Sub

    Private Sub code1_TextChanged(sender As Object, e As EventArgs) Handles code1.TextChanged

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strfilename As String = ""
        OpenFD.InitialDirectory = "C:\"
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            PictureBox1.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        picpath.Text = strfilename
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class