Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class claimspayappr
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
    Private Sub claimspayappr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        claimgrid.EnableHeadersVisualStyles = False
        claimgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        claimgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        claimgrid.ColumnHeadersHeight = 40
        claimgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        claimpayhistory.EnableHeadersVisualStyles = False
        claimpayhistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        claimpayhistory.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        claimpayhistory.ColumnHeadersHeight = 40
        claimpayhistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        pugrandtotal2.Text = 0.0
        loadenrol2searchcombo()
        loadailment2codecombo()
        loadailment2codecombo2()
        loadenrol2searchcombo2()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select hcpid,rtrim(Names)  as names from Hcptab order by hcpid"

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
            Searchtool.ValueMember = "hcpid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinputeApproved WHERE" _
                    & " appsendto = '" & My.Settings.loginid & "' and Mdapproves = '" & False & "' order by tdate"

            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            batchcode2.Text = CODDY
            batchcode2.Refresh()
            Me.Refresh()

            If (Not batchcode2.Text = String.Empty) Then
                batchcode2.Refresh()
                loadapprovedgriddata2()
                calctotal()
                batchcode2.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub calctotal()
        Dim ColSum2 As Decimal
        For Each RR As DataGridViewRow In claimgrid.Rows
            ColSum2 += RR.Cells(5).Value
            pugrandtotal2.Text = FormatNumber(ColSum2, 2, True, True, True)
        Next
    End Sub
    Sub loadapprovedgriddata2()

        Dim i2 As Integer
        For i2 = i2 To claimgrid.RowCount - 1
            claimgrid.Rows.Clear()
        Next

        Dim gg2 As String = "select hcpid,enrolleeid,dtreated,ailmentcode,defaultamt,billamount,Mdapproves,hcpname,tdate,batchcode,variance,authocode from claimsinputeApproved where rtrim(batchcode) = '" & RTrim(batchcode2.Text) & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = claimgrid.Rows.Add
                        claimgrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        claimgrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        claimgrid.Rows(row).Cells(2).Value = r(2)
                        claimgrid.Rows(row).Cells(3).Value = RTrim(r(3))
                        claimgrid.Rows(row).Cells(4).Value = Val(r(4))
                        claimgrid.Rows(row).Cells(5).Value = Val(r(5))
                        claimgrid.Rows(row).Cells(6).Value = r(6)
                        hcpnamess.Text = RTrim(r(7))
                        claimgrid.Rows(row).Cells(1).ReadOnly = True
                        claimgrid.Rows(row).Cells(3).ReadOnly = True

                    End While
                End If
                r.Close()
                calgrandtotal()
                Me.Refresh()
            End Using
            'loaddeafult()
            'Loadnewilnessgrid()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub loadailment2codecombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select code1,descr from Ailmenttypedefault order by code1"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ailmentt2.DataSource = ds.Tables(0)
            ailmentt2.ValueMember = "code1"
            ailmentt2.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try  'ailmentt2
    End Sub

    Sub loadenrol2searchcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from enrolleetab order by enrolleeid"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            enrolleeid2.DataSource = ds.Tables(0)
            enrolleeid2.ValueMember = "enrolleeid"
            enrolleeid2.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try  'enrolleeid2
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
    Sub calgrandtotal()
        Dim ColSum As Decimal
        For Each R As DataGridViewRow In claimgrid.Rows
            ColSum += R.Cells(5).Value
            pugrandtotal2.Text = FormatNumber(ColSum, 2, True, True, True)
        Next
        Dim ColSum2 As Decimal
        For Each RR As DataGridViewRow In claimpayhistory.Rows
            ColSum2 += RR.Cells(5).Value
            pugrandtotal.Text = FormatNumber(ColSum2, 2, True, True, True)
        Next
      
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        calgrandtotal()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        calgrandtotal()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If (Not batchcode2.Text = String.Empty) Then
            Dim result = MsgBox("Continue Approving .......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)

            If result = vbYes Then
                Try
                    Using CCNN As New SqlConnection(My.Settings.cnnstring)
                        Dim Cd3 As SqlCommand = CCNN.CreateCommand
                        Cd3.CommandType = CommandType.Text
                        Dim i As Integer
                        If claimgrid.RowCount > 0 Then
                            For i = 0 To claimgrid.RowCount - 1
                                Cd3.CommandText = "UPDATE claimsinputeApproved SET" _
                                  & " mdapproves = '" & True & "', " & " billamount = '" & claimgrid.Rows(i).Cells(5).Value & "', " & " batchtotal = '" & CDec(pugrandtotal2.Text) & "', " & " paid = '" & False & "' " & " WHERE" & " hcpid = '" & claimgrid.Rows(i).Cells(0).Value & "' and batchcode = '" & Me.batchcode2.Text & "'  and ailmentcode = '" & claimgrid.Rows(i).Cells(3).Value & "' and enrolleeid = '" & claimgrid.Rows(i).Cells(1).Value & "' "
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()
                            Next
                        End If
                        saveapprovedd33()
                        Me.Refresh()
                    End Using
                    MessageBox.Show("Batch Posted to account for payment")
                    clearrec()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Occurs in payment approvals")
                End Try
            End If
        End If
    End Sub
    Sub saveapprovedd33()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If claimgrid.RowCount > 0 Then
                    For i = 0 To claimgrid.RowCount - 1
                        Cd3.CommandText = "UPDATE claimsinpute SET" _
                          & "  allertstop = '" & True & "' " & " WHERE" & " batchcode = '" & Me.batchcode2.Text & "'"
                        CCNN.Open()
                        Cd3.ExecuteNonQuery()
                        CCNN.Close()
                    Next
                End If
                saveaudit("Approved Payment for Batcgcode : " + batchcode2.Text + " In " + Me.Text)
                Me.Refresh()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Stop Alert approval")
        End Try

    End Sub
    Sub clearrec()
        batchcode2.Text = ""
        hcpnamess.Text = ""
        pugrandtotal2.Text = 0.0
        Dim i23 As Integer
        For i23 = i23 To claimgrid.RowCount - 1
            claimgrid.Rows.Clear()
        Next
        Dim i24 As Integer
        For i24 = i24 To claimpayhistory.RowCount - 1
            claimpayhistory.Rows.Clear()
        Next
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
    End Sub
    Sub loadpayhistorygriddata()
        Dim i2 As Integer
        For i2 = i2 To claimpayhistory.RowCount - 1
            claimpayhistory.Rows.Clear()
        Next

        Dim gg2 As String = "select hcpid,enrolleeid,dtreated,ailmentcode,defaultamt,billamount,batchcode from claimsinputeApproved where" _
                             & " tdate >= '" & Format(gendate2.Value, "yyyy-MM-dd") & "' and  tdate < = '" & Format(gendate3.Value, "yyyy-MM-dd") & "' and Mdapproves = '" & True & "' and RTrim(hcpid) = '" & RTrim(Searchtool.SelectedValue) & "' order by batchcode"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = claimpayhistory.Rows.Add
                        claimpayhistory.Rows(row).Cells(0).Value = RTrim(r(0))
                        claimpayhistory.Rows(row).Cells(1).Value = RTrim(r(1))
                        claimpayhistory.Rows(row).Cells(2).Value = r(2)
                        claimpayhistory.Rows(row).Cells(3).Value = r(3)
                        claimpayhistory.Rows(row).Cells(4).Value = Val(r(4))
                        claimpayhistory.Rows(row).Cells(5).Value = Val(r(5))
                        claimpayhistory.Rows(row).Cells(6).Value = r(6)
                        claimpayhistory.Rows(row).Cells(1).ReadOnly = True
                        claimpayhistory.Rows(row).Cells(4).ReadOnly = True
                    End While
                End If
                r.Close()
                calgrandtotal()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If byhcp.Checked = True Then
            loadpayhistorygriddata()
        End If
        If all.Checked = True Then
            loadpayhistorygriddata2()
        End If



    End Sub
    Sub loadpayhistorygriddata2()
        Dim i2 As Integer
        For i2 = i2 To claimpayhistory.RowCount - 1
            claimpayhistory.Rows.Clear()
        Next

        Dim gg2 As String = "select hcpid,enrolleeid,dtreated,ailmentcode,defaultamt,billamount,batchcode from claimsinputeApproved where" _
                             & " tdate >= '" & Format(gendate2.Value, "yyyy-MM-dd") & "' and  tdate < = '" & Format(gendate3.Value, "yyyy-MM-dd") & "' and Mdapproves = '" & True & "' order by batchcode"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = claimpayhistory.Rows.Add
                        claimpayhistory.Rows(row).Cells(0).Value = RTrim(r(0))
                        claimpayhistory.Rows(row).Cells(1).Value = RTrim(r(1))
                        claimpayhistory.Rows(row).Cells(2).Value = r(2)
                        claimpayhistory.Rows(row).Cells(3).Value = r(3)
                        claimpayhistory.Rows(row).Cells(4).Value = Val(r(4))
                        claimpayhistory.Rows(row).Cells(5).Value = Val(r(5))
                        claimpayhistory.Rows(row).Cells(6).Value = r(6)
                        claimpayhistory.Rows(row).Cells(1).ReadOnly = True
                        claimpayhistory.Rows(row).Cells(4).ReadOnly = True
                    End While
                End If
                r.Close()
                calgrandtotal()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub loadailment2codecombo2()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select code1,descr from Ailmenttypedefault order by code1"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ailmentid3.DataSource = ds.Tables(0)
            ailmentid3.ValueMember = "code1"
            ailmentid3.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try  'ailmentt2
    End Sub

    Sub loadenrol2searchcombo2()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from enrolleetab order by enrolleeid"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            enrolleeid3.DataSource = ds.Tables(0)
            enrolleeid3.ValueMember = "enrolleeid"
            enrolleeid3.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try  'enrolleeid2
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
    Private Sub batchcode2_TextChanged(sender As Object, e As EventArgs) Handles batchcode2.TextChanged

    End Sub
    Private Sub batchcode2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles batchcode2.Validating
        If (Not batchcode2.Text = String.Empty) Then
            loadapprovedgriddata2()
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        For Each RR As DataGridViewRow In claimgrid.Rows
            If RR.Cells(6).Value = True Then
                RR.Cells(6).Value = False
            Else
                RR.Cells(6).Value = True
            End If
        Next
    End Sub

    

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        If (Not bcode2.Text = String.Empty) Then
            rptrangecode = ""
            My.Settings.reportsqlstr = "printclaimsverted"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = bcode2.Text
            viewreport2.Text = "Print Verting claims Report"
            viewreport2.Show()
        End If
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinpute order by tdate"

            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            bcode2.Text = CODDY
            bcode2.Refresh()
            Me.Refresh()
            'If (Not bcode2.Text = String.Empty) Then
            '    printclaimsverted()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub hcpnamess_TextChanged(sender As Object, e As EventArgs) Handles hcpnamess.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Not batchcode2.Text = String.Empty) Then
            Dim result = MsgBox("Continue rejecting batch.......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)

            If result = vbYes Then
                cSQL = "DELETE FROM claimsinputeApproved WHERE" _
            & " rtrim(batchcode) = '" & RTrim(Me.batchcode2.Text) & "'"
                Try
                    Using CCNN As New SqlConnection(My.Settings.cnnstring)
                        Dim Cd As SqlCommand = CCNN.CreateCommand
                        Cd.CommandType = CommandType.Text
                        Cd.CommandText = cSQL
                        CCNN.Open()
                        Cd.ExecuteNonQuery()
                        Me.Refresh()
                        MessageBox.Show("Batch Code : " + RTrim(batchcode2.Text) + "  Regected Successfully")
                    End Using
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
End Class