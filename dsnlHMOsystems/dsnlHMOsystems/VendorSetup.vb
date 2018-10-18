Imports System.Text
Imports System.Net.Sockets
Imports System.Text.StringBuilder
Imports System.Threading
Imports System.Collections
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
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
Public Class Vendorsreg
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Private Sub Vendorsreg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        ogaid.Focus()
        loadtoolscombo()
        loadglcodecombo()
        loadlgacombo()
        loadSTATEcombo()
        loadCOUNTRYcombo()
        loadsectorhp()
        loadhpplancombo()
        loadbankcombo()
        ogaid.Focus()
        disablecontrols()
        enrolleehcp.EnableHeadersVisualStyles = False
        enrolleehcp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        enrolleehcp.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        enrolleehcp.ColumnHeadersHeight = 30
        enrolleehcp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        clearrec()
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
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "ogaid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
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
            ogaid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM oganisationtab WHERE" _
            & " ogaid = '" & Me.ogaid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for code: " + Trim(ogaid.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    '  If result = vbNo Then
                    'Me.Close()
                    '   End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try

            Dim cSQL2 As String = "DELETE FROM ogaplangrid WHERE" _
                        & " ogaid = '" & Me.ogaid.Text & "'"
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






        End If
        '   MessageBox.Show("Update Data instead")
    End Sub

    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        'ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,
        'bankbranch, accountid, sortcode, sectortype, hcpplan, puprice, punumber, putotal, pugrandtotal
        Try
            '   Dim index As Integer

            'r(4)
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "Select ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,bankbranch,accountid,sortcode,sectortype,hcpplan,puprice,punumber,putotal,pugrandtotal,ugplan,Utidefaultfees,paidtodate,ContractExpires,cbalance FROM oganisationtab WHERE" _
                & " rtrim(ogaid) = '" & RTrim(ogaid.Text) & "'"

                Cd.CommandType = CommandType.Text
                '  ogaid, oganames, active, dregister, lga, state, country, tel, email, website, sperson, address, glcode,
                ' bank, bankbranch, accountid, sortcode, sectortype, hcpplan, puprice, punumber, putotal, pugrandtotal
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.oganames.Text = RTrim(r(1))
                    If Not r.IsDBNull(3) Then Me.dregister.Value = r(3)
                    If Not r.IsDBNull(2) Then
                        If r(2) = True Then
                            If Not r.IsDBNull(2) Then Me.active.Checked = True
                        End If
                    End If
                    If Not r.IsDBNull(4) Then Me.lga.SelectedValue = r(4)
                    If Not r.IsDBNull(5) Then Me.state.SelectedValue = r(5)
                    If Not r.IsDBNull(6) Then Me.country.SelectedValue = r(6)
                    If Not r.IsDBNull(7) Then Me.tel.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.email.Text = r(8)
                    If Not r.IsDBNull(9) Then Me.website.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.sperson.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.address.Text = r(11)
                    If Not r.IsDBNull(12) Then Me.glcode.SelectedValue = r(12)
                    If Not r.IsDBNull(13) Then Me.bank.SelectedValue = r(13)
                    If Not r.IsDBNull(14) Then Me.bankbranch.Text = r(14)
                    If Not r.IsDBNull(15) Then Me.accountid.Text = r(15)
                    If Not r.IsDBNull(16) Then Me.sortcode.Text = r(16)
                    If Not r.IsDBNull(17) Then Me.sectortype.SelectedValue = r(17)
                    If Not r.IsDBNull(18) Then Me.hcpplan.SelectedValue = r(18)
                    If Not r.IsDBNull(19) Then Me.puprice.Text = r(19)
                    If Not r.IsDBNull(20) Then Me.punumber.Text = r(20)
                    If Not r.IsDBNull(21) Then Me.putotal.Text = r(21)
                    If Not r.IsDBNull(22) Then Me.pugrandtotal.Text = r(22)
                    If RTrim(r(23)) = "ugplan1" Then ugplan1.Checked = True
                    If RTrim(r(23)) = "ugplan2" Then ugplan2.Checked = True
                    If Not r.IsDBNull(24) Then Me.Utidefaultfees.Text = r(24)
                    If Not r.IsDBNull(25) Then Me.paidtodate.Text = r(25)
                    If Not r.IsDBNull(26) Then Me.ContractExpires.Value = r(26)
                    If Not r.IsDBNull(27) Then Me.cbalance.Text = r(27)
                    My.Settings.newrec = True
                    enablecontrols()
                    enrollelist()
                    LoadnewPLANgrid()
                    calgrandtotal()
                    oganames.Focus()
                    Me.Refresh()
                    TabControl1.Refresh()
                Else
                    My.Settings.newrec = False

                    enablecontrols()
                    oganames.Focus()
                    LoadnewPLANgrid()
                    calgrandtotal()
                    enrollelist()
                End If
                Me.Refresh()
                ogaid.Enabled = False
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database                                                                                                                                                                                                                                                                                          lga,state,country,tel,                                                                                                                               email,website,sperson,address,glcode,bank,bankbranch,accountid,sortcode                                                                                                                                                                     ,sectortype,hcpplan,puprice,punumber,putotal,pugrandtotal                    

        '  MessageBox.Show(Format(dregister.Value, "yyyy-MM-dd"))
        MDIParent1.statusmsg2.Text = Format(dregister.Value, "yyyy-MM-dd")
        Try
            cSQL = "INSERT INTO oganisationtab(ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,bankbranch,accountid,sortcode,sectortype,hcpplan,puprice,punumber,putotal,pugrandtotal,ugplan,Utidefaultfees,paidtodate,ContractExpires,cbalance) VALUES('" & ogaid.Text.Trim & "','" & oganames.Text.Trim & "','" & active.Checked & "','" & Format(dregister.Value, "yyyy-MM-dd") & "','" & lga.SelectedValue & "','" & state.SelectedValue & "','" & country.SelectedValue & "','" & tel.Text & "','" & email.Text.Trim & "','" & website.Text & "','" & sperson.Text & "','" & address.Text & "','" & glcode.SelectedValue & "','" & bank.SelectedValue & "','" & bankbranch.Text & "','" & accountid.Text.Trim & "','" & sortcode.Text & "','" & sectortype.SelectedValue & "','" & hcpplan.SelectedValue & "','" & Val(puprice.Text) & "','" & Val(punumber.Text) & "','" & Val(putotal.Text) & "','" & Val(pugrandtotal.Text) & "','" & IIf(ugplan1.Checked = True, "ugplan1", "ugplan2") & "','" & Val(Utidefaultfees.Text) & "','" & Val(paidtodate.Text) & "','" & ContractExpires.Value & "','" & Val(cbalance.Text) & "');"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Insert new Organization record for code: " + RTrim(ogaid.Text) + " In " + Me.Text)
                MessageBox.Show("Record Save Sucessfully")
            End Using
            savetovendor()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        clearrec()
        loadtoolscombo()
    End Sub
    Sub savetovendor()
        '  custvendid,Names FROM custvendtab where custvendtype ='" & "C" paidtodate

        Try
            cSQL = "INSERT INTO custvendtab(custvendid,Names,custvendtype,address) VALUES('" & ogaid.Text.Trim & "','" & oganames.Text.Trim & "','" & "C" & "','" & address.Text.Trim & "');"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            If active.Checked = True Then
                disableenrollees()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        'ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,
        'bankbranch, accountid, sortcode, sectortype, hcpplan, puprice, punumber, putotal, pugrandtotal
        Dim ugplanvar As String
        If ugplan1.Checked = True Then
            ugplanvar = "ugplan1"
        End If
        If ugplan2.Checked = True Then
            ugplanvar = "ugplan2"
        End If
        Try
            Dim cSQL As String = "UPDATE oganisationtab SET oganames = '" & Me.oganames.Text & _
          "', active = '" & active.Checked & _
          "',dregister = '" & Format(dregister.Value, "yyyy-MM-dd") & _
            "',LGA = '" & lga.SelectedValue & _
            "',state = '" & state.SelectedValue & _
            "',country = '" & country.SelectedValue & _
            "',tel = '" & tel.Text & _
           "' ,email = '" & Me.email.Text & _
             "' ,website = '" & website.Text & _
             "' ,sperson = '" & Me.sperson.Text & _
           "' ,address = '" & Me.address.Text & _
            "',glcode = '" & glcode.SelectedValue & _
            "',bank = '" & Me.bank.SelectedValue & _
            "',bankbranch = '" & bankbranch.Text & _
            "',accountid = '" & accountid.Text & _
            "',sortcode = '" & sortcode.Text & _
            "',sectortype = '" & Me.sectortype.SelectedValue & _
             "',hcpplan = '" & Me.hcpplan.SelectedValue & _
                "',puprice = '" & Val(puprice.Text) & _
            "',punumber = '" & Val(Me.punumber.Text) & _
             "',putotal = '" & Val(Me.putotal.Text) & _
              "',paidtodate = '" & Me.paidtodate.Text & _
            "',ContractExpires = '" & Me.ContractExpires.Value & _
            "',cbalance = '" & Me.cbalance.Text & _
            "',ugplan = '" & IIf(ugplan1.Checked = True, "ugplan1", "ugplan2") & _
            "',Utidefaultfees = '" & Val(Me.Utidefaultfees.Text) & _
            "',pugrandtotal = '" & Val(Me.pugrandtotal.Text) & "' where  RTRIM(ogaid) = '" & RTrim(ogaid.Text) & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Updated Sucessfully")
                saveaudit("Update record for Organization code: " + Trim(ogaid.Text) + " In " + Me.Text)
            End Using
            If active.Checked = True Then
                disableenrollees()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        clearrec()
    End Sub
    Sub disableenrollees()
        Try
            cSQL = "UPDATE enrolleetab SET" _
                   & " active = '" & True & "' " & " WHERE" & " ogaid = '" & Me.ogaid.Text & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                '  MessageBox.Show("Record Updated Sucessfully")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.ogaid.Focus()
        oganames.Text = ""
        dregister.Text = ""
        active.Checked = False
        'lga.SelectedIndex = -1
        'state.SelectedIndex = -1
        'country.SelectedIndex = -1
        sperson.Text = ""
        tel.Text = ""
        ContractExpires.Value = Now
        paidtodate.Text = 0.0
        email.Text = ""
        website.Text = ""
        address.Text = ""
        'glcode.SelectedIndex = -1
        'bank.SelectedIndex = -1
        bankbranch.Text = ""
        accountid.Text = ""
        sortcode.Text = ""
        cbalance.Text = 0.0
        puprice.Text = 0.0
        punumber.Text = 0.0
        putotal.Text = 0.0
        Utidefaultfees.Text = 0.0
        pugrandtotal.Text = 0.0
        'sectortype.SelectedIndex = -1
        'hcpplan.SelectedIndex = -1

        Dim T As Integer
        For T = T To enrolleehcp.RowCount - 1
            enrolleehcp.Rows.Clear()
        Next

        Dim i2 As Integer
        For i2 = i2 To ogaplangrid.RowCount - 1
            ogaplangrid.Rows.Clear()
        Next
    End Sub
    Private Sub enablecontrols()
        'ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,
        'bankbranch, accountid, sortcode, sectortype, hcpplan, puprice, punumber, putotal, pugrandtotal


        Me.ogaid.Focus()
        oganames.Enabled = True
        dregister.Enabled = True
        active.Enabled = True
        lga.Enabled = True
        state.Enabled = True
        country.Enabled = True
        puprice.Enabled = True
        ContractExpires.Enabled = True
        tel.Enabled = True
        email.Enabled = True
        Utidefaultfees.Enabled = True
        website.Enabled = True
        address.Enabled = True
        glcode.Enabled = True
        bank.Enabled = True
        bankbranch.Enabled = True
        accountid.Enabled = True
        sortcode.Enabled = True
        punumber.Enabled = True
        putotal.Enabled = True
        pugrandtotal.Enabled = True
        sectortype.Enabled = True
    End Sub

    Private Sub disablecontrols()

        oganames.Enabled = False
        dregister.Enabled = False
        active.Enabled = False
        lga.Enabled = False
        state.Enabled = False
        country.Enabled = False
        puprice.Enabled = False
        ContractExpires.Enabled = False
        tel.Enabled = False
        email.Enabled = False
        Utidefaultfees.Enabled = False
        website.Enabled = False
        address.Enabled = False
        glcode.Enabled = False
        bank.Enabled = False
        bankbranch.Enabled = False
        accountid.Enabled = False
        sortcode.Enabled = False
        punumber.Enabled = False
        putotal.Enabled = False
        pugrandtotal.Enabled = False
        sectortype.Enabled = False
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
    Sub enrollelist()
        Dim i2 As Integer
        For i2 = i2 To enrolleehcp.RowCount - 1
            enrolleehcp.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dofb,sex,tel,email,NHIS,hcpid,sdate,ogaid FROM enrolleetab where" _
                             & " RTRIM(ogaid) = '" & Me.ogaid.Text.Trim & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = enrolleehcp.Rows.Add
                        enrolleehcp.Rows(row).Cells(0).Value = r(0)
                        enrolleehcp.Rows(row).Cells(1).Value = r(1)
                        enrolleehcp.Rows(row).Cells(2).Value = r(2)
                        enrolleehcp.Rows(row).Cells(3).Value = r(3)
                        enrolleehcp.Rows(row).Cells(4).Value = r(4)
                        enrolleehcp.Rows(row).Cells(5).Value = r(5)
                        enrolleehcp.Rows(row).Cells(6).Value = r(6)
                        enrolleehcp.Rows(row).Cells(7).Value = r(7)
                        enrolleehcp.Rows(row).Cells(8).Value = r(8)
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
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenEmail(email.Text)
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Process.Start(website.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        ogaid.Enabled = True
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
        '  Loadnewilnessgrid()
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        saverec()
    End Sub

    Private Sub DeleteEnrolleeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteEnrolleeToolStripMenuItem.Click
        delrec()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Sub loadglcodecombo()
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
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection accode! "
        End Try
    End Sub

    Sub loadlgacombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
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
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab F2! "
        End Try
    End Sub
    Sub loadSTATEcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
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
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab F1! "
        End Try
    End Sub
    Sub loadCOUNTRYcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
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
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab F11! "
        End Try
    End Sub
    Sub loadsectorhp()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F12" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            sectortype.DataSource = ds.Tables(0)
            sectortype.ValueMember = "code1"
            sectortype.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab F12! "
        End Try
    End Sub
    Sub loadhpplancombo()
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
            hcpplan.DataSource = ds.Tables(0)
            hcpplan.ValueMember = "code1"
            hcpplan.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection premiumplan! "
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
        sql = "select bankcode,rtrim(names) as names from BANKSETUP"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            bank.DataSource = ds.Tables(0)
            bank.ValueMember = "bankcode"
            bank.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection BANKSETUP! "
        End Try
    End Sub
    Sub LoadnewPLANgrid()
        '  MessageBox.Show("in LoadnewPLANgrid")
        Dim i2 As Integer
        For i2 = i2 To ogaplangrid.RowCount - 1
            ogaplangrid.Rows.Clear()
        Next
        Dim gg2 As String = "select CODE1,DESCR,NINPLAN,UPRICE,AMOUNT,OGAID from ogaplangrid where rtrim(OGAID) = '" & RTrim(ogaid.Text) & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = ogaplangrid.Rows.Add
                        ogaplangrid.Rows(row).Cells(0).Value = r(0)
                        ogaplangrid.Rows(row).Cells(1).Value = r(1)
                        ogaplangrid.Rows(row).Cells(2).Value = FormatNumber(r(2), 2, TriState.True)
                        ogaplangrid.Rows(row).Cells(3).Value = FormatNumber(r(3), 2, TriState.True)
                        ogaplangrid.Rows(row).Cells(4).Value = FormatNumber(r(4), 2, TriState.True)
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

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Addplan_Click(sender As Object, e As EventArgs) Handles Addplan.Click
        If (Not ogaid.Text = String.Empty) Then
            checkadremexist()
            Dim cSQL As String = "INSERT INTO ogaplangrid(CODE1,DESCR,NINPLAN,UPRICE,AMOUNT,OGAID) VALUES('" & hcpplan.SelectedValue & "','" & hcpplan.Text & "','" & Val(punumber.Text) & "','" & Val(puprice.Text) & "','" & Val(putotal.Text) & "','" & ogaid.Text & "')"

            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    MessageBox.Show("Generated Sucessfully")

                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



            LoadnewPLANgrid()
            calgrandtotal()
        End If
    End Sub

    Private Sub removeplan_Click(sender As Object, e As EventArgs) Handles removeplan.Click
        If (Not ogaid.Text = String.Empty) Then
            cSQL = "DELETE FROM ogaplangrid WHERE" _
                                   & " code1 = '" & hcpplan.SelectedValue & "' AND Ogaid = '" & ogaid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
            LoadnewPLANgrid()
            calgrandtotal()
        End If
    End Sub

    Private Sub ogaid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ogaid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not ogaid.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
    End Sub


    Private Sub hcpplan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hcpplan.SelectedIndexChanged
      
    End Sub

    Private Sub punumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles punumber.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Try
                If Not IsNumeric(punumber.Text) Then
                    MessageBox.Show("Entered numeric values to continue")
                    Exit Sub
                    punumber.Focus()
                End If
                Dim tot As Double
                tot = Val(Me.puprice.Text) * Val(Me.punumber.Text)
                '  MessageBox.Show(tot)
                putotal.Text = Val(tot)
            Catch ex As Exception
                MDIParent1.statusmsg.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub punumber_TextChanged(sender As Object, e As EventArgs) Handles punumber.TextChanged
       
    End Sub

    Private Sub puprice_TextChanged(sender As Object, e As EventArgs) Handles puprice.TextChanged
      
    End Sub

    Private Sub Utidefaultfees_TextChanged(sender As Object, e As EventArgs) Handles Utidefaultfees.TextChanged
       
    End Sub

    Private Sub punumber_Validating(sender As Object, e As CancelEventArgs) Handles punumber.Validating
        Try
            If Not IsNumeric(punumber.Text) Then
                MessageBox.Show("Entered numeric values to continue")
                Exit Sub
                punumber.Focus()
            End If
            Dim tot As Double
            tot = Val(Me.puprice.Text) * Val(Me.punumber.Text)
            '  MessageBox.Show(tot)
            putotal.Text = Val(tot)
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub hcpplan_Validating(sender As Object, e As CancelEventArgs) Handles hcpplan.Validating
        canplan()
    End Sub
    Sub canplan()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT code1, descr,amount,type FROM premiumplan WHERE" _
                & " code1 = '" & hcpplan.SelectedValue & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.Read = True Then
                    Me.puprice.Text = Val(r(2))
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub checkadremexist()
        Dim gg2 As String = "select CODE1,DESCR,NINPLAN,UPRICE,AMOUNT,OGAID from ogaplangrid where" _
          & " code1 = '" & hcpplan.SelectedValue & "' AND Ogaid = '" & ogaid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    MessageBox.Show("Plan already exist, use remove button")
                    Exit Sub
                    removeplan.Focus()
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub calgrandtotal()
        Dim gg2 As String = "select sum(AMOUNT) as amtnow from ogaplangrid where ogaid = '" & ogaid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    pugrandtotal.Text = FormatNumber(r(0), 2, TriState.True)
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        calgrandtotal()
    End Sub


    Private Sub Utidefaultfees_Validating(sender As Object, e As CancelEventArgs) Handles Utidefaultfees.Validating
        If Not IsNumeric(Utidefaultfees.Text) Then
            MessageBox.Show("Entered numeric values to continue")
            Utidefaultfees.Focus()
        End If
    End Sub

    Private Sub puprice_Validating(sender As Object, e As CancelEventArgs) Handles puprice.Validating
        If Not IsNumeric(puprice.Text) Then
            MessageBox.Show("Entered numeric values to continue")
            puprice.Focus()
        End If
    End Sub

    
    Private Sub bank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bank.SelectedIndexChanged
        Try
            bankbranch.Text = bank.Text
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub Searchtool_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Searchtool.PreviewKeyDown

    End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        clearrec()
        ogaid.Text = Searchtool.SelectedValue.ToString
        ogaid.Focus()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim lrevar As New DownupWiz
        lrevar.gstring1 = "Select ogaid,oganames,active as Inactive,dregister as Date_register,lga,state,country as Country_ID,tel,email,website,sperson as Contact_Person,address,glcode,bank,bankbranch,accountid,sortcode,sectortype,hcpplan,pugrandtotal as Plan_GrandTotal FROM oganisationtab  order by ogaid"
        lrevar.ltitle.Text = "Oginization Listing"
        lrevar.BindGrid()
        lrevar.MdiParent = MDIParent1
        lrevar.Show()
    End Sub

    Private Sub ogaid_TextChanged(sender As Object, e As EventArgs) Handles ogaid.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            cSQL = "UPDATE Enrolleetab SET" _
                   & " ugmfees = '" & Me.Utidefaultfees.Text & "' " & " WHERE" & " ogaid = '" & Me.ogaid.Text & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Generate Montly Capitation for oganisation ID : " + RTrim(ogaid.Text) + " In " + Me.Text)
                MessageBox.Show("Record Geenerated Sucessfully")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub paidtodate_TextChanged(sender As Object, e As EventArgs) Handles paidtodate.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim str As String = txt_search.Text

            If Me.txt_search.Text.Trim(" ") = " " Then
            Else
                For i As Integer = 0 To enrolleehcp.Rows.Count - 1
                    For j As Integer = 0 To Me.enrolleehcp.Rows(i).Cells.Count - 1
                        If enrolleehcp.Item(j, i).Value.ToString().ToLower.StartsWith(str.ToLower) Then
                            enrolleehcp.Rows(i).Selected = True
                            enrolleehcp.CurrentCell = enrolleehcp.Rows(i).Cells(j)
                            Exit Try
                        End If
                    Next
                Next i
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If ugplan1.Checked = True Then
            Try
                cSQL = "UPDATE enrolleetab SET" _
                       & " sdate = '" & Me.enrosdate.Value & "', " & " edate = '" & Me.enroedate.Value & "' " & " WHERE" & " ogaid = '" & Me.ogaid.Text & "' and  '" & ugplan1.Checked & "'"

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
        Else
            MessageBox.Show("Generate Only for NHIS Organisation")
        End If
    End Sub
End Class