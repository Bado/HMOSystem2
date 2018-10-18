Imports System.Text
Imports System.Net.Sockets
Imports System.Text.StringBuilder
Imports System.Threading
Imports System.Collections
Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
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
Public Class gencapitation
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public cnamess As String
    Private Sub gencapitation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        DoubleBuffered = True
        capitationgrid.EnableHeadersVisualStyles = False
        capitationgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        capitationgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        capitationgrid.ColumnHeadersHeight = 30
        capitationgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        nmonth.Text = "1"
        tcode.Focus()
        updatehmo()
        getsettingcode()
    End Sub

    Sub getsettingcode()
        Dim gg2 As String = "select companyid,paytcode from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    tcode.Text = LTrim(r(1).ToString)
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Public Sub UpdategencodeRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        Dim ttcode As String = Str(Val(tcode.Text) + 1)
        MessageBox.Show(ttcode)
        Try
            Dim cSQL As String = "UPDATE digitsettings SET paytcode = '" & LTrim(ttcode) & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                CCNN.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' clearrec()
    End Sub

    Sub delfirst()
        Dim sqlgen As String = "DELETE FROM gencapitation where tcode = '" & tcode.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = sqlgen
                CCNN.Open()
                Cd.ExecuteNonQuery()
                CCNN.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try
    End Sub
    Sub GENCAPTOENROLLES()
        'Try

        '    cSQL = "UPDATE Enrolleetab SET" _
        '           & " ugmfees = '" & Me.TextBox1.Text & "' " & " WHERE" & " code1 = '" & Me.code1.Text & "'"

        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd As SqlCommand = CCNN.CreateCommand
        '        Cd.CommandText = cSQL
        '        Cd.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Cd.ExecuteNonQuery()

        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Sub popgrid()

        Dim i2 As Integer
        For i2 = i2 To capitationgrid.RowCount - 1
            capitationgrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT hcpid, SPACE(70) AS HCPNAMES, SUM(1) AS PRINCIPAL, SUM(drelated) AS drelated, SUM(extra) AS extra, SUM(1) + SUM(drelated) + SUM(extra) AS TOTALLIVES, 0.00 AS CAPRATE, 0.00 AS CAPITATION FROM enrolleetab WHERE ugplan = 'ugplan1' AND active = 'False' and hcpid != ''  GROUP BY hcpid"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        '  MessageBox.Show(r(0))
                        Dim row As Integer = capitationgrid.Rows.Add
                        capitationgrid.Rows(row).Cells(0).Value = r(0)
                        capitationgrid.Rows(row).Cells(1).Value = r(1)
                        capitationgrid.Rows(row).Cells(2).Value = r(2)
                        capitationgrid.Rows(row).Cells(3).Value = r(3)
                        capitationgrid.Rows(row).Cells(4).Value = r(4)
                        capitationgrid.Rows(row).Cells(5).Value = r(5)
                        capitationgrid.Rows(row).Cells(6).Value = r(6)
                        capitationgrid.Rows(row).Cells(7).Value = r(7)
                    End While
                End If
                r.Close()
                capitationgrid.Refresh()
                gethcpnames()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()


        'gencapitation
    End Sub
   
    Sub gethcpnames()
        'MessageBox.Show(Int(nmonth.Text))
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Dim i As Integer
                If capitationgrid.RowCount > 0 Then
                    For i = 0 To capitationgrid.RowCount - 1
                        Cd3.CommandText = "SELECT hcpid,hcpname,ugmfees FROM enrolleetab WHERE" _
                                             & " rtrim(hcpid) = '" & RTrim(capitationgrid.Rows(i).Cells(0).Value) & "'"
                        Cd3.CommandType = CommandType.Text
                        CCNN.Open()
                        Dim rw As SqlDataReader = Cd3.ExecuteReader
                        If rw.HasRows = True Then
                            rw.Read()
                            capitationgrid.Rows(i).Cells(1).Value = RTrim(rw(1))
                            capitationgrid.Rows(i).Cells(6).Value = rw(2)
                            capitationgrid.Rows(i).Cells(7).Value = capitationgrid.Rows(i).Cells(6).Value * capitationgrid.Rows(i).Cells(5).Value
                            capitationgrid.Rows(i).Cells(7).Value = Val(capitationgrid.Rows(i).Cells(7).Value) * Val(nmonth.Text)
                        End If
                        '  Cd3.ExecuteNonQuery()
                        rw.Close()
                        CCNN.Close()
                    Next
                End If
                Me.Refresh()
            End Using

            savecapitation()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in gethcpnames Capitation Generation")
        End Try

    End Sub
    

    Sub savecapitation()
        delfirst()
        MessageBox.Show(Format(dateperiod.Value, "yyyy-MM-dd"))
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If capitationgrid.RowCount > 0 Then
                    For i = 0 To capitationgrid.RowCount - 1 ''familygrid.Rows(i).Cells(0).Value  where tcode = '" & tcode.Text  & '""
                        If (Not capitationgrid.Rows(i).Cells(0).Value = String.Empty) Then
                            Cd3.CommandText = "INSERT INTO gencapitation(hcpid,hcpname,principal,dependant,extra,totallives,capitationrate,capitation,dateperiod,tcode,nmonth,hmonames,posted)" & _
                                "VALUES('" & capitationgrid.Rows(i).Cells(0).Value & "','" & capitationgrid.Rows(i).Cells(1).Value & "','" & Val(capitationgrid.Rows(i).Cells(2).Value) & "','" & Val(capitationgrid.Rows(i).Cells(3).Value) & "','" & Val(capitationgrid.Rows(i).Cells(4).Value) & "','" & Val(capitationgrid.Rows(i).Cells(5).Value) & "','" & Val(capitationgrid.Rows(i).Cells(6).Value) & "','" & Val(capitationgrid.Rows(i).Cells(7).Value) & "','" & Format(dateperiod.Value, "yyyy-MM-dd") & "','" & tcode.Text & "','" & nmonth.Text & "','" & cnamess & "','" & False & "');"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                        End If

                        CCNN.Close()
                    Next
                End If
                saveaudit("Generate Capitation for Trans Code : " + tcode.Text + " In " + Me.Text)
                Me.Refresh()
                MessageBox.Show("Capitation Generated Successfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in savecapitation Capitation Generation Table")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        popgrid()
        welcomeme()
    End Sub
    Sub welcomeme()
        Dim unamess As String = My.Settings.loginname
        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Capitation Generated Successfully", frmMSGctrl.MessageType.Notice)
    End Sub
    Sub saveaudit(ByVal SWMODE As String)
        Dim uidd2 As String = My.Settings.loginid
        Dim date11 As DateTime
        ' Dim SWMODE As String = "Login into the system"
        date11 = Now
        Dim sumStr As String = "INSERT INTO audittab(userid, action1, period) VALUES('" & uidd2 & "','" & SWMODE & "','" & date11 & "')"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumStr
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '   CCNN.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If capitationgrid.RowCount > 0 Then

            My.Settings.reportsqlstr = "PrintCapitation"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            viewreport2.Text = "Print Capitation Report"
            rptrangecode = tcode.Text
            viewreport2.Show()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RTrim(poststat.Text) = "Posted" Then

        Else
            Dim result = MsgBox("Continue .......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
            If result = vbYes Then
                UpdategencodeRecord()

                Try
                    Using CCNN As New SqlConnection(My.Settings.cnnstring)
                        Dim Cd3 As SqlCommand = CCNN.CreateCommand
                        Cd3.CommandType = CommandType.Text
                        Dim i As Integer
                        If capitationgrid.RowCount > 0 Then
                            For i = 0 To capitationgrid.RowCount - 1
                                Cd3.CommandText = "UPDATE Hcptab SET" _
                                  & " lpay = '" & Val(capitationgrid.Rows(i).Cells(7).Value) & "', " & " paidtodate += '" & Val(capitationgrid.Rows(i).Cells(7).Value) & "'  where  rtrim(hcpid) = '" & RTrim(capitationgrid.Rows(i).Cells(0).Value) & "'"
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()
                            Next
                        End If
                        Me.Refresh()
                    End Using
                    saveaudit("Post Capitation for Trans Code : " + tcode.Text + " In " + Me.Text)
                    Me.Refresh()
                    '     updateposted()
                    MessageBox.Show("Capitation Posted Successfully")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Occurs in Capitation Posted")
                End Try
                Dim i2 As Integer
                For i2 = i2 To capitationgrid.RowCount - 1
                    capitationgrid.Rows.Clear()
                Next
                poststat.Text = "Status..."
                Button1.Enabled = True
                updateposted()
            End If
        End If
    End Sub
    Sub updateposted()

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd4 As SqlCommand = CCNN.CreateCommand
                Cd4.CommandType = CommandType.Text
                Dim ii As Integer
                If capitationgrid.RowCount > 0 Then
                    For ii = 0 To capitationgrid.RowCount - 1 ''familygrid.Rows(i).Cells(0).Value  where tcode = '" & tcode.Text  & '""
                        If (Not capitationgrid.Rows(ii).Cells(0).Value = String.Empty) Then
                            Cd4.CommandText = "UPDATE gencapitation SET" _
                            & " posted = '" & True & "' " & " WHERE" & " rtrim(tcode) = '" & RTrim(Me.tcode.Text) & "'"
                            CCNN.Open()
                            Cd4.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                Me.Refresh()
            End Using
            popexistgrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in updateposted Capitation Table")
        End Try

    End Sub
    Private Sub tcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tcode.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not tcode.Text = String.Empty) Then
                popexistgrid()
            End If
        End If
    End Sub

    Sub popexistgrid()

        Dim i2 As Integer
        For i2 = i2 To capitationgrid.RowCount - 1
            capitationgrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT hcpid,hcpname,principal,dependant,extra,totallives ,capitationrate,capitation,dateperiod,tcode," & _
            "posted FROM gencapitation where tcode = '" & tcode.Text & "' and dateperiod = '" & Format(dateperiod.Value, "yyyy-MM-dd") & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        '  MessageBox.Show(r(0))
                        Dim row As Integer = capitationgrid.Rows.Add
                        capitationgrid.Rows(row).Cells(0).Value = r(0)
                        capitationgrid.Rows(row).Cells(1).Value = r(1)
                        capitationgrid.Rows(row).Cells(2).Value = r(2)
                        capitationgrid.Rows(row).Cells(3).Value = r(3)
                        capitationgrid.Rows(row).Cells(4).Value = r(4)
                        capitationgrid.Rows(row).Cells(5).Value = r(5)
                        capitationgrid.Rows(row).Cells(6).Value = r(6)
                        capitationgrid.Rows(row).Cells(7).Value = r(7)
                        If r(10) = True Then
                            poststat.Text = "Posted"
                            Button1.Enabled = False
                        End If
                    End While
                End If
                r.Close()
                capitationgrid.Refresh()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
        'gencapitation
    End Sub
   
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select distinct tcode,hcpname,dateperiod from gencapitation order by dateperiod"
            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            tcode.Text = CODDY
            tcode.Refresh()
            Me.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim i2 As Integer
        For i2 = i2 To capitationgrid.RowCount - 1
            capitationgrid.Rows.Clear()
        Next
        poststat.Text = "Status..."
        Button1.Enabled = True
    End Sub

   
    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles postedlink.Click
        Dim result = MsgBox("Continue .......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            '   
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd4 As SqlCommand = CCNN.CreateCommand
                    Cd4.CommandType = CommandType.Text
                    Dim ii As Integer
                    If capitationgrid.RowCount > 0 Then
                        '    MessageBox.Show(capitationgrid.Rows(ii).Cells(0).Value)
                        For ii = 0 To capitationgrid.RowCount - 1 ''familygrid.Rows(i).Cells(0).Value  where tcode = '" & tcode.Text  & '""
                            Cd4.CommandText = "UPDATE gencapitation SET" _
                            & " posted = '" & True & "' " & " WHERE" & " rtrim(tcode) = '" & RTrim(Me.tcode.Text) & "'"
                            CCNN.Open()
                            Cd4.ExecuteNonQuery()
                            CCNN.Close()
                        Next
                    End If
                    Me.Refresh()
                End Using
                popexistgrid()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Occurs in updateposted Capitation Table")
            End Try
        End If
    End Sub
    Sub updatehmo()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT accountname FROM digitsettings"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    cnamess = r(0)
                    Me.Refresh()
                    r.Close()
                End If
            End Using
            '   MessageBox.Show(plink)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub capitationgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles capitationgrid.CellContentClick

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        savecapitation()
    End Sub
End Class