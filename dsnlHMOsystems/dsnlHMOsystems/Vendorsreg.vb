Imports System.Text
Imports System.Net.Sockets
Imports System.Text.StringBuilder
Imports System.Threading
Imports System.Collections
Imports System.Diagnostics
Public Class Vendorsreg

    Private Sub Vendorsreg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenEmail(email.Text)
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Process.Start(wsite.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Function OpenEmail(ByVal EmailAddress As String, _
    Optional ByVal Subject As String = "", _
    Optional ByVal Body As String = "") _
    As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & Subject

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & Body
        End If


        Try

            System.Diagnostics.Process.Start(sParams)

        Catch
            bAns = False
        End Try

        Return bAns

    End Function
End Class