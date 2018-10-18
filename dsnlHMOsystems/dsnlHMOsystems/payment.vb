
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
Public Class payment
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public plantt As String
    Public newpcode As String

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        paycode.Focus()
        payinvoicegrid.EnableHeadersVisualStyles = False
        payinvoicegrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        payinvoicegrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        payinvoicegrid.ColumnHeadersHeight = 30
        payinvoicegrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        paystat.Text = "Not Cleared.."
        ToolStripButton3.Enabled = True
        tid.Visible = False
        mcid.Visible = False
        tcodebtn.Visible = False
        totalpayment.Text = 0.0
        'Dim col As New CalendarColumn()
        'col.DataPropertyName = "ddate"
        'col.HeaderText = "Date_Due"
        'Dim loc As Integer =
        'payinvoicegrid.Columns.IndexOf(payinvoicegrid.Columns("ddate"))
        'payinvoicegrid.Columns.RemoveAt(loc)
        'payinvoicegrid.Columns.Insert(loc, col)
        gethcpinfo()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT CODE1,company FROM companytab"
                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Me.payincompany.Text = r(1)
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select bankcode,rtrim(names) as names from BANKSETUP"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            paybank.DataSource = ds.Tables(0)
            paybank.ValueMember = "bankcode"
            paybank.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
        vbanksub()
        acdebit()
        clearrec()
    End Sub
    Sub vbanksub()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql = "select bankcode,rtrim(names) + ' | ' + rtrim(branch) as names from BANKSETUP"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            vbank.DataSource = ds.Tables(0)
            vbank.ValueMember = "bankcode"
            vbank.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Sub acdebit()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select accode,descriptn from accode order by accode"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ACCode.DataSource = ds.Tables(0)
            ACCode.ValueMember = "accode"
            ACCode.DisplayMember = "descriptn"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub


    Public Sub saverec()
        If (Not totalpayment.Text = 0) Then
            Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
            If result = vbYes Then
                'RecordExist()
                If My.Settings.newrec = True Then
                    InsertRecord()
                    clearrec()
                End If
                If My.Settings.newrec = False Then
                    InsertRecord()
                    clearrec()
                End If

                Me.Refresh()
                paycode.Focus() '***Reset the default contol focus as 
                If result = vbNo Then
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Get Total Payment to continue !!!")
        End If
    End Sub

    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM payment WHERE" _
            & " paycode = '" & Me.paycode.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for paycode code: " + Trim(paycode.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    '  If result = vbNo Then payment
                    'Me.Close()
                    '   End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try

            Dim cSQL2 As String = "DELETE FROM pinvoicegrid WHERE" _
                        & " paycode = '" & Me.paycode.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        Dim index As Integer
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT paycode,paybank,totalpayment,mcid,pmethod,tdate,glcode,paid FROM payment WHERE" _
                & " paycode = '" & paycode.Text & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.paybank.SelectedValue = RTrim(r(1))
                    If Not r.IsDBNull(2) Then Me.totalpayment.Text = r(2)
                    If Not r.IsDBNull(3) Then
                        If RTrim(r(3)) = "ffs" Then
                            ffs.Checked = True
                            mc.Checked = False
                        End If
                        If RTrim(r(3)) = "mc" Then
                            mc.Checked = True
                            ffs.Checked = False
                        End If
                    End If
                    If Not r.IsDBNull(4) Then
                        index = pmethod.FindString(RTrim(r(4)))
                        pmethod.SelectedIndex = index
                    End If
                    tdate.Value = r(5)
                    If Not r.IsDBNull(6) Then Me.glcode.Text = r(6)
                    If Not r.IsDBNull(7) Then
                        If r(7) = True Then
                            paid.Checked = True
                            paystat.Text = "Cleared.."
                            ToolStripButton3.Enabled = False
                            MDIParent1.statusmsg.Text = "Payment Total registered:   " & r(2)
                            'posttogl()
                        End If
                    End If
                    loadgriddata()
                    My.Settings.newrec = True
                    enablecontrols()
                    paycode.Focus()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    paycode.Focus()
                    If ffs.Checked = True Then
                        loadpayfeesservice()
                    End If
                    If mc.Checked = True Then
                        loadpaymenmedicare()
                    End If
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Load invoice data")
        End Try
    End Sub
    Public Sub clearrec()
        ToolStripButton3.Enabled = True
        paycode.Text = ""
        totalpayment.Text = 0.0
        paybank.Text = ""
        Me.mcid.Text = ""
        amtword.Text = ""
        glcode.Text = ""
        tdate.Text = Now
        paid.Checked = False
        Dim T As Integer
        For T = T To payinvoicegrid.RowCount - 1
            payinvoicegrid.Rows.Clear()
        Next
        Me.Refresh()
    End Sub
    Sub enablecontrols()

        totalpayment.Enabled = True
        paybank.Enabled = True
        Me.mcid.Enabled = True
        pmethod.Enabled = True
        glcode.Enabled = True
        tdate.Enabled = True


    End Sub
    Sub disablecontrols()
        totalpayment.Enabled = False
        paybank.Enabled = False
        Me.mcid.Enabled = False
        pmethod.Enabled = False
        glcode.Enabled = False
        tdate.Enabled = False
    End Sub

    Sub delfirst()
        ' 'SELECT billcode,pcode,eqty,uprice,tax,discou2nt,amt FROM sinvoicegrid
        Dim cSQL5 As String = "DELETE FROM pinvoicegrid WHERE" _
            & " paycode = '" & Me.paycode.Text & "'"
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
    Sub delpayment()
        Dim cSQL5 As String = "DELETE FROM payment WHERE" _
            & " paycode = '" & paycode.Text & "'"
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
    Public Sub InsertRecord()  'Subroutine to insert a record into the database                                                                                                                                                                                                                                                                                                                                                                                                                                                        ',accountname,accountno,bankname,branch,sortno
        If (paycode.Text = String.Empty) Then
            MessageBox.Show("Input Paycode to continue")
            paycode.Focus()
            Return 
            Exit Sub
        End If
        delpayment()
       
        If ffs.Checked = True Then
            plantt = "ffs"
        Else
            plantt = "mc"
        End If
        cSQL = "INSERT INTO payment(paycode,paybank,totalpayment,mcid,pmethod,tdate,glcode,paid)" & _
            "VALUES('" & paycode.Text & "','" & paybank.SelectedValue & "','" & totalpayment.Text & "','" & plantt & "','" & pmethod.Text & "','" & Format(tdate.Value, "yyyy-MM-dd") & "','" & glcode.Text & "','" & paid.Checked & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Record Save Sucessfully")
                saveaudit("Insert new record for paycode: " + Trim(paycode.Text) + " In " + Me.Text)
            End Using
            InsertRecordgrid()
            'If paid.Checked = True Then
            '    updatehcp()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in payment ")
            'If Not r.IsDBNull(3) Then CheckCodestab.CALLCODESTAB(r(3), "F8")
            'Me.qsection.Text = CheckCodestab.descvar
        End Try
    End Sub
    Sub updatehcp()

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                '                                                                                                                                                            billcode,descr,invoicetopic,tdate,paycode,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM payment pinvoicegrid
                If payinvoicegrid.RowCount > 0 Then
                    For i = 0 To payinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value  
                        If payinvoicegrid.Rows(i).Cells(5).Value > 0 Then
                            Cd3.CommandText = "UPDATE hcptab SET" _
                                               & " paidtodate += '" & payinvoicegrid.Rows(i).Cells(5).Value & "', " & " lpay = '" & payinvoicegrid.Rows(i).Cells(5).Value & "'" & " WHERE" & " hcpid = '" & payinvoicegrid.Rows(i).Cells(8).Value & "'"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If

                Me.Refresh()
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in hcptab todate Table")
        End Try
        If mc.Checked = True Then
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd3 As SqlCommand = CCNN.CreateCommand
                    Cd3.CommandType = CommandType.Text

                    Dim i As Integer
                    '                                                                                                                                                            billcode,descr,invoicetopic,tdate,paycode,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM payment pinvoicegrid
                    If payinvoicegrid.RowCount > 0 Then
                        For i = 0 To payinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value  , " & " Paid = '" & True & "'
                            If payinvoicegrid.Rows(i).Cells(5).Value > 0 And payinvoicegrid.Rows(i).Cells(6).Value = True Then
                                Cd3.CommandText = "UPDATE claimsinputeApproved SET" _
                                                   & " Paid = '" & True & "'" & " WHERE" & " batchcode = '" & payinvoicegrid.Rows(i).Cells(0).Value & "'"
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()
                            End If
                        Next
                    End If

                    Me.Refresh()
                End Using
                getenrolletodate()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Occurs in hcptab todate Table")
            End Try
        End If
   
    End Sub
    
    Sub getenrolletodate()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "Select Distinct enrolleeid,sum(billamount) as bamount from claimsinputeApproved  where paid = '" & True & "' and batchcode =  '" & paycode.Text & "' group by enrolleeid"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()
                        Updateenrolleedata(r(0), r(1))
                    Loop
                    '   r.Close()
                Else
                    MDIParent1.statusmsg2.Text = "No defaulttab Record Selected"
                    '      Exit Sub
                End If
            End Using
        Catch ex As Exception
            'Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()
            '  MesgBox("Process Completed Successfully")
        End Try



    End Sub
    Sub Updateenrolleedata(ByVal staffidv As String, ByVal amountv As Double)
        Dim sumSQL As String = "UPDATE enrolleetab SET" _
      & " ugstodate += '" & amountv & "'," & " lpay= '" & amountv & "' " & " WHERE " & " rtrim(enrolleeid) = '" & RTrim(staffidv) & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Updating Enrollee data")
        End Try

    End Sub
    Public Sub InsertRecordgrid()  'Subroutine to insert a record into the database  
        delfirst()
        Dim PREMI As String
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                '                                                                                                                                                            billcode,descr,invoicetopic,tdate,paycode,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM payment pinvoicegrid
                If payinvoicegrid.RowCount > 0 Then
                    For i = 0 To payinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value  
                        If payinvoicegrid.Rows(i).Cells(5).Value > 0 And payinvoicegrid.Rows(i).Cells(6).Value = True Then
                            CheckCodestab.bankdesc(payinvoicegrid.Rows(i).Cells(7).Value)
                            PREMI = CheckCodestab.descvar
                            Cd3.CommandText = "INSERT INTO pinvoicegrid(invoiceno,ddate,amtdue,descr,discount,amtpaid,pay,vbank,hcpid,hcpname,bank,bankbranch,accid,sortcode,email,payref,pdescr,paycode,totalpayment )" & _
                                "VALUES('" & payinvoicegrid.Rows(i).Cells(0).Value & "','" & payinvoicegrid.Rows(i).Cells(1).Value & "','" & Val(payinvoicegrid.Rows(i).Cells(2).Value) & "','" & payinvoicegrid.Rows(i).Cells(3).Value & "','" & Val(payinvoicegrid.Rows(i).Cells(4).Value) & "','" & Val(payinvoicegrid.Rows(i).Cells(5).Value) & "','" & payinvoicegrid.Rows(i).Cells(6).Value & "','" & payinvoicegrid.Rows(i).Cells(7).Value & "','" & payinvoicegrid.Rows(i).Cells(8).Value & "','" & payinvoicegrid.Rows(i).Cells(9).Value & "','" & payinvoicegrid.Rows(i).Cells(10).Value & "','" & payinvoicegrid.Rows(i).Cells(11).Value & "','" & payinvoicegrid.Rows(i).Cells(12).Value & "','" & payinvoicegrid.Rows(i).Cells(13).Value & "','" & payinvoicegrid.Rows(i).Cells(14).Value & "','" & payinvoicegrid.Rows(i).Cells(15).Value & "','" & PREMI & "','" & paycode.Text & "','" & totalpayment.Text & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update paycode code: " + Trim(paycode.Text) + " In " + Me.Text)
                Me.Refresh()
                If paid.Checked = True Then
                    updatehcp()
                    getupdatepayrefcode()
                    Updatetranstab()
                    posttogl()
                    savetovendor()
                End If

                MessageBox.Show("Record Save/Update Sucessfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Payment Grid Table")
        End Try
    End Sub
    Sub getupdatepayrefcode() '
        Dim getref As String = ""
        Dim gg2 As String = "SELECT max(substring(payref,6,10)) as payref FROM pinvoicegrid where paycode = '" & paycode.Text & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    newpcode = r(0)
                End If
            End Using
            getupdatepayrefcode2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Payment Grid Table")
        End Try

    End Sub
    Sub getupdatepayrefcode2()
        Try
            'payref FROM digitsettings


            cSQL = "UPDATE digitsettings SET" _
                   & " payref = '" & newpcode & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Sub posttogl()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If payinvoicegrid.RowCount > 0 Then
                    For i = 0 To payinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value  
                        If payinvoicegrid.Rows(i).Cells(5).Value > 0 And payinvoicegrid.Rows(i).Cells(6).Value = True Then
                            Cd3.CommandText = "INSERT INTO transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)" & _
                                "VALUES('" & payinvoicegrid.Rows(i).Cells(8).Value & "','" & payinvoicegrid.Rows(i).Cells(9).Value & "','" & payinvoicegrid.Rows(i).Cells(15).Value & "','" & Val(payinvoicegrid.Rows(i).Cells(3).Value) & "','" & "PY" & "','" & 0.0 & "','" & 0.0 & "','" & CDec(payinvoicegrid.Rows(i).Cells(5).Value) & "','" & tdate.Value & "','" & glcode.Text & "','" & payinvoicegrid.Rows(i).Cells(16).Value & "','" & True & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Payment Grid Table post to GL")
        End Try
    End Sub
    'Sub UpdatePaytogl(ByVal headcodev As String, ByVal hdescrv As String, ByVal transcodev As String, ByVal tdescrv As String, ByVal typecodev As String, ByVal qtyv As Double, ByVal upricev As Double, ByVal totalv As Double, ByVal staffidv As String, ByVal transdatev As Date, ByVal acctcreditv As String, ByVal acctdebitv As String, ByVal postv As Boolean)
    '    Try

    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim DSQL4 As String = "INSERT INTO transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)" & _
    '                "values('" & headcodev & "','" & hdescrv & "','" & transcodev & "','" & tdescrv & "','" & typecodev & "','" & qtyv & "','" & totalv & "','" & transdatev & "','" & acctcreditv & "','" & acctdebitv & "','" & postv & "')"

    '            Dim Cd As SqlCommand = CCNN.CreateCommand
    '            Cd.CommandText = DSQL4
    '            Cd.CommandType = CommandType.Text
    '            CCNN.Open()
    '            Cd.ExecuteNonQuery()
    '            'MessageBox.Show("Paysum populated")
    '        End Using
    '        'Me.statuspoint.Text = "Paysum populated"
    '    Catch ex As Exception
    '        'Me.statuspoint.Text = ex.Message

    '    End Try

    'End Sub
    Sub Updatetranstab() '

        


    End Sub
    Sub loadgriddata()
        Dim i2 As Integer
        For i2 = i2 To payinvoicegrid.RowCount - 1
            payinvoicegrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT paycode,ddate,amtdue,descr,discount,amtpaid,pay,vbank,hcpid,hcpname,bank,bankbranch,accid,sortcode,email,payref FROM pinvoicegrid where paycode = '" & paycode.Text & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = payinvoicegrid.Rows.Add
                        payinvoicegrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        payinvoicegrid.Rows(row).Cells(1).Value = r(1)
                        payinvoicegrid.Rows(row).Cells(2).Value = r(2)
                        payinvoicegrid.Rows(row).Cells(3).Value = RTrim(r(3))
                        payinvoicegrid.Rows(row).Cells(4).Value = Val(r(4))
                        payinvoicegrid.Rows(row).Cells(5).Value = Val(r(5))
                        payinvoicegrid.Rows(row).Cells(6).Value = r(6)
                        payinvoicegrid.Rows(row).Cells(7).Value = RTrim(r(7))

                        payinvoicegrid.Rows(row).Cells(8).Value = RTrim(r(8))
                        payinvoicegrid.Rows(row).Cells(9).Value = RTrim(r(9))
                        payinvoicegrid.Rows(row).Cells(10).Value = RTrim(r(10))
                        payinvoicegrid.Rows(row).Cells(11).Value = r(11)
                        payinvoicegrid.Rows(row).Cells(12).Value = RTrim(r(12))
                        payinvoicegrid.Rows(row).Cells(13).Value = RTrim(r(13))
                        payinvoicegrid.Rows(row).Cells(14).Value = RTrim(r(14))
                        payinvoicegrid.Rows(row).Cells(15).Value = RTrim(r(15))
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
    Public Function AmountInWords(ByVal nAmount As String, Optional ByVal wAmount _
                 As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then _
            tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                    > (CLng(intAmount.ToString.Trim.Length / 3)), _
                  CLng(intAmount.ToString.Trim.Length / 3) + 1, _
                    CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim, _
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = _
                {"", "One", "Two", "Three", _
                  "Four", "Five", _
                  "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", _
                "Eleven", "Twelve", "Thirteen", _
                  "Fourteen", "Fifteen", _
                  "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", _
                "Twenty", "Thirty", _
                  "Forty", "Fifty", "Sixty", _
                  "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", _
                "Thousand", "Million", _
                  "Billion", "Trillion", _
                  "Quadrillion", "Quintillion"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                If nHundred > 0 Then wAmount = wAmount & _
                Ones(nHundred) & " Hundred " 'This is for hundreds                
                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If
                wAmount = wAmount & HMBT(nSet) & " "
                wAmount = AmountInWords(CStr(CLng(nAmount) - _
                  (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
            Else
                If Val(nAmount) = 0 Then nAmount = nAmount & _
                tempDecValue : tempDecValue = String.Empty
                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount = _
                  Trim(AmountInWords(CStr(Math.Round(Val(nAmount), 2) * 100), _
                  wAmount.Trim & " Naira And ", 1)) & " Kobo"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Encountered: " & ex.Message, _
              "Convert Numbers To Words", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount = _
          IIf(InStr(wAmount.Trim.ToLower, ""), _
          wAmount.Trim, wAmount.Trim & " ")

        amtword.Text = wAmount
        'Display the result
        Return wAmount
    End Function
    Private Sub TextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        AmountInWords(totalpayment.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select accode,descriptn,actype from accode order by accode"
            Dim sfrm As New searchfrm
            '  sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            'sfrm.Show()
            glcode.Text = CODDY
            glcode.Refresh()
            Me.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles ffs.CheckedChanged
        clearrec()
        tid.Visible = False
        mcid.Visible = False
        tcodebtn.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles mc.CheckedChanged
        clearrec()
        tid.Visible = True
        mcid.Visible = True
        tcodebtn.Visible = True
        loadpaymenmedicare()
    End Sub

    Private Sub totalpayment_TextChanged(sender As Object, e As EventArgs) Handles totalpayment.TextChanged
        AmountInWords(totalpayment.Text)
    End Sub

    Private Sub paycode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles paycode.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not paycode.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clearrec()
        If ffs.Checked = True Then
            Try
                gsql = ""
                DESCC = ""
                OPTRR = publicvarmodule.OPT
                gsql = "select distinct tcode,dateperiod,POSTED from gencapitation where posted = '" & True & "' order by dateperiod"
                Dim sfrm As New searchfrm
                ' sfrm.MdiParent = MDIParent1
                sfrm.ShowDialog()
                '  sfrm.Show()
                paycode.Text = CODDY
                paycode.Refresh()
                Me.Refresh()
                If (Not paycode.Text = String.Empty) Then
                    LoadRecord()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        If mc.Checked = True Then
            Try
                gsql = ""
                DESCC = ""
                OPTRR = publicvarmodule.OPT
                gsql = "SELECT distinct batchcode,hcpname,tdate FROM claimsinputeApproved WHERE" _
                    & " Mdapproves = '" & True & "' order by tdate"
                Dim sfrm As New searchfrm
                '  sfrm.MdiParent = MDIParent1
                sfrm.ShowDialog()
                'sfrm.Show()
                paycode.Text = CODDY
                paycode.Refresh()
                Me.Refresh()
                If (Not paycode.Text = String.Empty) Then
                    LoadRecord()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
           
        End If
    End Sub
    Sub loadpayfeesservice()
        Dim countt2 As Integer = Val(payrefcode)
        Dim i2 As Integer
        For i2 = i2 To payinvoicegrid.RowCount - 1
            payinvoicegrid.Rows.Clear()
        Next
        '  SELECT tcode,dateperiod,capitation,hcpid,hcpname FROM gencapitation where tcode = '" & paycode.Text & "'"
        Dim gg2 As String = "SELECT a.tcode,a.dateperiod,a.capitation,a.hcpid,a.hcpname,b.bank,b.bankbranch,b.accid,b.sortcode,b.email FROM gencapitation a,hcptab b where a.tcode = '" & paycode.Text & "' and rtrim(a.hcpid)=rtrim(b.hcpid)"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = payinvoicegrid.Rows.Add
                        payinvoicegrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        payinvoicegrid.Rows(row).Cells(1).Value = r(1)
                        payinvoicegrid.Rows(row).Cells(2).Value = r(2)
                        payinvoicegrid.Rows(row).Cells(5).Value = r(2)
                        payinvoicegrid.Rows(row).Cells(7).Value = RTrim(r(5))
                        payinvoicegrid.Rows(row).Cells(8).Value = RTrim(r(3))
                        payinvoicegrid.Rows(row).Cells(9).Value = RTrim(r(4))
                        payinvoicegrid.Rows(row).Cells(10).Value = r(5)
                        payinvoicegrid.Rows(row).Cells(11).Value = r(6)
                        payinvoicegrid.Rows(row).Cells(12).Value = RTrim(r(7))
                        payinvoicegrid.Rows(row).Cells(13).Value = RTrim(r(8))
                        payinvoicegrid.Rows(row).Cells(14).Value = RTrim(r(9))
                        countt2 = countt2 + 1
                        If ffs.Checked = True Then
                            payrefcode = "NHIS0" + LTrim(Str(countt2))
                        Else
                            payrefcode = "MCARE" + LTrim(Str(countt2))
                        End If
                        payinvoicegrid.Rows(row).Cells(15).Value = payrefcode
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
            '  gethcpinfo()

        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
    Sub loadpaymenmedicare()
        Dim i2 As Integer
        For i2 = i2 To payinvoicegrid.RowCount - 1
            payinvoicegrid.Rows.Clear()
        Next

        Dim countt2 As Integer = Val(payrefcode)
        Dim gg2 As String = "SELECT distinct a.batchcode,a.tdate,a.batchtotal,a.hcpid,a.hcpname,b.bank,b.bankbranch,b.accid,b.sortcode,b.email FROM claimsinputeApproved a,hcptab b where a.MDAPPROVES = '" & True & "' AND a.Paid = '" & False & "' AND rtrim(a.hcpid)=rtrim(b.hcpid)"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = payinvoicegrid.Rows.Add
                        payinvoicegrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        payinvoicegrid.Rows(row).Cells(1).Value = r(1)
                        payinvoicegrid.Rows(row).Cells(2).Value = r(2)
                        payinvoicegrid.Rows(row).Cells(5).Value = r(2)
                        payinvoicegrid.Rows(row).Cells(7).Value = RTrim(r(5))
                        payinvoicegrid.Rows(row).Cells(8).Value = RTrim(r(3))
                        payinvoicegrid.Rows(row).Cells(9).Value = RTrim(r(4))
                        payinvoicegrid.Rows(row).Cells(10).Value = r(5)
                        payinvoicegrid.Rows(row).Cells(11).Value = r(6)
                        payinvoicegrid.Rows(row).Cells(12).Value = RTrim(r(7))
                        payinvoicegrid.Rows(row).Cells(13).Value = RTrim(r(8))
                        payinvoicegrid.Rows(row).Cells(14).Value = RTrim(r(9))
                        ' MessageBox.Show(countt2)
                        countt2 = countt2 + 1
                        If ffs.Checked = True Then
                            payrefcode = "NHIS0" + LTrim(Str(countt2))
                        Else
                            payrefcode = "MCARE" + LTrim(Str(countt2))
                        End If
                        payinvoicegrid.Rows(row).Cells(15).Value = payrefcode
                        ' 
                    
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
            '   gethcpinfo()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub
 
    Private Sub TotalSum()
        Dim sum As Decimal = 0
        If totalpayment.Text = 0 Then
            For Each row As DataGridViewRow In payinvoicegrid.Rows
                If row.Cells(6).Value = True Then
                    row.Cells(5).Value = row.Cells(5).Value - row.Cells(4).Value
                    sum += row.Cells(5).Value
                End If
            Next
            Me.totalpayment.Text = sum
            Me.totalpayment.Text = sum.ToString("0.00")
            payinvoicegrid.Columns(5).DefaultCellStyle.Format = ("0.00")
        Else
            getrvalues()
            sum = 0.0
            Me.totalpayment.Text = 0.0
        End If



    End Sub
    Sub getrvalues()
        Try
            Dim dic As Double = 0
            Dim i As Integer = 0
            For i = 0 To payinvoicegrid.Rows.Count - 1
                payinvoicegrid.Rows(i).Cells(5).Value = payinvoicegrid.Rows(i).Cells(2).Value
            Next i
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub payinvoicegrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles payinvoicegrid.CellEndEdit
        'Try
        '    Dim totalunits As Double = 0
        '    Dim dic As Double = 0
        '    Dim i As Integer = 0
        '    For i = 0 To payinvoicegrid.Rows.Count - 1
        '        dic = Convert.ToDouble(payinvoicegrid.Rows(i).Cells(5).Value - payinvoicegrid.Rows(i).Cells(4).Value)
        '        payinvoicegrid.Rows(i).Cells(5).Value = dic
        '    Next i
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        'Try
        '    Dim tott3 As Double = 0
        '    Dim tott As Double = 0
        '    Dim tott2 As Double = 0
        '    For index As Integer = 0 To payinvoicegrid.RowCount - 1
        '        If payinvoicegrid.Rows.Count = 0 Then Exit Sub
        '        Dim Idx = e.RowIndex
        '        If Val(payinvoicegrid.Rows(index).Cells(4).Value) > 0 Then
        '            payinvoicegrid.Rows(index).Cells(5).Value = Val(payinvoicegrid.Rows(index).Cells(5).Value) - Val(payinvoicegrid.Rows(index).Cells(4).Value)
        '            'tott2 += Convert.ToDouble(Val(payinvoicegrid.Rows(index).Cells(5).Value) - Val(payinvoicegrid.Rows(index).Cells(4).Value))
        '            'payinvoicegrid.Rows(index).Cells(5).Value = tott2

        '        End If
        '    Next
        '    '   totalpayment.Text = tott
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TotalSum()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        paystat.Text = "Not Cleared.."
        posting.Checked = False
        ToolStripButton3.Enabled = True
    End Sub
    Sub gethcpinfo()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT payref FROM digitsettings"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(0) Then payrefcode = RTrim(r(0))
                    Me.Refresh()
                    r.Close()
                End If
            End Using
            ' MessageBox.Show(gstrinsql1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        If (Not paycode.Text = String.Empty) And paid.Checked = True Then
            rptrangecode = ""
            My.Settings.reportsqlstr = "Printpaymentrpt"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = paycode.Text
            viewreport2.Text = "Print Payment Report"
            viewreport2.Show()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If payinvoicegrid.RowCount > 0 Then
            For i = 0 To payinvoicegrid.RowCount - 1
                payinvoicegrid.Rows(i).Cells(3).Value = naraall.Text
            Next
        End If
    End Sub

  

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If payinvoicegrid.RowCount > 0 Then
            For i = 0 To payinvoicegrid.RowCount - 1
                If payinvoicegrid.Rows(i).Cells(6).Value = True Then
                    payinvoicegrid.Rows(i).Cells(6).Value = False
                Else
                    payinvoicegrid.Rows(i).Cells(6).Value = True
                End If
            Next
        End If
    End Sub

    
   
    Private Sub paid_CheckedChanged(sender As Object, e As EventArgs) Handles paid.CheckedChanged
        posting.Checked = True
    End Sub

    Sub savetovendor()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If payinvoicegrid.RowCount > 0 Then
                    For i = 0 To payinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value  
                        If payinvoicegrid.Rows(i).Cells(5).Value > 0 And payinvoicegrid.Rows(i).Cells(6).Value = True Then
                            Cd3.CommandText = "UPDATE custvendtab SET" _
                                            & " laspdate = '" & tdate.Value & "', " & " lastpamt = '" & payinvoicegrid.Rows(i).Cells(5).Value & "' " & " WHERE" & " custvendid = '" & payinvoicegrid.Rows(i).Cells(8).Value & "'"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Payment Grid Table post to Cutomer table")
        End Try

    End Sub
End Class