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
Imports System.Data.Odbc
Imports System.Drawing.Imaging
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class reportformvb
    Public rptid As String

    Private Sub reportformvb_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub
    Private Sub reportformvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.searchid = ""
        My.Settings.searchsqlstm = ""
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        assignfolder.SelectedIndex = -1
        STAT2.Text = ""
        codeidall.Text = ""
        acc1.Text = ""
        acc2.Text = ""
        Combotype.Enabled = False
        Combosearch.Enabled = False
        codeidall.Enabled = True


    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Reportcat.SelectedIndexChanged
        If Reportcat.Text = "Medical (HMO) Reports" Then
            loadrptlist("MD")
        End If
        If Reportcat.Text = "Personel Reports" Then
            loadrptlist("PER")
        End If
        If Reportcat.Text = "Acount Reports" Then
            loadrptlist("FIN")
        End If

    End Sub

    Private Sub Listreportname_DockChanged(sender As Object, e As EventArgs) Handles Listreportname.DockChanged

    End Sub
    Private Sub Listreportname_DoubleClick(sender As Object, e As EventArgs) Handles Listreportname.DoubleClick
        '    Dim tt As String
        rptrangecode = ""
        codeidall.Text = ""
        codeidall2.Text = ""
        rptid = Listreportname.SelectedItems.Item(0).SubItems(1).Text

        Statusmsg.Text = "You Selected : " & Listreportname.SelectedItems(0).Text

        If RTrim(rptid) = "115" Then
            all.Enabled = False
            range.Enabled = True
        End If
        If RTrim(rptid) = "116" Then
            all.Enabled = True
            range.Enabled = True

        End If
        If RTrim(rptid) = "103" Then
            codeidall.Enabled = False
            all.Enabled = False
            range.Enabled = False
            Combotype.Enabled = True
            Combosearch.Enabled = False
        End If
        If RTrim(rptid) = "126" Or RTrim(rptid) = "125" Or RTrim(rptid) = "109" Or RTrim(rptid) = "128" Then
            all.Enabled = True
            range.Enabled = True
            Combotype.Enabled = False
            Combosearch.Enabled = False
        End If
      


    End Sub
    Sub loadrptlist(ByVal typevar As String)
        Listreportname.Clear()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "select reportname,reportid from reports where type = '" & typevar & "'" & "and" & " awitch = '" & True & "' order by reportname"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    Me.Listreportname.View = View.Details
                    Me.Listreportname.Columns.Add(New ColumnHeader)
                    Me.Listreportname.Columns(0).Text = "Description                    "
                    Me.Listreportname.Columns(0).Width = 650
                    Listreportname.Columns.Add(New ColumnHeader)
                    Listreportname.Columns(1).Text = "Report ID"
                    Me.Listreportname.Columns(1).Width = 5
                    Listreportname.SuspendLayout()
                    Do While r.Read()
                        Dim lItem As ListViewItem = Me.Listreportname.Items.Add(r("reportname"))
                        lItem.SubItems.Add(r("Reportid"))
                    Loop
                End If
            End Using
            Listreportname.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub Printenrolleinactive()
        My.Settings.reportsqlstr = "Printenrolleinactive"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print Inactive Enrolles "
        viewreport2.Show()
    End Sub
    Sub Printenrollehcp()
        My.Settings.reportsqlstr = "Printenrollehcp"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = " Print Enrolles By HCP"
        viewreport2.Show()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Listreportname.Clear()
        Statusmsg.Text = ""
        STAT2.Text = ""
        range.Checked = False
        all.Checked = False
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles all.CheckedChanged

    End Sub
    Sub PrintOgaall()

        My.Settings.reportsqlstr = "PrintOgaall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print All Organisations"
        viewreport2.Show()
    End Sub
    Sub PrintOgarange()
        My.Settings.reportsqlstr = "PrintOgarange"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = RTrim(Combosearch.SelectedValue)
        viewreport2.Text = " Print All Organisations"
        viewreport2.Show()
    End Sub



    Sub PrintenrolleeAll()
        My.Settings.reportsqlstr = "PrintenrolleeAll"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print All Enrollee "
        viewreport2.Show()

    End Sub
    Sub Printenrolleerange()
        If (Not codeidall.Text = String.Empty) Then
            My.Settings.reportsqlstr = "Printenrolleerange"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = codeidall.Text
            viewreport2.Text = " Print All Enrollee by Range"
            viewreport2.Show()
        Else
            MessageBox.Show("Select Range Code to continue")
        End If

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        rptcode = ""

        If range.Checked = True Then
            If RTrim(rptid) = "137" Or RTrim(rptid) = "138" Then

                Try

                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select ogaid,rtrim(ogaNames)  as names, space(10) as tdate  from oganisationtab order by ogaid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    '  sfrm.Show()
                    codeidall.Text = CODDY
                    rptcode = codeidall.Text
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "101" Then

                Try

                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select ogaid,rtrim(ogaNames)  as names, space(10) as tdate  from oganisationtab order by ogaid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    '  sfrm.Show()
                    codeidall.Text = CODDY
                    rptcode = codeidall.Text
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "128" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select hcpid,names,active from hcptab order by hcpid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                getinvoicereportdata1()
            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "115" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "SELECT distinct invoiceno,billcode,tdate FROM salesinvoice order by invoiceno"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                getinvoicereportdata1()
            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "106" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select code1,descr,option1 from CODESTAB where option1 = '" & "F12" & "'"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If

        If range.Checked = True Then
            If RTrim(rptid) = "143" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select code1,descr,option1 from CODESTAB where option1 = '" & "F12" & "'"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
            If RTrim(rptid) = "141" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select code1,descr,option1 from CODESTAB where option1 = '" & "F12" & "'"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then

            If RTrim(rptid) = "102" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select code1,descr,option1 from CODESTAB where option1 = '" & "F12" & "'"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "124" Then
                Try

                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select hcpid,names,active from hcptab order by hcpid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    ' sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "129" Then
                Try

                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select hcpid,names,active from hcptab order by hcpid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "109" Then
                Try

                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select hcpid,names,active from hcptab order by hcpid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "107" Then
                Try

                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinpute order by tdate"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If

        If range.Checked = True Then
            If RTrim(rptid) = "132" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dengage from stafftab where staffid != '" & "ADMIN" & "' and suspended = '" & False & "' order by staffid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "133" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dengage from stafftab where staffid != '" & "ADMIN" & "' and suspended = '" & False & "' order by staffid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "134" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dengage from stafftab where staffid != '" & "ADMIN" & "' and suspended = '" & False & "' order by staffid"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "135" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select code1,descr,option1 from CODESTAB where option1 = '" & "F3" & "'"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If

        If range.Checked = True Then
            If RTrim(rptid) = "136" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select code1,descr,option1 from CODESTAB where option1 = '" & "F6" & "'"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "130" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select ogaid,oganames,tel from oganisationtab"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "139" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "select ITEMCODE,ITEMDESCR,ITEMTYPE from payitems"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall.Text = CODDY
                    codeidall.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        STAT2.Text = "Loading Please wait ....."
        rptrangecode = ""
        If RTrim(rptid) = "101" Then
            If all.Checked = True Then
                PrintenrolleeAll()
            End If
            If range.Checked = True Then
                Printenrolleerange()
            End If

        End If
        If RTrim(rptid) = "110" Then
            If all.Checked = True Then
                PrintstaffAll()
            End If
            If range.Checked = True Then
                Printstaffrange()
            End If
        End If
        If RTrim(rptid) = "115" Then
            If range.Checked = True Then
                Prininvoice()
            End If

        End If
        If RTrim(rptid) = "123" Then
            If all.Checked = True Then
                Printenrolleinactive()
                'range.Enabled = False
            End If

        End If
        If RTrim(rptid) = "124" Then
            If range.Checked = True Then
                Printenrollehcp()
                'range.Enabled = False
            End If

        End If

        If RTrim(rptid) = "106" Then
            If all.Checked = True Then
                PrintOgaall()
            End If

            If range.Checked = True Then
                PrintOgarange()
            End If
        End If
        If RTrim(rptid) = "103" Then
            Printcodesetup()
        End If
        If RTrim(rptid) = "126" Then
            Printhealthplan()
        End If
        If RTrim(rptid) = "125" Then
            Printailment()
        End If

        If RTrim(rptid) = "141" Then
            If range.Checked = True Then
                Printenrolleebysector()
            End If
        End If
        If RTrim(rptid) = "102" Then

            If all.Checked = True Then
                Printhcp()
            End If

            If range.Checked = True Then
                Printhcprange()
            End If
        End If
        If RTrim(rptid) = "109" Then
            If all.Checked = True Then
                PrintAuthocdeall()
            End If

            If range.Checked = True Then
                PrintAuthocderange()
            End If
        End If
        If RTrim(rptid) = "127" Then
            all.Enabled = True
            If all.Checked = True Then
                PrintActiveinactenrollees()
            End If
        End If
        If RTrim(rptid) = "128" Then
            all.Enabled = True
            If all.Checked = True Then
                Printpaymenperiodall()
            End If
            If range.Checked = True Then
                Printpaymenperiodrange()
            End If
        End If

        If RTrim(rptid) = "107" Then
            If range.Checked = True Then
                printclaimsvertedrpt()
            End If

        End If
        If RTrim(rptid) = "131" Then
            If range.Checked = True Then
                Printenrbydate()
            End If

        End If
        If RTrim(rptid) = "132" Then
            If range.Checked = True Then
                Printleavecert()
            End If

        End If
        If RTrim(rptid) = "133" Then
            If range.Checked = True Then
                Printjobappraisal()
            End If

        End If
        If RTrim(rptid) = "134" Then
            all.Enabled = True
            If all.Checked = True Then
                prinpayslipall()
            End If
            range.Enabled = True
            If range.Checked = True Then
                prinpaysliparange()
            End If
        End If
        If RTrim(rptid) = "129" Then

            all.Enabled = True
            If all.Checked = True Then
                printhcpdisputvaluall()
            End If
            range.Enabled = True
            If range.Checked = True Then
                printhcpdisputvalubyhcp()
            End If
        End If


        If RTrim(rptid) = "130" Then
            populateslreport()
            all.Enabled = True
            If all.Checked = True Then
                printsledgerall()
            End If
            range.Enabled = True
            If range.Checked = True Then
                printsledgerclient()
            End If
        End If
        If RTrim(rptid) = "135" Then
            all.Enabled = True
            If all.Checked = True Then
                printfixedassall()
            End If
            range.Enabled = True
            If range.Checked = True Then
                printfixedassdept()
            End If
        End If


        If RTrim(rptid) = "136" Then
            all.Enabled = False

            range.Enabled = True
            If range.Checked = True Then
                printfixedassbranch()
            End If
        End If
        If RTrim(rptid) = "137" Then
            all.Enabled = True
            If all.Checked = True Then
                printprepartpayall()
            End If
            range.Enabled = True
            If range.Checked = True Then
                printprepartpayrange()
            End If
        End If
        If RTrim(rptid) = "138" Then
            all.Enabled = True
            If all.Checked = True Then
                printreceiptbyperiodall()
            End If
            range.Enabled = True
            If range.Checked = True Then
                printreceiptbyperiodrange()
            End If
        End If
        If RTrim(rptid) = "113" Then
            If all.Checked = True Then
                Printclist()
            End If

        End If
        If RTrim(rptid) = "114" Then
            If all.Checked = True Then
                Printvlist()
            End If

        End If
        If RTrim(rptid) = "139" Then
            If range.Checked = True Then
                Printpayvalues()
            End If

        End If
        If RTrim(rptid) = "142" Then
            If range.Checked = True Then
                printenrobydate()
            End If

        End If
        If RTrim(rptid) = "111" Then
            If all.Checked = True Then
                printchartofaccount()
            End If

        End If
        If RTrim(rptid) = "143" Then
            If all.Checked = True Then
                printenrolleedepentall()
            End If
            If range.Checked = True Then
                printenrolleedepent()
            End If
        End If
        

        STAT2.Text = ""
    End Sub

    Sub printenrolleedepentall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printenrolleedepentall"
        rptrangecode = codeidall.Text
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Enrollee/dependant Report"
        viewreport2.Show()
    End Sub
    Sub printenrolleedepent()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printenrolleedepent"
        rptrangecode = codeidall.Text
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Enrollee/dependant Report"
        viewreport2.Show()
    End Sub



    Sub printchartofaccount()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printchartofaccount"
        rptrangecode = codeidall.Text
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Chart of Account Report"
        viewreport2.Show()
    End Sub
    Sub printenrobydate()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printenrobydate"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print enrollee by date join Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub Printenrolleebysector()
        If (Not codeidall.Text = String.Empty) Then
            My.Settings.reportsqlstr = "Printenrolleebysector"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = codeidall.Text
            viewreport2.Text = "Print Enrollee Listing by sector "
            viewreport2.Show()
        End If
    End Sub
    Sub Printpayvalues()
        rptrangecode = ""
        My.Settings.reportsqlstr = "Printpayvalues"
        rptrangecode = codeidall.Text
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Pay values bi item Report"
        viewreport2.Show()
    End Sub
    Sub Printclist()
        rptrangecode = ""
        My.Settings.reportsqlstr = "Printclist"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Customer list Report"
        viewreport2.Show()
    End Sub
    Sub Printvlist()
        rptrangecode = ""
        My.Settings.reportsqlstr = "Printvlist"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Vendor list Report"
        viewreport2.Show()
    End Sub
    Sub printreceiptbyperiodall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printreceiptbyperiodall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Receipt listport"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printreceiptbyperiodrange()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printreceiptbyperiodrange"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Premium Part pay Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printprepartpayall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printprepartpayall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Premium Part pay Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printprepartpayrange()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printprepartpayrange"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Premium Part pay Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printhcpdisputvaluall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printhcpdisputvaluall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Sales Ledger Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printhcpdisputvalubyhcp()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printhcpdisputvalubyhcp"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Sales Ledger Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printsledgerall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printsledgerall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Sales Ledger Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printsledgerclient()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printsledgerclient"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Sales Ledger Report"
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Show()
    End Sub
    Sub printfixedassall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printfixedassall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Fixed Assert Report"
        viewreport2.Show()
    End Sub
    Sub printfixedassdept()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printfixedassdept"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Fixed Assert Report"
        viewreport2.Show()
    End Sub
    Sub printfixedassbranch()
        rptrangecode = ""
        My.Settings.reportsqlstr = "printfixedassbranch"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Fixed Assert Report"
        viewreport2.Show()
    End Sub


    Sub prinpayslipall()
        rptrangecode = ""
        My.Settings.reportsqlstr = "prinpayslipall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Staff Payslip Report"
        viewreport2.Show()
    End Sub
    Sub prinpaysliparange()
        rptrangecode = ""
        My.Settings.reportsqlstr = "prinpaysliparange"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        viewreport2.Text = "Print Staff Payslip Report"
        viewreport2.Show()
    End Sub



    Sub Printjobappraisal()
        rptrangecode = ""
        My.Settings.reportsqlstr = "Printjobappraisal"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        rptrangecode2 = codeidall2.Text
        viewreport2.Text = "Print Job Appraisal Report"
        viewreport2.Show()
    End Sub

    Sub Printleavecert()
        rptrangecode = ""
        My.Settings.reportsqlstr = "Printleavecert"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        rptrangecode2 = codeidall2.Text
        viewreport2.Text = "Print Leave Report"
        viewreport2.Show()
    End Sub

    Sub Printenrbydate()
        My.Settings.reportsqlstr = "Printenrbydate"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Text = " Print Enrollee by Date registered "
        viewreport2.Show()
    End Sub
    Sub printclaimsvertedrpt()
        If (Not codeidall.Text = String.Empty) Then
            My.Settings.reportsqlstr = "printclaimsvertedrpt"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = codeidall.Text
            viewreport2.Text = " Print payment by Period "
            viewreport2.Show()
        Else
            MessageBox.Show("Select Batch code to continue")
        End If
    End Sub
    Sub Printpaymenperiodall()
        My.Settings.reportsqlstr = "Printpaymenperiodall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Text = " Print payment by Period "
        viewreport2.Show()
    End Sub
    Sub Printpaymenperiodrange()
        My.Settings.reportsqlstr = "Printpaymenperiodrange"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = codeidall.Text
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
        viewreport2.Text = " Print  payment by Period"
        viewreport2.Show()
    End Sub
    Sub PrintAuthocdeall()
        My.Settings.reportsqlstr = "PrintAuthocdeall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print Authourisation code "
        viewreport2.Show()
    End Sub
    Sub PrintActiveinactenrollees()
        My.Settings.reportsqlstr = "PrintActiveinactenrollees"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print Active and Inactive Report"
        viewreport2.Show()
    End Sub



    Sub PrintAuthocderange()
        If (Not codeidall.Text = String.Empty) Then
            My.Settings.reportsqlstr = "PrintAuthocderange"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = codeidall.Text
            viewreport2.Text = "Print Authourisation code "
            viewreport2.Show()
        End If

    End Sub
    Sub Printhcp()
        My.Settings.reportsqlstr = "Printhcp"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print HCP Listing "
        viewreport2.Show()

    End Sub
    Sub Printhcprange()
        If (Not codeidall.Text = String.Empty) Then
            My.Settings.reportsqlstr = "Printhcprange"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = codeidall.Text
            viewreport2.Text = "Print HCP Listing "
            viewreport2.Show()
        End If

    End Sub

    Sub Printcodesetup()
        If (Not Combosearch.Text = String.Empty) Then
            My.Settings.reportsqlstr = "Printcodesetup"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            ' rptrangecode = RTrim(Combosearch.SelectedValue)
            viewreport2.Text = "Print Codesetup "
            viewreport2.Show()
        End If

    End Sub
    Sub Prininvoice()
        If (Not codeidall.Text = String.Empty) Then
            My.Settings.reportsqlstr = "Prininvoice"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = codeidall.Text
            viewreport2.Text = "Print Invoice "
            viewreport2.Show()
        End If

    End Sub
    Sub PrintstaffAll()
        My.Settings.reportsqlstr = "PrintstaffAll"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print All staff "
        viewreport2.Show()

    End Sub
    Sub Printhealthplan()
        My.Settings.reportsqlstr = "Printhealthplan"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print Health Care Plan "
        viewreport2.Show()

    End Sub
    Sub Printailment()
        My.Settings.reportsqlstr = "Printailment"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print Ailment Type "
        viewreport2.Show()

    End Sub

    Sub Printstaffrange()
        My.Settings.reportsqlstr = "Printstaffrange"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = " Print All staff by Range"
        viewreport2.Show()

    End Sub
    Private Sub codeidall_TextChanged(sender As Object, e As EventArgs) Handles codeidall.TextChanged
        rptcode = codeidall.Text
    End Sub

    Private Sub codeidall_Validating(sender As Object, e As CancelEventArgs) Handles codeidall.Validating
        rptcode = codeidall.Text
    End Sub

    Private Sub range_CheckedChanged(sender As Object, e As EventArgs) Handles range.CheckedChanged
        If RTrim(rptid) = "106" Or RTrim(rptid) = "102" Then
            codeidall.Enabled = False
            Combotype.Enabled = True
        End If
    End Sub

    Sub getinvoicereportdata1()
        delinvoicefirst()
        'MessageBox.Show("getinvoicereportdata1")
        'insert into tableB select * FROM tableA where DATE_OF_SELL BETWEEN Convert(DateTime,'" & TextBox1.Text "',105) AND Convert(DateTime,'" & TextBox2.Text "',105)", Connection)
        Dim cSQL As String = "INSERT INTO salesinvoicerpt select * from salesinvoice where invoiceno = '" & codeidall.Text & "'"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            getinvoicereportdata2()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Sub getinvoicereportdata2()
        ' MessageBox.Show("getinvoicegridreportdata2")
        'insert into tableB select * FROM tableA where DATE_OF_SELL BETWEEN Convert(DateTime,'" & TextBox1.Text "',105) AND Convert(DateTime,'" & TextBox2.Text "',105)", Connection)
        Dim cSQL As String = "INSERT INTO sinvoicegridrpt select * from sinvoicegrid where invoiceno = '" & codeidall.Text & "'"

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
    Sub delinvoicefirst()
        ' 'SELECT billcode,pcode,eqty,uprice,tax,discou2nt,amt FROM sinvoicegrid
        Dim cSQL5 As String = "DELETE FROM sinvoicegridrpt"
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

        Dim cSQL6 As String = "DELETE FROM salesinvoicerpt"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL6

                CCNN.Open()
                Cd.ExecuteNonQuery()

                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try

    End Sub

    Private Sub Listreportname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Listreportname.SelectedIndexChanged

    End Sub

    Private Sub Combosearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combotype.SelectedIndexChanged
        If Combotype.Text = "LGA" Then
            Combosearch.SelectedIndex = -1
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
            rptrangecode2 = "F2"
            connection = New SqlConnection(connetionString)
            Try
                connection.Open()
                command = New SqlCommand(sql, connection)
                adapter.SelectCommand = command
                adapter.Fill(ds)
                adapter.Dispose()
                command.Dispose()
                connection.Close()
                Combosearch.DataSource = ds.Tables(0)
                Combosearch.ValueMember = "code1"
                Combosearch.DisplayMember = "descr"
            Catch ex As Exception
                MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB LGA ! "
            End Try
        End If
        If Combotype.Text = "STATE" Then
            Combosearch.SelectedIndex = -1
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
            rptrangecode2 = "F1"
            connection = New SqlConnection(connetionString)
            Try
                connection.Open()
                command = New SqlCommand(sql, connection)
                adapter.SelectCommand = command
                adapter.Fill(ds)
                adapter.Dispose()
                command.Dispose()
                connection.Close()
                Combosearch.DataSource = ds.Tables(0)
                Combosearch.ValueMember = "code1"
                Combosearch.DisplayMember = "descr"
            Catch ex As Exception
                MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB LGA ! "
            End Try
        End If
        If Combotype.Text = "SECTOR" Then
            Combosearch.SelectedIndex = -1
            Dim connetionString As String = Nothing
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter()
            Dim ds As New DataSet()
            Dim i As Integer = 0
            Dim sql As String = Nothing
            connetionString = My.Settings.cnnstring
            'sql = "select staffid,surnrame from enrolleetab"
            sql = "select code1,descr from CODESTAB where option1 = '" & "F12" & "'"
            rptrangecode2 = "F11"
            connection = New SqlConnection(connetionString)
            Try
                connection.Open()
                command = New SqlCommand(sql, connection)
                adapter.SelectCommand = command
                adapter.Fill(ds)
                adapter.Dispose()
                command.Dispose()
                connection.Close()
                Combosearch.DataSource = ds.Tables(0)
                Combosearch.ValueMember = "code1"
                Combosearch.DisplayMember = "descr"
            Catch ex As Exception
                MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB LGA ! "
            End Try
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Combosearch_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles Combosearch.SelectedIndexChanged

    End Sub
    Private Sub sdate_Validating(sender As Object, e As CancelEventArgs) Handles sdate.Validating
        sdaterpt = Format(sdate.Value, "yyyy-MM-dd")
    End Sub

    Private Sub edate_Validating(sender As Object, e As CancelEventArgs) Handles edate.Validating
        edaterpt = Format(edate.Value, "yyyy-MM-dd")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If range.Checked = True Then
            If RTrim(rptid) = "132" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "SELECT distinct leaveref,names,staffid FROM leavetab order by leaveref"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall2.Text = CODDY
                    codeidall2.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If range.Checked = True Then
            If RTrim(rptid) = "133" Then
                Try
                    gsql = ""
                    DESCC = ""
                    OPTRR = publicvarmodule.OPT
                    gsql = "SELECT distinct appref,names,tdate FROM appraisaltab order by appref,tdate"
                    Dim sfrm As New searchfrm
                    'sfrm.MdiParent = MDIParent1
                    sfrm.ShowDialog()
                    'sfrm.Show()
                    codeidall2.Text = CODDY
                    codeidall2.Refresh()
                    Me.Refresh()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If














    End Sub

    Sub populateslreport()
        deltranstabdelrec()
        Try
            Dim sumSQL As String = "INSERT INTO transtabrpt(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,stotal,rtotal,transdate,acctcredit,acctdebit,post)" & _
                                                     "select headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total as stotal,0.00 as rtotal,transdate,acctcredit,acctdebit,post FROM transtab where Rtrim(typecode) = '" & "IV" & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '  MessageBox.Show("Record Posted Successfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in populate slreport")
        End Try

        Try
            Dim sumSQL2 As String = "INSERT INTO transtabrpt(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,stotal,rtotal,transdate,acctcredit,acctdebit,post)" & _
                                                     "select headcode,hdescr,transcode,tdescr,typecode,qty,uprice,0.00 as stotal,total as rtotal,transdate,acctcredit,acctdebit,post FROM transtab where Rtrim(typecode) = '" & "RC" & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL2
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '  MessageBox.Show("Record Posted Successfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in in populate slreport")
        End Try
    End Sub
    Public Sub deltranstabdelrec()
        Dim cSQL As String = "DELETE FROM transtabrpt"
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
    End Sub

    Private Sub sdate_ValueChanged(sender As Object, e As EventArgs) Handles sdate.ValueChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        rptrangecode = ""
        My.Settings.reportsqlstr = "Enrodep2"
        rptrangecode = codeidall.Text
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Enrollee/dependant Report"
        viewreport2.Show()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        rptrangecode = codeidall.Text
        My.Settings.reportsqlstr = "Enrodep2"
        rptrangecode = codeidall.Text
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Enrollee/dependant Report"
        viewreport2.Show()
    End Sub
End Class