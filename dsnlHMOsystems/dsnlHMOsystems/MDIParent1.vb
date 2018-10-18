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

Public Class MDIParent1
    Dim scrolledString As String = "                    ** Data Sciences HMO Manager -- a Data Sciences Health Maintenance Organization Package. For DSNL Support Call: Lekan on 08052254262  ........."
    Dim myStrings(scrolledString.Length - 1) As String
    Dim position As Integer = -1
    Public gstrinsql1 As String
    Public gstrinsql4 As String
    Public thirtyy As Integer
    Public thirtyy2 As Integer
    Public plink As String
    'cmd.CommandText = "INSERT INTO Items (Item_Name, Item_Type, Date_Added)" & _
    '                 "VALUES(?, ?, ?)"
    Sub saveaudit()
        '  Dim uidd2 As String = CType(Session.Item("passid"), String)
        Dim date11 As DateTime
        Dim SWMODE As String = "Exit system"
        date11 = Now
        Dim sumStr As String = "INSERT INTO audittab(userid, action1, period) VALUES('" & My.Settings.loginid & "','" & SWMODE & "','" & date11 & "')"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = ccnn.CreateCommand
                Cd2.CommandText = sumStr
                Cd2.CommandType = CommandType.Text
                ccnn.Open()
                Cd2.ExecuteNonQuery()
                '   CCNN.Close()
            End Using

        Catch ex As Exception
            Me.statusmsg.Text = ex.Message
        Finally
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        'aboutfrm
        Dim abt As New Aboutfrm2
        abt.MdiParent = Me
        abt.StartPosition = FormStartPosition.CenterScreen
        abt.Show()


    End Sub

    Private Sub MDIParent1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        loaddefaultpicture()
        My.Settings.loginname = ""
        Dim cSQL As String = "UPDATE useracct SET" _
       & " staffonline = '" & False & "'" & " WHERE" & " userid = '" & My.Settings.loginid & "' "
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

    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT rptpath,photopath,docfolder,imgaepath,paymentapprovaltrig,bcodedidgit,autocode,companyid,claimbatchcode,invoicepaytrig,enrolleexptrig,portallink,paymentapprovaltrig,birthdaytrig,cursymbol,deprciatn,invoiceno,accountname,bankname,branch,accountno,sortno,autorecieptno,paytcode,payref,ContExpirllert FROM digitsettings"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(4) Then gstrinsql1 = r(4)
                    If Not r.IsDBNull(11) Then plink = r(11)
                    thirtyy = Val(r(10))
                    thirtyy2 = Val(r(9))
                    gstrinsql4 = r(25)
                    Me.Refresh()
                    r.Close()
                End If
            End Using
            '   MessageBox.Show(plink)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        enrollelist()
        Dim labelSize As Size

        labelSize.Width = 15000

        labelSize.Height = 13

        Label13.MinimumSize = labelSize

        Label13.MaximumSize = labelSize

        Label13.Size = labelSize



        Call ScrollType2(scrolledString)

        'Make this value smaller say as low as 25 for

        'a faster scroll effect.

        Timer1.Interval = 200

        Timer1.Enabled = True

        Timer1.Start()

        Try
            Using CCNN As New SqlClient.SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlClient.SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT company,code1 FROM companytab"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlClient.SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    '  coyto.Text = Trim(r(0))
                    compcode = Trim(r(1))
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()
        Backpanel1.Visible = False
        Loadmessagepanel.Show()
        Loadmessagepanel.Width = 540
        Loadmessagepanel.Height = 637
        Loadmessagepanel.Dock = DockStyle.Left
        COYNAME.Visible = False
        COYADD1.Visible = False
        COYADD2.Visible = False
        COYPICS.Visible = False

        MenuStrip.Enabled = False
        Me.Text = "Dsnl HMO Manager " & " Date and Time: " & My.Computer.Clock.LocalTime & "    Welcome :  " & My.Settings.loginname
        Dim lg1 As New LoginForm2
        lg1.MdiParent = Me
        lg1.StartPosition = FormStartPosition.CenterScreen
        lg1.Show()


       


        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select hcpid,rtrim(Names)  as names from Hcptab order by Names"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            hcpp.DataSource = ds.Tables(0)
            hcpp.ValueMember = "hcpid"
            hcpp.DisplayMember = "names"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        loadpnetworkcombo()
        loadgriddata()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT company,address,address2,picpath,code1,backgroundimg FROM companytab"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    lto.Text = Trim(r(0))
                    COYNAME.Text = Trim(r(0))
                    COYADD1.Text = Trim(r(1))
                    COYADD2.Text = Trim(r(2))
                    'coypic2.Text = Trim(r(3))
                    'coy3.Text = Trim(r(5))
                    My.Settings.companyname = Trim(r(0))
                    My.Settings.companyadd1 = Trim(r(1))
                    My.Settings.companyadd2 = Trim(r(2))
                    My.Settings.companyid = Trim(r(4))
                    Dim data As Byte() = DirectCast(r("picpath"), Byte())
                    Dim ms As New MemoryStream(data)
                    COYPICS.Image = Image.FromStream(ms)
                End If
                Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' runenrolleetrigerexepire()

        Me.Refresh()
    End Sub
    Sub LOADCOMPPIC()
        'MessageBox.Show("loadcompimg")
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)
                cn.Open()
                Dim sql As String = "Select * from companytab"
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    Dim data As Byte() = DirectCast(dr("picpath"), Byte())
                    Dim ms As New MemoryStream(data)
                    COYPICS.Image = Image.FromStream(ms)
                    MessageBox.Show("loadcompimg")
                    ''---------------------------  Me.BackgroundImage = Image.FromFile(coy3.Text)
                    'Dim data2 As Byte() = DirectCast(dr("backgroundimg"), Byte())
                    'Dim ms2 As New MemoryStream(data2)
                    'Me.BackgroundImage = Image.FromStream(ms2)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '  Me.statuspoint.Text = ex.Message
        Finally
        End Try
    End Sub
    Sub Hcpapproval()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT distinct Batchcode,hcpname as HCP,tdate as Date_Posted FROM claimsinpute WHERE" _
                & " postedforapprove = '" & True & "' and allertstop = '" & False & "' and rtrim(appsendto) = '" & RTrim(My.Settings.loginid) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    runpayapprovaltriger()
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()
    End Sub
    Sub abttoexpiredenrollee()
        '' MessageBox.Show("Enrollees Expired 1")
        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd As SqlCommand = CCNN.CreateCommand
        '        Cd.CommandText = "SELECT * FROM enrolleetab WHERE" _
        '        & " active = '" & False & "' and day(edate) <= '" & thirtyy & "'"
        '        Cd.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Dim r As SqlDataReader = Cd.ExecuteReader
        '        If r.HasRows Then
        '            r.Read()
        '            '  MessageBox.Show("Enrollees Expired 2")
        '            runenrolleetrigerexepire()
        '        End If
        '        Me.Refresh()
        '        r.Close()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'Me.Refresh()
    End Sub
    Sub runenINVOICEtrigercall()
        Dim oldDate As Date
        Dim oldDay As Integer
        ' Assign a date using standard short format.
        oldDate = Today
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT billcode,descr,tdate,netdue FROM salesinvoice WHERE '" & oldDay & "' - day(tdate) > '" & thirtyy2 & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    '  MessageBox.Show("Enrollees Expired 2")
                    runenINVOICEtriger()
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()
    End Sub
    Sub loadgriddata()
        Dim i2 As Integer
        For i2 = i2 To audittabgrid.RowCount - 1
            audittabgrid.Rows.Clear()
        Next
        Dim gg2 As String = "select userid,action1,period from audittab order by period desc "

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = audittabgrid.Rows.Add
                        audittabgrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        audittabgrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        audittabgrid.Rows(row).Cells(2).Value = RTrim(r(2))
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            ' MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub loaddefaultpicture()
        ' '' ''SPIX2.Text = My.Settings.imgaepath + "\" + "loginimg3.jpg"
        '    Dim imgdefau As String = My.Settings.imgaepath + "\" + "loginimg3.jpg"

        ' '' ''Me.staffpix.Image = Image.FromFile(SPIX2.Text)
        ' ""
        'MessageBox.Show("IN")
        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd As SqlCommand = CCNN.CreateCommand
        '        Cd.CommandText = "SELECT staffid,spicture FROM stafftab WHERE" _
        '        & " staffid = '" & My.Settings.loginid & "'"
        '        Cd.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Dim r As SqlDataReader = Cd.ExecuteReader
        '        If r.HasRows Then
        '            r.Read()
        '            MessageBox.Show(Trim(r(1)))
        '            SPIX2.Text = Trim(r(1))
        '            staffpix.Image = Image.FromFile(SPIX2.Text)
        '            '
        '        End If
        '        Me.Refresh()
        '        r.Close()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
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

        Label13.Text = testString

        'You could add this line to scroll the FORM title text too!!

        'Me.Text = testString

        If position = UBound(myStrings) Then position = -1

    End Sub
    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        loaddefaultpicture()
        '  MessageBox.Show(My.Settings.loginid)
        Dim cSQL As String = "UPDATE useracct SET" _
       & " staffonline = '" & False & "'" & " WHERE" & " userid = '" & My.Settings.loginid & "' "
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

        Backpanel1.Visible = False
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        ChildForm.Close()
        COYNAME.Visible = False
        COYADD1.Visible = False
        COYADD2.Visible = False
        COYPICS.Visible = False
        Usernames2.Text = "User Logon Name"
        My.Settings.loginid = ""
        My.Settings.loginname = ""
        Me.Text = ""
        Loadmessagepanel.Visible = True
        'SetUpToolStripMenuItem.Enabled = False
        'OptionsToolStripMenuItem.Enabled = False
        '' MarkerManagerToolStripMenuItem.Enabled = False
        'AuditTrailSettingsToolStripMenuItem.Enabled = False
        'ImportUtilityToolStripMenuItem.Enabled = False
        '' SystemReportToolStripMenuItem.Enabled = False
        ''UserAccountToolStripMenuItem.Enabled = False


        CompanySetupToolStripMenuItem.Enabled = False
        SetUpToolStripMenuItem.Enabled = False
        ToolStripMenuItem1.Enabled = False
        EnrollToolStripMenuItem.Enabled = False
        OrganizationInformationToolStripMenuItem.Enabled = False
        HCPRegisterToolStripMenuItem.Enabled = False
        HCPPaymentRegisterVettingToolStripMenuItem.Enabled = False
        PaymentApprovalsListToolStripMenuItem.Enabled = False
        TreatmentAuthorizationToolStripMenuItem1.Enabled = False
        StaffInformationToolStripMenuItem.Enabled = False
        JobAppraisalToolStripMenuItem.Enabled = False
        LeaveManagementToolStripMenuItem.Enabled = False
        StaffBirthdayToolStripMenuItem.Enabled = False
        AccountToolStripMenuItem.Enabled = False
        ChartOfAccountsToolStripMenuItem.Enabled = False
        AccountingPeriodSetupToolStripMenuItem.Enabled = False
        OpeningBalanceToolStripMenuItem.Enabled = False
        BankToolStripMenuItem.Enabled = False
        AccountGroupToolStripMenuItem.Enabled = False
        PayrollToolStripMenuItem.Enabled = False
        FixedAssetModuleToolStripMenuItem.Enabled = False
        ReceivableDebtorsModuleToolStripMenuItem.Enabled = False
        PayableCreditorsModuleToolStripMenuItem.Enabled = False
        GeneralLedgerModuleToolStripMenuItem.Enabled = False
        DetailReportDailogToolStripMenuItem.Enabled = False
        ListReportsToolStripMenuItem.Enabled = False
        OptionsToolStripMenuItem.Enabled = False
        UserAccountToolStripMenuItem.Enabled = False
        AuditTrailSettingsToolStripMenuItem.Enabled = False
        ImportUtilityToolStripMenuItem.Enabled = False
        'EnrollToolStripMenuItem1.Enabled = False
        GenerateToolStripMenuItem.Enabled = False

        Dim opt1 As New LoginForm2
        opt1.MdiParent = Me
        opt1.StartPosition = FormStartPosition.CenterScreen
        opt1.Show()
    End Sub

    Sub activatemenus()
        '  SystemReportToolStripMenuItem.Enabled = False
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT userid,menucode,menuname,available FROM usersmenu WHERE" _
                & " userid = '" & Trim(My.Settings.loginid) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r4 As SqlDataReader = Cd.ExecuteReader
                If r4.HasRows = True Then
                    While r4.Read
                        If Trim(r4(1)) = "M1" Then
                            CompanySetupToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M2" Then
                            SetUpToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M3" Then
                            ToolStripMenuItem1.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M4" Then
                            EnrollToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M5" Then
                            OrganizationInformationToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M6" Then
                            HCPRegisterToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M7" Then
                            HCPPaymentRegisterVettingToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M8" Then
                            PaymentApprovalsListToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M9" Then
                            TreatmentAuthorizationToolStripMenuItem1.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M10" Then
                            StaffInformationToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M11" Then
                            JobAppraisalToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M12" Then
                            LeaveManagementToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M13" Then
                            StaffBirthdayToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M14" Then
                            AccountToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M15" Then
                            ChartOfAccountsToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M16" Then
                            AccountingPeriodSetupToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M17" Then
                            OpeningBalanceToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M18" Then
                            BankToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M19" Then
                            AccountGroupToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M20" Then
                            PayrollToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M21" Then
                            FixedAssetModuleToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M22" Then
                            ReceivableDebtorsModuleToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M23" Then
                            PayableCreditorsModuleToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M25" Then
                            GeneralLedgerModuleToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M26" Then
                            DetailReportDailogToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M27" Then
                            ListReportsToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M28" Then
                            OptionsToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M29" Then
                            UserAccountToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M30" Then
                            AuditTrailSettingsToolStripMenuItem.Enabled = r4(3)
                        End If
                        If Trim(r4(1)) = "M31" Then
                            ImportUtilityToolStripMenuItem.Enabled = r4(3)
                        End If
                        'If Trim(r4(1)) = "M32" Then
                        '    EnrollToolStripMenuItem1.Enabled = r4(3)
                        'End If
                        If Trim(r4(1)) = "M33" Then
                            GenerateToolStripMenuItem.Enabled = r4(3)
                        End If
                    End While
                Else
                    MessageBox.Show("Contact your Admin to setup your Account's Rights")
                    Exit Sub
                    End
                End If
                Me.Refresh()
                CCNN.Close()
                r4.Close()
                '  UserAccountToolStripMenuItem.Enabled = True
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim opt1 As New changepassword
        opt1.MdiParent = Me
        ' opt1.Text = "Change Password "
        opt1.StartPosition = FormStartPosition.CenterScreen
        opt1.Show()
    End Sub
    Private Sub DepartmentSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentSetupToolStripMenuItem.Click
        My.Settings.fsave = "F3"
        My.Settings.OPTRR = "F3"
        My.Settings.optname = "Department Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub


    Private Sub AuditTrailSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditTrailSettingsToolStripMenuItem.Click
        Dim audittrail2 As New audittrail
        audittrail2.MdiParent = Me
        '  audittrail2.Text = "System Audit "
        audittrail2.Show()
    End Sub

    Private Sub CompanySetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanySetupToolStripMenuItem.Click
        Dim company2 As New company
        company2.MdiParent = Me
        ' company2.Text = "Company Setup "
        company2.Show()
    End Sub

    Private Sub PositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PositionToolStripMenuItem.Click
        My.Settings.fsave = "F5"
        My.Settings.OPTRR = "F5"
        My.Settings.optname = "Position Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub BranchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchToolStripMenuItem.Click
        My.Settings.fsave = "F6"
        My.Settings.OPTRR = "F6"
        My.Settings.optname = "Branch Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryToolStripMenuItem.Click
        My.Settings.fsave = "F8"
        My.Settings.OPTRR = "F8"
        My.Settings.optname = "Category Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub PFAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PFAToolStripMenuItem.Click
        My.Settings.fsave = "F9"
        My.Settings.OPTRR = "F9"
        My.Settings.optname = "PFA Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub AssetTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssetTypeToolStripMenuItem.Click
        My.Settings.fsave = "F10"
        My.Settings.OPTRR = "F10"
        My.Settings.optname = "Asset Type"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub RelationshipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelationshipToolStripMenuItem.Click
        My.Settings.fsave = "F7"
        My.Settings.OPTRR = "F7"
        My.Settings.optname = "Relationship Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub GradeLevelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GradeLevelToolStripMenuItem.Click
        My.Settings.fsave = "F4"
        My.Settings.OPTRR = "F4"
        My.Settings.optname = "Grade Level Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub LGAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LGAToolStripMenuItem.Click
        My.Settings.fsave = "F2"
        My.Settings.OPTRR = "F2"
        My.Settings.optname = "LGA Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub StateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StateToolStripMenuItem.Click
        My.Settings.fsave = "F1"
        My.Settings.OPTRR = "F1"
        My.Settings.optname = "State Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub CountryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountryToolStripMenuItem.Click
        My.Settings.fsave = "F11"
        My.Settings.OPTRR = "F11"
        My.Settings.optname = "Country Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub

    Private Sub ProductsAndServicesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsAndServicesToolStripMenuItem.Click
        My.Settings.fsave = "F12"
        My.Settings.OPTRR = "F12"
        My.Settings.optname = "Product and Services Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        ' codesetupp.Text = "Department Setup "
        codesetupp.Show()
    End Sub
    Private Sub HealthCarePlanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HealthCarePlanToolStripMenuItem.Click
        Dim premiumplanvar As New premiumplan
        premiumplanvar.MdiParent = Me
        premiumplanvar.Show()
    End Sub
    Private Sub ProviderNetworkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProviderNetworkToolStripMenuItem.Click
        My.Settings.fsave = "F14"
        My.Settings.OPTRR = "F14"
        My.Settings.optname = "Provider Network Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        codesetupp.Show()
    End Sub
    Private Sub IlmentTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IlmentTypeToolStripMenuItem.Click
        Dim Ailmenttypedefaultvar As New Ailmenttypedefault
        Ailmenttypedefaultvar.MdiParent = Me
        Ailmenttypedefaultvar.Show()
    End Sub

    Private Sub EnrollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnrollToolStripMenuItem.Click
        Dim enrolleevar As New enrolleefrm
        enrolleevar.MdiParent = Me
        enrolleevar.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        loaddefaultpicture()
        Dim cSQL As String = "UPDATE useracct SET" _
       & " staffonline = '" & False & "'" & " WHERE" & " userid = '" & My.Settings.loginid & "' "
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
        End
    End Sub
    Sub updateonlinelist()
        '  MessageBox.Show("in")
        Dim i2 As Integer
        For i2 = i2 To answersheettab.RowCount - 1
            answersheettab.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT userid,names,staffonline FROM useracct WHERE" _
                    & " staffonline = '" & True & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                    End While
                End If
                answersheettab.Refresh()
                Me.Refresh()
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Private Sub UserAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserAccountToolStripMenuItem.Click
        Dim useraccountvar As New useraccount
        useraccountvar.MdiParent = Me
        useraccountvar.Show()
    End Sub


    Private Sub HCPRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HCPRegisterToolStripMenuItem.Click
        Dim hcpsetupvar As New hcpsetup
        hcpsetupvar.MdiParent = Me
        hcpsetupvar.Show()
    End Sub

    Private Sub BankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankToolStripMenuItem.Click
        Dim Banksetupvar As New Banksetup
        Banksetupvar.MdiParent = Me
        Banksetupvar.Show()
    End Sub

    Private Sub OrganizationInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrganizationInformationToolStripMenuItem.Click
        Dim Vendorsregvar As New Vendorsreg
        Vendorsregvar.MdiParent = Me
        Vendorsregvar.Show()
    End Sub

    Private Sub StaffInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffInformationToolStripMenuItem.Click
        Dim Staffinfovar As New Staffinfo
        Staffinfovar.MdiParent = Me
        Staffinfovar.Show()
    End Sub

    Private Sub UtilizationFeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilizationFeesToolStripMenuItem.Click
        Dim Utilisationfeesgenvar As New Utilisationfeesgen
        Utilisationfeesgenvar.MdiParent = Me
        Utilisationfeesgenvar.Show()
    End Sub

    Private Sub AccountGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountGroupToolStripMenuItem.Click
        My.Settings.fsave = "F16"
        My.Settings.OPTRR = "F16"
        My.Settings.optname = "Account Group Setup"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        codesetupp.Show()
    End Sub

    Private Sub ChartOfAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChartOfAccountsToolStripMenuItem.Click
        Dim Chartofaccountvar As New Chartofaccount
        Chartofaccountvar.MdiParent = Me
        Chartofaccountvar.Show()
    End Sub


    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub OpenStatusBarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenStatusBarToolStripMenuItem.Click
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "SELECT userid,password,status,names,appraise,admin,approve FROM useracct WHERE" _
                & " userid = '" & My.Settings.loginid & "'" '  AND scode = '" &  & "'"

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    r.Read()
                    If r(2) = True Then
                        Backpanel1.Visible = True
                    Else
                        Backpanel1.Visible = False
                    End If
                End If
            End Using
        Catch ex As Exception
            ' Me.statuspoint.Text = ex.Message

        End Try
    End Sub

    Private Sub OpeningBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpeningBalanceToolStripMenuItem.Click
        'Dim Openningbalvar As New Openningbal
        'Openningbalvar.MdiParent = Me
        'Openningbalvar.Show()
    End Sub

    Private Sub AccountingPeriodSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountingPeriodSetupToolStripMenuItem.Click
        Dim Accountingperiodvar As New Accountingperiod
        Accountingperiodvar.MdiParent = Me
        Accountingperiodvar.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        updateonlinelist()
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Backpanel1.Visible = False
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        'If Panel3.Visible = False Then
        '    Panel3.Visible = True
        'Else
        '    Panel3.Visible = False
        'End If

        If Panel4.Visible = False Then
            Panel4.Visible = True
        Else
            Panel4.Visible = False
        End If

        If Panel5.Visible = False Then
            Panel5.Visible = True
        Else
            Panel5.Visible = False
        End If

        'If Backpanel1.Width = 1362 Then
        '    Backpanel1.Dock = DockStyle.Left
        '    Backpanel1.Width = 175

        'Else
        '    Backpanel1.Dock = DockStyle.Fill
        '    Backpanel1.Width = 1362

        'End If
        If Backpanel1.Dock = DockStyle.Fill Then
            Backpanel1.Dock = DockStyle.Left
            Backpanel1.Width = 90
        Else
            Backpanel1.Dock = DockStyle.Fill
            Backpanel1.Width = 1362
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim Settingsvar As New Settings
        Settingsvar.MdiParent = Me
        Settingsvar.Show()
    End Sub

    Private Sub StaffBirthdayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffBirthdayToolStripMenuItem.Click
        Dim Staffbirthdayvar As New Staffbirthday
        Staffbirthdayvar.MdiParent = Me
        Staffbirthdayvar.Show()
    End Sub

    Private Sub HCPPaymentRegisterVettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HCPPaymentRegisterVettingToolStripMenuItem.Click
        Dim claimsregistervar As New claimsregister
        claimsregistervar.MdiParent = Me
        claimsregistervar.Show()
    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs) Handles Panel16.Paint

    End Sub

    Private Sub PaymentApprovalsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentApprovalsListToolStripMenuItem.Click
        Dim claimspayapprvar As New claimspayappr
        claimspayapprvar.MdiParent = Me
        claimspayapprvar.Show()
    End Sub



    Private Sub LeaveManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeaveManagementToolStripMenuItem.Click
        Dim leavemgtvar As New leavemgt
        leavemgtvar.MdiParent = Me
        leavemgtvar.Show()
    End Sub

    Private Sub TreatmentAuthorizationToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PayrollDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayrollDetailsToolStripMenuItem.Click
        Dim payandloanvar As New payandloan
        payandloanvar.MdiParent = Me
        payandloanvar.Show()
    End Sub

    Private Sub TreatmentAuthorizationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TreatmentAuthorizationToolStripMenuItem1.Click
        Dim autogencodevar As New autogencode
        autogencodevar.MdiParent = Me
        autogencodevar.Show()
    End Sub

    Private Sub PayitemSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayitemSetupToolStripMenuItem.Click
        Dim payitemsvar As New payitems
        payitemsvar.MdiParent = Me
        payitemsvar.Show()
    End Sub

    Private Sub DetailReportDailogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailReportDailogToolStripMenuItem.Click
        Dim reportformvbvar As New reportformvb
        reportformvbvar.MdiParent = Me
        reportformvbvar.Show()
    End Sub


    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim enrolleevar As New enrolleefrm
        enrolleevar.MdiParent = Me
        enrolleevar.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim Vendorsregvar As New Vendorsreg
        Vendorsregvar.MdiParent = Me
        Vendorsregvar.Show()
    End Sub

    Private Sub ViewChartOfAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewChartOfAccountToolStripMenuItem.Click
        Dim hcpsetupvar As New hcpsetup
        hcpsetupvar.MdiParent = Me
        hcpsetupvar.Show()
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim Staffinfovar As New Staffinfo
        Staffinfovar.MdiParent = Me
        Staffinfovar.Show()
    End Sub

    Private Sub ViewSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSettingsToolStripMenuItem.Click
        Dim Settingsvar As New Settings
        Settingsvar.MdiParent = Me
        Settingsvar.Show()
    End Sub

    Private Sub ViewListWizardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewListWizardToolStripMenuItem.Click
        Dim Listresultvar As New Listresult

        Listresultvar.Show()
    End Sub

    Private Sub ViewReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewReportToolStripMenuItem.Click
        Dim reportformvbvar As New reportformvb
        reportformvbvar.MdiParent = Me
        reportformvbvar.Show()
    End Sub

    Private Sub ViewCustomerVendorFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCustomerVendorFormToolStripMenuItem.Click
        Dim CustvendSetupvar As New CustvendSetup
        CustvendSetupvar.MdiParent = Me
        CustvendSetupvar.Show()
    End Sub

    Private Sub FixedAssetModuleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixedAssetModuleToolStripMenuItem.Click
        Dim Asset_Registervar As New Asset_Register
        Asset_Registervar.MdiParent = Me
        Asset_Registervar.Show()
    End Sub

    Private Sub SalesDebtorInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesDebtorInvoiceToolStripMenuItem.Click

        Dim sales_invoicingvar As New sales_invoicing
        sales_invoicingvar.MdiParent = Me
        sales_invoicingvar.Show()

    End Sub



    Private Sub SalesReceiptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReceiptsToolStripMenuItem.Click
        Dim salesreceiptvar As New salesreceipt
        salesreceiptvar.MdiParent = Me
        salesreceiptvar.Show()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentToolStripMenuItem.Click
        Dim paymentvar As New payment
        paymentvar.MdiParent = Me
        paymentvar.Show()
    End Sub
    Sub enrollelist()
        'mtotal.Text = 0.0
        Dim i2 As Integer
        For i2 = i2 To enrolleehcp.RowCount - 1
            enrolleehcp.Rows.Clear()
        Next
        'Dim gg2 As String = "SELECT enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dofb,sex,tel,email,NHIS,ogaid,sdate FROM enrolleetab order by ogaid where" _
        '                             & " RTRIM(hcpid) = '" & Me.hcpid.Text.Trim & "'"
        Dim gg2 As String = "SELECT enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,tel,NHIS,ogaid,hcpid FROM enrolleetab order by hcpid"

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

                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()

    End Sub

    Private Sub hcpp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hcpp.SelectedIndexChanged
        mtotal.Text = 0.0
        Dim i2 As Integer
        For i2 = i2 To enrolleehcp.RowCount - 1
            enrolleehcp.Rows.Clear()
        Next
        'Dim gg2 As String = "SELECT enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dofb,sex,tel,email,NHIS,ogaid,sdate FROM enrolleetab order by ogaid where" _
        '                             & " RTRIM(hcpid) = '" & Me.hcpid.Text.Trim & "'"
        Dim gg2 As String = "SELECT enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,tel,NHIS,ogaid,hcpid FROM enrolleetab where" _
                & " RTRIM(hcpid) = '" & hcpp.SelectedValue.ToString.Trim & "'"
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
                        mtotal.Text = Val(mtotal.Text) + 1
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()



    End Sub

    Private Sub ogasearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pnetworksearch.SelectedIndexChanged
        htotal.Text = 0.0
        Dim i2 As Integer
        For i2 = i2 To hcpogaview.RowCount - 1
            hcpogaview.Rows.Clear()                                                        'ogaid,hcpid FROM enrolleetab
        Next
        'Dim gg2 As String = " Select a.hcpid,a.Names,a.dregister,a.active,a.NHIS,a.LGA,a.tel,a.email,b.ogaid FROM Hcptab a,enrolleetab b WHERE" _
        '        & " rtrim(b.ogaid) = '" & ogasearch.SelectedValue.ToString.Trim & "' and a."
        Dim gg2 As String = " Select hcpid,Names,dregister,active,NHIS,LGA,Mdnames,mdtel,mdemail FROM Hcptab WHERE" _
               & " RTRIM(pnetwork) = '" & RTrim(pnetworksearch.SelectedValue) & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = hcpogaview.Rows.Add
                        hcpogaview.Rows(row).Cells(0).Value = r(0)
                        hcpogaview.Rows(row).Cells(1).Value = r(1)
                        hcpogaview.Rows(row).Cells(2).Value = r(2)
                        hcpogaview.Rows(row).Cells(3).Value = r(3)
                        hcpogaview.Rows(row).Cells(4).Value = r(4)
                        hcpogaview.Rows(row).Cells(5).Value = r(5)
                        hcpogaview.Rows(row).Cells(6).Value = r(6)
                        hcpogaview.Rows(row).Cells(7).Value = r(7)
                        hcpogaview.Rows(row).Cells(8).Value = r(8)
                        htotal.Text = Val(htotal.Text) + 1
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Refresh()
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
            pnetworksearch.DataSource = ds.Tables(0)
            pnetworksearch.ValueMember = "code1"
            pnetworksearch.DisplayMember = "descr"
        Catch ex As Exception
            '    MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Private Sub ListReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListReportsToolStripMenuItem.Click
        Dim DownupWizvar As New DownupWiz
        DownupWizvar.MdiParent = Me
        DownupWizvar.Show()
    End Sub
    '************************************* Trigger Section ****************************************************************
    Sub runenINVOICEtriger()
        Dim oldDate As Date
        Dim oldDay As Integer
        ' Assign a date using standard short format.
        oldDate = Today
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        ' MessageBox.Show(oldDay)
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT invoiceno,descr,tdate,netdue FROM salesinvoice WHERE '" & oldDay & "' - day(tdate) > '" & thirtyy2 & "' and paid = '" & False & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Dim Trigervar As New trigerinvoicepay
                    Trigervar.gstring2 = "SELECT invoiceno,descr,tdate,netdue FROM salesinvoice WHERE '" & oldDay & "' - day(tdate) > '" & thirtyy2 & "' and paid = '" & False & "'"
                    Trigervar.Text = "Invoice still in Recievable"
                    Trigervar.MdiParent = Me
                    rptrangecode = thirtyy2
                    Trigervar.BindGrid()
                    Trigervar.Show()
                    '  reportcodee = "runpayapprovaltriger"
                Else

                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in trigerenrolle Trigger")
        End Try
    End Sub
    Sub runenrolleetrigerexepire()
        '  MessageBox.Show(Str(thirtyy))
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT enrolleeid,surname,firstname,email,nhis,sdate,edate,ogaid FROM enrolleetab WHERE" _
                        & " active = '" & False & "'  and DATEDIFF(day,'" & Date.Today & "',edate)  <=  '" & thirtyy & "' and DATEDIFF(day,'" & Date.Today & "',edate)  !>  '" & thirtyy & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Dim Trigervar As New trigerenrolle
                    Trigervar.gstring2 = "SELECT enrolleeid,surname,firstname,email,nhis,sdate,edate,ogaid FROM enrolleetab WHERE" _
                        & " active = '" & False & "'  and DATEDIFF(day,'" & Date.Today & "',edate)  <=  '" & thirtyy & "' and DATEDIFF(day,'" & Date.Today & "',edate)  !>  '" & thirtyy & "'"
                    Trigervar.Text = "Enrollees Due to Expired"
                    Trigervar.MdiParent = Me
                    rptnum = thirtyy
                    Trigervar.BindGrid()
                    Trigervar.Show()
                Else

                End If
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in trigerenrolle Trigger")
        End Try
    End Sub
    Sub runpayapprovaltriger()
        ' MessageBox.Show("inside run")
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT distinct Batchcode,hcpname as HCP,tdate as Date_Posted FROM claimsinpute WHERE" _
                        & " postedforapprove = '" & True & "' and allertstop = '" & False & "' and rtrim(appsendto) = '" & RTrim(My.Settings.loginid) & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()

                    Dim Trigervar As New trigpayapproval
                    Trigervar.gstring2 = "SELECT distinct Batchcode,hcpname as HCP,tdate as Date_Posted FROM claimsinpute WHERE" _
                        & " postedforapprove = '" & True & "' and allertstop = '" & False & "' and rtrim(appsendto) = '" & RTrim(My.Settings.loginid) & "'"
                    Trigervar.Trigermsg.Text = "Some Payment Approvals are Due"
                    Trigervar.MdiParent = Me
                    Trigervar.BindGrid()
                    Trigervar.Show()
                    reportcodee = "runpayapprovaltriger"
                Else

                End If
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in runpayapprovaltriger Trigger")
        End Try
    End Sub
    Sub runenleavetrigercall()
        ' MessageBox.Show("inside run")
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT staffid,leaveref,sldate FROM leavetab WHERE" _
                                           & " RTRIM(appby) = '" & RTrim(My.Settings.loginid) & "' and appnow = '" & False & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Dim Trigervar As New leaveapproval
                    Trigervar.gstring2 = "SELECT staffid,leaveref,sldate FROM leavetab WHERE" _
                                           & " RTRIM(appby) = '" & RTrim(My.Settings.loginid) & "' and appnow = '" & False & "'"
                    Trigervar.Trigermsg.Text = "Some Leave Due For Approvals"
                    Trigervar.MdiParent = Me
                    Trigervar.BindGrid()
                    Trigervar.Show()
                    reportcodee = "runenleavetriger"
                Else

                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in runleaveapprovaltriger Trigger")
        End Try
    End Sub
    Sub runClienttrigercall()

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT oganames,email,ContractExpires FROM oganisationtab WHERE" _
                        & " active = '" & False & "' and DATEDIFF(day,'" & Date.Today & "',ContractExpires)  <= '" & Val(gstrinsql4) & "' and DATEDIFF(day,'" & Date.Today & "',ContractExpires)  !> '" & Val(gstrinsql4) & "'"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    'MessageBox.Show(r(3))
                    Dim Trigerclientvar As New Contractexpiresallert
                    Trigerclientvar.gstring2 = "SELECT ogaid,oganames,email,ContractExpires FROM oganisationtab WHERE" _
                        & " active = '" & False & "' and DATEDIFF(day,'" & Date.Today & "',ContractExpires)  <= '" & Val(gstrinsql4) & "' and DATEDIFF(day,'" & Date.Today & "',ContractExpires)  !> '" & Val(gstrinsql4) & "'"
                    Trigerclientvar.Trigermsg.Text = "Some Client Contract are Due"
                    Trigerclientvar.MdiParent = Me
                    Trigerclientvar.BindGrid()
                    Trigerclientvar.Show()
                    rptrangecode = Val(gstrinsql4)
                Else

                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in runClienttrigercall Trigger")
        End Try
    End Sub

    Sub runbirthdaytriger()
        Dim Trigervar As New trigpayapproval
        Trigervar.Show()
    End Sub
    '************************************* Trigger Section ****************************************************************
    Private Sub CustomerSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerSetupToolStripMenuItem.Click
        Dim CustvendSetupvar As New CustvendSetup
        CustvendSetupvar.MdiParent = Me
        custvendswith = "C"
        CustvendSetupvar.Show()
    End Sub

    Private Sub VendorsSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendorsSetupToolStripMenuItem.Click
        Dim CustvendSetupvar As New CustvendSetup
        CustvendSetupvar.MdiParent = Me
        custvendswith = "V"
        CustvendSetupvar.Show()
    End Sub

    Private Sub GenerateCapitationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateCapitationToolStripMenuItem.Click
        'gencapitation
        Dim gencapitationvar As New gencapitation
        gencapitationvar.MdiParent = Me
        gencapitationvar.Show()
    End Sub

    Private Sub SetupToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SetupToolStripMenuItem1.Click

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        loadgriddata()
    End Sub

    Private Sub JobAppraisalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobAppraisalToolStripMenuItem.Click
        Dim jobappraiservar As New jobappraiser
        jobappraiservar.MdiParent = Me
        jobappraiservar.Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim reportformvbvar As New reportformvb
        reportformvbvar.MdiParent = Me
        reportformvbvar.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim reportformvbvar As New reportformvb
        reportformvbvar.MdiParent = Me
        reportformvbvar.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim DownupWizvar As New DownupWiz
        DownupWizvar.MdiParent = Me
        DownupWizvar.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim DownupWizvar As New DownupWiz
        DownupWizvar.MdiParent = Me
        DownupWizvar.Show()
    End Sub

    Private Sub RunTriggersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunTriggersToolStripMenuItem.Click
        runpayapprovaltriger()
        abttoexpiredenrollee()
        Hcpapproval()
        runenINVOICEtrigercall()
        runenleavetrigercall()
        runClienttrigercall()
    End Sub
    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            Process.Start(plink)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ProcessPayrollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessPayrollToolStripMenuItem.Click
        Dim procespayvar As New procespay
        procespayvar.MdiParent = Me
        procespayvar.Show()
    End Sub

    Private Sub ImportUtilityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportUtilityToolStripMenuItem.Click
        Dim procespayvar As New importutility
        procespayvar.MdiParent = Me
        procespayvar.Show()
    End Sub
    Private Sub AppraiserRewardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AppraiserRewardToolStripMenuItem.Click
        My.Settings.fsave = "L31"
        My.Settings.OPTRR = "L31"
        My.Settings.optname = "Leave Type"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        codesetupp.Show()
    End Sub
    'Private Sub UpdateToStartNewMonthPayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToStartNewMonthPayToolStripMenuItem.Click
    '    Dim result = MsgBox("Continue Updating summary table.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
    '    If result = vbYes Then
    '        backuptohistory()
    '        statusmsg2.Text = "Updating Please wait .........."
    '        '"Select staffid,fixedtax,totalallowance,totaldeduction,netpay from summarytab"
    '        Dim sumSQL As String = "UPDATE summarytab SET taxtd += fixedtax,grosstd += totalallowance"
    '        Try
    '            Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '                Dim Cd2 As SqlCommand = CCNN.CreateCommand
    '                Cd2.CommandText = sumSQL
    '                Cd2.CommandType = CommandType.Text
    '                CCNN.Open()
    '                Cd2.ExecuteNonQuery()
    '            End Using
    '        Catch ex As Exception
    '            Me.statusmsg2.Text = ex.Message
    '        Finally
    '            '  CCNN.Close()

    '        End Try
    '        'SELECT pic,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate FROM loantab
    '        Dim sumSQL2 As String = "UPDATE loantab SET stopped = '" & True & "' where paidtoadate >= amtcollected"
    '        Try
    '            Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '                Dim Cd2 As SqlCommand = CCNN.CreateCommand
    '                Cd2.CommandText = sumSQL2
    '                Cd2.CommandType = CommandType.Text
    '                CCNN.Open()
    '                Cd2.ExecuteNonQuery()
    '            End Using
    '        Catch ex As Exception
    '            Me.statusmsg2.Text = ex.Message
    '        Finally
    '            '  CCNN.Close()

    '        End Try

    '        Dim sumSQL3 As String = "UPDATE loantab SET paidtoadate += mpayment where paidtoadate !> amtcollected and stopped = '" & False & "'"
    '        Try
    '            Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '                Dim Cd2 As SqlCommand = CCNN.CreateCommand
    '                Cd2.CommandText = sumSQL3
    '                Cd2.CommandType = CommandType.Text
    '                CCNN.Open()
    '                Cd2.ExecuteNonQuery()
    '            End Using
    '        Catch ex As Exception
    '            Me.statusmsg2.Text = ex.Message
    '        End Try

    '    End If
    '    ClearRec()
    'End Sub
    Sub ClearRec()
        Dim cSQL As String = "DELETE FROM paysum "
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
            MessageBox.Show(ex.Message)
        End Try
        '  summarytab
        Try
            'staffid,names,fixedtax,grosstd,taxtd
            cSQL = "UPDATE summarytab SET" _
                   & " totalallowance = '" & 0.0 & "', " & " totaldeduction = '" & 0.0 & "', " & " netpay = '" & 0.0 & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Update Summary to date for period:'" & Now & "' ")
                statusmsg2.Text = "Process Completed Successfully"
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub backuptohistory()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "INSERT INTO payhst(staffid,Names,pic,itemdescr,pictype,taxable,scheme,advance,gradelvl,deptcode,bankid,accountid,pamount,period,paycaldate,year,month,fixedtax,totalallowance,totaldeduction,netpay)" & _
                                                "select staffid,Names,pic,itemdescr,pictype,taxable,scheme,advance,gradelvl,deptcode,bankid,accountid,pamount,period,paycaldate,year,month,fixedtax,totalallowance,totaldeduction,netpay FROM paysum"

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Paysum populated")
            End Using
            'Me.statuspoint.Text = "Paysum populated"
        Catch ex As Exception
            Me.statusmsg2.Text = ex.Message

        End Try

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL22 As String = "INSERT INTO summarytabhst(staffid,names,fixedtax,grosstd,taxtd,totalallowance,totaldeduction,netpay)" & _
                                                "select staffid,names,fixedtax,grosstd,taxtd,totalallowance,totaldeduction,netpay FROM summarytab"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL22
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Paysum populated")
            End Using
            'Me.statuspoint.Text = "Paysum populated"
        Catch ex As Exception
            Me.statusmsg2.Text = ex.Message

        End Try


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

    Private Sub YearEndClearDownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YearEndClearDownToolStripMenuItem.Click
        'SELECT staffid,names,fixedtax,grosstd,taxtd FROM summarytab
        Dim result = MsgBox("Continue Year Clear down.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Dim sumSQL As String = "UPDATE summarytab SET" _
         & " fixedtax = '" & 0.0 & "' ," & " grosstd = '" & 0.0 & "'," & " taxtd = '" & 0.0 & "'," & " totalallowance = '" & 0.0 & "'," & " totalaldeduction = '" & 0.0 & "'," & " netpay = '" & 0.0 & "' "

            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd2 As SqlCommand = CCNN.CreateCommand
                    Cd2.CommandText = sumSQL
                    Cd2.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd2.ExecuteNonQuery()
                    Me.statusmsg2.Text = "Record Cleared Year down Successfully"
                End Using

            Catch ex As Exception
                Me.statusmsg2.Text = ex.Message
            Finally
                'CCNN.Close()
            End Try
            ClearRec()
        End If

    End Sub

    Private Sub GenerateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateToolStripMenuItem.Click

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub hcpogaview_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles hcpogaview.CellContentClick

    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub TrialBalanceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TrialBalanceToolStripMenuItem1.Click
        Dim enrolleevar As New sincome
        enrolleevar.MdiParent = Me
        enrolleevar.Show()
    End Sub

    Private Sub ReceivableDebtorsModuleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceivableDebtorsModuleToolStripMenuItem.Click

    End Sub

    Private Sub enrolleehcp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles enrolleehcp.CellContentClick

    End Sub

    Private Sub SuspendedReasonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuspendedReasonToolStripMenuItem.Click
        My.Settings.fsave = "K31"
        My.Settings.OPTRR = "K31"
        My.Settings.optname = "Suspended Reason"
        Dim codesetupp As New Codesform
        codesetupp.MdiParent = Me
        codesetupp.Show()
    End Sub
End Class
