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
Imports System.IO

Public Class Aboutfrm2
    Dim scrolledString As String = "                    Data Sciences HMO Manager -- a Data Sciences Package"
    Dim myStrings(scrolledString.Length - 1) As String
    Dim position As Integer = -1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Aboutfrm2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        Dim labelSize As Size

        labelSize.Width = 15000

        labelSize.Height = 13

        Label7.MinimumSize = labelSize

        Label7.MaximumSize = labelSize

        Label7.Size = labelSize



        Call ScrollType2(scrolledString)

        'Make this value smaller say as low as 25 for

        'a faster scroll effect.

        Timer1.Interval = 200

        Timer1.Enabled = True

        Timer1.Start()

        Try
            Using CCNN As New SqlClient.SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlClient.SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT company FROM companytab"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlClient.SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    coyto.Text = Trim(r(0))
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()

    End Sub
    Private Sub ScrollType1(ByVal someString As String)

        For index As Integer = 0 To UBound(myStrings)

            Dim workedString As String = ""

            workedString = someString.Substring(index)

            myStrings(index) = workedString

        Next

    End Sub



    Private Sub ScrollType2(ByVal someString As String)

        For index As Integer = 0 To UBound(myStrings)

            Dim workedString As String = ""

            workedString = someString.Substring(index) & " " & someString.Substring(0, index)

            myStrings(index) = workedString

        Next

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        position += 1

        Dim testString As String

        testString = myStrings(position)

        Label7.Text = testString

        'You could add this line to scroll the FORM title text too!!

        'Me.Text = testString

        If position = UBound(myStrings) Then position = -1

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            PictureBox2.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        picpath.Text = strfilename
        saveandapply()
    End Sub

    Sub saveandapply()

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)", " & " picpath = '" & Me.picpath.Text & "'
                Dim sql As String = "UPDATE companytab SET backgroundimg = @picpath3 where code1 = '" & My.Settings.companyid & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@picpath3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                applynow()
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try
        'Try

        '    Dim cSQL As String = "UPDATE companytab SET" _
        '          & " backgroundimg = '" & Me.picpath.Text & "' " & " WHERE" & " code1 = '" & My.Settings.companyid & "'"

        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd As SqlCommand = CCNN.CreateCommand
        '        Cd.CommandText = cSQL
        '        Cd.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Cd.ExecuteNonQuery()
        '        applynow()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Sub applynow()
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)
                cn.Open()
                Dim sql As String = "SELECT company,address,address2,picpath,code1,backgroundimg FROM companytab"
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("backgroundimg"), Byte())
                    Dim ms As New MemoryStream(data)
                    MDIParent1.BackgroundImage = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try


        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd As SqlCommand = CCNN.CreateCommand
        '        Cd.CommandText = "SELECT company,address,address2,picpath,code1,backgroundimg FROM companytab"
        '        Cd.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Dim r As SqlDataReader = Cd.ExecuteReader
        '        If r.HasRows Then
        '            r.Read()
        '            MDIParent1.BackgroundImage = Image.FromFile(Trim(r(5)))
        '        End If
        '        Me.Refresh()
        '        r.Close()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'Me.Refresh()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub
End Class