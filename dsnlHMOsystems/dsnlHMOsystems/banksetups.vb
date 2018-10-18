Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class banksetups
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Private Sub banksetups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        bankgrid.EnableHeadersVisualStyles = False
        bankgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        bankgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        bankgrid.ColumnHeadersHeight = 30
        bankgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing


        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select bankcode,rtrim(branch) as names from BANKSETUP"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            bank.DataSource = ds.Tables(0)
            bank.ValueMember = "bankcode"
            bank.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Public Sub saverec()
        Dim result = MsgBox("Continue Saving.......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            InsertRecordperiod()
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Sub loagriddata()
        Dim i2 As Integer
        For i2 = i2 To bankgrid.RowCount - 1
            bankgrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT BANKCODE,NAMES,sortcode,BRANCH,CMANAGER1,address FROM BANKSETUP where RTrim(bankcode) = '" & BANKCODE.Text & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    Names.Text = r(1)
                    While r.Read
                        Dim row As Integer = bankgrid.Rows.Add
                        bankgrid.Rows(row).Cells(2).Value = r(2)
                        bankgrid.Rows(row).Cells(3).Value = r(3)
                        bankgrid.Rows(row).Cells(4).Value = r(4)
                        bankgrid.Rows(row).Cells(5).Value = r(5)
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()

















        'Dim i2 As Integer
        'For i2 = i2 To bankgrid.RowCount - 1
        '    bankgrid.Rows.Clear()
        'Next
        ''  MessageBox.Show("inside load")
        'Dim gg2 As String = "SELECT BANKCODE,NAMES,sortcode,BRANCH,CMANAGER1,address FROM BANKSETUP where RTrim(bankcode) = '" & RTrim(codee.Text) & "'"
        'Try
        '    Using ccnn As New SqlConnection(My.Settings.cnnstring)
        '        Dim cd As SqlCommand = ccnn.CreateCommand
        '        cd.CommandText = gg2
        '        cd.CommandType = CommandType.Text
        '        ccnn.Open()
        '        Dim r As SqlDataReader = cd.ExecuteReader
        '        If r.HasRows() Then
        '            'MessageBox.Show("in")
        '            MessageBox.Show(r(1))
        '            Names.Text = r(1)
        '            While r.Read
        '                Dim row As Integer = bankgrid.Rows.Add
        '                bankgrid.Rows(row).Cells(2).Value = r(2)
        '                bankgrid.Rows(row).Cells(3).Value = r(3)
        '                bankgrid.Rows(row).Cells(4).Value = r(4)
        '                bankgrid.Rows(row).Cells(5).Value = r(5)
        '                MessageBox.Show(bankgrid.Rows(row).Cells(2).Value)
        '            End While
        '        End If
        '        r.Close()
        '        Me.Refresh()
        '    End Using
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = ex.Message
        'End Try
        'Me.Refresh()
    End Sub
    Sub delbankfirst()

        Dim cSQL5 As String = "DELETE FROM BANKSETUP where BANKCODE = '" & BANKCODE.Text & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL5
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
            '     MessageBox.Show("Record Deleted Successfully")
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try
    End Sub
    Public Sub InsertRecordperiod()  'Subroutine to insert a record into the database  
        delbankfirst()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If bankgrid.RowCount > 0 Then
                    For i = 0 To bankgrid.RowCount - 1
                        If Not bankgrid.Rows(i).Cells(0).Value = String.Empty Then
                            Cd3.CommandText = "INSERT INTO BANKSETUP(BANKCODE,NAMES,sortcode,BRANCH,CMANAGER1,address) VALUES('" & BANKCODE.Text & "','" & Names.Text & "','" & bankgrid.Rows(i).Cells(0).Value & "','" & bankgrid.Rows(i).Cells(1).Value & "','" & bankgrid.Rows(i).Cells(2).Value & "','" & bankgrid.Rows(i).Cells(3).Value & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update Bankcode code : " + BANKCODE.Text + " In " + Me.Text)
                MessageBox.Show("Record Saved Successfully")
                Me.Refresh()
                '  MessageBox.Show("Batch Save/Update Sucessfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Inserting BANKSETUP ")
        End Try
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

    'Private Sub CODE_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If Asc(e.KeyChar) = Keys.Enter Then
    '        If (Not BANKCODE.Text = String.Empty) Then
    '            loagriddata()
    '        End If
    '    End If
    'End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub
    Sub delrec()
        Dim result = MsgBox("Delete Record Continue.......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Dim cSQL5 As String = "DELETE FROM BANKSETUP where BANKCODE = '" & BANKCODE.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL5
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
                MessageBox.Show("Record Deleted Successfully")
            Catch ex As Exception
                '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
            End Try
        End If
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        '  BANKCODE.Text = ""
        Names.Text = ""
        Dim i2 As Integer
        For i2 = i2 To bankgrid.RowCount - 1
            bankgrid.Rows.Clear()
        Next
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        '  BANKCODE.Text = ""
        Names.Text = ""
        Dim i2 As Integer
        For i2 = i2 To bankgrid.RowCount - 1
            bankgrid.Rows.Clear()
        Next

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        saverec()
    End Sub

    Private Sub DeleteEnrolleeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteEnrolleeToolStripMenuItem.Click
        delrec()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub bank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bank.SelectedIndexChanged
        Try
            '   clearrec()
            BANKCODE.Text = bank.SelectedValue.ToString
            BANKCODE.Focus()
            If (Not BANKCODE.Text = String.Empty) Then
                loagriddata()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BANKCODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BANKCODE.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not BANKCODE.Text = String.Empty) Then
                loagriddata()
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loagriddata()
    End Sub
 
End Class