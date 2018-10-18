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
Public Class Utilisationfeesgen
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Private Sub Utilisationfeesgen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        listgrid.EnableHeadersVisualStyles = False
        listgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        listgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        listgrid.ColumnHeadersHeight = 30
        listgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        ogaplangrid.EnableHeadersVisualStyles = False
        ogaplangrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        ogaplangrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        ogaplangrid.ColumnHeadersHeight = 30
        ogaplangrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select ogaid,rtrim(ogaNames)  as names from oganisationtab where ugplan = 'ugplan2' order by ogaid"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "ogaid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
    End Sub

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        Try
            ogaid.Text = Searchtool.SelectedValue.ToString
            oganames.Text = Searchtool.Text.ToString
            pugrandtotal.Text = 0.0
            Utidefaultfees.Text = 0.0
            Dim i2 As Integer
            For i2 = i2 To ogaplangrid.RowCount - 1
                ogaplangrid.Rows.Clear()
            Next
            LoadRecord()
            ogaid.Focus()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        Dim dd As String = " Select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,sdate,edate,NHIS,hplan,ugyfees as Capitation FROM enrolleetab WHERE" _
                & " rtrim(ogaid) = '" & RTrim(ogaid.Text) & "' and  active = '" & False & "'"
        Try
            Dim constring As String = My.Settings.cnnstring
            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand(dd, con)
                    cmd.CommandType = CommandType.Text
                    Using sda As New SqlDataAdapter(cmd)
                        Using ds As New DataSet()
                            sda.Fill(ds)

                            listgrid.DataSource = ds.Tables(0)
                        End Using
                    End Using
                End Using
            End Using
            LoadnewPLANgrid()
            calgrandtotal()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Organization Table")
        End Try


    End Sub

    Sub LoadnewPLANgrid()
        '  MessageBox.Show("in LoadnewPLANgrid")
        Dim dd As String = " Select ogaid,Ugplan,Utidefaultfees FROM oganisationtab WHERE" _
         & " rtrim(ogaid) = '" & RTrim(ogaid.Text) & "' and  active = '" & False & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = dd
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim rr As SqlDataReader = cd.ExecuteReader
                If rr.HasRows() Then
                    rr.Read()
                    If RTrim(rr(1)) = "ugplan1" Then
                        ugplan1.Checked = True
                        Utidefaultfees.Text = rr(2)
                    Else
                        popgrid()
                        ugplan2.Checked = True
                    End If


                End If
                rr.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Sub popgrid()
        Dim i2 As Integer
        For i2 = i2 To ogaplangrid.RowCount - 1
            ogaplangrid.Rows.Clear()
        Next
        Dim gg2 As String = "select CODE1,DESCR,NINPLAN,UPRICE,AMOUNT,OGAID from ogaplangrid where OGAID = '" & ogaid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = ogaplangrid.Rows.Add
                        ogaplangrid.Rows(row).Cells(0).Value = r(0)
                        ogaplangrid.Rows(row).Cells(1).Value = r(1)
                        ogaplangrid.Rows(row).Cells(2).Value = FormatNumber(r(2), 2, TriState.True)
                        ogaplangrid.Rows(row).Cells(3).Value = r(3)
                        ogaplangrid.Rows(row).Cells(4).Value = FormatNumber(r(4), 2, TriState.True)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub calgrandtotal()
        Dim gg2 As String = "select sum(AMOUNT) as amtnow from ogaplangrid where ogaid = '" & ogaid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    pugrandtotal.Text = FormatNumber(r(0), 2, TriState.True)
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If (Not ogaid.Text = String.Empty) Then
        '    If ugplan.Checked = True Then
        '        candefault()
        '    End If
        '    If ugplan3.Checked = True Then

        '    End If
        'End If
        canpla()
        welcomeme()

        ' Dim dd As String = " Select ogaid,Ugplan,Utidefaultfees FROM oganisationtab WHERE" _
        '& " rtrim(ogaid) = '" & RTrim(ogaid.Text) & "' and  active = '" & False & "'"
        ' Try
        '     Using ccnn As New SqlConnection(My.Settings.cnnstring)
        '         Dim cd As SqlCommand = ccnn.CreateCommand

        '         cd.CommandText = dd
        '         cd.CommandType = CommandType.Text
        '         ccnn.Open()
        '         Dim rr As SqlDataReader = cd.ExecuteReader
        '         If rr.HasRows() Then
        '             rr.Read()
        '             If RTrim(rr(1)) = "ugplan1" Then

        '             Else

        '             End If
        '         End If
        '         rr.Close()
        '         Me.Refresh()
        '     End Using
        ' Catch ex As Exception
        '     MDIParent1.statusmsg.Text = ex.Message
        ' End Try

    End Sub
    Sub welcomeme()
        Dim unamess As String = My.Settings.loginname
        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Premium Fees distribution Successfully", frmMSGctrl.MessageType.Notice)
    End Sub
    Sub canpla()

        Dim result = MsgBox("Generate Premium - Continue .......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd3 As SqlCommand = CCNN.CreateCommand
                    Cd3.CommandType = CommandType.Text
                    Dim i As Integer
                    If ogaplangrid.RowCount > 0 Then
                        For i = 0 To ogaplangrid.RowCount - 1
                            Cd3.CommandText = "UPDATE enrolleetab SET" _
                              & " ugyfees = '" & Val(ogaplangrid.Rows(i).Cells(3).Value) & "', " & " ugmfees = '" & 0.0 & "', " & " sdate = '" & Format(sdate.Value, "yyyy-MM-dd") & "', " & " edate = '" & Format(edate.Value, "yyyy-MM-dd") & "' " & " WHERE" & " rtrim(ogaid) = '" & RTrim(ogaid.Text) & "' and rtrim(hplan) = '" & RTrim(ogaplangrid.Rows(i).Cells(0).Value) & "'"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        Next
                    End If
                    LoadRecord()
                    Me.Refresh()
                End Using
                MessageBox.Show("Utilisation Generated Successfully")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Occurs in Utilisation Generation")
            End Try
        End If
    End Sub
    Sub candefault()
        Try
            cSQL = "UPDATE enrolleetab SET" _
                   & " ugyfees = '" & Val(Utidefaultfees.Text) * 12 & "', " & " ugmfees = '" & Val(Utidefaultfees.Text) & "', " & " sdate = '" & Me.sdate.Value & "', " & " edate = '" & Me.edate.Value & "' " & " WHERE" & " rtrim(ogaid) = '" & RTrim(Me.ogaid.Text) & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Utilisation Generated Successfully")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles ugplan3.CheckedChanged
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select ogaid,rtrim(ogaNames)  as names from oganisationtab where ugplan = 'ugplan2' order by ogaid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "ogaid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles ugplan.CheckedChanged
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select ogaid,rtrim(ogaNames)  as names from oganisationtab where ugplan = 'ugplan1' order by ogaid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "ogaid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class