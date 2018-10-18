Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
'Imports System.Drawing.Image
Public Class leavemgt
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public notif As New NotifyIcon
    'Public myRandom As New Random
    'Public formNumber As Integer = 1
    Private Sub apprvnleavedays_KeyPress(sender As Object, e As KeyPressEventArgs) Handles apprvnleavedays.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Try
                If apprvnleavedays.Text > leaveentile.Text Then
                    MessageBox.Show("Approve Numbers of days cannot be greater than Leave entitlement")
                    apprvnleavedays.Text = 0
                    Return
                Else
                    leavebal.Text = leaveentile.Text - apprvnleavedays.Text
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles apprvnleavedays.TextChanged

    End Sub
    Private Sub leavemgt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        'SELECT staffid,leaveref,names,leaveadd,leavetype,tel,leaveentile,apprvnleavedays,leavebal,resumeat,anualsal,sldate,eldate,leavemode,signby,approved,ccmd,ccothers,resumedate,daysused FROM leavetab
        disablecontrols()
        loadstaffccmdcombo()
        loadstaffccotherscombo()
        loadstaffleavetypecombo()
        loadstaffsignbycombo()
        clearrec()
    End Sub
    Public Sub saverec()
        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            If My.Settings.newrec = False Then

                UpdategencodeRecord()
                InsertRecord()

            End If
            If My.Settings.newrec = True Then

                updaterecord()
            End If
            welcomeme()
            Me.Refresh()
            staffid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Sub welcomeme()

        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Record Updated Successfully", frmMSGctrl.MessageType.Information)
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            cSQL = "DELETE FROM leavetab WHERE" _
            & " staffid = '" & Me.staffid.Text & "' and appref = '" & Me.leaveref.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for Leave Ref Code: " + Trim(leaveref.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
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

                Cd.CommandText = " SELECT staffid,leaveref,names,leaveadd,leavetype,tel,leaveentile,apprvnleavedays,leavebal,resumeat,anualsal,sldate,eldate,leavemode,signby,approved,ccmd,ccothers,resumedate,daysused FROM leavetab WHERE" _
                & " staffid = '" & Me.staffid.Text & "' and leaveref = '" & Me.leaveref.Text & "'"

                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(2) Then Me.names.Text = RTrim(r(2))
                    If Not r.IsDBNull(3) Then Me.leaveadd.Text = RTrim(r(3))

                    If Not r.IsDBNull(4) Then Me.leavetype.SelectedValue = RTrim(r(4))
                    If Not r.IsDBNull(5) Then Me.tel.Text = RTrim(r(5))
                    If Not r.IsDBNull(6) Then Me.leaveentile.Text = r(6)
                    If Not r.IsDBNull(7) Then Me.apprvnleavedays.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.leavebal.Text = r(8)
                    If Not r.IsDBNull(9) Then Me.resumeat.Text = RTrim(r(9))
                    If Not r.IsDBNull(10) Then Me.anualsal.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.sldate.Value = r(11)
                    If Not r.IsDBNull(12) Then Me.eldate.Value = r(12)
                    If Not r.IsDBNull(13) Then
                        If r(13) = "O" Then
                            Me.leavemodeo.Checked = True
                        Else
                            Me.leavemodep.Checked = True
                        End If
                        If Not r.IsDBNull(14) Then Me.signby.SelectedValue = RTrim(r(14))
                        If Not r.IsDBNull(15) Then Me.approved.Checked = r(15)
                        If Not r.IsDBNull(16) Then Me.ccmd.SelectedValue = RTrim(r(16))
                        If Not r.IsDBNull(17) Then Me.ccothers.SelectedValue = RTrim(r(17))
                        If Not r.IsDBNull(18) Then Me.resumedate.Value = r(18)
                        If Not r.IsDBNull(19) Then Me.daysused.Text = r(19)

                    End If
                    callforapproval()
                    enablecontrols()
                    getannusal()
                    My.Settings.newrec = True
                    Me.Refresh()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    getannusal()
                    getentitlement()
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub getannusal()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = " SELECT a.staffid,a.amount FROM defaulttab a,payitems b WHERE" _
                & " a.staffid = '" & Me.staffid.Text & "' and rtrim(a.pic)=rtrim(b.itemcode) and  rtrim(b.itemtype) = '" & "Basic" & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.anualsal.Text = r(1) * 12
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub getentitlement()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = " SELECT staffid,leavedays FROM stafftab WHERE" _
                & " staffid = '" & Me.staffid.Text & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.leaveentile.Text = r(1)
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
   
    Public Sub InsertRecord()  'Subroutine to insert a record into the database            descvar                                                                                                                                                                                                                 dregister,active,NHIS,                                                      LGA,state,country,pmethod,tel,                                                                                                                  email,website,address,                                                                                              glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        ' delrec2()
        CheckCodestab.CALLCODESTAB(leavetype.SelectedValue, "L31")
        Dim ltynow As String = CheckCodestab.descvar
        CheckCodestab.stafftabname(ccmd.SelectedValue)
        Dim ccmdvar As String = CheckCodestab.descvar
        CheckCodestab.stafftabname(ccothers.SelectedValue)
        Dim ccothersvar As String = CheckCodestab.descvar
        CheckCodestab.stafftabname(signby.SelectedValue)
        Dim appbyvar As String = CheckCodestab.descvar
        cSQL = "INSERT INTO leavetab(staffid,leaveref,names,leaveadd,leavetype,tel,leaveentile,apprvnleavedays,leavebal,resumeat,anualsal,sldate,eldate,leavemode,signby,approved,ccmd,ccothers,resumedate,daysused,appby,appnow,ltypedescr,ccmdnames,ccothersnames,appbynames)" & _
       "VALUES('" & staffid.Text & "','" & leaveref.Text & "','" & names.Text & "','" & leaveadd.Text & "','" & RTrim(leavetype.SelectedValue) & "','" & tel.Text & "','" & Val(leaveentile.Text) & "','" & Val(apprvnleavedays.Text) & "','" & Val(leavebal.Text) & "','" & resumeat.Text & "','" & Val(anualsal.Text) & "','" & Format(sldate.Value, "yyyy-MM-dd") & "','" & Format(eldate.Value, "yyyy-MM-dd") & "','" & IIf(leavemodeo.Checked = True, "O", "P") & "','" & RTrim(signby.SelectedValue) & "','" & approved.Checked & "','" & RTrim(ccmd.SelectedValue) & "','" & RTrim(ccothers.SelectedValue) & "','" & Format(resumedate.Value, "yyyy-MM-dd") & "','" & Val(daysused.Text) & "','" & RTrim(signby.SelectedValue) & "','" & False & "','" & ltynow & "','" & ccmdvar & "','" & ccothersvar & "','" & appbyvar & "')"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Insert new record for leave reference code: " + Trim(leaveref.Text) + " In " + Me.Text)
                clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in LEAVTAB Table")
        End Try
        updateleavebal()
        disablecontrols()
    End Sub

    Sub updateleavebal()
        If approved.Checked = False Then
            cSQL = "UPDATE stafftab SET" _
          & " leavebal = '" & Me.leavebal.Text & "'" & " WHERE" & " RTRIM(staffid) = '" & RTrim(Me.staffid.Text.ToString) & "'"
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
        Else
            MessageBox.Show("Sorry leave already been approved")
        End If
        'MessageBox.Show("Record 
    End Sub
    Sub updaterecord()
        'staffid,leaveref,names,leaveadd,leavetype,tel,leaveentile,                                                                                                             apprvnleavedays,leavebal                                                                                                                                 ,resumeat,anualsal,sldate,eldate,leavemode,                                                                                                                                                                                signby,approved,ccmd,ccothers,resumedate,daysused,appby,appnow)

        Try
            CheckCodestab.CALLCODESTAB(leavetype.SelectedValue, "L31")
            Dim ltynow As String = CheckCodestab.descvar
            CheckCodestab.stafftabname(ccmd.SelectedValue)
            Dim ccmdvar As String = CheckCodestab.descvar
            CheckCodestab.stafftabname(ccothers.SelectedValue)
            Dim ccothersvar As String = CheckCodestab.descvar
            CheckCodestab.stafftabname(signby.SelectedValue)
            Dim appbyvar As String = CheckCodestab.descvar

            Dim cSQL5 As String = "UPDATE leavetab SET" _
                           & " leavetype = '" & Trim(leavetype.SelectedValue) & "', " & " tel = '" & Me.tel.Text & "', " & " leaveentile = '" & Me.leaveentile.Text & "', " & " apprvnleavedays = '" & Me.apprvnleavedays.Text & "', " & " leavebal = '" & Me.leavebal.Text & "', " & " resumeat = '" & Me.resumeat.Text & "', " & " anualsal = '" & Me.anualsal.Text & "', " & " sldate = '" & Me.sldate.Value & "', " & " eldate = '" & Format(Me.eldate.Value, "yyyy-MM-dd") & "', " & " leavemode = '" & IIf(leavemodeo.Checked = True, "O", "P") & "', " & " signby = '" & Trim(Me.signby.SelectedValue) & "', " & " approved = '" & approved.Checked & "', " & " ccmd = '" & Trim(Me.ccmd.SelectedValue) & "', " & " ccothers = '" & Trim(Me.ccothers.SelectedValue) & "', " & " resumedate = '" & Format(resumedate.Value, "yyyy-MM-dd") & "', " & " daysused = '" & daysused.Text & "', " & " appby = '" & Trim(Me.signby.SelectedValue) & "', " & " appnow = '" & IIf(approved.Checked = True, True, False) & "', " & " ltypedescr = '" & ltynow & "', " & " ccmdnames = '" & ccmdvar & "', " & " ccothersnames = '" & ccothersvar & "', " & " appbynames = '" & appbyvar & "'   " & " WHERE" & " staffid = '" & Me.staffid.Text & "' and leaveref = '" & Me.leaveref.Text & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL5
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Updated Sucessfully")
                saveaudit("Update record for Leave reference code: " + Trim(leaveref.Text) + " In " + Me.Text)

                clearrec()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Sub clearrec()
        'SELECT staffid,leaveref,names,leaveadd,leavetype,,,,,,,,,,,,,,, FROM leavetab
        '  names.Text = ""
        leaveadd.Text = ""
        tel.Text = ""
        leaveentile.Text = 0.0
        apprvnleavedays.Text = 0.0
        leavebal.Text = 0.0
        resumeat.Text = ""
        anualsal.Text = 0.0
        sldate.Value = Now
        eldate.Value = Now
        approved.Checked = False
        resumedate.Value = Now
        daysused.Text = 0.0
    End Sub
    Sub enablecontrols()
        names.Enabled = True
        leaveadd.Enabled = True
        tel.Enabled = True
        leaveentile.Enabled = True
        apprvnleavedays.Enabled = True
        leavebal.Enabled = True
        resumeat.Enabled = True
        anualsal.Enabled = True
        sldate.Enabled = True
        eldate.Enabled = True
        ' approved.Enabled = True
        resumedate.Enabled = True
        daysused.Enabled = True
    End Sub
    Sub disablecontrols()
        names.Enabled = False
        leaveadd.Enabled = False
        tel.Enabled = False
        leaveentile.Enabled = False
        apprvnleavedays.Enabled = False
        leavebal.Enabled = False
        resumeat.Enabled = False
        anualsal.Enabled = False
        sldate.Enabled = False
        eldate.Enabled = False
        approved.Enabled = False
        resumedate.Enabled = False
        daysused.Enabled = False
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


    Public Sub UpdategencodeRecord() '****This procedures,updates,CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        Dim leavrefvar As Integer = Str(Val(LTrim(leaveref.Text.Trim)) + 1)
        Try
            Dim cSQL As String = "UPDATE digitsettings SET leavref = '" & leavrefvar & "'"
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
        ' clearrec()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gg2 As String = "select companyid,leavref from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    leaveref.Text = RTrim(r(1)).Trim
                    LoadRecord()
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub loadstaffccmdcombo()
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
            ccmd.DataSource = ds.Tables(0)
            ccmd.ValueMember = "staffid"
            ccmd.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadstaffccotherscombo()
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
            ccothers.DataSource = ds.Tables(0)
            ccothers.ValueMember = "staffid"
            ccothers.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadstaffsignbycombo()
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
            signby.DataSource = ds.Tables(0)
            signby.ValueMember = "staffid"
            signby.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadstaffleavetypecombo()
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
        sql = "select code1,descr from CODESTAB where option1 = '" & "L31" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            leavetype.DataSource = ds.Tables(0)
            leavetype.ValueMember = "code1"
            leavetype.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB COUNTRY ! "
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dengage from stafftab where staffid != '" & "ADMIN" & "' and suspended = '" & False & "' order by staffid"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            '  sfrm.Show()

            staffid.Refresh()
            Me.Refresh()
            staffid.Text = CODDY
            names.Text = DESCC
            If (Not staffid.Text = String.Empty) Then
                staffid.Refresh()
                '  LoadRecord()
                staffid.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'SELECT staffid,leaveref,names,leaveadd,leavetype,tel,leaveentile,apprvnleavedays,leavebal,resumeat,anualsal,sldate,eldate,leavemode,signby,approved,ccmd,ccothers,resumedate,daysused FROM leavetab


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct leaveref,names,staffid FROM leavetab order by leaveref"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            '  sfrm.Show()

            leaveref.Refresh()
            Me.Refresh()

            If (Not staffid.Text = String.Empty) Then
                leaveref.Refresh()
                leaveref.Text = CODDY
                LoadRecord()
                leaveref.Refresh()
            Else
                MessageBox.Show("Select Staffid to continue")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub apprvnleavedays_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles apprvnleavedays.Validating
        Try
            If apprvnleavedays.Text > leaveentile.Text Then
                MessageBox.Show("Approve Numbers of days cannot be greater than Leave entitlement")
                apprvnleavedays.Text = 0
                Return
            Else
                leavebal.Text = leaveentile.Text - apprvnleavedays.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub leavebal_GotFocus(sender As Object, e As EventArgs) Handles leavebal.GotFocus
        leavebal.Text = leaveentile.Text - apprvnleavedays.Text
    End Sub

    Private Sub leavebal_TextChanged(sender As Object, e As EventArgs) Handles leavebal.TextChanged

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        staffid.Text = ""
        leaveref.Text = ""
        names.Text = ""
        leaveadd.Text = ""
        tel.Text = ""
        leaveentile.Text = 0.0
        apprvnleavedays.Text = 0.0
        leavebal.Text = 0.0
        resumeat.Text = ""
        anualsal.Text = 0.0
        sldate.Value = Now
        eldate.Value = Now
        approved.Checked = False
        resumedate.Value = Now
        daysused.Text = 0.0
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim result = MsgBox("Post Leave For Approval.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            saverec()
            If (Not staffid.Text = String.Empty) And (Not leaveref.Text = String.Empty) Then
                If My.Settings.newrec = True Then

                    Try
                        Dim cSQL As String = "UPDATE leavetab SET appby  = '" & signby.SelectedValue & "' , " & " appnow = '" & False & "' " & " WHERE" & " staffid = '" & Me.staffid.Text & "' and leaveref = '" & Me.leaveref.Text & "'"
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



                End If
            End If
        End If
    End Sub


    Sub callforapproval()
        Dim gg2 As String = "SELECT staffid,leaveref,appby FROM leavetab  WHERE" _
         & " appby = '" & My.Settings.loginid & "' and leaveref = '" & leaveref.Text & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    approved.Enabled = True
                    reasonb.Visible = True
                    reasonL.Visible = True
                    resumeat.Visible = True
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg2.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Private Sub leaveref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles leaveref.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not leaveref.Text = String.Empty) Then
                leaveref.Refresh()
                LoadRecord()
                leaveref.Refresh()
            End If
        End If
    End Sub
    


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (Not daysused.Text = String.Empty) And approved.Checked Then

            rptrangecode = ""
            My.Settings.reportsqlstr = "Printleavecert"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = staffid.Text
            rptrangecode2 = leaveref.Text
            viewreport2.Text = "Print Leave Report"
            viewreport2.Show()

            'Dim notif As New NotifyIcon
            'notif.Visible = True
            'notif.ShowBalloonTip(3000, "Leave Allert", "Your Leave Certificate", ToolTipIcon.Info)

        Else

        End If
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles reasonb.Click
        updaterecord()

    End Sub
    Private Sub approved_CheckedChanged(sender As Object, e As EventArgs) Handles approved.CheckedChanged
        updaterecord()
    End Sub
End Class