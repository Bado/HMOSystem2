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
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class viewreport
    Private Sub viewreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        If My.Settings.reportsqlstr = "uAccount" Then
            usersaccuts()
        End If
        If My.Settings.reportsqlstr = "printapprovpayalert" Then
            printapprovpayalert()
        End If

        If My.Settings.reportsqlstr = "audittrailoption" Then
            audittrailoption2()
        End If
        If My.Settings.reportsqlstr = "PrintenrolleeAll" Then
            PrintenrolleeAll()
        End If
        If My.Settings.reportsqlstr = "Printenrolleerange" Then
            Printenrolleerange()
        End If
        If My.Settings.reportsqlstr = "PrintstaffAll" Then
            PrintstaffAll()
        End If
        If My.Settings.reportsqlstr = "Printstaffrange" Then
            Printstaffrange()
        End If
        If My.Settings.reportsqlstr = "Prininvoice" Then
            Prininvoice()
        End If
        If My.Settings.reportsqlstr = "Printreceipt" Then
            Printreceipt()
        End If
        If My.Settings.reportsqlstr = "PrintCapitation" Then
            PrintCapitation()
        End If
        If My.Settings.reportsqlstr = "Printpaymentrpt" Then
            Printpaymentrpt()
        End If
        If My.Settings.reportsqlstr = "staffbirthday" Then
            Staffbirthday()
        End If
        If My.Settings.reportsqlstr = "PrintOgaall" Then
            PrintOgaall()
        End If
        If My.Settings.reportsqlstr = "PrintOgarange" Then
            PrintOgarange()
        End If
        If My.Settings.reportsqlstr = "Printenrolleinactive" Then
            Printenrolleinactive()
        End If
        If My.Settings.reportsqlstr = "Printenrollehcp" Then
            Printenrollehcp()
        End If
        If My.Settings.reportsqlstr = "Printcodesetup" Then
            Printcodesetup()
        End If
        If My.Settings.reportsqlstr = "Printhealthplan" Then
            Printhealthplan()
        End If
        If My.Settings.reportsqlstr = "Printailment" Then
            Printailment()
        End If
        If My.Settings.reportsqlstr = "Printhcp" Then
            Printhcp()
        End If
        If My.Settings.reportsqlstr = "Printhcprange" Then
            Printhcprange()
        End If
        ' PrintAuthocdeall PrintAuthocderange
        If My.Settings.reportsqlstr = "PrintAuthocdeall" Then
            PrintAuthocdeall()
        End If
        If My.Settings.reportsqlstr = "PrintAuthocderange" Then
            PrintAuthocderange()
        End If
        If My.Settings.reportsqlstr = "printenrolleealert" Then
            printenrolleealert()
        End If
        'rptrangecode
        If My.Settings.reportsqlstr = "printinvoicerecblealert" Then
            printinvoicerecblealert()
        End If
        If My.Settings.reportsqlstr = "PrintActiveinactenrollees" Then
            PrintActiveinactenrollees()
        End If
        If My.Settings.reportsqlstr = "Printpaymenperiodall" Then
            Printpaymenperiodall()
        End If
        If My.Settings.reportsqlstr = "Printpaymenperiodrange" Then
            Printpaymenperiodrange()
        End If
        If My.Settings.reportsqlstr = "printclaimsverted" Then
            printclaimsverted()
        End If
        If My.Settings.reportsqlstr = "printclaimsverted2" Then
            printclaimsverted2()
        End If

        If My.Settings.reportsqlstr = "printclaimsvertedrpt" Then
            printclaimsvertedrpt()
        End If
        If My.Settings.reportsqlstr = "Printenrbydate" Then
            Printenrbydate()
        End If
        If My.Settings.reportsqlstr = "Printleavecert" Then
            Printleavecert()
        End If
        If My.Settings.reportsqlstr = "Printjobappraisal" Then
            Printjobappraisal()
        End If
        If My.Settings.reportsqlstr = "prinpayslipall" Then
            prinpayslipall()
        End If
        If My.Settings.reportsqlstr = "prinpaysliparange" Then
            prinpaysliparange()
        End If
        If My.Settings.reportsqlstr = "printfixedassall" Then
            printfixedassall()
        End If
        If My.Settings.reportsqlstr = "printfixedassdept" Then
            printfixedassdept()
        End If
        If My.Settings.reportsqlstr = "printfixedassbranch" Then
            printfixedassbranch()
        End If
        If My.Settings.reportsqlstr = "runClienttrigercall" Then
            runClienttrigercall()
        End If
        If My.Settings.reportsqlstr = "printsledgerall" Then
            printsledgerall()
        End If
        If My.Settings.reportsqlstr = "printsledgerclient" Then
            printsledgerclient()
        End If
        If My.Settings.reportsqlstr = "printhcpdisputvaluall" Then
            printhcpdisputvaluall()
        End If
        If My.Settings.reportsqlstr = "printhcpdisputvalubyhcp" Then
            printhcpdisputvalubyhcp()
        End If
        If My.Settings.reportsqlstr = "printprepartpayall" Then
            printprepartpayall()
        End If
        If My.Settings.reportsqlstr = "printprepartpayrange" Then
            printprepartpayrange()
        End If
        If My.Settings.reportsqlstr = "printreceiptbyperiodall" Then
            printreceiptbyperiodall()
        End If
        If My.Settings.reportsqlstr = "printreceiptbyperiodrange" Then
            printreceiptbyperiodrange()
        End If
        If My.Settings.reportsqlstr = "printstmreport" Then
            printstmreport()
        End If
        If My.Settings.reportsqlstr = "Printclist" Then
            Printclist()
        End If
        If My.Settings.reportsqlstr = "Printvlist" Then
            Printvlist()
        End If
        If My.Settings.reportsqlstr = "Printpayvalues" Then
            Printpayvalues()
        End If
        If My.Settings.reportsqlstr = "Printenrolleebysector" Then
            Printenrolleebysector()
        End If

        If My.Settings.reportsqlstr = "printenrobydate" Then
            printenrobydate()
        End If
        If My.Settings.reportsqlstr = "printchartofaccount" Then
            printchartofaccount()
        End If
        If My.Settings.reportsqlstr = "printenrolleedepentall" Then
            printenrolleedepentall()
        End If
        If My.Settings.reportsqlstr = "printenrolleedepent" Then
            printenrolleedepent()
        End If
        If My.Settings.reportsqlstr = "Enrodep2" Then
            Enrodep2()
        End If



    End Sub
    Sub Enrodep2()
        Try
            Dim cryRpt As New ReportDocument
            cryRpt.Load(My.Settings.Rptpath & "\" & "Enrodep2.rpt")
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Sub printenrolleedepentall()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "accoderpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM enrolleetab"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub printenrolleedepent()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "accoderpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM enrolleetab"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printchartofaccount()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "accoderpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM accode"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "accode")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printenrobydate()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "printenrobydate.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM enrolleetab where dregister >= '" & sdaterpt & "' AND dregister <= '" & edaterpt & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printenrolleebysector()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "printenrosector.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM enrolleetab where sectortype = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printpayvalues()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "payvaluesitem.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM paysum where pic = '" & rptrangecode & "' and pamount > 0"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "paysum")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub Printclist()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "custvendtabRPTC.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM custvendtab where custvendtype ='" & "C" & "' order by custvendtype,custvendid"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "custvendtab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printvlist()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "custvendtabRPTV.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM custvendtab where custvendtype ='" & "V" & "' order by custvendtype,custvendid"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "custvendtab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printstmreport()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "incomestm1.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM transtabworks"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "transtabworks")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub printreceiptbyperiodall()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "receiptbyperiod.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "'"

                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "salesreceipt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printreceiptbyperiodrange()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "receiptbyperiod.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "' and billcode = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "salesreceipt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printprepartpayall()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "partpay.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "' and partbalace > '" & 0.0 & "'"

                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "salesreceipt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printprepartpayrange()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "partpay.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "' and partbalace > '" & 0.0 & "' and billcode = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "salesreceipt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printhcpdisputvaluall()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "Claimsvariance.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM claimsinputeApproved where tdate >= '" & sdaterpt & "' AND tdate <= '" & edaterpt & "' and paid = '" & True & "' and variance > '" & 0.0 & "'"

                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "claimsinputeApproved")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printhcpdisputvalubyhcp()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "Claimsvariance.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM claimsinputeApproved where tdate >= '" & sdaterpt & "' AND tdate <= '" & edaterpt & "' and hcpid = '" & rptrangecode & "' and paid = '" & True & "' and variance > '" & 0.0 & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "claimsinputeApproved")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printsledgerall()
        Try
            MessageBox.Show(sdaterpt)
            MessageBox.Show(edaterpt)
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "sledgerrpt2.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM transtabrpt where transdate >= '" & sdaterpt & "' AND transdate <= '" & edaterpt & "'"

                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "transtabrpt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printsledgerclient()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "sledgerrpt2.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM transtabrpt where transdate >= '" & sdaterpt & "' AND transdate <= '" & edaterpt & "' and headcode = '" & rptrangecode & "'"

                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "transtabrpt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub runClienttrigercall()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "oganisationtaballert.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT ogaid,oganames,ContractExpires FROM oganisationtab WHERE" _
                        & " active = '" & False & "' and DATEDIFF(day,'" & Date.Today & "',ContractExpires)  <= '" & rptrangecode & "'"

                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "oganisationtab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub printfixedassall()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "asserttaball.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM asserttab"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "asserttab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printfixedassdept()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "asserttaball.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM asserttab where dept = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "asserttab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printfixedassbranch()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "asserttaball.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM asserttab where branch = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "asserttab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub



    Sub prinpayslipall()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "payslip.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from paysum"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "paysum")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub prinpaysliparange()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "payslip.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from paysum where staffid = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "paysum")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub Printjobappraisal()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "jobappraisalrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from appraisaltab where staffid = '" & rptrangecode & "' AND appref = '" & rptrangecode2 & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "appraisaltab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printleavecert()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "leavecertrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from leavetab where staffid = '" & rptrangecode & "' AND leaveref = '" & rptrangecode2 & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "leavetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printclaimsvertedrpt()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "printclaimsverted.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from claimsinpute where batchcode = '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "claimsinpute")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printclaimsverted()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "printclaimsverted.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from claimsinpute where batchcode >= '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "claimsinpute")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printclaimsverted2()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "claimsinputrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from claimsinputenew where batchcode >= '" & rptrangecode & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "claimsinputenew")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub Printenrbydate()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleetabdreg.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from enrolleetab where dregister >= '" & sdaterpt & "' AND dregister <= '" & edaterpt & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printpaymenperiodall()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "paymentrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from pinvoicegrid where ddate >= '" & sdaterpt & "' AND ddate <= '" & edaterpt & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "pinvoicegrid")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printpaymenperiodrange()
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "paymentrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from pinvoicegrid where hcpid = '" & rptrangecode & "' and ddate >= '" & sdaterpt & "' AND ddate <= '" & edaterpt & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "pinvoicegrid")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub



    Sub printinvoicerecblealert()
        Dim oldDate As Date
        Dim oldDay As Integer
        ' Assign a date using standard short format.
        oldDate = Today
        oldDay = Microsoft.VisualBasic.DateAndTime.Day(oldDate)
        ' MessageBox.Show(oldDay)
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.rptrangecode
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "invoiceallert.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT * FROM salesinvoice WHERE '" & oldDay & "' - day(tdate) > '" & Val(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "salesinvoice")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printenrolleealert()
        ' MessageBox.Show(rptnum)
        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.rptrangecode
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolledexpired.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "SELECT enrolleeid,surname,firstname,othernames,nhis,sdate,edate,ogaid FROM enrolleetab WHERE" _
                & " active = '" & False & "' and day(edate) <= '" & rptnum & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub PrintActiveinactenrollees()

        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleetabai.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from enrolleetab "
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub PrintAuthocdeall()

        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "authorisgrid2rpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from authorisgrid2 "
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "authorisgrid2")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub PrintAuthocderange()

        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "authorisgrid2rpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from authorisgrid2 where RTrim(hcpid) = '" & RTrim(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "authorisgrid2")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printhcp()

        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "hcptabrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from hcptab where active = '" & False & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "hcptab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printhcprange()

        Try
            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "hcptabrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from hcptab where  active = '" & False & "' and sectortype = '" & RTrim(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "hcptab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printhealthplan()

        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "Printhealthplan.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from premiumplan"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "premiumplan")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printailment()

        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "AilmenttypeRPT.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from Ailmenttypedefault"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "Ailmenttypedefault")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub PrintOgaall()

        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "organisationrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from oganisationtab where Active = '" & False & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "oganisationtab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub



    Sub Printcodesetup()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "Codesetup.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from codestab where option1 = '" & RTrim(rptrangecode2) & "' "
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "codestab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub PrintOgarange()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "organisationrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from oganisationtab where sectortype = '" & RTrim(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "oganisationtab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub Printpaymentrpt()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "paymentrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from pinvoicegrid where RTrim(paycode) = '" & RTrim(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "pinvoicegrid")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub staffbirthday()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "staffbirthdayrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = audisql2
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "stafftab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printreceipt()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "salesreceiptreport.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from salesreceipt where invoiceno = '" & RTrim(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "salesreceipt")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub usersaccuts()
        Try
            Dim cryRpt As New ReportDocument
            cryRpt.Load(My.Settings.Rptpath & "\" & "stafflist.rpt")
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Sub PrintCapitation()
        'MessageBox.Show(rptrangecode)
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "capitationreport.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from gencapitation where rTrim(tcode) = '" & RTrim(rptrangecode) & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "gencapitation")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
        'Try
        '    Dim cryRpt As New ReportDocument
        '    cryRpt.Load(My.Settings.Rptpath & "\" & "capitationreport.rpt")
        '    CrystalReportViewer1.ReportSource = cryRpt
        '    CrystalReportViewer1.Refresh()
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = ex.Message
        'End Try
    End Sub



    Sub audittrailoption2()
        'Try
        '    Dim cryRpt As New ReportDocument
        '    cryRpt.Load(My.Settings.Rptpath & "\" & "audittrailoption.rpt")
        '    CrystalReportViewer1.ReportSource = cryRpt
        '    CrystalReportViewer1.Refresh()
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = ex.Message
        'End Try

        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "audittrailoption.rpt")

                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                If audisql2 = "S" Then
                    MyCommand.CommandText = "SELECT userid,action1,period FROM audittab Where period BETWEEN '" & rptrangecode & "' AND '" & rptrangecode2 & "'  AND userid = '" & audisql3 & "' order by period"
                Else
                    MyCommand.CommandText = "SELECT userid,action1,period FROM audittab Where period BETWEEN '" & rptrangecode & "' AND '" & rptrangecode2 & "'  order by period"
                End If
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "audittab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            ' Me.statuspoint.Text = Excep.Message
        End Try




    End Sub
    Sub Printenrolleinactive()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleebyall.rpt")

                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "Select * FROM enrolleetab  where Active = '" & True & "' "
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            ' Me.statuspoint.Text = Excep.Message
        End Try
    End Sub
    Sub Printenrollehcp()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleebyall.rpt")
                'SetParameterValue("param1", Session("param1"))
                cryRpt.SetParameterValue("erolleepara", "param1")
                '@erolleepara, "Hospital")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "Select * FROM enrolleetab  where rtrim(hcpid) = '" & RTrim(rptrangecode) & "' and Active = '" & False & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            ' Me.statuspoint.Text = Excep.Message
        End Try
    End Sub
    Sub PrintenrolleeAll()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleebyall.rpt")

                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "Select * FROM enrolleetab  where Active = '" & False & "' "
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            ' Me.statuspoint.Text = Excep.Message
        End Try
    End Sub
    Sub Printenrolleerange()
        ' MessageBox.Show(rptcode)
        'Try

        '    Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
        '        Dim MyCommand As New SqlCommand()
        '        Dim myDA As New SqlDataAdapter()
        '        Dim myDS As New reportdata2  'The DataSet you created.
        '        Dim cryRpt As New ReportDocument

        '        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        '        Dim crParameterFieldDefinition As ParameterFieldDefinition
        '        Dim crParameterValues As New ParameterValues
        '        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        '        CheckCodestab.oganisationnames(rptcode)
        '        Dim ognames As String = CheckCodestab.descvar
        '        MessageBox.Show(ognames)
        '        crParameterDiscreteValue.Value = "Oganisation Names"
        '        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
        '        crParameterFieldDefinition = crParameterFieldDefinitions.Item("oga2")
        '        crParameterValues = crParameterFieldDefinition.CurrentValues

        '        crParameterValues.Clear()
        '        crParameterValues.Add(crParameterDiscreteValue)
        '        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        '        cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleebyalleroll.rpt")
        '        MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
        '        MyCommand.CommandText = "Select distinct enrolleeid,Surname,Firstname,othernames,sdate,edate,NHIS,ogaid,hcpname FROM enrolleetab  where ogaid = '" & rptrangecode & "'"
        '        MyCommand.CommandType = CommandType.Text
        '        myDA.SelectCommand = MyCommand
        '        myDA.Fill(myDS, "enrolleetab")
        '        cryRpt.SetDataSource(myDS)
        '        CrystalReportViewer1.ReportSource = cryRpt
        '        CrystalReportViewer1.RefreshReport()
        '        CrystalReportViewer1.Show()
        '        CrystalReportViewer1.Refresh()
        '    End Using
        'Catch Excep As Exception
        '    ' Me.statuspoint.Text = Excep.Message
        'End Try
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleebyall.rpt")

                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "Select * FROM enrolleetab  where Active = '" & False & "' and ogaid = '" & rptrangecode & "'  "
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "enrolleetab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            ' Me.statuspoint.Text = Excep.Message
        End Try
    End Sub


    Sub printapprovpayalert()
        'Try
        'Dim cryRpt As New ReportDocument
        ' '' MessageBox.Show(My.Settings.Rptpath & "\" & "payaproval.rpt")
        'cryRpt.Load(My.Settings.Rptpath & "\" & "payaproval.rpt")
        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()







        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = ex.Message
        'End Try
    End Sub
    Sub PrintstaffAll()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created. 
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "Stafflistrpt.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from stafftab where suspended = '" & False & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "stafftab")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try

    End Sub
    Sub Printstaffrange()
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "Stafflistrpt.rpt")

                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "Select * FROM STAFFTAB WHERE active = '" & False & "'"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "STAFFTAB")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
        Catch Excep As Exception
            ' Me.statuspoint.Text = Excep.Message
        End Try
    End Sub
    Sub Prininvoice()
        ' MessageBox.Show(rptrangecode)
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument
                cryRpt.Load(My.Settings.Rptpath & "\" & "invoicereport.rpt")
                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "select * from(select a.billcode,a.descr,a.invoicetopic,a.tdate,a.invoiceno,a.glcode,a.Amtword,a.salesrep,a.stax,a.itotal,a.netdue,a.addressto,a.signby,b.pcode,b.eqty,b.uprice,b.tax,b.discount,b.amt,c.company,c.address,c.address2,c.tel,a.accountname,a.accountno,a.bankname,a.branch,a.sortno from salesinvoicerpt a, sinvoicegridrpt b,companytab c Where rtrim(a.invoiceno) = rtrim(b.invoiceno) and rtrim(a.invoiceno) = '" & RTrim(rptrangecode) & "')school"
                MyCommand.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA.Fill(myDS, "school")
                cryRpt.SetDataSource(myDS)
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
                CrystalReportViewer1.Show()
                CrystalReportViewer1.Refresh()
            End Using
            'Try
            'Dim cryRpt As New ReportDocument
            'cryRpt.Load(My.Settings.Rptpath & "\" & "invoicereport.rpt")
            'CrystalReportViewer1.ReportSource = cryRpt
            'CrystalReportViewer1.Refresh()
            'Catch ex As Exception
            '    MDIParent1.statusmsg.Text = ex.Message
            'End Try
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub



    'Here's an easy way to pass parameters 
    '' Declare variables needed to pass the parameters to the viewer control.
    'Dim paramFields As New ParameterFields
    'Dim paramField As New ParameterField
    'Dim discreteVal As New ParameterDiscreteValue

    '' The first parameter is a discrete parameter with multiple values.
    '' Set the name of the parameter field, this must match a parameter in the report.
    '        paramField.ParameterFieldName = "@LevyYear"
    ''*** SETTING THE FIRST DISCRETE VALUE & PASS IT TO THE PARAMETER ***
    '        discreteVal.Value = "Levy Year: " & glbLevyYear
    '        paramField.CurrentValues.Add(discreteVal)
    ''*** ADDING THE PARAMETER TO THE PARAMETER FIELDS COLLECTION ***
    '        paramFields.Add(paramField)

    ''*** PASSING A SECOND PARAMETER (DISCRETE VALUE) ***
    '        paramField = New ParameterField
    '        paramField.ParameterFieldName = "@Description"
    '        discreteVal = New ParameterDiscreteValue
    '        discreteVal.Value = "Levy Year: " & glbLevyYear & " | Commitment Number: " & glbCommitNumber
    '        paramField.CurrentValues.Add(discreteVal)
    '        paramFields.Add(paramField)
    ''*** DON'T FORGET TO ALWAYS ADD THE PARAMETER TO THE PARAMFIELDS AFTER ENTERING THE VALUE *** IT MUST BE ADDED AFTER EACH NEW PARAMETER ***

    ''*** SET THE PARAMETER FIELDS COLLECTION INTO THE VIEWER CONTROL ***
    '        crpViewer.ParameterFieldInfo = paramFields

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class