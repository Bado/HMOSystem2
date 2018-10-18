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
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Office.Interop

Public Class hcpsetup
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Private Sub hcpsetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button8.Enabled = False
        Dim gg2 As String = "SELECT userid,password,names,admin,status,appraise,approve,staffonline ,staffpin,claimsinput,claimsvetting FROM useracct WHERE" _
          & " userid = '" & My.Settings.loginid & "' and admin = '" & True & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    If r(3) = True Then
                        Button8.Enabled = True
                    End If
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()





        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        'hcpid,Names,dregister,active,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        'IH = Me.Height
        ailmentgrid.EnableHeadersVisualStyles = False
        ailmentgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        ailmentgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        ailmentgrid.ColumnHeadersHeight = 30
        ailmentgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        enrolleehcp.EnableHeadersVisualStyles = False
        enrolleehcp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        enrolleehcp.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        enrolleehcp.ColumnHeadersHeight = 30
        enrolleehcp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        disablecontrols()

        
        ' MessageBox.Show("B4")
        loadCOUNTRYcombo()
        loadSTATEcombo()
        loadlgacombo()
        loadsectorhp()
        loadhpplancombo()
        loadglcodecombo()
        loadbankcombo()

        loadpnetworkcombo()
        LOANDCOMBOSERACH()
        '  MessageBox.Show("AFTER")
        clearrec()
        ' loadailmentcodecombo()
    End Sub

    Sub LOANDCOMBOSERACH()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select hcpid,rtrim(Names)  as names from Hcptab order by hcpid"

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
            Searchtool.ValueMember = "hcpid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
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
            hcpid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM Hcptab WHERE" _
            & " hcpid = '" & Me.hcpid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for code: " + Trim(hcpid.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    '  If result = vbNo Then
                    'Me.Close()
                    '   End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try


            Dim cSQL2 As String = "DELETE FROM hcpailmenttab WHERE" _
                        & " hcpid = '" & Me.hcpid.Text & "'"
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
        ' enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,
        Try
            Dim index As Integer

            'r(4)
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = " Select hcpid,Names,dregister,active,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan,pnetwork,lpay,paidtodate FROM Hcptab WHERE" _
                & " rtrim(hcpid) = '" & RTrim(hcpid.Text) & "'"

                Cd.CommandType = CommandType.Text
                'address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.names.Text = RTrim(r(1))
                    If Not r.IsDBNull(2) Then Me.dregister.Text = r(2)
                    If Not r.IsDBNull(2) Then
                        If r(3) = True Then
                            If Not r.IsDBNull(3) Then Me.active.Checked = True
                        End If
                    End If
                    If Not r.IsDBNull(4) Then Me.NHIS.Text = r(4)
                    If Not r.IsDBNull(5) Then Me.LGA.SelectedValue = r(5)
                    If Not r.IsDBNull(6) Then Me.state.SelectedValue = r(6)
                    If Not r.IsDBNull(7) Then Me.country.SelectedValue = r(7)
                    '    If Not r.IsDBNull(8) Then Me.pmethod.SelectedValue = r(8)
                    If Not r.IsDBNull(8) Then
                        index = pmethod.FindString(RTrim(r(8)))
                        pmethod.SelectedIndex = index
                    End If
                    If Not r.IsDBNull(9) Then Me.tel.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.email.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.website.Text = r(11)
                    If Not r.IsDBNull(12) Then Me.address.Text = r(12)
                    If Not r.IsDBNull(13) Then Me.glcode.SelectedValue = r(13)
                    If Not r.IsDBNull(14) Then Me.bank.SelectedValue = r(14)
                    If Not r.IsDBNull(15) Then Me.bankbranch.Text = r(15)
                    If Not r.IsDBNull(16) Then Me.accid.Text = r(16)
                    If Not r.IsDBNull(17) Then Me.sortcode.Text = r(17)
                    If Not r.IsDBNull(18) Then Me.Mdnames.Text = r(18)
                    If Not r.IsDBNull(19) Then Me.mdtel.Text = r(19)
                    If Not r.IsDBNull(20) Then Me.mdemail.Text = r(20)
                    If Not r.IsDBNull(21) Then Me.sectortype.SelectedValue = r(21)
                    If Not r.IsDBNull(22) Then Me.hcpplan.SelectedValue = r(22)
                    If Not r.IsDBNull(23) Then Me.pnetwork.SelectedValue = r(23)
                    If Not r.IsDBNull(24) Then Me.lpay.Text = r(24)
                    If Not r.IsDBNull(25) Then Me.paidtodate.Text = r(25)
                    My.Settings.newrec = True
                    enablecontrols()
                    enrollelist()
                    Loadilnessgrid()
                    NHIS.Focus()
                    Me.Refresh()
                    TabControl1.Refresh()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    NHIS.Focus()
                    Loadnewilnessgrid()
                    enrollelist()
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
            hcpid.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database                                                                                                                                                                                                                             dregister,active,NHIS,                                                      LGA,state,country,pmethod,tel,                                                                                                                  email,website,address,                                                                                              glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        MessageBox.Show(Format(dregister.Value, "yyyy-MM-dd"))
        Try
            cSQL = "INSERT INTO Hcptab(hcpid,Names,dregister,active,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan,pnetwork,paidtodate) VALUES('" & hcpid.Text.Trim & "','" & names.Text.Trim & "','" & Format(dregister.Value, "yyyy-MM-dd") & "','" & active.Checked & "','" & RTrim(NHIS.Text) & "','" & LGA.SelectedValue & "','" & state.SelectedValue & "','" & country.SelectedValue & "','" & RTrim(pmethod.Text) & "','" & tel.Text & "','" & email.Text.Trim & "','" & website.Text & "','" & address.Text & "','" & glcode.SelectedValue & "','" & bank.SelectedValue & "','" & bankbranch.Text & "','" & accid.Text.Trim & "','" & sortcode.Text & "','" & Mdnames.Text & "','" & mdtel.Text & "','" & mdemail.Text & "','" & sectortype.SelectedValue & "','" & hcpplan.SelectedValue & "','" & pnetwork.SelectedValue & "','" & paidtodate.Text & "');"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Insert new record for  code: " + RTrim(hcpid.Text) + " In " + Me.Text)
                MessageBox.Show("Record Save Sucessfully")
            End Using
            saveailmentvalues()
            savetocustomer()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Loadnewilnessgrid()
        LOANDCOMBOSERACH()
    End Sub
    Sub savetocustomer()
        '  custvendid,Names FROM custvendtab where custvendtype ='" & "C" 
        Try
            cSQL = "INSERT INTO custvendtab(custvendid,Names,custvendtype,address) VALUES('" & hcpid.Text.Trim & "','" & RTrim(names.Text) & "','" & "V" & "','" & address.Text & "');"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            clearrec()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        'hcpid, names, dregister, active, NHIS, LGA, state, country, pmethod, tel, email, website, address, glcode
        ',bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        MessageBox.Show(Format(dregister.Value, "yyyy-MM-dd"))
        Try
            Dim cSQL As String = "UPDATE Hcptab SET names = '" & Me.names.Text & _
          "',dregister = '" & Format(dregister.Value, "yyyy-MM-dd") & _
          "',active = '" & active.Checked & _
           "',NHIS = '" & RTrim(NHIS.Text) & _
            "',LGA = '" & LGA.SelectedValue & _
            "',state = '" & state.SelectedValue & _
            "',country = '" & country.SelectedValue & _
            "',pmethod = '" & pmethod.Text & _
            "',tel = '" & tel.Text & _
           "' ,email = '" & Me.email.Text & _
           "' ,website = '" & website.Text & _
           "' ,address = '" & Me.address.Text & _
            "',glcode = '" & glcode.SelectedValue & _
            "',bank = '" & Me.bank.SelectedValue & _
            "',bankbranch = '" & bankbranch.Text & _
            "',accid = '" & accid.Text & _
            "',sortcode = '" & sortcode.Text & _
            "',Mdnames = '" & Me.Mdnames.Text & _
            "',mdtel = '" & mdtel.Text & _
            "',mdemail = '" & mdemail.Text.Trim & _
            "',pnetwork = '" & pnetwork.SelectedValue.Trim & _
            "',sectortype = '" & Me.sectortype.SelectedValue & _
            "',paidtodate = '" & Me.paidtodate.Text & _
            "',hcpplan = '" & Me.hcpplan.SelectedValue & "' where  hcpid = '" & hcpid.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Save Sucessfully")
                saveaudit("Update record for code: " + Trim(hcpid.Text) + " In " + Me.Text)
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        saveailmentvalues()
        Loadnewilnessgrid()
        LOANDCOMBOSERACH()
    End Sub
    Public Sub clearrec()
        'MsgBox("CLEAR")
        Me.hcpid.Focus()
        names.Text = ""
        dregister.Text = ""
        active.Checked = False
        NHIS.Text = ""
        'LGA.SelectedIndex = -1
        'state.SelectedIndex = -1
        'country.SelectedIndex = -1
        'pmethod.SelectedIndex = -1
        'pnetwork.SelectedIndex = -1
        ',lpay,paidtodate
        lpay.Text = 0.0
        paidtodate.Text = 0.0
        tel.Text = ""
        email.Text = ""

        website.Text = ""
        address.Text = ""
        'glcode.SelectedIndex = -1
        'bank.SelectedIndex = -1
        bankbranch.Text = ""
        accid.Text = ""
        sortcode.Text = ""
        Mdnames.Text = ""
        mdtel.Text = ""
        mdemail.Text = ""
        'sectortype.SelectedIndex = -1
        'hcpplan.SelectedIndex = -1

        Dim T As Integer
        For T = T To enrolleehcp.RowCount - 1
            enrolleehcp.Rows.Clear()
        Next

        'Dim TT As Integer
        'For TT = TT To ailmentgrid.RowCount - 1
        '    ailmentgrid.Rows.Clear()
        'Next
    End Sub
    Private Sub enablecontrols()
        Enabled = True
        Me.hcpid.Focus()
        names.Enabled = True
        dregister.Enabled = True
        active.Enabled = True
        NHIS.Enabled = True
        LGA.Enabled = True
        state.Enabled = True
        country.Enabled = True
        pmethod.Enabled = True
        pnetwork.Enabled = True
        tel.Enabled = True
        email.Enabled = True
        website.Enabled = True
        address.Enabled = True
        glcode.Enabled = True
        bank.Enabled = True
        bankbranch.Enabled = True
        accid.Enabled = True
        sortcode.Enabled = True
        Mdnames.Enabled = True
        mdtel.Enabled = True
        mdemail.Enabled = True
        sectortype.Enabled = True
    End Sub

    Private Sub disablecontrols()
        '  Enabled = False
        names.Enabled = False
        dregister.Enabled = False
        active.Enabled = False
        NHIS.Enabled = False
        LGA.Enabled = False
        state.Enabled = False
        country.Enabled = False
        pmethod.Enabled = False
        pnetwork.Enabled = False
        tel.Enabled = False
        email.Enabled = False
        website.Enabled = False
        address.Enabled = False
        glcode.Enabled = False
        bank.Enabled = False
        bankbranch.Enabled = False
        accid.Enabled = False
        sortcode.Enabled = False
        Mdnames.Enabled = False
        mdtel.Enabled = False
        mdemail.Enabled = False
        sectortype.Enabled = False
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

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Sub loadailmentcodecombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select code1,descr from Ailmenttypedefault order by code1"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ailment.DataSource = ds.Tables(0)
            ailment.ValueMember = "code1"
            ailment.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
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
            MDIParent1.statusmsg.Text = "Can not open connection ! "
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
            LGA.DataSource = ds.Tables(0)
            LGA.ValueMember = "code1"
            LGA.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
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
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
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
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
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
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
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
            MDIParent1.statusmsg.Text = "Can not open connection ! "
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
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Sub loadpnetworkcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F14" & "'"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            pnetwork.DataSource = ds.Tables(0)
            pnetwork.ValueMember = "code1"
            pnetwork.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Private Sub hcpid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hcpid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not hcpid.Text = String.Empty) Then
                LoadRecord()
                names.Focus()
            End If
        End If
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
        Dim gg2 As String = "SELECT enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dofb,sex,tel,email,NHIS,ogaid,sdate FROM enrolleetab where" _
                             & " RTRIM(hcpid) = '" & Me.hcpid.Text.Trim & "'"

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
                        '  enrolleehcp.Refresh()
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
    Sub Loadnewilnessgrid()
        'MessageBox.Show("loading service charge")
        Try
            Dim i2 As Integer
            For i2 = i2 To ailmentgrid.RowCount - 1
                ailmentgrid.Rows.Clear()
            Next
            Dim gg2 As String = "select code1,descr,AMOUNT from Ailmenttypedefault order by code1,descr desc"


            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = ailmentgrid.Rows.Add
                       
                            ailmentgrid.Rows(row).Cells(0).Value = r(0)
                            ailmentgrid.Rows(row).Cells(1).Value = r(1)
                            ailmentgrid.Rows(row).Cells(2).Value = r(2)

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
    Sub Loadilnessgrid()
        ''   MessageBox.Show("load exist")
        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd3 As SqlCommand = CCNN.CreateCommand
        '        Cd3.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Dim i As Integer
        '        ' MsgBox(Payvalgrid.RowCount)
        '        If ailmentgrid.RowCount > 0 Then
        '            For i = 0 To ailmentgrid.RowCount - 1
        '                ' MessageBox.Show(Payvalgrid.Rows(i).Cells(0).Value)
        '                '   Dim picc As String = ailmentgrid.Rows(i).Cells(0).Value
        '                Cd3.CommandText = "select code,descr,amount,hcpid FROM hcpailmenttab where RTRIM(hcpid) = '" & RTrim(hcpid.Text) & "'"
        '                Dim rr As SqlDataReader = Cd3.ExecuteReader
        '                rr.Read()
        '                ailmentgrid.Rows(i).Cells(0).Value = rr(0)
        '                ailmentgrid.Rows(i).Cells(1).Value = rr(1)
        '                ailmentgrid.Rows(i).Cells(2).Value = rr(2)
        '                rr.Close()
        '            Next
        '        End If

        '        Me.Refresh()
        '        '  MessageBox.Show("default Save Sucessfully")
        '    End Using

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in hcpailmenttab Table")
        'End Try

        Try
            Dim i2 As Integer
            For i2 = i2 To ailmentgrid.RowCount - 1
                ailmentgrid.Rows.Clear()
            Next
            Dim gg2 As String = "select code,descr,amount,hcpid FROM hcpailmenttab where RTRIM(hcpid) = '" & RTrim(hcpid.Text) & "'"
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = ailmentgrid.Rows.Add
                        ailmentgrid.Rows(row).Cells(0).Value = r(0)
                        ailmentgrid.Rows(row).Cells(1).Value = r(1)
                        ailmentgrid.Rows(row).Cells(2).Value = r(2)
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

    Sub saveailmentvalues()

        cSQL = "DELETE FROM hcpailmenttab WHERE" _
          & " hcpid = '" & Me.hcpid.Text.Trim & "'"
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

        Try

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                CCNN.Open()
                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If ailmentgrid.RowCount > 0 Then
                    For i = 0 To ailmentgrid.RowCount - 1
                        '  MessageBox.Show(ailmentgrid.Rows(i).Cells(0).Value)
                        Cd3.CommandText = "insert into hcpailmenttab(code,descr,amount,hcpid) values('" & ailmentgrid.Rows(i).Cells(0).Value & "','" & ailmentgrid.Rows(i).Cells(1).Value & "','" & Val(ailmentgrid.Rows(i).Cells(2).Value) & "','" & hcpid.Text & "')"
                        Cd3.ExecuteNonQuery()
                    Next
                End If
                Me.Refresh()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub bank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bank.SelectedIndexChanged
        bankbranch.Text = bank.Text
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        Loadnewilnessgrid()
        hcpid.Enabled = True
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
        Loadnewilnessgrid()
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

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    Try

    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd3 As SqlCommand = CCNN.CreateCommand
    '            Cd3.CommandType = CommandType.Text
    '            CCNN.Open()
    '            Dim i As Integer

    '            ' MsgBox(Payvalgrid.RowCount)
    '            If ailmentgrid.RowCount > 0 Then
    '                For i = 0 To ailmentgrid.RowCount - 1
    '                    ' MessageBox.Show(Payvalgrid.Rows(i).Cells(0).Value)
    '                    Dim picc As String = ailmentgrid.Rows(i).Cells(0).Value
    '                    Cd3.CommandText = "select code,descr,amount,hcpid FROM hcpailmenttab where hcpid = '" & hcpid.Text.Trim & "'" & "and" & " code = '" & ailment.SelectedValue & "'"
    '                    Dim rr As SqlDataReader = Cd3.ExecuteReader
    '                    If rr.HasRows Then
    '                        rr.Read()
    '                        'ailmentgrid.Rows(i).Cells(2).Value = rr(2)
    '                        'rr.Close()
    '                    Else
    '                        savenewailment()
    '                    End If
    '                    rr.Close()
    '                Next
    '            End If

    '            Me.Refresh()
    '            '  MessageBox.Show("default Save Sucessfully")
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Occurs in hcpailmenttab Table")
    '    End Try
    'End Sub
    'Sub savenewailment()
    '    MessageBox.Show("Adding New Ailment")
    '    Dim sumStr As String = "INSERT INTO hcpailmenttab(code,descr,amount,hcpid) VALUES('" & ailment.SelectedValue & "','" & RTrim(ailment.Text) & "','" & 0.0 & "','" & hcpid.Text & "')"
    '    Try
    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd2 As SqlCommand = CCNN.CreateCommand
    '            Cd2.CommandText = sumStr
    '            Cd2.CommandType = CommandType.Text
    '            CCNN.Open()
    '            Cd2.ExecuteNonQuery()
    '        End Using

    '    Catch ex As Exception
    '        '   Me.statuspoint.Text = ex.Message
    '    Finally
    '    End Try

    '    Loadnewilnessgrid()


    '    Try

    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd3 As SqlCommand = CCNN.CreateCommand
    '            Cd3.CommandType = CommandType.Text
    '            CCNN.Open()
    '            Dim i As Integer
    '            ' MsgBox(Payvalgrid.RowCount)
    '            If ailmentgrid.RowCount > 0 Then
    '                For i = 0 To ailmentgrid.RowCount - 1
    '                    '  MessageBox.Show(ailmentgrid.Rows(i).Cells(0).Value)
    '                    Cd3.CommandText = "insert into hcpailmenttab(code,descr,amount,hcpid) values('" & ailmentgrid.Rows(i).Cells(0).Value & "','" & ailmentgrid.Rows(i).Cells(1).Value & "','" & Val(ailmentgrid.Rows(i).Cells(2).Value) & "','" & hcpid.Text & "')"
    '                    Cd3.ExecuteNonQuery()
    '                Next
    '            End If
    '            Me.Refresh()
    '            clearrec()
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged

        Try
            clearrec()
            hcpid.Text = Searchtool.SelectedValue.ToString
            hcpid.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub glcode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles glcode.SelectedIndexChanged
        Try
            glcode2.Text = glcode.SelectedValue.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ailmentgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ailmentgrid.CellContentClick

    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim lrevar As New DownupWiz
        lrevar.gstring1 = " Select hcpid,Names,dregister as Date_register,active as Inactive,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid as accountid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan,pnetwork FROM Hcptab order by hcpid"
        lrevar.ltitle.Text = "Hospital Listing"
        lrevar.BindGrid()
        lrevar.MdiParent = MDIParent1
        lrevar.Show()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Loadnewilnessgrid()
        saveaudit("Update Service type record for HCP code: " + Trim(hcpid.Text) + " In " + Me.Text)
    End Sub
    Sub gg()
        Try
           
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click


        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim DSQL As String = "Select hcpid from hcptab"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()
                        UpdatePayvalues(r(0))
                    Loop
                Else
                    MDIParent1.statusmsg2.Text = "No hcptab Record Selected"
                End If
            End Using
        Catch ex As Exception

        End Try
        MessageBox.Show("finished")
    End Sub
    Sub UpdatePayvalues(ByVal hcpidvar As String)
        Try

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                CCNN.Open()
                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If ailmentgrid.RowCount > 0 Then
                    For i = 0 To ailmentgrid.RowCount - 1
                        '  MessageBox.Show(ailmentgrid.Rows(i).Cells(0).Value)
                        Cd3.CommandText = "insert into hcpailmenttab(code,descr,amount,hcpid) values('" & ailmentgrid.Rows(i).Cells(0).Value & "','" & ailmentgrid.Rows(i).Cells(1).Value & "','" & Val(ailmentgrid.Rows(i).Cells(2).Value) & "','" & hcpidvar & "')"
                        Cd3.ExecuteNonQuery()
                    Next
                End If
                Me.Refresh()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
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

    Private Sub hcpid_TextChanged(sender As Object, e As EventArgs) Handles hcpid.TextChanged

    End Sub

    Private Sub hcpid_Validating(sender As Object, e As CancelEventArgs) Handles hcpid.Validating
        If (Not hcpid.Text = String.Empty) Then
            LoadRecord()
            names.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim str As String = TextBox1.Text

            If Me.TextBox1.Text.Trim(" ") = " " Then
            Else
                For i As Integer = 0 To ailmentgrid.Rows.Count - 1
                    For j As Integer = 0 To Me.ailmentgrid.Rows(i).Cells.Count - 1
                        If ailmentgrid.Item(j, i).Value.ToString().ToLower.StartsWith(str.ToLower) Then
                            ailmentgrid.Rows(i).Selected = True
                            ailmentgrid.CurrentCell = ailmentgrid.Rows(i).Cells(j)
                            Exit Try
                        End If
                    Next
                Next i
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class