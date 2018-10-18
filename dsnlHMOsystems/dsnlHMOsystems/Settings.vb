Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class Settings
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = FolderBD.SelectedPath
            imgaepath.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = FolderBD.SelectedPath
            rptpath.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT autocode,companyid,claimbatchcode,rptpath,photopath,docfolder,imgaepath,invoicepaytrig ,enrolleexptrig,paymentapprovaltrig,birthdaytrig,cursymbol,deprciatn,invoiceno,accountname,bankname,branch,accountno,sortno,autorecieptno,paytcode,payref,portallink,appraisalref,leavref,ugmfees,ContExpirllert,upsource,updestination FROM digitsettings"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(0) Then Me.autocode.Text = r(0)
                    If Not r.IsDBNull(1) Then Me.companyid.Text = r(1)
                    If Not r.IsDBNull(2) Then Me.claimbatchcode.Text = r(2)
                    If Not r.IsDBNull(3) Then Me.rptpath.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.photopath.Text = r(4)
                    If Not r.IsDBNull(5) Then Me.docfolder.Text = r(5)
                    If Not r.IsDBNull(6) Then Me.imgaepath.Text = r(6)
                    If Not r.IsDBNull(7) Then Me.invoicepaytrig.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.enrolleexptrig.Text = r(8)
                    If Not r.IsDBNull(9) Then Me.paymentapprovaltrig.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.birthdaytrig.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.cursymbol.Text = r(11)
                    If Not r.IsDBNull(13) Then Me.invoiceno.Text = r(13)
                    ',accountname,bankname,branch,accountno,sortno
                    If Not r.IsDBNull(14) Then Me.accountname.Text = r(14)
                    If Not r.IsDBNull(15) Then Me.bankname.Text = r(15)
                    If Not r.IsDBNull(16) Then Me.branch.Text = r(16)
                    If Not r.IsDBNull(17) Then Me.accountno.Text = r(17)
                    If Not r.IsDBNull(18) Then Me.sortno.Text = r(18)
                    If Not r.IsDBNull(19) Then Me.autorecieptno.Text = r(19)
                    If Not r.IsDBNull(20) Then Me.paytcode.Text = r(20)
                    If Not r.IsDBNull(21) Then Me.payref.Text = r(21)
                    If Not r.IsDBNull(22) Then Me.portallink.Text = r(22)
                    If Not r.IsDBNull(23) Then Me.appraisalref.Text = r(23)
                    If Not r.IsDBNull(24) Then Me.leavref.Text = r(24)
                    If Not r.IsDBNull(25) Then Me.ugmfees.Text = r(25)
                    If Not r.IsDBNull(26) Then Me.ContExpirllert.Text = r(26)
                    If Not r.IsDBNull(27) Then Me.upsource.Text = r(27)
                    If Not r.IsDBNull(28) Then Me.updestination.Text = r(28)
                    If RTrim(r(1)) = "DPM" Then
                        Me.dpm.Checked = True
                    Else
                        Me.dpy.Checked = True
                    End If
                    Me.Refresh()
                    '  MsgBox(addnew)
                    r.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Public Sub UpdateRecord()
        'autocode,companyid,claimbatchcode,rptpath,photopath,docfolder,imgaepath,invoicepaytrig 
        ',enrolleexptrig,paymentapprovaltrig,birthdaytrig,cursymbol,deprciatn FROM digitsettings"
        Try
            Dim cSQL As String = "UPDATE digitsettings SET autocode = '" & Me.autocode.Text & _
          "',companyid = '" & Me.companyid.Text & _
         "',claimbatchcode = '" & Me.claimbatchcode.Text & _
        "',rptpath = '" & Me.rptpath.Text & _
        "',photopath = '" & Me.photopath.Text & _
        "',docfolder = '" & Me.docfolder.Text & _
        "',imgaepath = '" & Me.imgaepath.Text & _
         "',invoicepaytrig = '" & Me.invoicepaytrig.Text & _
        "',enrolleexptrig = '" & Me.enrolleexptrig.Text & _
        "',paymentapprovaltrig = '" & Me.paymentapprovaltrig.Text & _
        "',birthdaytrig = '" & Me.birthdaytrig.Text & _
        "',invoiceno = '" & Me.invoiceno.Text & _
        "',accountname = '" & Me.accountname.Text & _
        "',bankname = '" & Me.bankname.Text & _
        "',branch = '" & Me.branch.Text & _
        "',accountno = '" & Me.accountno.Text & _
        "',sortno = '" & Me.sortno.Text & _
        "',autorecieptno = '" & Me.autorecieptno.Text & _
        "',cursymbol = '" & Me.cursymbol.Text & _
        "',paytcode = '" & Me.paytcode.Text & _
            "',payref = '" & Me.payref.Text & _
            "',portallink = '" & Me.portallink.Text & _
            "',leavref = '" & Me.leavref.Text & _
            "',ugmfees = '" & Me.ugmfees.Text & _
             "',ContExpirllert = '" & Me.ContExpirllert.Text & _
            "',upsource = '" & Me.upsource.Text & _
            "',updestination = '" & Me.updestination.Text & _
            "',appraisalref = '" & Me.appraisalref.Text & _
            "',deprciatn = '" & IIf(dpm.Checked = True, "DPM", "DPY") & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Updated Sucessfully")
                saveaudit("Update Settings records" + " In " + Me.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        LoadRecord()
        loadtoolscombo()
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        UpdateRecord()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = FolderBD.SelectedPath
            docfolder.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = FolderBD.SelectedPath
            photopath.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        UpdateRecord()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result = MsgBox("Continue to generate Capitation rate for all enrolleeg.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Try

                cSQL = "UPDATE Enrolleetab SET" _
                       & " ugmfees = '" & Me.ugmfees.Text & "' " & " WHERE" & " ugplan = '" & "ugplan1" & "'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Generate Montly Capitation Rate for all NHIS oganisation " + " In " + Me.Text)
                    MessageBox.Show("Capitation Rate Geenerated Sucessfully")
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim result = MsgBox("Continue to generate Care Start and End Date for all enrolleeg.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Try
                cSQL = "UPDATE enrolleetab SET" _
                       & " sdate = '" & Me.enrosdate.Value & "', " & " edate = '" & Me.enroedate.Value & "' " & " WHERE" & " ugplan = '" & "ugplan1" & "'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    MessageBox.Show("Record Updated Sucessfully")
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = FolderBD.SelectedPath
            upsource.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = FolderBD.SelectedPath
            updestination.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim result = MsgBox("Are you sure you want to update destination, Kindly close destination program to continue.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
            If result = vbYes Then
                My.Computer.FileSystem.CopyDirectory(RTrim(upsource.Text), RTrim(updestination.Text), True)
                End
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub loadtoolscombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select ogaid,rtrim(ogaNames)  as names from oganisationtab order by ogaid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ogasearch.DataSource = ds.Tables(0)
            ogasearch.ValueMember = "ogaid"
            ogasearch.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim result = MsgBox("Continue to deactivate the account of this organisation......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Try
                cSQL = "UPDATE enrolleetab SET" _
                       & " active = '" & True & "' " & " WHERE" & " rtrim(ogaid) = '" & ogasearch.SelectedValue & "'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    'MessageBox.Show("Record Updated Sucessfully")
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            Try
                Dim cSQL222 As String = "UPDATE oganisationtab SET" _
                       & " active = '" & True & "' " & " WHERE" & " rtrim(ogaid) = '" & RTrim(ogasearch.SelectedValue) & "'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL222
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    MessageBox.Show("Record Updated Sucessfully")
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class