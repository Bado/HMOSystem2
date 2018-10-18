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
Public Class audittrail
    Public dfolder As String
    Public gg2 As String
    Sub sgprocess()
        Dim dfrommm As Date = dfrom.Value
        Dim dtoo As Date = dto.Value
        If sg.Checked = True Then
            gg2 = "SELECT userid,action1,period FROM audittab where" _
              & " period >= '" & dfrommm & "' AND period <= '" & dtoo & "' AND userid = '" & Slist.SelectedValue & "'" & " order by period"
        End If

        If All.Checked = True Then

            gg2 = "SELECT userid,action1,period FROM audittab where" _
              & " period >= '" & dfrommm & "' AND period <= '" & dtoo & "'" & " order by period"
        End If
        Try


            Dim I As Integer
            For I = I To answersheettab.RowCount - 1
                answersheettab.Rows.Clear()
            Next


            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    '  MessageBox.Show("HasRows")
                    While r.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                        answersheettab.Rows(row).Cells(2).Value = r(2)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If PB.Checked Then
            sgprocess()
        End If
        If DB.Checked Then
            del()
        End If
        If FB.Checked Then
            filedownload()
        End If
    End Sub

    Sub loadstaffsearchcombo()
        Slist.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from stafftab order by staffid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Slist.DataSource = ds.Tables(0)
            Slist.ValueMember = "staffid"
            Slist.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Private Sub audittrail_Load(sender As Object, e As EventArgs) Handles Me.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        answersheettab.EnableHeadersVisualStyles = False
        answersheettab.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        answersheettab.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        answersheettab.ColumnHeadersHeight = 30
        answersheettab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        loadstaffsearchcombo()
        'TODO: This line of code loads data into the 'UserAccountTab.useracct' table. You can move, or remove it, as needed.
        Slist.Enabled = False
        '  Me.UseracctTableAdapter.Fill(Me.UserAccountTab.useracct)
        Try
            Dim gg2 As String = "SELECT userid,action1,period FROM audittab order by period"

            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    '  MessageBox.Show("HasRows")
                    While r.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                        answersheettab.Rows(row).Cells(2).Value = r(2)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try

        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd As SqlCommand = CCNN.CreateCommand
        '        Cd.CommandText = "SELECT bcodedidgit,tnp,scode,tns,filepath,filepath2 FROM digitsettings WHERE" _
        '        & " scode = '" & My.Settings.sloginid & "'"
        '        Cd.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Dim r As SqlDataReader = Cd.ExecuteReader
        '        If r.HasRows Then
        '            r.Read()
        '            dfolder = Trim(r(5))
        '        End If
        '        Me.Refresh()
        '        r.Close()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Dim dfrommm As Date = dfrom.Value
        Dim dtoo As Date = dto.Value
    End Sub
    Sub del()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then


            Try
                Dim dfrommm As Date = dfrom.Value
                Dim dtoo As Date = dto.Value
                Dim cSQL As String = "DELETE FROM audittab WHERE" _
             & " period >= '" & dfrommm & "' AND period <= '" & dtoo & "'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    MessageBox.Show("Record Deleted Sucessfully")
                    If result = vbNo Then
                        Me.Close()
                    End If
                    reloadgrid()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        '   End If
    End Sub
    Sub reloadgrid()
        Try
            Dim I As Integer
            For I = I To answersheettab.RowCount - 1
                answersheettab.Rows.Clear()
            Next
            Dim gg2 As String = "SELECT userid,action1,period FROM audittab order by period"

            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    '  MessageBox.Show("HasRows")
                    While r.Read
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                        answersheettab.Rows(row).Cells(2).Value = r(2)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub filedownload()
        sgprocess()
        Try
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")


            For i = 0 To answersheettab.RowCount - 1
                For j = 0 To answersheettab.ColumnCount - 1
                    For k As Integer = 1 To answersheettab.Columns.Count
                        xlWorkSheet.Cells(1, k) = answersheettab.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 9, j + 1) = answersheettab(j, i).Value.ToString()
                    Next
                Next
            Next

            MDIParent1.statusmsg.Text = "Processing, Please wait"
            xlWorkSheet.SaveAs(dfolder + "\" + Trim(filepath.Text) + ".xlsx")
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            MDIParent1.statusmsg.Text = "Processing, Please wait"
            Dim res As MsgBoxResult
            res = MsgBox("Process completed, Would you like to open file?", MsgBoxStyle.YesNo)
            If (res = MsgBoxResult.Yes) Then
                Process.Start(dfolder + "\" + Trim(filepath.Text) + ".xlsx")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub sg_CheckedChanged(sender As Object, e As EventArgs) Handles sg.CheckedChanged
        Slist.Enabled = True
    End Sub

    Private Sub All_CheckedChanged(sender As Object, e As EventArgs) Handles All.CheckedChanged
        Slist.Enabled = False
        Slist.Text = "None"
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Previewbtn.Click
        Dim dfrommm As Date = Format(dfrom.Value, "yyyy-MM-dd")
        Dim dtoo As Date = Format(dto.Value, "yyyy-MM-dd")
        My.Settings.reportsqlstr = "audittrailoption"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        rptrangecode = Format(dfrom.Value, "yyyy-MM-dd")
        rptrangecode2 = Format(dto.Value, "yyyy-MM-dd")
        If sg.Checked = True Then
            audisql2 = "S"
            audisql3 = RTrim(Slist.SelectedValue.ToString)
            'audisql = "SELECT userid,action1,period FROM audittab Where period >= '" & dfrommm & "' AND period <= '" & dtoo & "' AND userid = '" & Slist.SelectedValue & "' order by period"
        End If

        If All.Checked = True Then
            audisql3 = ""
            audisql2 = "A"
            'audisql = "SELECT userid,action1,period FROM audittab Where period >= '" & dfrommm & "' AND period <= '" & dtoo & "' order by period"
        End If
        'MessageBox.Show(audisql)
        viewreport2.Text = " Audit Trail Option "
        viewreport2.Show()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class