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
Public Class PaymentHst

    Private Sub PaymentHst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
    End Sub
    Sub GENECEL()
        Try
            Dim headers = (From header As DataGridViewColumn In resultgrid.Columns.Cast(Of DataGridViewColumn)() Select header.HeaderText).ToArray

            Dim rows = From row As DataGridViewRow In resultgrid.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
            ' Dim anafoldervar As String = anafolder.Text
            'MessageBox.Show(anafoldervar)
            Dim str As String = ""
            Dim str2 As String = outfilename.Text.Trim + ".csv"


            Using sw As New IO.StreamWriter(My.Settings.docfolder + "\" + str2)
                sw.WriteLine(String.Join(",", headers))
                For Each r In rows
                    sw.WriteLine(String.Join(",", r))
                Next
                sw.Close()
            End Using
            MessageBox.Show("CSV File sucessfully dwonloaded")
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub
End Class