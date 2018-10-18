

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

Public Class changepassword
    Dim OPTR As New MDIParent1
    Dim optname As New MDIParent1
    Dim optname2 As String
    Public fsave As String
    Public OPTRR As String
    Public cSQL As String
    Public addnew As Boolean
    Dim DSQL As String
    Dim x(15) As Short
    Dim y As Short
    Public gstring1 As String
    Public deptcombo As String

    Public Sub checusername()
        '   MessageBox.Show(My.Settings.loginid)
        Dim passidd As String = My.Settings.loginid

        '  MessageBox.Show(passidd)
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                DSQL = "SELECT userid,password,email,names FROM useracct WHERE" _
                & " userid = '" & Trim(passidd) & "' "

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    If r.Read = True Then
                        username.Text = " Welcome :  " + r(3).ToString
                        Dim [source] As String = Me.oldpass.Text
                        Using md5Hash As MD5 = MD5.Create()
                            Dim hash As String = GetMd5Hash(md5Hash, source)
                            If VerifyMd5Hash(md5Hash, [source], Trim(r(1)).ToString) Then
                                newpasswordd.Focus()
                            Else
                                MessageBox.Show("Old Password Not Correct")
                                oldpass.Focus()
                            End If
                        End Using
                    Else
                        MessageBox.Show("User ID not Exist")
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("User pass not Exist")
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
            ' Me.statuspoint.Text = ex.Message
        End Try
    End Sub
    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

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

    End Function 'GetMd5Hash
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
    ' Verify a hash against a string. 
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input. 

        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes. 
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
        ' Response.Redirect("~/AdminPanel.aspx")
    End Function '
    Public Sub checksamepass()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Not newpasswordd.Text = String.Empty) Then
            If newpasswordd.Text <> password.Text Then
                MessageBox.Show("Confirm Password not equal")
                newpasswordd.Focus()
                Exit Sub
            End If
        End If
        ' checksamepass()
        Dim passidd As String = My.Settings.loginid
        Dim hash As String = GetMd5Hash(password.Text.ToString)

        Dim sumSQL As String = "UPDATE useracct SET" _
    & " password = '" & hash & "' WHERE" & " userid = '" & passidd & "'"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                MessageBox.Show("Password Change Sucessfully")
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub oldpass_TextChanged(sender As Object, e As EventArgs) Handles oldpass.TextChanged

    End Sub

    Private Sub oldpass_Validating(sender As Object, e As CancelEventArgs) Handles oldpass.Validating
        If (Not oldpass.Text = String.Empty) Then
            checusername()
        End If
    End Sub

    Private Sub changepassword_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub changepassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Not oldpass.Text = String.Empty) Then
            checusername()
        End If
    End Sub

    Private Sub password_TextChanged(sender As Object, e As EventArgs) Handles password.TextChanged

    End Sub
End Class
