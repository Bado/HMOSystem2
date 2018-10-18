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
Imports System.Data.Odbc
Imports System.Drawing.Imaging
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class sincome
    Public sreportdate As Date
    Public ereportdate As Date

    'transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If typedesc.Text = "Statement of income - By Head Code" Then


            sreportdate = Format(sdate.Value, "yyyy-MM-dd")
            ereportdate = Format(edate.Value, "yyyy-MM-dd")
            delfirst()
            Try
                Dim sumSQL As String = "INSERT INTO transtabworks(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,credit,debit,period1)" & _
                                                         "select headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,0.00 as credit,total as debit,'" & ereportdate & "' FROM transtab where  transdate >= '" & Format(sdate.Value, "yyyy-MM-dd") & "' AND transdate <= '" & Format(edate.Value, "yyyy-MM-dd") & "' and typecode = 'RC'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd2 As SqlCommand = CCNN.CreateCommand
                    Cd2.CommandText = sumSQL
                    Cd2.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd2.ExecuteNonQuery()
                    '  MessageBox.Show("Record Posted Successfully")
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Occurs in UPDATE income Insert")
            End Try

            Try
                Dim sumSQL3 As String = "INSERT INTO transtabworks(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,credit,debit,period1)" & _
                                                         "select headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,total as credit,0.00 debit,'" & ereportdate & "' FROM transtab where  transdate >= '" & Format(sdate.Value, "yyyy-MM-dd") & "' AND transdate <= '" & Format(edate.Value, "yyyy-MM-dd") & "'  AND typecode = 'PY'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd2 As SqlCommand = CCNN.CreateCommand
                    Cd2.CommandText = sumSQL3
                    Cd2.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd2.ExecuteNonQuery()
                    '  MessageBox.Show("Record Posted Successfully")
                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Occurs in UPDATE expenditure Insert")
            End Try
            My.Settings.reportsqlstr = "printstmreport"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            viewreport2.Text = "Print statement of income Report"
            viewreport2.Show()
        End If
        If typedesc.Text = "Statement of income - By Account Code" Then

        End If
        welcomeme()
    End Sub
    Sub welcomeme()
        Dim unamess As String = My.Settings.loginname
        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Record Proccessed Successfully", frmMSGctrl.MessageType.Notice)
    End Sub
    Sub delfirst()
        Dim cSQL As String = "DELETE FROM transtabworks"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL

                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
        Catch ex As Exception


        End Try
    End Sub
End Class