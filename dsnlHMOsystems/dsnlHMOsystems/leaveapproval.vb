Imports System.Data.SqlClient
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
Public Class leaveapproval
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring2 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Public inc As Integer
    Public MaxRows As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub leaveapproval_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        gstring2 = ""
    End Sub

    Private Sub leaveapproval_Load(sender As Object, e As EventArgs) Handles Me.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

    End Sub
    Sub BindGrid()
        Try
            Dim constring As String = My.Settings.cnnstring
            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand(gstring2, con)
                    cmd.CommandType = CommandType.Text
                    Using sda As New SqlDataAdapter(cmd)
                        Using ds As New DataSet()
                            sda.Fill(ds)
                            TrigerGridView.DataSource = ds.Tables(0)
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Leave Table")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.reportsqlstr = "runenleavetriger"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Leave Alert"
        viewreport2.Show()
    End Sub

End Class