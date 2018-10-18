
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
Public Class sales_invoicing
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Private Sub sales_invoicing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        saleinvoicegrid.EnableHeadersVisualStyles = False
        saleinvoicegrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        saleinvoicegrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        saleinvoicegrid.ColumnHeadersHeight = 30
        saleinvoicegrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        posting.Checked = False

        Searchtool.SelectedItem = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "SELECT custvendid,Names FROM custvendtab where custvendtype ='" & "C" & "' order by custvendtype,custvendid"
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
            Searchtool.ValueMember = "custvendid"
            Searchtool.DisplayMember = "Names"
            Searchtool.Refresh()
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
        presetup()
        clearrec()
        disablecontrols()

    End Sub
    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        Try
            Billcode.Text = Searchtool.SelectedValue.ToString
            descr.Text = Searchtool.Text
            getcustaddress()
            Billcode.Focus()
            enablecontrols()
            getsettingcode()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub getcustaddress()
        ' Dim gg2 As String = "select hcpid,Names,address FROM Hcptab WHERE rtrim(hcpid) = '" & RTrim(Billcode.Text) & "'"
        Dim gg2 As String = "SELECT custvendid,Names,address FROM custvendtab where custvendtype ='" & "C" & "' and rtrim(custvendid) = '" & RTrim(Billcode.Text) & "' order by custvendtype,custvendid"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    descr.Text = RTrim(r(1)) & vbCrLf & RTrim(r(2))
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub

    Sub getsettingcode()
        Dim gg2 As String = "select companyid,invoiceno from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    invoiceno.Text = LTrim(r(1))
                    autobatch.Text = LTrim(r(1))
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

        Dim inca As String = RTrim(Str(Val(invoiceno.Text) + 1))
        Try
            Dim cSQL As String = "UPDATE digitsettings SET invoiceno = '" & inca & "'"
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
        ' clearrec()
    End Sub
   



    Public Sub clearrec()
        itotal.Text = 0.0
        stax.Text = 0.0
        netdue.Text = 0.0
        Me.descr.Text = ""
        salesrep.Text = ""
        discount2.Text = 0.0
        glcode.Text = ""
        glcode2.Text = ""
        Amtword.Text = ""
        invoicetopic.Text = ""
        addressto.Text = ""
        signby.Text = ""
        posting.Checked = False
        accountname.Text = ""
        accountno.Text = ""
        bankname.Text = ""
        branch.Text = ""
        sortno.Text = ""
        '  Me.tdate.Value = Now
        Dim T As Integer
        For T = T To saleinvoicegrid.RowCount - 1
            saleinvoicegrid.Rows.Clear()
        Next

        Me.Refresh()
    End Sub
    Sub GETHMOBANK()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT accountname,bankname,branch,accountno,sortno FROM digitsettings"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(0) Then accountname.Text = r(0)
                    If Not r.IsDBNull(1) Then bankname.Text = r(1)
                    If Not r.IsDBNull(2) Then branch.Text = r(2)
                    If Not r.IsDBNull(3) Then accountno.Text = r(3)
                    If Not r.IsDBNull(4) Then sortno.Text = r(4)
                    Me.Refresh()
                    r.Close()
                End If
            End Using
            '   MessageBox.Show(plink)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub saverec()

        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)

        If result = vbYes Then
            If My.Settings.newrec = True Then
                InsertRecord()
                clearrec()
            End If
            If My.Settings.newrec = False Then
                InsertRecord()
                clearrec()
                invoiceno.Text = ""
                getsettingcode()
            End If

            Me.Refresh()
            invoiceno.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If

    End Sub
    Public Sub delrec()


        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM salesinvoice WHERE" _
            & " invoiceno = '" & Me.invoiceno.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for invoiceno code: " + Trim(invoiceno.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    '  If result = vbNo Then
                    'Me.Close()
                    '   End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try

            Dim cSQL2 As String = "DELETE FROM sinvoicegrid WHERE" _
                        & " invoiceno = '" & Me.invoiceno.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand

                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2

                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for invoiceno code: " + Trim(invoiceno.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    '  If result = vbNo Then
                    'Me.Close()
                    '   End If
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If

    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        '   clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                ',accountname,accountno,bankname,branch,sortno
                Cd.CommandText = "SELECT billcode,descr,invoicetopic,tdate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,addressto,signby,accountname,accountno,bankname,branch,sortno,discount2,paid,glcode2,posted FROM salesinvoice WHERE" _
                & " billcode = '" & Billcode.Text & "' and tdate = '" & Format(tdate.Value, "yyyy-MM-dd") & "' and rtrim(invoiceno) = '" & RTrim(invoiceno.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.descr.Text = RTrim(r(1))
                    If Not r.IsDBNull(2) Then Me.invoicetopic.Rtf = r(2)
                    tdate.Value = r(3)
                    If Not r.IsDBNull(4) Then Me.invoiceno.Text = RTrim(r(4))
                    If Not r.IsDBNull(5) Then Me.glcode.Text = RTrim(r(5))
                    If Not r.IsDBNull(6) Then Me.Amtword.Text = RTrim(r(6))
                    If Not r.IsDBNull(7) Then Me.salesrep.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.stax.Text = r(8)
                    If Not r.IsDBNull(9) Then Me.itotal.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.netdue.Text = FormatNumber(r(10), 2, True, True, True)
                    If Not r.IsDBNull(11) Then Me.addressto.Rtf = r(11)
                    If Not r.IsDBNull(12) Then Me.signby.Rtf = r(12)
                    ',accountname,accountno,bankname,branch,sortno
                    If Not r.IsDBNull(13) Then Me.accountname.Text = r(13)
                    If Not r.IsDBNull(14) Then Me.accountno.Text = r(14)
                    If Not r.IsDBNull(15) Then Me.bankname.Text = r(15)
                    If Not r.IsDBNull(16) Then Me.branch.Text = r(16)
                    If Not r.IsDBNull(17) Then Me.sortno.Text = r(17)
                    If Not r.IsDBNull(18) Then Me.discount2.Text = r(18)
                    If r(19) = True Then
                        paystat.Text = "PAID"
                        ToolStripButton3.Enabled = False
                    End If
                    If Not r.IsDBNull(20) Then Me.glcode2.Text = r(20)
                    If r(21) = True Then
                        posting.Checked = True
                    End If

                    loadgriddata()

                    My.Settings.newrec = True
                    enablecontrols()
                    invoiceno.Focus()
                    GETHMOBANK()
                Else
                    My.Settings.newrec = False

                    enablecontrols()
                    invoiceno.Focus()
                    GETHMOBANK()
                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Load invoice data")
        End Try
    End Sub
    Sub enablecontrols()
       
        Me.descr.Enabled = True
        salesrep.Enabled = True
        invoiceno.Enabled = True
        glcode.Enabled = True
        glcode2.Enabled = True
        Amtword.Enabled = True
        invoicetopic.Enabled = True
        addressto.Enabled = True
        signby.Enabled = True
        discount2.Enabled = True
        Me.tdate.Enabled = True

        glcode.Enabled = True
    End Sub
    Sub disablecontrols()
        itotal.Enabled = False
        discount2.Enabled = False
        stax.Enabled = False
        netdue.Enabled = False
        Me.descr.Enabled = False
        '   salesrep.Enabled = False
        '  glcode.Enabled = False
        Amtword.Enabled = False
        invoicetopic.Enabled = False
        addressto.Enabled = False
        signby.Enabled = False
    End Sub
    Sub delfirst()
        ' 'SELECT billcode,pcode,eqty,uprice,tax,discou2nt,amt FROM sinvoicegrid
        Dim cSQL5 As String = "DELETE FROM sinvoicegrid WHERE" _
            & " invoiceno = '" & Me.invoiceno.Text & "'"
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
    Sub delsalesinvoice()
        Dim cSQL5 As String = "DELETE FROM salesinvoice WHERE" _
            & " invoiceno = '" & invoiceno.Text & "'"
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
        delsalesinvoice()
        MessageBox.Show(Format(tdate.Value, "yyyy-MM-dd"))
        cSQL = "INSERT INTO salesinvoice(billcode,descr,invoicetopic,tdate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,addressto,signby,accountname,accountno,bankname,branch,sortno,discount2,paid,posted,glcode2) VALUES('" & Billcode.Text & "','" & descr.Text & "','" & invoicetopic.Rtf & "','" & Format(tdate.Value, "yyyy-MM-dd") & "','" & invoiceno.Text & "','" & glcode.Text & "','" & Amtword.Text & "','" & salesrep.Text & "','" & stax.Text & "','" & itotal.Text & "','" & CDec(netdue.Text) & "','" & addressto.Rtf & "','" & signby.Rtf & "','" & accountname.Text & "','" & accountno.Text & "','" & bankname.Text & "','" & branch.Text & "','" & sortno.Text & "','" & discount2.Text & "','" & False & "','" & posting.Checked & "','" & glcode2.Text & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Record Save Sucessfully")
                saveaudit("Insert new record for invoiceno: " + Trim(invoiceno.Text) + " In " + Me.Text)
            End Using
            If posting.Checked = True Then
                posttogl()
                savetovendor()
            End If
            InsertRecordgrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in sales invoice postING table")
            'If Not r.IsDBNull(3) Then CheckCodestab.CALLCODESTAB(r(3), "F8")
            'Me.qsection.Text = CheckCodestab.descvar
        End Try
    End Sub
    Sub posttogl()
        'SELECT headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post FROM transtab

        cSQL = "INSERT INTO transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)" & _
            "VALUES('" & Billcode.Text & "','" & descr.Text & "','" & invoiceno.Text & "','" & salesrep.Text & "','" & "IV" & "','" & 0.0 & "','" & 0.0 & "','" & CDec(netdue.Text) & "','" & Format(tdate.Value, "yyyy-MM-dd") & "','" & glcode.Text & "','" & glcode2.Text & "','" & posting.Checked & "')"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Post to GL invoiceno: " + Trim(invoiceno.Text) + " In " + Me.Text)
                posting.Checked = False
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' invoicedate,linvoicepay,laspdate,lastpamt
    Sub savetovendor()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                Cd3.CommandText = "UPDATE custvendtab SET" _
                                & " linvoicedate = '" & tdate.Value & "', " & " linvoicepay = '" & CDec(netdue.Text) & "' " & " WHERE" & " rtrim(custvendid) = '" & RTrim(Billcode.Text) & "'"
                CCNN.Open()
                Cd3.ExecuteNonQuery()
                CCNN.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in sales invoice post to client register table")
        End Try

    End Sub
    Public Sub InsertRecordgrid()  'Subroutine to insert a record into the database  
        delfirst()
        'Dim PREMI As String
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer
                ' MsgBox(Payvalgrid.RowCount) SELECT                                                                                                                                                                                                   billcode,descr,invoicetopic,tdate,invoiceno,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM salesinvoice sinvoicegrid
                If saleinvoicegrid.RowCount > 0 Then
                    For i = 0 To saleinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value
                        '     MessageBox.Show()
                        If saleinvoicegrid.Rows(i).Cells(2).Value > 0 Then
                            'CheckCodestab.premiumplan(saleinvoicegrid.Rows(i).Cells(0).Value)
                            'PREMI = CheckCodestab.descvar

                            Cd3.CommandText = "INSERT INTO sinvoicegrid(pcode,pdescr,eqty,uprice,tax,discount,amt,invoiceno) VALUES('" & saleinvoicegrid.Rows(i).Cells(0).Value & "','" & saleinvoicegrid.Rows(i).Cells(1).Value & "','" & Val(saleinvoicegrid.Rows(i).Cells(2).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(3).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(4).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(5).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(6).Value) & "','" & invoiceno.Text & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update invoiceno code: " + Trim(invoiceno.Text) + " In " + Me.Text)
                Me.Refresh()
                MessageBox.Show("Record Save/Update Sucessfully")
                UpdategencodeRecord()
            End Using
            ' getgriddesc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in invoice Table")
        End Try
    End Sub
    'Sub getgriddesc()
    '    Dim gg2 As String = "select code1,descr from premiumplan"

    '    Try
    '        Using ccnn As New SqlConnection(My.Settings.cnnstring)
    '            Dim cd As SqlCommand = ccnn.CreateCommand

    '            cd.CommandText = gg2
    '            cd.CommandType = CommandType.Text
    '            ccnn.Open()
    '            Dim r As SqlDataReader = cd.ExecuteReader
    '            If r.HasRows() Then
    '                r.Read()
    '                getgriddescrpost(r(0), r(1))
    '            End If
    '            r.Close()
    '            Me.Refresh()
    '        End Using
    '    Catch ex As Exception
    '        MDIParent1.statusmsg.Text = ex.Message
    '    End Try
    '    Me.Refresh()
    'End Sub
    'Sub getgriddescrpost(ByVal idd As String, ByVal iddescr As String)

    '    ' premiumplan()
    '    cSQL = "UPDATE sinvoicegrid SET" _
    '        & " pdescr = '" & RTrim(iddescr) & "' " & " WHERE" & " RTrim(pcode) = '" & RTrim(idd) & "'"
    '    Try
    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd As SqlCommand = CCNN.CreateCommand
    '            Cd.CommandText = cSQL
    '            Cd.CommandType = CommandType.Text
    '            CCNN.Open()
    '            MessageBox.Show(idd)
    '            MessageBox.Show(iddescr)
    '            Cd.ExecuteNonQuery()
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)

    '    End Try
    'End Sub
    'Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
    '    '  delfirst()
    '    Try
    '        Using CCNN As New SqlConnection(My.Settings.cnnstring)
    '            Dim Cd3 As SqlCommand = CCNN.CreateCommand
    '            Cd3.CommandType = CommandType.Text

    '            Dim i As Integer
    '            ' MsgBox(Payvalgrid.RowCount)
    '            If saleinvoicegrid.RowCount > 0 Then
    '                For i = 0 To saleinvoicegrid.RowCount - 1 ''familygrid.Rows(i).Cells(0).Value
    '                    '   MessageBox.Show(claimsinputegrid.Rows(i).Cells(0).Value)
    '                    Cd3.CommandText = "INSERT INTO claimsinpute(hcpid,hcpname,tdate,batchcode,enrolleeid,ailmentcode,authocode,dtreated,ddischard,billamount,posted,approved,postedforapprove) VALUES('" & hcpid.Text & "','" & hcpname.Text & "','" & tdate.Value & "','" & batchcode1.Text & "','" & claimsinputegrid.Rows(i).Cells(0).Value & "','" & claimsinputegrid.Rows(i).Cells(1).Value & "','" & claimsinputegrid.Rows(i).Cells(2).Value & "','" & claimsinputegrid.Rows(i).Cells(3).Value & "','" & claimsinputegrid.Rows(i).Cells(4).Value & "','" & Val(claimsinputegrid.Rows(i).Cells(5).Value) & "','" & False & "','" & False & "','" & False & "')"
    '                    CCNN.Open()
    '                    Cd3.ExecuteNonQuery()
    '                    CCNN.Close()

    '                Next
    '            End If
    '            saveaudit("Save/Update Batch record for code: " + Trim(batchcode1.Text) + " In " + Me.Text)
    '            delemptyenrolle()
    '            Me.Refresh()
    '            MessageBox.Show("Batch Save/Update Sucessfully")
    '        End Using

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
    '    End Try
    'End Sub

    Sub loadgriddata()
        Dim i2 As Integer
        For i2 = i2 To saleinvoicegrid.RowCount - 1
            saleinvoicegrid.Rows.Clear()
        Next
        Dim gg2 As String = "select pcode,pdescr,eqty,uprice,tax,discount,amt,invoiceno from sinvoicegrid where invoiceno = '" & invoiceno.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = saleinvoicegrid.Rows.Add
                        saleinvoicegrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        saleinvoicegrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        saleinvoicegrid.Rows(row).Cells(2).Value = Val(r(2))
                        saleinvoicegrid.Rows(row).Cells(3).Value = Val(r(3))
                        saleinvoicegrid.Rows(row).Cells(4).Value = Val(r(4))
                        saleinvoicegrid.Rows(row).Cells(5).Value = Val(r(5))
                        saleinvoicegrid.Rows(row).Cells(6).Value = Val(r(6))
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


    Sub presetup()
        'Dim connetionString As String = Nothing
        'Dim connection As SqlConnection
        'Dim command As SqlCommand
        'Dim adapter As New SqlDataAdapter()
        'Dim ds As New DataSet()
        'Dim i As Integer = 0
        'Dim sql As String = Nothing
        'connetionString = My.Settings.cnnstring
        'sql = "select code1,descr,amount from premiumplan"
        'connection = New SqlConnection(connetionString)
        'Try
        '    connection.Open()
        '    command = New SqlCommand(sql, connection)
        '    adapter.SelectCommand = command
        '    adapter.Fill(ds)
        '    adapter.Dispose()
        '    command.Dispose()
        '    connection.Close()
        '    pcode.DataSource = ds.Tables(0)
        '    pcode.ValueMember = "code1"
        '    pcode.DisplayMember = "descr"
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = "Can not open connection ! "
        'End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            FontDialog1.ShowDialog()
            addressto.SelectionFont = FontDialog1.Font
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            FontDialog1.ShowDialog()
            invoicetopic.SelectionFont = FontDialog1.Font
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            FontDialog1.ShowDialog()
            signby.SelectionFont = FontDialog1.Font
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
   
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AmountInWords(netdue.Text)
    End Sub
    'Private Function Replace(nAmount As String, tempDecValue As String, Empty As String) As String
    '    Throw New NotImplementedException
    'End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '    "SELECT billcode,descr,invoicetopic,tdate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM salesinvoice WHERE" _
        '            & " billcode = '" & Billcode.Text & "' and tdate = '" & tdate.Value & "' and rtrim(invoiceno) = '" & RTrim(invoiceno.Text) & "'"

        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct invoiceno,billcode,tdate FROM salesinvoice order by invoiceno"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            '  sfrm.Show()
            invoiceno.Text = CODDY
            invoiceno.Refresh()
            Me.Refresh()

            If (Not invoiceno.Text = String.Empty) Then
                invoiceno.Refresh()
                LoadRecord()
                invoiceno.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub invoiceno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles invoiceno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not invoiceno.Text = String.Empty) Then
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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        ToolStripButton3.Enabled = True
        getsettingcode()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs)
        clearrec()
        ToolStripButton3.Enabled = True
        getsettingcode()
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        saverec()
    End Sub

    Private Sub DeleteEnrolleeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        delrec()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select accode,descriptn,actype from accode order by accode"
            Dim sfrm As New searchfrm
            'sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            'sfrm.Show()
            glcode.Text = CODDY
            glcode.Refresh()
            Me.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
      
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub saleinvoicegrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles saleinvoicegrid.CellContentClick

    End Sub

    Private Sub saleinvoicegrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles saleinvoicegrid.CellEndEdit
        Try
            Dim tott2 As Double = 0.0
            Dim tott As Double = 0.0
            Dim tott3 As Double = 0.0
        For index As Integer = 0 To saleinvoicegrid.RowCount - 1
            If saleinvoicegrid.Rows.Count = 0 Then Exit Sub
                Dim Idx = e.RowIndex

                saleinvoicegrid.Rows(e.RowIndex).Cells(6).Value = Val(saleinvoicegrid.Rows(e.RowIndex).Cells(2).Value) * Val(saleinvoicegrid.Rows(e.RowIndex).Cells(3).Value)
                'If saleinvoicegrid.Rows(e.RowIndex).Cells(4).Value > 0 Then
                saleinvoicegrid.Rows(e.RowIndex).Cells(6).Value = Val(saleinvoicegrid.Rows(e.RowIndex).Cells(2).Value) * Val(saleinvoicegrid.Rows(e.RowIndex).Cells(3).Value)
                'End If


                tott2 += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(3).Value / 12 * saleinvoicegrid.Rows(index).Cells(4).Value)
                saleinvoicegrid.Rows(e.RowIndex).Cells(6).Value = tott2
                tott += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(6).Value)
                itotal.Text = tott
                'tott2 += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(6).Value / 100 * saleinvoicegrid.Rows(index).Cells(4).Value)
                'stax.Text = tott2
                'tott3 += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(6).Value / 100 * saleinvoicegrid.Rows(index).Cells(5).Value)

                tott3 += Convert.ToInt32(tott2 / 100 * saleinvoicegrid.Rows(index).Cells(5).Value)
                discount2.Text = tott3
                Dim taxval As Double = Val(itotal.Text) '+ Val(stax.Text)
                netdue.Text = FormatNumber(taxval - Val(discount2.Text), 2, True, True, True)
            Next

        'itotal.Text += Convert.ToInt32(Val(saleinvoicegrid.Rows(e.RowIndex).Cells(5).Value))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub invoiceno_ReadOnlyChanged(sender As Object, e As EventArgs) Handles invoiceno.ReadOnlyChanged

    End Sub

    Private Sub invoiceno_TextChanged(sender As Object, e As EventArgs) Handles invoiceno.TextChanged

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

    Private Sub itotal_TextChanged(sender As Object, e As EventArgs) Handles itotal.TextChanged

    End Sub


    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        rptrangecode = ""
        If (Not invoiceno.Text = String.Empty) Then
            getinvoicereportdata1()
            My.Settings.reportsqlstr = "Prininvoice"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = invoiceno.Text
            viewreport2.Text = "Print Invoice "
            viewreport2.Show()
        End If

    End Sub

    Private Sub netdue_TextChanged(sender As Object, e As EventArgs) Handles netdue.TextChanged
        AmountInWords(netdue.Text)
    End Sub
    Sub getinvoicereportdata1()
        delinvoicefirst()
        'MessageBox.Show("getinvoicereportdata1")
        'insert into tableB select * FROM tableA where DATE_OF_SELL BETWEEN Convert(DateTime,'" & TextBox1.Text "',105) AND Convert(DateTime,'" & TextBox2.Text "',105)", Connection)
        Dim cSQL As String = "INSERT INTO salesinvoicerpt select * from salesinvoice where invoiceno = '" & invoiceno.Text & "'"

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
            getinvoicereportdata2()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Sub getinvoicereportdata2()
        ' MessageBox.Show("getinvoicegridreportdata2")
        'insert into tableB select * FROM tableA where DATE_OF_SELL BETWEEN Convert(DateTime,'" & TextBox1.Text "',105) AND Convert(DateTime,'" & TextBox2.Text "',105)", Connection)
        Dim cSQL As String = "INSERT INTO sinvoicegridrpt select * from sinvoicegrid where invoiceno = '" & invoiceno.Text & "'"

        Try
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
    Sub delinvoicefirst()
        ' 'SELECT billcode,pcode,eqty,uprice,tax,discou2nt,amt FROM sinvoicegrid
        Dim cSQL5 As String = "DELETE FROM sinvoicegridrpt"
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

        Dim cSQL6 As String = "DELETE FROM salesinvoicerpt"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL6

                CCNN.Open()
                Cd.ExecuteNonQuery()

                Me.Refresh()
            End Using
        Catch ex As Exception
            '   MessageBox.Show(ex.Message, "Occurs in claimsinpute Table")
        End Try

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select accode,descriptn,actype from accode order by accode"
            Dim sfrm As New searchfrm
            sfrm.ShowDialog()
            glcode2.Text = CODDY
            glcode2.Refresh()
            Me.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub descr_TextChanged(sender As Object, e As EventArgs) Handles descr.TextChanged

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        GETHMOBANK()
    End Sub
End Class