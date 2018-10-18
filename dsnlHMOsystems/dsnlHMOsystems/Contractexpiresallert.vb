
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
Public Class Contractexpiresallert
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
            addtomail()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Client Contract Expires Table")
        End Try

    End Sub
 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.reportsqlstr = "runClienttrigercall"
        Dim viewreport2 As New viewreport
        viewreport2.MdiParent = MDIParent1
        viewreport2.Text = "Print Client Contract Expires Alert"
        viewreport2.Show()
    End Sub

    Private Sub Contractexpiresallert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
       
    End Sub
 
    Public Function OpenEmail(ByVal EmailAddress As String, _
    Optional ByVal Subject As String = ":", _
    Optional ByVal Body As String = "") _
    As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & " '" & mSubject.Text & "'"

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & " :  '" & "" & "'"
        End If
        Try
            System.Diagnostics.Process.Start(sParams)
        Catch
            bAns = False
        End Try

        Return bAns

    End Function

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If (Not mailh.Text = String.Empty) Then
            OpenEmail(mailh.Text)
        End If
    End Sub

    Private Sub mbody_TextChanged(sender As Object, e As EventArgs) Handles mSubject.TextChanged

    End Sub
    Sub addtomail()
        Dim T As Integer
        For T = T To TrigerGridView.RowCount - 1
            mailh.Text = mailh.Text + RTrim(TrigerGridView.Rows(T).Cells(2).Value) + ","
        Next
    End Sub

End Class