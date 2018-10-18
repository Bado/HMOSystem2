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
        If My.Settings.reportsqlstr = "Printenrollehcpall" Then
            Printenrollehcpall()
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
        If My.Settings.reportsqlstr = "printenrolleedepentsector" Then
            printenrolleedepentsector()
        End If

        If My.Settings.reportsqlstr = "printenrolleedepenthcp" Then
            printenrolleedepenthcp()
        End If
        'If My.Settings.reportsqlstr = "Enrodep2" Then
        '    Enrodep2()
        'End If



    End Sub
    'Sub Enrodep2()
    '    Try
    '        Dim cryRpt As New ReportDocument
    '        cryRpt.Load(My.Settings.Rptpath & "\" & "Enrodep2.rpt")
    '        CrystalReportViewer1.ReportSource = cryRpt
    '        CrystalReportViewer1.Refresh()
    '    Catch ex As Exception
    '        MDIParent1.statusmsg.Text = ex.Message
    '    End Try
    'End Sub
    Sub printenrolleedepentall()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate,sectortype FROM enrolleetab where Active = '" & False & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Enrodep3.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try

    End Sub

    Sub printenrolleedepent()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate,sectortype FROM enrolleetab where Active = '" & False & "' and ogaid = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Enrodep3.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printenrolleedepentsector()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate,sectortype FROM enrolleetab where Active = '" & False & "' and sectortype = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Enrodep3.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printenrolleedepenthcp()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate,sectortype FROM enrolleetab where Active = '" & False & "' and hcpid = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Enrodep3.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printchartofaccount()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM accode"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "accode")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "accoderpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try


    End Sub
    Sub printenrobydate()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate FROM enrolleetab where dregister >= '" & sdaterpt & "' AND dregister <= '" & edaterpt & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "printenrobydate.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try




    End Sub
    Sub Printenrolleebysector()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS,sectortype, ogaid, hcpid, hcpname, ugstodate FROM enrolleetab where sectortype = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "printenrosector.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printpayvalues()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM paysum where pic = '" & rptrangecode & "' and pamount > 0"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "paysum")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "payvaluesitem.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub Printclist()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM custvendtab where custvendtype ='" & "C" & "' order by custvendtype,custvendid"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "custvendtab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "custvendtabRPTC.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printvlist()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM custvendtab where custvendtype ='" & "V" & "' order by custvendtype,custvendid"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "custvendtab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "custvendtabRPTV.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printstmreport()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM transtabworks"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "transtabworks")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "incomestm1.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub printreceiptbyperiodall()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "salesreceipt")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "receiptbyperiod.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printreceiptbyperiodrange()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "' and billcode = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "salesreceipt")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "receiptbyperiod.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printprepartpayall()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "' and partbalace > '" & 0.0 & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "salesreceipt")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "partpay.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printprepartpayrange()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM salesreceipt where issuedate >= '" & sdaterpt & "' AND issuedate <= '" & edaterpt & "' and paid = '" & True & "' and partbalace > '" & 0.0 & "' and billcode = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "salesreceipt")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "partpay.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try

    End Sub
    Sub printhcpdisputvaluall()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM claimsinputeApproved where tdate >= '" & sdaterpt & "' AND tdate <= '" & edaterpt & "' and paid = '" & True & "' and variance > '" & 0.0 & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "claimsinputeApproved")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Claimsvariance.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printhcpdisputvalubyhcp()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM claimsinputeApproved where tdate >= '" & sdaterpt & "' AND tdate <= '" & edaterpt & "' and hcpid = '" & rptrangecode & "' and paid = '" & True & "' and variance > '" & 0.0 & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "claimsinputeApproved")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Claimsvariance.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printsledgerall()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM transtabrpt where transdate >= '" & sdaterpt & "' AND transdate <= '" & edaterpt & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "transtabrpt")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "sledgerrpt2.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printsledgerclient()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM transtabrpt where transdate >= '" & sdaterpt & "' AND transdate <= '" & edaterpt & "' and headcode = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "transtabrpt")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "sledgerrpt2.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub runClienttrigercall()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT ogaid,oganames,ContractExpires FROM oganisationtab WHERE" _
                        & " active = '" & False & "' and DATEDIFF(day,'" & Date.Today & "',ContractExpires)  <= '" & rptrangecode & "'"

            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "oganisationtab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "oganisationtaballert.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub printfixedassall()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM asserttab"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "asserttab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "asserttaball.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printfixedassdept()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM asserttab where dept = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "asserttab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "asserttaball.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printfixedassbranch()


        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM asserttab where branch = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "asserttab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "asserttaball.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub



    Sub prinpayslipall()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from paysum"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "paysum")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "payslip.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub prinpaysliparange()


        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from paysum where staffid = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "paysum")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "payslip.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try

    End Sub

    Sub Printjobappraisal()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from appraisaltab where staffid = '" & rptrangecode & "' AND appref = '" & rptrangecode2 & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "appraisaltab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "jobappraisalrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printleavecert()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from leavetab where staffid = '" & rptrangecode & "' AND leaveref = '" & rptrangecode2 & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "leavetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "leavecertrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printclaimsvertedrpt()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from claimsinpute where batchcode = '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "claimsinpute")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "printclaimsverted.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printclaimsverted()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from claimsinpute where batchcode >= '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "claimsinpute")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "printclaimsverted.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printclaimsverted2()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from claimsinputenew where batchcode >= '" & rptrangecode & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "claimsinputenew")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "claimsinputrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub Printenrbydate()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active,sectortype, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate from enrolleetab where dregister >= '" & sdaterpt & "' AND dregister <= '" & edaterpt & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "enrolleetabdreg.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printpaymenperiodall()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from pinvoicegrid where ddate >= '" & sdaterpt & "' AND ddate <= '" & edaterpt & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "pinvoicegrid")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "paymentrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printpaymenperiodrange()
        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from pinvoicegrid where hcpid = '" & rptrangecode & "' and ddate >= '" & sdaterpt & "' AND ddate <= '" & edaterpt & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "pinvoicegrid")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "paymentrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
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
        'Try
        '    Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
        '        Dim MyCommand As New SqlCommand()
        '        Dim myDA As New SqlDataAdapter()
        '        Dim myDS As New reportdata2  'The DataSet you created.rptrangecode
        '        Dim cryRpt As New ReportDocument
        '        cryRpt.Load(My.Settings.Rptpath & "\" & "invoiceallert.rpt")
        '        MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
        '        MyCommand.CommandText = "SELECT * FROM salesinvoice WHERE '" & oldDay & "' - day(tdate) > '" & Val(rptrangecode) & "'"
        '        MyCommand.CommandType = CommandType.Text
        '        myDA.SelectCommand = MyCommand
        '        myDA.Fill(myDS, "salesinvoice")
        '        cryRpt.SetDataSource(myDS)
        '        CrystalReportViewer1.ReportSource = cryRpt
        '        CrystalReportViewer1.RefreshReport()
        '        CrystalReportViewer1.Show()
        '        CrystalReportViewer1.Refresh()
        '    End Using
        'Catch Excep As Exception
        '    MessageBox.Show(Excep.Message)
        'End Try


        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT * FROM salesinvoice WHERE '" & oldDay & "' - day(tdate) > '" & Val(rptrangecode) & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "salesinvoice")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "invoiceallert.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub printenrolleealert()
        ' MessageBox.Show(rptnum)

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT enrolleeid,surname,firstname,othernames,nhis,sdate,edate,ogaid FROM enrolleetab WHERE" _
                & " active = '" & False & "' and day(edate) <= '" & rptnum & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "enrolledexpired.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub

    Sub PrintActiveinactenrollees()

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate from enrolleetab "
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "enrolleetabai.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub PrintAuthocdeall()
        Try
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from authorisgrid2"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "authorisgrid2")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "authorisgrid2rpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub PrintAuthocderange()
        Try
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from authorisgrid2 where RTrim(hcpid) = '" & RTrim(rptrangecode) & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "authorisgrid2")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "authorisgrid2rpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printhcp()

        Try
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "select * from hcptab where active = '" & False & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "hcptab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "hcptabrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printhcprange()
        'Bado Bado
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
                MyCommand.CommandText = "Select enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, nationalid,NHIS, ogaid, hcpid, hcpname, ugstodate FROM enrolleetab  where Active = '" & True & "' "
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
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "Select enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, NHIS, ogaid, hcpid, hcpname, ugstodate FROM enrolleetab  where rtrim(hcpid) = '" & RTrim(rptrangecode) & "' and Active = '" & False & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "enrolleebyHCP.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
        End Try
    End Sub
    Sub Printenrollehcpall()
        '  MessageBox.Show("all")

        Try
            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "Select enrolleeid, Surname, Firstname, othernames, dregister, sdate, edate, active, NHIS, ogaid, hcpid, hcpname, ugstodate FROM enrolleetab where Active = '" & False & "'"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "enrolleetab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "enrolleebyHCP.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
        Catch Excep As Exception
            MessageBox.Show(Excep.Message)
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
                MyCommand.CommandText = "Select enrolleeid, Surname, Firstname, othernames, email, dregister, sdate, edate, active, NHIS, ogaid,ogaloc, hcpid, hcpname,ugstodate, ugbalance FROM enrolleetab  where Active = '" & False & "' "
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

        '"Select * FROM TPM.dbo.tblFCTPM; Select Name as Associate from TPM.dbo.tblFCTPM", conn1
        Try

            Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
                Dim MyCommand As New SqlCommand()
                Dim myDA As New SqlDataAdapter()
                Dim myDS As New reportdata2  'The DataSet you created.
                Dim cryRpt As New ReportDocument

                cryRpt.Load(My.Settings.Rptpath & "\" & "enrolleebyall.rpt")

                MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
                MyCommand.CommandText = "Select enrolleeid, Surname, Firstname, othernames, email, dregister, sdate, edate, active, NHIS, ogaid, ogaloc,hcpid, hcpname,ugstodate, ugbalance FROM enrolleetab  where Active = '" & False & "' and ogaid = '" & rptrangecode & "'  "
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
        'Try
        '    Using myConnection2 As New SqlConnection(My.Settings.cnnstring)
        '        Dim MyCommand As New SqlCommand()
        '        Dim myDA As New SqlDataAdapter()
        '        Dim myDS As New reportdata2  'The DataSet you created. 
        '        Dim cryRpt As New ReportDocument
        '        cryRpt.Load(My.Settings.Rptpath & "\" & "Stafflistrpt.rpt")
        '        MyCommand.Connection = myConnection2  'AND OP1 = '" & "F7" & "' "
        '        MyCommand.CommandText = "select staffid, surname, firstname, othernames, title, sex, mstatus, dengage, dofb, age, tel, email, pofb, natid, address, pfa, lga, state, country, cat, position, glevel, bankid, branch, dept, accountid, accttype,scode, suspended, leavedays, leavebal, officebranch, lpromotedd, suspendeddate, reason from stafftab where suspended = '" & False & "'"
        '        MyCommand.CommandType = CommandType.Text
        '        myDA.SelectCommand = MyCommand
        '        myDA.Fill(myDS, "stafftab")
        '        cryRpt.SetDataSource(myDS)
        '        CrystalReportViewer1.ReportSource = cryRpt
        '        CrystalReportViewer1.RefreshReport()
        '        CrystalReportViewer1.Show()
        '        CrystalReportViewer1.Refresh()
        '    End Using
        'Catch Excep As Exception
        '    MessageBox.Show(Excep.Message)
        'End Try

        Try

            Dim connection As SqlConnection
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim dataset As New DataSet
            Dim s_sqlcmd1 As String = "SELECT code1, company, address, address2, tel, Web, email FROM companytab"
            Dim s_sqlcmd2 As String = "SELECT staffid, surname, firstname, othernames, title, sex, mstatus, dengage, dofb, age, tel, email, pofb, natid, address, pfa, lga, state, country, cat, position, glevel, bankid, branch, dept, accountid, accttype,scode, suspended, leavedays, leavebal, officebranch, lpromotedd, suspendeddate, reason FROM stafftab"
            connection = New SqlConnection(My.Settings.cnnstring)
            connection.Open()

            ' load the table with headers into the dataset
            command = New SqlCommand(s_sqlcmd1, connection)
            adapter.SelectCommand = command
            adapter.Fill(dataset, "companytab") ' tablename *MUST* match with the tablename used in the report

            ' load the 2nd table into the dataset (lines)
            adapter.SelectCommand.CommandText = s_sqlcmd2
            adapter.Fill(dataset, "stafftab")

            ' define the relation between the tables
            ' dataset.Relations.Add("relation", dataset.Tables("bill_headers").Columns("billnr"), dataset.Tables("bill_lines").Columns("parent_billnr"))

            ' dataset is ready, get rid of the objects used to construct it
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            ' Load the defined report with the dataset we just created
            Dim myreport As ReportDocument
            myreport = New ReportDocument
            myreport.Load(My.Settings.Rptpath & "\" & "Stafflistrpt.rpt")
            myreport.SetDataSource(dataset)

            ' bind viewer
            ' CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.RefreshReport()
            CrystalReportViewer1.Show()
            CrystalReportViewer1.Refresh()
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
                MyCommand.CommandText = "Select staffid, surname, firstname, othernames, title, sex, mstatus, dengage, dofb, age, tel, email, pofb, natid, address, pfa, lga, state, country, cat, position, glevel, bankid, branch, dept, accountid, accttype,scode, suspended, leavedays, leavebal, officebranch, lpromotedd, suspendeddate, reason FROM STAFFTAB WHERE active = '" & False & "'"
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