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
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Web.UI
Imports Microsoft.Office.Interop


Public Class DownupWiz
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Public tablenamew As String
    Public tablepathw As String
    Public inc As Integer
    Public MaxRows As Integer
    'Change "C:\Users\Jimmy\Documents\Merchandise.accdb" to your database location
    'Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\Jimmy\Desktop\test.accdb"
   
    Private Sub DownupWiz_Load(sender As Object, e As EventArgs) Handles Me.Load
        listgrid.EnableHeadersVisualStyles = False
        listgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        listgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        listgrid.ColumnHeadersHeight = 30
        listgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        listgrid.Dock = DockStyle.Top
        '  listgrid.ScrollBars = ScrollBars.Both
        'CrystalReportViewer1.Visible = False
       
    End Sub
    Sub BindGrid()
        Try
            Dim sts As Integer
            'Dim i2 As Integer
            'For i2 = i2 To listgrid.RowCount - 1
            '    listgrid.Rows.Clear()
            'Next

            Dim constring As String = My.Settings.cnnstring
            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand(gstring1, con)
                    cmd.CommandType = CommandType.Text
                    Using sda As New SqlDataAdapter(cmd)
                        Using ds As New DataSet()
                            sda.Fill(ds)
                            listgrid.DataSource = ds.Tables(0)

                        End Using
                    End Using
                End Using
            End Using
            sts = listgrid.RowCount
            RENOO.Text = "Record Count: " + Str(sts)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in file listing Table")
        End Try

    End Sub


    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
    Private Sub LinkLabel3_Disposed(sender As Object, e As EventArgs) Handles enrolleelist.Disposed
        gstring1 = ""
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles enrolleelist.LinkClicked

        gstring1 = "Select Enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,ogaid,ogaloc,hcpid,hcpname,Sex,Maritalstatus,Title,Age,Dofb,Tel,Email,dregister as Date_Register,sdate as Start_Date,edate as End_Date,active as Inactive,nationalid,NHIS as NHIS_ID,ugbalance as Yearly_Banalce FROM enrolleetab order by ogaid,enrolleeid"
        ltitle.Text = "Enrollee Listing"
        Me.Text = "Enrollee Listing"
        tablenamew = "EnrolleeList.xlsx"
        BindGrid()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles hcplist.LinkClicked
        gstring1 = " Select hcpid,Names,dregister as Date_register,active as Inactive,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid as accountid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan,pnetwork FROM Hcptab order by Names"
        ltitle.Text = "Hospital Listing"
        Me.Text = "Hospital Listing"
        tablenamew = "HospitalList.xlsx"
        BindGrid()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ogalist.LinkClicked
        gstring1 = "Select ogaid,oganames,active as Inactive,dregister as Date_register,lga,state,country as Country_ID,tel,email,website,sperson as Contact_Person,address,glcode,bank,bankbranch,accountid,sortcode,sectortype,hcpplan,pugrandtotal as Plan_GrandTotal FROM oganisationtab  order by oganames"
        ltitle.Text = "Oganization Listing"
        Me.Text = "Organization Listing"
        tablenamew = "OrganizationList.xlsx"
        BindGrid()
    End Sub
    Private Sub chartacct_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles chartacct.LinkClicked
        gstring1 = "SELECT accode, DESCRIPTN, ACTYPE, post_ac  as Header_AcctID, ACLEVEL, acactive, consolid, OPENBAL, ctype2 as Account_Group, acctbalcat, Runingbalance FROM accode order by DESCRIPTN"
        ltitle.Text = "Chart of Account Listing"
        Me.Text = "Chart of Account Listing"
        tablenamew = "ChartAcctList.xlsx"
        BindGrid()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        Try
            Dim str As String = txt_search.Text

            If Me.txt_search.Text.Trim(" ") = " " Then
            Else
                For i As Integer = 0 To listgrid.Rows.Count - 1
                    For j As Integer = 0 To Me.listgrid.Rows(i).Cells.Count - 1
                        If listgrid.Item(j, i).Value.ToString().ToLower.StartsWith(str.ToLower) Then
                            listgrid.Rows(i).Selected = True
                            listgrid.CurrentCell = listgrid.Rows(i).Cells(j)
                            Exit Try
                        End If
                    Next
                Next i
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub stafflist_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles stafflist.LinkClicked
        gstring1 = "SELECT staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as Names,title,sex,mstatus as Marital_Status,dengage as Date_hired,dofb as Date_of_Birth,age,tel,email,pofb as Place_of_Birth,natid,address ,pfa,lga ,state,country,cat as Category,position,glevel ,bankid,branch,dept,accountid,accttype,scode,suspended,suspendeddate, leavedays, leavebal,officebranch,lpromotedd FROM stafftab where staffid != 'ADMIN' order by staffid"

        ltitle.Text = "Staff List"
        Me.Text = "Staff List"
        tablenamew = "StaffList.xlsx"
        BindGrid()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dim result = MsgBox("Continue .......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            downall()
        End If




    End Sub
    Sub downall()



    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        'CrystalReportViewer1.Visible = True
        Try

            BindGrid2()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BindGrid2()

    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        'CrystalReportViewer1.Visible = False
        'listgrid.Visible = True
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.listgrid.Width, Me.listgrid.Height)
        listgrid.DrawToBitmap(bm, New Rectangle(0, 0, Me.listgrid.Width, Me.listgrid.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        PrintDocument1.Print()
    End Sub

    Private Sub exportexcel_Click(sender As Object, e As EventArgs) Handles exportexcel.Click
        Try
            msglbl.Text = "Generating Files Please wait.........."
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")


            For i = 0 To listgrid.RowCount - 2
                For j = 0 To listgrid.ColumnCount - 1
                    For k As Integer = 1 To listgrid.Columns.Count
                        xlWorkSheet.Cells(1, k) = listgrid.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = listgrid(j, i).Value.ToString()
                    Next
                Next
            Next

            getsavefile()
            '  MessageBox.Show(tablepathw + "\" + tablenamew)
            xlWorkSheet.SaveAs(tablepathw + "\" + tablenamew)
            '  xlWorkSheet.SaveAs("C:\dsnldoc\vbexcel.xlsx")
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            ' MsgBox("You can find the file C:\dsnldoc\vbexcel.xlsx")
            MessageBox.Show("File Export Successfully")
            msglbl.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Sub getsavefile()
            Dim strfilename As String = ""

        Dim didwork As Integer = FolderBD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            tablepathw = FolderBD.SelectedPath
            ' imgaepath.Text = strfilename
            FolderBD.Reset()
        End If
    End Sub






    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class