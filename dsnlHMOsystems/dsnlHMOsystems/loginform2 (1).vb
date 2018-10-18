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

Public Class LoginForm2
    Dim OPTRRNEW As String
    Public addnew As Boolean
    Public DSQL As String
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If (userid.Text = String.Empty) Then
            MessageBox.Show("Attn:  userid must not be empty")
            MDIParent1.statusmsg.Text = "Attn:  userid must not be empty"
            userid.Focus()
            Exit Sub
        End If
        If (Not userid.Text = String.Empty) Then
            checusername()
        End If
        If (Not password.Text = String.Empty) Then



            '******************************************
            '   If chkRememberMe.Checked Then
            'Response.Cookies("userid").Expires = DateTime.Now.AddDays(2)
            ' 'Response.Cookies("Password").Expires = DateTime.Now.AddDays(2)
            '  Else
            '  Response.Cookies("userid").Expires = DateTime.Now.AddDays(-1)
            '  Response.Cookies("Password").Expires = DateTime.Now.AddDays(-1)
            '   End If
            '   Response.Cookies("userid").Value = userid.Text.Trim
            '    Response.Cookies("Password").Value = Password.Text.Trim

            '******************************************

            ' checusername()

            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    DSQL = "SELECT userid,password,status,names,appraise,admin,approve FROM useracct WHERE" _
                    & " userid = '" & Me.userid.Text & "'" '  AND scode = '" &  & "'"

                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = DSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Dim r As SqlDataReader = Cd.ExecuteReader
                    If r.HasRows Then
                        r.Read()

                        Dim [source] As String = Me.password.Text
                        Using md5Hash As MD5 = MD5.Create()
                            Dim hash As String = GetMd5Hash(md5Hash, source)
                            If VerifyMd5Hash(md5Hash, [source], Trim(r(1)).ToString) Then
                                ' MessageBox.Show(r(4))
                                ' MessageBox.Show(subjectcbm.SelectedValue)
                                'If Trim(r(4)) = Trim(subjectcbm.SelectedValue) Then
                                My.Settings.loginname = r(3).ToString
                                My.Settings.loginid = r(0).ToString
                                MessageBox.Show("Access Permited")
                                MDIParent1.statusmsg.Text = "Access Permited"
                                welcomeme()
                                '   MDIParent1.statusmsg.Text = "Subject : " + subjectcbm.Text
                                '  My.Settings.sloginid = subjectcbm.SelectedValue.ToString
                                '  My.Settings.sloginname = subjectcbm.Text
                                MDIParent1.Text = "Data Sciences HMO Manager  " & " Date and Time Login: " & My.Computer.Clock.LocalTime '& "       Welcome : " & Trim(My.Settings.loginname) '+ "           Login Subject: " + My.Settings.sloginname
                                MDIParent1.Loadmessagepanel.Visible = False
                                MDIParent1.activatemenus()
                                MDIParent1.Usernames2.Text = Trim(My.Settings.loginname)
                                MDIParent1.MenuStrip.Enabled = True
                                MDIParent1.COYNAME.Visible = True
                                MDIParent1.COYADD1.Visible = True
                                MDIParent1.COYADD2.Visible = True
                                MDIParent1.COYPICS.Visible = True
                               

                                'MDIParent1.runpayapprovaltriger()
                                loadpix()
                                updateonline()

                                saveaudit("Login into the system")
                                MDIParent1.Refresh()

                                If r(2) = True Then
                                    MDIParent1.Backpanel1.Visible = True
                                Else
                                    MDIParent1.Backpanel1.Visible = False
                                End If
                                Me.Close()
                            Else
                                MessageBox.Show("Access Denied")
                            End If
                        End Using

                    Else
                        MessageBox.Show("UserID not exist, Please try again")
                        ' MDIParent1.statusmsg.Text = "Authentication failed. Please try again "
                        Exit Sub
                    End If
                    ' MesgBox(checksave2)
                End Using
            Catch ex As Exception
                ' Me.statuspoint.Text = ex.Message

            End Try
        Else
            MessageBox.Show("Attn:  password must not be empty")
            MDIParent1.statusmsg.Text = "Attn:  password must not be empty"
            password.Focus()
            Exit Sub
        End If
    End Sub
    Sub updateonline()
        Dim cSQL As String = "UPDATE useracct SET" _
            & " staffonline = '" & True & "' " & " WHERE" & " userid = '" & Me.userid.Text & "'"
        Try
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
    Sub welcomeme()
        Dim unamess As String = My.Settings.loginname
        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Your are welcome : " + unamess, frmMSGctrl.MessageType.Information)
    End Sub
    Sub loadpix()
        SPIX2.Text = ""

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT staffid,spicture FROM stafftab WHERE" _
                & " staffid = '" & RTrim(userid.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    SPIX2.Text = Trim(r(1))
                    MDIParent1.staffpix.Image = Image.FromFile(SPIX2.Text)
                    'Me.staffpix = Image.FromFile(strfilename)
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()
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
    End Function 'VerifyMd5Hash

    Sub checusername()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                DSQL = "SELECT staffid,email,concat(SURNAME,firstname) as names FROM STAFFTAB WHERE" _
                & " staffid = '" & Me.userid.Text & "' "

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    ' MDIParent1.statusmsg.Text = " Welcome : " + r(2).ToString
                    My.Settings.loginname = r(2).ToString
                    My.Settings.loginid = r(0).ToString
                    Dim MDI As New MDIParent1
                    '  MDI.Text = "Data Sciences HMO Manager:  " & " Date and Time: " & My.Computer.Clock.LocalTime & "    Welcome :  " & My.Settings.loginname
                    password.Focus()
                    MDI.Refresh()
                Else
                    MessageBox.Show("User ID not Exist")
                    MDIParent1.statusmsg.Text = "User ID not Exist"
                    password.Focus()
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
            ' Me.statuspoint.Text = ex.Message
        End Try
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'Exit Sub
        'MDIParent1.Close()
        End
    End Sub

    Private Sub userid_Leave(sender As Object, e As EventArgs) Handles userid.Leave

    End Sub

    Private Sub userid_Validated(sender As Object, e As EventArgs) Handles userid.Validated
        checusername()
        Dim thisDate As Date
        Dim thisYear As Integer
        thisDate = Now '#2/12/1969#
        thisYear = Year(thisDate)
        year1.Text = thisYear
        '  password.Focus()
    End Sub
    Private Sub userid_Validating(sender As Object, e As CancelEventArgs) Handles userid.Validating
        '   checusername()
    End Sub

    Private Sub LoginForm2_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        MDIParent1.runpayapprovaltriger()
        MDIParent1.runenrolleetrigerexepire()
        MDIParent1.Hcpapproval()
        MDIParent1.runenINVOICEtrigercall()
        MDIParent1.runenleavetrigercall()
        MDIParent1.runClienttrigercall()

        ' runenrolleetrigerexepire()
    End Sub
    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.loginid = ""
        'password.Focus()

        'TODO: This line of code loads data into the 'Codestab._codestab' table. You can move, or remove it, as needed.
        'Me.CodestabTableAdapter2.Fill(Me.Codestab._codestab)
        'FillBy1ToolStripButton.PerformClick()
    End Sub

    'Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
    '    Try
    '        Me.CodestabTableAdapter1.FillBy(Me.Logincodestab.codestab)
    '    Catch ex As System.Exception
    '        System.Windows.Forms.MessageBox.Show(ex.Message)
    '    End Try

    'End Sub
    'Sub activatemenus2()
    '    '  MDIParent1.SystemReportToolStripMenuItem.Enabled = False
    '    Try
    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd As SqlCommand = CCNN.CreateCommand

    '            Cd.CommandText = "SELECT userid,menucode,menuname,available FROM usersmenu WHERE" _
    '            & " userid = '" & My.Settings.loginid & "'"
    '            Cd.CommandType = CommandType.Text
    '            CCNN.Open()
    '            Dim r4 As SqlDataReader = Cd.ExecuteReader
    '            If r4.HasRows = True Then
    '                While r4.Read
    '                    MessageBox.Show(r4(3))
    '                    If r4(2) = "M1" Then
    '                        MDIParent1.SetUpToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                    If r4(2) = "M2" Then
    '                        MDIParent1.OptionsToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                    If r4(2) = "M5" Then
    '                        '     MDIParent1.MarkerManagerToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                    If r4(2) = "M6" Then
    '                        MDIParent1.AuditTrailSettingsToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                    If r4(2) = "M7" Then
    '                        MDIParent1.ImportUtilityToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                    If r4(2) = "M8" Then
    '                        '  MDIParent1.SystemReportToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                    If r4(2) = "M9" Then
    '                        MDIParent1.UserAccountToolStripMenuItem.Enabled = r4(3)
    '                    End If
    '                End While
    '            End If
    '            Me.Refresh()
    '            CCNN.Close()
    '            r4.Close()
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

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




    'Private Sub FillBy1ToolStripButton_Click(sender As Object, e As EventArgs) Handles FillBy1ToolStripButton.Click
    '    Try
    '        Me.CodestabTableAdapter2.FillBy1(Me.Codestab._codestab)
    '    Catch ex As System.Exception
    '        '  System.Windows.Forms.MessageBox.Show(ex.Message)
    '        MDIParent1.statusmsg.Text = "Log"
    '    End Try

    'End Sub



    Private Sub userid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles userid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not userid.Text = String.Empty) Then
                checusername()
            End If
        End If
    End Sub

    Private Sub password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles password.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not password.Text = String.Empty) Then
                logmein()
            End If
        End If
    End Sub
    Sub logmein()
        If (Not password.Text = String.Empty) Then
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    DSQL = "SELECT userid,password,status,names,appraise,admin,approve FROM useracct WHERE" _
                    & " userid = '" & Me.userid.Text & "'" '  AND scode = '" &  & "'"

                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = DSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Dim r As SqlDataReader = Cd.ExecuteReader
                    If r.HasRows Then
                        r.Read()
                        Dim [source] As String = Me.password.Text
                        Using md5Hash As MD5 = MD5.Create()
                            Dim hash As String = GetMd5Hash(md5Hash, source)
                            If VerifyMd5Hash(md5Hash, [source], Trim(r(1)).ToString) Then
                                ' MessageBox.Show(r(4))
                                ' MessageBox.Show(subjectcbm.SelectedValue)
                                'If Trim(r(4)) = Trim(subjectcbm.SelectedValue) Then
                                My.Settings.loginname = r(3).ToString
                                My.Settings.loginid = r(0).ToString
                                MessageBox.Show("Access Permited")
                                MDIParent1.statusmsg.Text = "Access Permited"
                                welcomeme()
                                '   MDIParent1.statusmsg.Text = "Subject : " + subjectcbm.Text
                                '  My.Settings.sloginid = subjectcbm.SelectedValue.ToString
                                '  My.Settings.sloginname = subjectcbm.Text
                                MDIParent1.Text = "Data Sciences HMO Manager  " & " Date and Time Login: " & My.Computer.Clock.LocalTime '& "       Welcome : " & Trim(My.Settings.loginname) '+ "           Login Subject: " + My.Settings.sloginname
                                MDIParent1.Loadmessagepanel.Visible = False
                                MDIParent1.activatemenus()
                                MDIParent1.Usernames2.Text = Trim(My.Settings.loginname)
                                MDIParent1.MenuStrip.Enabled = True
                                MDIParent1.COYNAME.Visible = True
                                MDIParent1.COYADD1.Visible = True
                                MDIParent1.COYADD2.Visible = True
                                MDIParent1.COYPICS.Visible = True
                            
                                loadpix()
                                updateonline()
                                saveaudit("Login into the system")
                                If r(2) = True Then
                                    MDIParent1.Backpanel1.Visible = True
                                Else
                                    MDIParent1.Backpanel1.Visible = False
                                End If
                                MDIParent1.Refresh()
                                Me.Close()

                            Else
                                MessageBox.Show("Access Denied")
                            End If
                        End Using

                    Else
                        MessageBox.Show("Authentication failed, Please try again")
                        ' MDIParent1.statusmsg.Text = "Authentication failed. Please try again "
                        Exit Sub
                    End If
                    ' MesgBox(checksave2)
                End Using
            Catch ex As Exception
                ' Me.statuspoint.Text = ex.Message

            End Try
        Else
            MessageBox.Show("Attn:  password must not be empty")
            MDIParent1.statusmsg.Text = "Attn:  password must not be empty"
            password.Focus()
            Exit Sub
        End If
    End Sub
   
  
    Private Sub userid_TextChanged(sender As Object, e As EventArgs) Handles userid.TextChanged

    End Sub
End Class
