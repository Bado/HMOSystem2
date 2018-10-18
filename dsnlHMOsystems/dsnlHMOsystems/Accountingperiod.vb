Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class Accountingperiod
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
    Public sqlstring As String
    Private Sub Accountingperiod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        periodgrid.EnableHeadersVisualStyles = False
        periodgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        periodgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        periodgrid.ColumnHeadersHeight = 40
        periodgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        Try
            Dim col2 As New CalendarColumn()
            col2.DataPropertyName = "odate"
            col2.HeaderText = "Opening_Date"
            Dim loc2 As Integer =
            periodgrid.Columns.IndexOf(periodgrid.Columns("odate"))
            periodgrid.Columns.RemoveAt(loc2)
            periodgrid.Columns.Insert(loc2, col2)

            Dim col As New CalendarColumn()
            col.DataPropertyName = "cldate"
            col.HeaderText = "Close_Date"
            Dim loc As Integer =
            periodgrid.Columns.IndexOf(periodgrid.Columns("cldate"))
            periodgrid.Columns.RemoveAt(loc)
            periodgrid.Columns.Insert(loc, col)

            Dim col3 As New CalendarColumn()
            col3.DataPropertyName = "closeddate"
            col3.HeaderText = "Closed_Date"
            Dim loc3 As Integer =
            periodgrid.Columns.IndexOf(periodgrid.Columns("closeddate"))
            periodgrid.Columns.RemoveAt(loc3)
            periodgrid.Columns.Insert(loc3, col3)
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try
        loagriddata()
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
        For i2 = i2 To periodgrid.RowCount - 1
            periodgrid.Rows.Clear()
        Next
        'SELECT ACPERIOD,ACYEAR,OPENDATE,CLOSEDATE,CLOSEIND,CLOSEDDATE FROM ACCTPERIOD
        Dim gg2 As String = "select ACPERIOD,ACYEAR,OPENDATE,CLOSEDATE,CLOSEIND,CLOSEDDATE from ACCTPERIOD"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = periodgrid.Rows.Add
                        periodgrid.Rows(row).Cells(0).Value = r(0)
                        periodgrid.Rows(row).Cells(1).Value = r(1)
                        periodgrid.Rows(row).Cells(2).Value = r(2)
                        periodgrid.Rows(row).Cells(3).Value = r(3)
                        periodgrid.Rows(row).Cells(4).Value = r(4)
                        periodgrid.Rows(row).Cells(5).Value = r(5)
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
    Sub delperiodfirst()

        Dim cSQL5 As String = "DELETE FROM ACCTPERIOD"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL5
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try
    End Sub
    Public Sub InsertRecordperiod()  'Subroutine to insert a record into the database  
        delperiodfirst()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount)
                If periodgrid.RowCount > 0 Then
                    For i = 0 To periodgrid.RowCount - 1
                        If Not periodgrid.Rows(i).Cells(0).Value = String.Empty Then
                            Cd3.CommandText = "INSERT INTO ACCTPERIOD(ACPERIOD,ACYEAR,OPENDATE,CLOSEDATE,CLOSEIND,CLOSEDDATE) VALUES('" & periodgrid.Rows(i).Cells(0).Value & "','" & periodgrid.Rows(i).Cells(1).Value & "','" & periodgrid.Rows(i).Cells(2).Value & "','" & periodgrid.Rows(i).Cells(3).Value & "','" & periodgrid.Rows(i).Cells(4).Value & "','" & periodgrid.Rows(i).Cells(5).Value & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update ACCTPERIOD record : " + " In " + Me.Text)
                MessageBox.Show("Record Saved Successfully")
                Me.Refresh()
                '  MessageBox.Show("Batch Save/Update Sucessfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Inserting ACCTPERIOD ")
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM ACCTPERIOD where acperiod = '" & periodd.Text & "' and acyear = '" & yearr.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record : " + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
        '   MessageBox.Show("Update Data instead")
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Updatewages()
        Dim result = MsgBox("Are you sure you want to close this period.......?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Try

                cSQL = "UPDATE ACCTPERIOD SET" _
                       & " CLOSEIND = '" & True & "' " & " WHERE" & " rtrim(acperiod) = '" & RTrim(periodd.Text) & "' and rtrim(acyear) = '" & RTrim(yearr.Text) & "'"

                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Close Period: " + Trim(periodd.Text) + " In " + Me.Text)
                End Using
                Updatesumary()
                updatepaymentrecepthstFindexist()

                MessageBox.Show("Record Updated Sucessfully")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        'MessageBox.Show("
    End Sub

    Sub Updatesumary()

       
            backuptohistory()
            MDIParent1.statusmsg2.Text = "Updating Please wait .........."
            '"Select staffid,fixedtax,totalallowance,totaldeduction,netpay from summarytab"
            Dim sumSQL As String = "UPDATE summarytab SET taxtd += fixedtax,grosstd += totalallowance"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd2 As SqlCommand = CCNN.CreateCommand
                    Cd2.CommandText = sumSQL
                    Cd2.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd2.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg2.Text = ex.Message
            Finally
                '  CCNN.Close()

            End Try
            'SELECT pic,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate FROM loantab
            Dim sumSQL2 As String = "UPDATE loantab SET stopped = '" & True & "' where paidtoadate >= amtcollected"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd2 As SqlCommand = CCNN.CreateCommand
                    Cd2.CommandText = sumSQL2
                    Cd2.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd2.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg2.Text = ex.Message
            Finally
                '  CCNN.Close()

            End Try

            Dim sumSQL3 As String = "UPDATE loantab SET paidtoadate += mpayment where paidtoadate !> amtcollected and stopped = '" & False & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd2 As SqlCommand = CCNN.CreateCommand
                    Cd2.CommandText = sumSQL3
                    Cd2.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd2.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg2.Text = ex.Message
            End Try


        ClearRec()
    End Sub
    Sub ClearRec()
        Dim cSQL As String = "DELETE FROM paysum "
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
            MessageBox.Show(ex.Message)
        End Try
        '  summarytab
        Try
            'staffid,names,fixedtax,grosstd,taxtd
            cSQL = "UPDATE summarytab SET" _
                   & " totalallowance = '" & 0.0 & "', " & " totaldeduction = '" & 0.0 & "', " & " netpay = '" & 0.0 & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Update Summary to date for period:'" & Now & "' ")
                MDIParent1.statusmsg2.Text = "Process Completed Successfully"
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub backuptohistory()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "INSERT INTO payhst(staffid,Names,pic,itemdescr,pictype,taxable,scheme,advance,gradelvl,deptcode,bankid,accountid,pamount,period,paycaldate,year,month,fixedtax,totalallowance,totaldeduction,netpay)" & _
                                                "select staffid,Names,pic,itemdescr,pictype,taxable,scheme,advance,gradelvl,deptcode,bankid,accountid,pamount,period,paycaldate,year,month,fixedtax,totalallowance,totaldeduction,netpay FROM paysum"

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Paysum populated")
            End Using
            'Me.statuspoint.Text = "Paysum populated"
        Catch ex As Exception
            MDIParent1.statusmsg2.Text = ex.Message

        End Try

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL22 As String = "INSERT INTO summarytabhst(staffid,names,fixedtax,grosstd,taxtd,totalallowance,totaldeduction,netpay)" & _
                                                "select staffid,names,fixedtax,grosstd,taxtd,totalallowance,totaldeduction,netpay FROM summarytab"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL22
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Paysum populated")
            End Using
            'Me.statuspoint.Text = "Paysum populated"
        Catch ex As Exception
            MDIParent1.statusmsg2.Text = ex.Message

        End Try


    End Sub

    Sub updatepaymentrecepthstFindexist()
        'MessageBox.Show(Month(closeddate2.Text))
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "select * FROM headtodate where YEAR(tdate) = '" & yearr.Text & "' and MONTH(tdate) = '" & Month(closeddate2.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    MessageBox.Show("Customer/Vender Period Balance Already posted")
                    Return
                Else
                    updatepaymentrecepthst()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in headtodate Insert")
        End Try
    End Sub

    Sub updatepaymentrecepthst()
        'ACCTPERIOD
        '  MessageBox.Show("IN")
        Try
            Dim sumSQL As String = "INSERT INTO headtodate(tdate,receipt,payment,headcode)" & _
                                                     "select '" & closeddate2.Text & "' as tdate,sum(total) as receipt,0.00 as payment,headcode FROM transtab where typecode = 'RC' and MONTH(transdate) = '" & Month(closeddate2.Text) & "' group by headcode "
            'select headcode,sum(total) as amount from transtab where typecode = 'RC' and MONTH(transdate)='05' group by headcode 
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                MessageBox.Show("Record Posted Successfully")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in headtodate Insert")
        End Try

        Try
            Dim sumSQL2 As String = "INSERT INTO headtodate(tdate,receipt,payment,headcode)" & _
                                                     "select '" & closeddate2.Text & "' as tdate,0.00 as receipt,sum(total) as payment,headcode FROM transtab where typecode = 'PY' and MONTH(transdate) = '" & Month(closeddate2.Text) & "' group by headcode "
            'select headcode,sum(total) as amount from transtab where typecode = 'RC' and MONTH(transdate)='05' group by headcode 
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL2
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                MessageBox.Show("Record Posted Successfully")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in headtodate Insert")
        End Try
        '  MessageBox.Show("Out")

    End Sub

    Private Sub yearr_TextChanged(sender As Object, e As EventArgs) Handles yearr.TextChanged

    End Sub

    Private Sub yearr_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles yearr.Validating
        'SELECT ACPERIOD,ACYEAR,OPENDATE,CLOSEDATE,CLOSEIND,CLOSEDDATE FROM ACCTPERIOD
        Try
            sqlstring = "select ACPERIOD,ACYEAR,CLOSEDDATE from ACCTPERIOD where rtrim(acperiod) = '" & RTrim(periodd.Text) & "' and rtrim(acyear) = '" & RTrim(yearr.Text) & "'"

            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = sqlstring
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    closeddate2.Text = r(2)
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in UPDATE CLAIMACTINPUE Insert")
        End Try

    End Sub
    Sub Updatewages()
        'Try
        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd3 As SqlCommand = CCNN.CreateCommand
        '        Cd3.CommandType = CommandType.Text
        '        Dim i As Integer
        '        Cd3.CommandText = "INSERT INTO transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)" & _
        '                        "VALUES('" & payinvoicegrid.Rows(i).Cells(8).Value & "','" & payinvoicegrid.Rows(i).Cells(9).Value & "','" & payinvoicegrid.Rows(i).Cells(15).Value & "','" & Val(payinvoicegrid.Rows(i).Cells(3).Value) & "','" & "PY" & "','" & 0.0 & "','" & 0.0 & "','" & CDec(payinvoicegrid.Rows(i).Cells(5).Value) & "','" & tdate.Value & "','" & glcode.Text & "','" & payinvoicegrid.Rows(i).Cells(16).Value & "','" & True & "')"
        '        CCNN.Open()
        '        Cd3.ExecuteNonQuery()
        '        CCNN.Close()
        '        Me.Refresh()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in Payment Grid Table post to GL")
        'End Try
    End Sub

End Class