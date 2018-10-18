Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
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
Imports System.Text
Imports System.IO

Public Class Staffinfo
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Public inc As Integer
    Public MaxRows As Integer

    Private Sub Staffinfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        familygrid.EnableHeadersVisualStyles = False
        familygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        familygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        familygrid.ColumnHeadersHeight = 30
        familygrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        qualification.EnableHeadersVisualStyles = False
        qualification.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        qualification.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        qualification.ColumnHeadersHeight = 30
        qualification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        'Try
        '    Dim col3 As New CalendarColumn()
        '    col3.DataPropertyName = "dsubmitted"
        '    col3.HeaderText = "Date_Submitted"
        '    Dim loc3 As Integer =
        '    qualification.Columns.IndexOf(qualification.Columns("dsubmitted"))
        '    qualification.Columns.RemoveAt(loc3)
        '    qualification.Columns.Insert(loc3, col3)
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = "Can not open connection to ! "
        'End Try

        loadbankcombo()
        disablecontrols()
        loadstaffPFAcombo()
        loadstaTEcombo()
        loadlgacombo()
        loadCOUNTRYcombo()
        loadDEPTcombo()
        loadPOSITIONcombo()
        loadglevelcombo()
        loadbrancombo()
        loadcatcombo()
        loadstaffsearchcombo()
        loadreasoncombo()
    End Sub
    Private Sub stopped_CheckedChanged(sender As Object, e As EventArgs) Handles suspended.CheckedChanged
        If suspended.Checked Then
            stoplbl.Visible = True
            suspendeddate.Visible = True
            reason.Visible = True
            rreason.Visible = True
        Else
            stoplbl.Visible = False
            suspendeddate.Visible = False
            reason.Visible = False
            rreason.Visible = False
        End If
    End Sub

    Public Sub saverec()
        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            If My.Settings.newrec = True Then
                UpdateRecord()
            End If
            If My.Settings.newrec = False Then
                InsertRecord()
            End If

            Me.Refresh()
            staffid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM stafftab WHERE" _
            & " staffid = '" & Me.staffid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record of staffID: " + Trim(staffid.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
            'qualification nextofkin
            Dim cSQL2 As String = "DELETE FROM qualification WHERE" _
                        & " staffid = '" & Me.staffid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try

            Dim cSQL3 As String = "DELETE FROM nextofkin WHERE" _
                                   & " staffid = '" & Me.staffid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL3
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try

        End If
        '   MessageBox.Show("Update Data instead")
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        ' staffid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,
        Dim index As Integer
        Dim index2 As Integer
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT staffid,surname,firstname,othernames,title,sex,mstatus,dengage,dofb,age,tel,email,pofb,natid,address ,pfa,lga ,state,country,cat,position,glevel ,bankid,branch,dept,accountid,accttype,scode,suspended, leavedays, leavebal,officebranch,lpromotedd,suspendeddate,reason FROM stafftab WHERE" _
                & " rtrim(staffid) = '" & RTrim(staffid.Text) & "'"

                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.Surname.Text = RTrim(r(1))
                    If Not r.IsDBNull(2) Then Me.Firstname.Text = r(2)
                    If Not r.IsDBNull(3) Then Me.othernames.Text = r(3)
                    If Not r.IsDBNull(4) Then
                        index = title.FindString(RTrim(r(4)))
                        title.SelectedIndex = index
                    End If
                    If Not r.IsDBNull(5) Then
                        index = sex.FindString(RTrim(r(5)))
                        sex.SelectedIndex = index
                    End If

                    If Not r.IsDBNull(6) Then
                        index2 = mstatus.FindString(RTrim(r(6)))
                        mstatus.SelectedIndex = index2
                    End If
                    If Not r.IsDBNull(7) Then Me.dengage.Value = r(7)
                    If Not r.IsDBNull(8) Then Me.dofb.Value = r(8)
                    If Not r.IsDBNull(9) Then Me.age.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.tel.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.email.Text = r(11)
                    If Not r.IsDBNull(12) Then Me.pofb.Text = r(12)
                    If Not r.IsDBNull(13) Then Me.natid.Text = r(13)
                    If Not r.IsDBNull(14) Then Me.address.Text = r(14)
                    If Not r.IsDBNull(15) Then Me.pfa.SelectedValue = RTrim(r(15))
                    If Not r.IsDBNull(16) Then Me.lga.SelectedValue = RTrim(r(16))
                    If Not r.IsDBNull(17) Then Me.state.SelectedValue = RTrim(r(17)) ''
                    If Not r.IsDBNull(18) Then Me.country.SelectedValue = RTrim(r(18)) ''
                    If Not r.IsDBNull(19) Then Me.cat.SelectedValue = RTrim(r(19))
                    If Not r.IsDBNull(20) Then Me.position.SelectedValue = RTrim(r(20))
                    If Not r.IsDBNull(21) Then Me.glevel.SelectedValue = RTrim(r(21))
                    If Not r.IsDBNull(22) Then Me.bankid.SelectedValue = r(22)
                    If Not r.IsDBNull(23) Then Me.branch.Text = r(23)
                    If Not r.IsDBNull(24) Then Me.dept.SelectedValue = r(24)
                    If Not r.IsDBNull(25) Then Me.accountid.Text = r(25)
                    If Not r.IsDBNull(26) Then Me.accttype.SelectedValue = RTrim(r(26))
                    If Not r.IsDBNull(27) Then Me.scode.Text = r(27)
                    If r(28) = True Then
                        If Not r.IsDBNull(28) Then Me.suspended.Checked = True
                    End If
                    If Not r.IsDBNull(29) Then leavedays.Text = r(29)
                    If Not r.IsDBNull(30) Then Me.leavebal.Text = r(30)
                    If Not r.IsDBNull(31) Then Me.officebranch.Text = r(31)
                    If Not r.IsDBNull(32) Then Me.lpromotedd.Value = r(32)
                    If Not r.IsDBNull(33) Then Me.suspendeddate.Value = r(33)
                    If Not r.IsDBNull(34) Then Me.reason.SelectedValue = RTrim(r(34))
                    My.Settings.newrec = True
                    enablecontrols()
                    Surname.Focus()
                    loadpix()
                    loadpictures()
                    TabControl1.Refresh()
                    loadfamilygriddata()
                    loadquliriddata()
                    Surname.Focus()
                    Me.Refresh()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    Surname.Focus()
                End If
                Me.Refresh()
                r.Close()
            End Using
            staffid.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        MessageBox.Show(Format(dofb.Value, "yyyy-MM-dd"))
        Dim spcss As String = My.Settings.imgaepath + "\" + "spics.jpg"
        Try
            cSQL = "INSERT INTO stafftab(staffid,surname,firstname,othernames,title,sex,mstatus,dengage,dofb,age,tel,email,pofb,natid,address ,pfa,lga ,state,country,cat,position,glevel ,bankid,branch,dept,accountid,accttype,scode,suspended, leavedays, leavebal,officebranch,lpromotedd,suspendeddate,ppicture,spicture,childpix1,childpix2,childpix3,childpix4,reason) VALUES('" & staffid.Text.Trim & "','" & Surname.Text.Trim & "','" & Firstname.Text.Trim & "','" & othernames.Text.Trim & "','" & RTrim(title.Text) & "','" & RTrim(sex.Text) & "','" & RTrim(mstatus.Text) & "','" & Format(dengage.Value, "yyyy-MM-dd") & "','" & Format(dofb.Value, "yyyy-MM-dd") & "','" & age.Text & "','" & tel.Text.Trim & "','" & email.Text & "','" & pofb.Text & "','" & natid.Text & "','" & address.Text & "','" & RTrim(pfa.SelectedValue) & "','" & lga.SelectedValue & "','" & state.SelectedValue & "','" & RTrim(country.SelectedValue) & "','" & cat.SelectedValue & "','" & position.SelectedValue & "','" & glevel.SelectedValue & "','" & bankid.SelectedValue & "','" & branch.Text & "','" & dept.SelectedValue & "','" & accountid.Text & "','" & accttype.Text & "','" & RTrim(scode.Text) & "','" & suspended.Checked & "','" & leavedays.Text & "','" & leavebal.Text & "','" & officebranch.SelectedValue & "','" & Format(lpromotedd.Value, "yyyy-MM-dd") & "','" & Format(suspendeddate.Value, "yyyy-MM-dd") & "','" & IIf(ppicture.Text.Trim = "", spcss, ppicture.Text.Trim) & "','" & IIf(spicture.Text.Trim = "", spcss, spicture.Text.Trim) & "','" & IIf(childpix1.Text.Trim = "", spcss, childpix1.Text.Trim) & "','" & IIf(childpix2.Text.Trim = "", spcss, childpix2.Text.Trim) & "','" & IIf(childpix3.Text.Trim = "", spcss, childpix3.Text.Trim) & "','" & IIf(childpix4.Text.Trim = "", spcss, childpix4.Text.Trim) & "','" & reason.SelectedValue & "');"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Insert new record for Staffid : " + RTrim(staffid.Text) + " In " + Me.Text)
                MessageBox.Show("Record Save Sucessfully")
                '  staffid.Text = ""
                'clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '   savenewfamily()
        updateimage()
        InsertRecordqualification()
        InsertRecordfamily()
        clearrec()
        loadstaffsearchcombo()
    End Sub
    Sub updateimage()
        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE stafftab SET ppicture = @ppicture3 where staffid = '" & staffid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                ppicture1.Image.Save(ms, ppicture1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@ppicture3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE stafftab SET spicture = @spicture3 where staffid = '" & staffid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                spicture1.Image.Save(ms, spicture1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@spicture3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try





    End Sub
    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        MessageBox.Show(Format(dofb.Value, "yyyy-MM-dd"))
        Try
            Dim cSQL3 As String = "UPDATE stafftab SET surname = '" & Me.Surname.Text & _
               "',firstname = '" & Me.Firstname.Text & _
          "',othernames = '" & Me.othernames.Text & _
             "',title = '" & RTrim(Me.title.Text) & _
           "',sex = '" & RTrim(sex.Text) & _
            "',mstatus = '" & RTrim(mstatus.Text) & _
            "',dengage = '" & Format(dengage.Value, "yyyy-MM-dd") & _
            "',age = '" & Me.age.Text & _
            "',dofb = '" & Format(dofb.Value, "yyyy-MM-dd") & _
           "' ,tel = '" & Me.tel.Text & _
           "' ,email = '" & email.Text & _
           "' ,pofb = '" & Me.pofb.Text & _
            "',natid = '" & natid.Text & _
            "',address = '" & Me.address.Text & _
            "',pfa = '" & pfa.SelectedValue & _
            "',lga = '" & lga.SelectedValue & _
            "',state = '" & state.SelectedValue & _
            "',country = '" & Me.country.SelectedValue & _
            "',cat = '" & cat.SelectedValue & _
        "',position = '" & position.SelectedValue & _
            "',glevel = '" & glevel.SelectedValue & _
            "',bankid = '" & Me.bankid.SelectedValue & _
            "',branch = '" & branch.Text & _
         "',dept = '" & dept.SelectedValue & _
         "',accountid = '" & accountid.Text & _
         "',accttype = '" & accttype.Text & _
         "',scode = '" & scode.Text & _
         "',suspended = '" & suspended.Checked & _
        "',leavedays = '" & leavedays.Text & _
        "',leavebal = '" & leavebal.Text & _
        "',officebranch = '" & officebranch.SelectedValue & _
        "',reason = '" & reason.SelectedValue & _
        "',lpromotedd = '" & Format(lpromotedd.Value, "yyyy-MM-dd") & _
        "',suspendeddate = '" & Format(suspendeddate.Value, "yyyy-MM-dd") & _
            "',ppicture = '" & RTrim(ppicture.Text) & _
            "',spicture = '" & RTrim(spicture.Text) & _
            "',childpix1 = '" & RTrim(childpix1.Text) & _
           "' ,childpix2 = '" & RTrim(childpix2.Text) & _
           "' ,childpix3 = '" & RTrim(childpix3.Text) & _
               "',childpix4 = '" & RTrim(childpix4.Text) & "' where  staffid= '" & staffid.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL3
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Updated Sucessfully")
                saveaudit("Update record for StaffID: " + Trim(staffid.Text) + " In " + Me.Text)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        updateimage()
        InsertRecordqualification()
        InsertRecordfamily()
        clearrec()
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


    Public Sub clearrec()
        'MsgBox("CLEAR")
        staffid.Focus()
        Surname.Text = ""
        Firstname.Text = ""
        othernames.Text = ""
        dengage.Value = Now
        dofb.Value = Now
        age.Text = ""
        tel.Text = ""
        email.Text = ""
        pofb.Text = ""
        natid.Text = ""
        address.Text = ""
        branch.Text = ""
        accountid.Text = ""
        scode.Text = ""
        suspended.Checked = False
        leavedays.Text = 0.0
        leavebal.Text = 0.0
        officebranch.Text = ""
        lpromotedd.Value = Now
        suspendeddate.Value = Now
        Clearpix()
        Dim i As Integer
        For i = i To familygrid.RowCount - 1
            familygrid.Rows.Clear()
        Next
        Dim i2 As Integer
        For i2 = i2 To qualification.RowCount - 1
            qualification.Rows.Clear()
        Next
    End Sub
    Sub enablecontrols()
        Surname.Enabled = True
        Firstname.Enabled = True
        othernames.Enabled = True
        dengage.Enabled = True
        dofb.Enabled = True
        age.Enabled = True
        tel.Enabled = True
        email.Enabled = True
        pofb.Enabled = True
        natid.Enabled = True
        address.Enabled = True
        branch.Enabled = True
        accountid.Enabled = True
        scode.Enabled = True
        leavedays.Enabled = True
        leavebal.Enabled = True
        officebranch.Enabled = True
        lpromotedd.Enabled = True
        suspendeddate.Enabled = True
    End Sub
    Sub disablecontrols()
        Surname.Enabled = False
        Firstname.Enabled = False
        othernames.Enabled = False
        dengage.Enabled = False
        dofb.Enabled = False
        age.Enabled = False
        tel.Enabled = False
        email.Enabled = False
        pofb.Enabled = False
        natid.Enabled = False
        address.Enabled = False
        branch.Enabled = False
        accountid.Enabled = False
        scode.Enabled = False
        leavedays.Enabled = False
        leavebal.Enabled = False
        officebranch.Enabled = False
        lpromotedd.Enabled = False
        suspendeddate.Enabled = False
    End Sub
    Sub Clearpix()
        ppicture1.Image = Nothing
        spicture1.Image = Nothing
        childpix1p.Image = Nothing
        childpix2p.Image = Nothing
        childpix3p.Image = Nothing
        childpix4p.Image = Nothing
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles ppicture1.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            ppicture1.Image = Image.FromFile(strfilename)

            OpenFD.Reset()
        End If
        ppicture.Text = strfilename
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles spicture1.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            spicture1.Image = Image.FromFile(strfilename)

            OpenFD.Reset()
        End If
        spicture.Text = strfilename
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles childpix1p.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix1p.Image = Image.FromFile(strfilename)

            OpenFD.Reset()
        End If
        childpix1.Text = strfilename
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles childpix2p.Click
        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix2p.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        childpix2.Text = strfilename
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles childpix3p.Click
        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix3p.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        childpix3.Text = strfilename
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles childpix4p.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix4p.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        childpix4.Text = strfilename
    End Sub
    Sub loadpix()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = " Select staffid,ppicture,spicture,childpix1,childpix2,childpix3,childpix4 FROM stafftab WHERE" _
                & " rtrim(staffid) = '" & RTrim(staffid.Text) & "'"

                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.ppicture.Text = r(1)
                    If Not r.IsDBNull(2) Then Me.spicture.Text = r(2)
                    If Not r.IsDBNull(3) Then Me.childpix1.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.childpix2.Text = r(4)
                    If Not r.IsDBNull(5) Then Me.childpix3.Text = r(5)
                    If Not r.IsDBNull(6) Then Me.childpix4.Text = r(6)
                    ppicture1.Image = Image.FromFile(RTrim(Me.ppicture.Text))
                    spicture1.Image = Image.FromFile(RTrim(Me.spicture.Text))
                    childpix1p.Image = Image.FromFile(RTrim(Me.childpix1.Text))
                    childpix2p.Image = Image.FromFile(RTrim(Me.childpix2.Text))
                    childpix3p.Image = Image.FromFile(RTrim(Me.childpix3.Text))
                    childpix4p.Image = Image.FromFile(RTrim(Me.childpix4.Text))
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub staffid_Click(sender As Object, e As EventArgs) Handles staffid.Click

    End Sub


    Private Sub staffid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles staffid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not staffid.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
    End Sub
    Sub loadstaffsearchcombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from stafftab where staffid != '" & "ADMIN" & "' order by staffid"

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
            Searchtool.ValueMember = "staffid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadreasoncombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "K31" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            reason.DataSource = ds.Tables(0)
            reason.ValueMember = "code1"
            reason.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB PFA ! "
        End Try
    End Sub
    Sub loadstaffPFAcombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F9" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            pfa.DataSource = ds.Tables(0)
            pfa.ValueMember = "code1"
            pfa.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB PFA ! "
        End Try
    End Sub
    Sub loadstaTEcombo()
        '  Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F1" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            state.DataSource = ds.Tables(0)
            state.ValueMember = "code1"
            state.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB STATE ! "
        End Try
    End Sub
    Sub loadlgacombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F2" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            lga.DataSource = ds.Tables(0)
            lga.ValueMember = "code1"
            lga.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB LGA ! "
        End Try
    End Sub
    Sub loadCOUNTRYcombo()
        '  Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F11" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            country.DataSource = ds.Tables(0)
            country.ValueMember = "code1"
            country.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB COUNTRY ! "
        End Try
    End Sub
    Sub loadDEPTcombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F3" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            dept.DataSource = ds.Tables(0)
            dept.ValueMember = "code1"
            dept.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB DEPT ! "
        End Try
    End Sub
    Sub loadPOSITIONcombo()
        '   Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F5" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            position.DataSource = ds.Tables(0)
            position.ValueMember = "code1"
            position.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB Position ! "
        End Try
    End Sub
    Sub loadglevelcombo()
        ' Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F4" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            glevel.DataSource = ds.Tables(0)
            glevel.ValueMember = "code1"
            glevel.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB glevel ! "
        End Try
    End Sub
    Sub loadbrancombo()
        '  Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F6" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            officebranch.DataSource = ds.Tables(0)
            officebranch.ValueMember = "code1"
            officebranch.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB officebranch ! "
        End Try
    End Sub
    Sub loadcatcombo()
        ' Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F8" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            cat.DataSource = ds.Tables(0)
            cat.ValueMember = "code1"
            cat.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB category ! "
        End Try
    End Sub
    Sub loadbankcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select DISTINCT bankcode,rtrim(names) as names from BANKSETUP"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            bankid.DataSource = ds.Tables(0)
            bankid.ValueMember = "bankcode"
            bankid.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        Try
            '  clearrec()
            staffid.Text = Searchtool.SelectedValue.ToString
            staffid.Focus()
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        staffid.Enabled = True
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
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

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim lrevar As New DownupWiz
        lrevar.gstring1 = "SELECT staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as Names,title,sex,mstatus as Marital_Status,dengage as Date_hired,dofb as Date_of_Birth,age,tel,email,pofb as Place_of_Birth,natid,address ,pfa,lga ,state,country,cat as Category,position,glevel ,bankid,branch,dept,accountid,accttype,scode,suspended,suspendeddate, leavedays, leavebal,officebranch,lpromotedd FROM stafftab  order by staffid"
        lrevar.ltitle.Text = "Staff List"
        lrevar.BindGrid()
        lrevar.MdiParent = Me
        lrevar.Show()
    End Sub

    Private Sub Searchtool_Validated(sender As Object, e As EventArgs) Handles Searchtool.Validated

    End Sub

    Sub loadfamilygriddata()
        Dim i2 As Integer
        For i2 = i2 To familygrid.RowCount - 1
            familygrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT Nkinnames,address,tel,rela,allocation,staffid FROM nextofkin where staffid = '" & staffid.Text & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        ''    MessageBox.Show(RTrim(r(3)))
                        Dim row As Integer = familygrid.Rows.Add
                        familygrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        familygrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        familygrid.Rows(row).Cells(2).Value = r(2)
                        familygrid.Rows(row).Cells(3).Value = RTrim(r(3))
                        familygrid.Rows(row).Cells(4).Value = Val(r(4))
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
    Sub loadquliriddata()
        Dim i2 As Integer
        For i2 = i2 To qualification.RowCount - 1
            qualification.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT quali ,div ,year ,course ,dsubmitted ,enrty,staffid FROM qualification where staffid = '" & staffid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = qualification.Rows.Add
                        qualification.Rows(row).Cells(0).Value = RTrim(r(0))
                        qualification.Rows(row).Cells(1).Value = RTrim(r(1))
                        qualification.Rows(row).Cells(2).Value = r(2)
                        qualification.Rows(row).Cells(3).Value = RTrim(r(3))
                        qualification.Rows(row).Cells(4).Value = r(4)
                        qualification.Rows(row).Cells(5).Value = r(5)
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
    Sub delfamilyfirst()
        Dim cSQL5 As String = "DELETE FROM nextofkin WHERE" _
            & " staffid = '" & Me.staffid.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL5
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try
    End Sub
    Sub delqualifirst()
        Dim cSQL5 As String = "DELETE FROM qualification WHERE" _
            & " staffid = '" & Me.staffid.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL5
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try



    End Sub
    Public Sub InsertRecordfamily()  'Subroutine to insert a record into the database  
        delfamilyfirst()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If familygrid.RowCount > 0 Then
                    For i = 0 To familygrid.RowCount - 1
                        If Not familygrid.Rows(i).Cells(0).Value = String.Empty Then
                            Cd3.CommandText = "INSERT INTO nextofkin(staffid ,Nkinnames ,address,tel,rela ,allocation) VALUES('" & staffid.Text & "','" & familygrid.Rows(i).Cells(0).Value & "','" & familygrid.Rows(i).Cells(1).Value & "','" & familygrid.Rows(i).Cells(2).Value & "','" & familygrid.Rows(i).Cells(3).Value & "','" & Val(familygrid.Rows(i).Cells(4).Value) & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                            saveaudit("Save/Update Family record for code: " + Trim(staffid.Text) + " In " + Me.Text)
                        End If
                    Next
                End If

                Me.Refresh()
                '  MessageBox.Show("Batch Save/Update Sucessfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Inserting Record family")
        End Try
    End Sub
    'Sub deletequaempty()
    '    Dim cSQL54 As String = "DELETE FROM qualification WHERE" _
    '               & " quali = '" & String.Empty & "'"
    '    Try
    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd As SqlCommand = CCNN.CreateCommand
    '            Cd.CommandType = CommandType.Text
    '            Cd.CommandText = cSQL54
    '            CCNN.Open()
    '            Cd.ExecuteNonQuery()
    '            Me.Refresh()
    '        End Using
    '    Catch ex As Exception
    '        '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
    '    End Try
    'End Sub
    Public Sub InsertRecordqualification()  'Subroutine to insert a record into the database  
        delqualifirst()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If qualification.RowCount > 0 Then
                    For i = 0 To qualification.RowCount - 1
                        If Not qualification.Rows(i).Cells(0).Value = String.Empty Then
                            MDIParent1.statusmsg2.Text = qualification.Rows(i).Cells(0).Value
                            Cd3.CommandText = "INSERT INTO qualification(quali,div,year,course,dsubmitted,enrty,staffid) VALUES('" & RTrim(qualification.Rows(i).Cells(0).Value) & "','" & qualification.Rows(i).Cells(1).Value & "','" & qualification.Rows(i).Cells(2).Value & "','" & qualification.Rows(i).Cells(3).Value & "','" & qualification.Rows(i).Cells(4).Value & "','" & qualification.Rows(i).Cells(5).Value & "','" & staffid.Text & "');"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                            saveaudit("Save/Update qualification record for code: " + Trim(staffid.Text) + " In " + Me.Text)
                        End If
                    Next
                End If

                Me.Refresh()
                ' MessageBox.Show("Batch Save/Update Sucessfully")
            End Using
            'deletequaempty()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Inserting qualification Record")
        End Try
    End Sub

    Private Sub Searchtool_Validating(sender As Object, e As CancelEventArgs) Handles Searchtool.Validating

    End Sub

    Private Sub staffid_TextChanged(sender As Object, e As EventArgs) Handles staffid.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenEmail(email.Text)
    End Sub
    Public Function OpenEmail(ByVal EmailAddress As String, _
  Optional ByVal Subject As String = "", _
  Optional ByVal Body As String = "") _
  As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & Subject

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & Body
        End If
        Try
            System.Diagnostics.Process.Start(sParams)
        Catch
            bAns = False
        End Try

        Return bAns

    End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        spicture1.Image = Nothing
        spicture.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        childpix1p.Image = Nothing
        childpix1.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        childpix2p.Image = Nothing
        childpix2.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        childpix3p.Image = Nothing
        childpix3.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        childpix4p.Image = Nothing
        childpix4.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub dofb_ValueChanged(sender As Object, e As EventArgs) Handles dofb.ValueChanged
        Dim dob As Date = Me.dofb.Value
        Dim age2 As Integer = Convert.ToInt32(DateDiff(DateInterval.Year, dob, Date.Today))
        age.Text = age2
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            ppicture1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            spicture1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix1p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix2p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix3p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix4p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ppicture1.Image = Nothing
        ppicture.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Sub loadpictures()
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from stafftab where staffid = " + staffid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("ppicture"), Byte())
                    Dim ms As New MemoryStream(data)
                    ppicture1.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from stafftab where staffid = " + staffid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("spicture"), Byte())
                    Dim ms As New MemoryStream(data)
                    spicture1.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try











    End Sub
End Class