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
Imports System.Data.OleDb
Imports System.IO.Directory
Imports Microsoft.Office.Interop.Excel
Imports CrystalDecisions.Shared.Interop
Public Class Staffbirthday
    Public dfolder As String
    Public gg2 As String
 

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dfrommm As Date = Format(dfrom.Value, "yyyy-MM-dd")
        Dim dtoo As Date = Format(dto.Value, "yyyy-MM-dd")
        My.Settings.reportsqlstr = "staffbirthday"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = dfrommm
        rptrangecode2 = dtoo
        If drange.Checked = True Then

            audisql2 = "select staffid,rtrim(surname) as surname,rtrim(firstname) as firstname,rtrim(othernames) as othernames,dofb,tel from stafftab Where dofb BETWEEN '" & rptrangecode & "' AND '" & rptrangecode2 & "' order by staffid"
            '   audisql2 = "select staffid,rtrim(surname) as surname,rtrim(firstname) as firstname,rtrim(othernames) as othernames,dofb,tel from stafftab where dofb >= '" & rptrangecode & "' and dofb <= '" & rptrangecode2 & "' order by staffid"
        End If
        If yearby.Checked = True Then
            audisql2 = "select staffid,rtrim(surname) as surname,rtrim(firstname) as firstname,rtrim(othernames) as othernames,dofb,tel from stafftab where rtrim(Year(dofb)) = '" & RTrim(yearr.SelectedValue.ToString) & "' order by staffid"
        End If
        viewreport2.Text = " Staff Birthday Report"
        viewreport2.Show()
    End Sub
    Private Sub Staffbirthday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        For x = 1900 To Year(Now())
            yearr.Items.Add(x)
        Next



    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class