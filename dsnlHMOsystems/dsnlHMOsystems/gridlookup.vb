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
Imports System.Security.Cryptography
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel
Public Class gridlookup

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub answersheettab_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles answersheettab.CellContentClick

    End Sub

    Private Sub gridlookup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim i2 As Integer
        For i2 = i2 To answersheettab.RowCount - 1
            answersheettab.Rows.Clear()
        Next
        '  MessageBox.Show(My.Settings.searchsqlstm)
        Dim gg2 As String = My.Settings.searchsqlstm
        '   MessageBox.Show(gg2)
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
                        answersheettab.Rows(row).Cells(2).Value = r(2)
                    End While
                End If

                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub

    Private Sub answersheettab_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles answersheettab.CellContentDoubleClick
        MessageBox.Show("You select  .. " + answersheettab.SelectedCells.Item(0).Value)
        My.Settings.searchid = answersheettab.SelectedCells.Item(0).Value
        Me.Close()
    End Sub
End Class