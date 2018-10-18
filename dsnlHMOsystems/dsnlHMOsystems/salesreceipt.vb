
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
Public Class salesreceipt
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String

    Private Sub salesreceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        saleinvoicegrid.EnableHeadersVisualStyles = False
        saleinvoicegrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        saleinvoicegrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        saleinvoicegrid.ColumnHeadersHeight = 30
        saleinvoicegrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        partpay.Visible = False
        If custventype2.Text = "Customer" Then
            Dim ccvv As String = "C"
        Else
            Dim ccvv As String = "V"
        End If

        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "select code1,descr,amount from premiumplan"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            pcode.DataSource = ds.Tables(0)
            pcode.ValueMember = "code1"
            pcode.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
        posting.Checked = False




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clearrec()
 
        'If partpay.Checked = True Then
        '    Try
        '        gsql = ""
        '        DESCC = ""
        '        OPTRR = publicvarmodule.OPT
        '        gsql = "SELECT distinct invoiceno,billcode,issuedate FROM salesreceipt where partbalance > 0"
        '        Dim sfrm As New searchfrm
        '        ' sfrm.MdiParent = MDIParent1
        '        sfrm.ShowDialog()
        '        ' sfrm.Show()
        '        invoiceno.Text = CODDY
        '        invoiceno.Refresh()
        '        Me.Refresh()

        '        If (Not invoiceno.Text = String.Empty) Then
        '            invoiceno.Refresh()
        '            LoadreceiptRecord()
        '            loadgriddata()
        '            invoiceno.Refresh()
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try
        'Else

        'If custventype2.Text = "Customer" Then
        Dim ccvv As String = "C"
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct invoiceno,billcode,tdate FROM salesinvoice order by invoiceno"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            invoiceno.Text = CODDY
            invoiceno.Refresh()
            Me.Refresh()

            If (Not invoiceno.Text = String.Empty) Then
                invoiceno.Refresh()
                LoadreceiptRecord()
                loadgriddata()
                invoiceno.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Else
        '    Dim ccvv As String = "V"


        'End If
        'End If

    End Sub
    Public Sub saverec()

        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)

        If result = vbYes Then
            'RecordExist()

            If My.Settings.newrec = True Then
                InsertRecord()
                clearrec()
            End If
            If My.Settings.newrec = False Then
                InsertRecord()
                UpdategencodeRecord()
                clearrec()
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

            cSQL = "DELETE FROM salesreceipt WHERE" _
            & " invoiceno = '" & invoiceno.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for salesreceipt code: " + Trim(recieptno.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try



        End If
    End Sub

    Sub getsettingcode()
        Dim gg2 As String = "select companyid,autorecieptno from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    recieptno.Text = LTrim(r(1))
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

        Me.autobatch.Text = Str(Val(autobatch.Text) + 1)
        Try
            Dim cSQL As String = "UPDATE digitsettings SET autorecieptno = '" & Me.autobatch.Text.Trim & "'"
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
        partbalace.Text = 0.0
        Me.descr.Text = ""
        chequeref.Text = ""
        recieptno.Text = ""
        salesrep.Text = ""
        discount2.Text = 0
        glcode.Text = ""
        Me.descr.Text = ""
        salesrep.Text = ""
        invoiceno.Text = ""
        glcode.Text = ""
        glcode2.Text = ""
        Amtword.Text = ""
        issuedate.Text = Now
        ramt.Text = 0.0
        collectedfrom.Text = ""
        discount2.Text = 0.0
        paid.Checked = False
        Me.issuedate.Value = Now
        Dim T As Integer
        For T = T To saleinvoicegrid.RowCount - 1
            saleinvoicegrid.Rows.Clear()
        Next

        Me.Refresh()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select accode,descriptn,actype from accode order by accode"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            ' sfrm.Show()
            glcode.Text = CODDY
            glcode.Refresh()
            Me.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadinvoiceRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        ''   clearrec()
        'Try
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            Dim Cd As SqlCommand = CCNN.CreateCommand
            ',accountname,accountno,bankname,branch,sortno
            Cd.CommandText = "SELECT invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,discount2,billcode,descr,glcode2 FROM salesinvoice WHERE" _
            & " rtrim(invoiceno) = '" & RTrim(invoiceno.Text) & "'"
            Cd.CommandType = CommandType.Text
            CCNN.Open()
            Dim r As SqlDataReader = Cd.ExecuteReader
            If r.HasRows = True Then
                r.Read()
                If Not r.IsDBNull(1) Then Me.glcode.Text = RTrim(r(1))
                'If Not r.IsDBNull(2) Then Me.mword.Text = r(2)
                'Me.Amtword.Rtf = Me.mword.Text
                ' If Not r.IsDBNull(2) Then Me.Amtword.Rtf = r(2)
                If Not r.IsDBNull(3) Then Me.salesrep.Text = r(3)
                If Not r.IsDBNull(4) Then Me.stax.Text = r(4)
                If Not r.IsDBNull(5) Then Me.itotal.Text = r(5)
                If Not r.IsDBNull(6) Then Me.netdue.Text = FormatNumber(r(6), 2, True, True, True)
                If Not r.IsDBNull(7) Then Me.discount2.Text = r(7)
                If Not r.IsDBNull(8) Then Me.Billcode.Text = r(8)
                If Not r.IsDBNull(9) Then Me.descr.Text = r(9)
                'If Not r.IsDBNull(10) Then Me.descr.Text = r(10)
                'If Not r.IsDBNull(10) Then Me.partbalace.Text = r(10)
            Else
                enablecontrols()
            End If
            Me.Refresh()
            '  MsgBox(addnew)
            r.Close()
            '  LoadreceiptRecord()

        End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in Load invoice data")
        'End Try
    End Sub
    Public Sub LoadreceiptRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        ToolStripButton3.Enabled = True
        Dim index As Integer
        'Try
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            Dim Cd As SqlCommand = CCNN.CreateCommand
            '"SELECT billcode,descr,issuedate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,collectedfrom,paid,pmethod,chequeref,recieptno,ramt,discount2,beingpart FROM salesreceipt WHERE" _--+
            Cd.CommandText = "SELECT billcode,descr,issuedate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,collectedfrom,paid,pmethod,chequeref,recieptno,ramt,discount2,beingpart,paid,partbalace,glcode2 FROM salesreceipt WHERE" _
            & " rtrim(invoiceno) = '" & RTrim(invoiceno.Text) & "'"
            Cd.CommandType = CommandType.Text
            CCNN.Open()
            Dim r As SqlDataReader = Cd.ExecuteReader
            If r.HasRows = True Then
                r.Read()
                If Not r.IsDBNull(0) Then Me.Billcode.Text = RTrim(r(0))
                If Not r.IsDBNull(1) Then Me.descr.Text = RTrim(r(1))
                issuedate.Value = r(2)
                If Not r.IsDBNull(3) Then Me.invoiceno.Text = r(3)
                If Not r.IsDBNull(4) Then Me.glcode.Text = r(4)
                If Not r.IsDBNull(5) Then Me.Amtword.Rtf = r(5)
                If Not r.IsDBNull(6) Then Me.salesrep.Text = r(6)
                If Not r.IsDBNull(7) Then Me.stax.Text = r(7)
                If Not r.IsDBNull(8) Then Me.itotal.Text = r(8)
                'chequeref,recieptno,ramt,discount2,beingpart
                If Not r.IsDBNull(9) Then Me.netdue.Text = FormatNumber(r(9), 2, True, True, True)
                If Not r.IsDBNull(10) Then Me.collectedfrom.Text = r(10)
                If r(11) = True Then
                    Me.paid.Checked = True
                    ToolStripButton3.Enabled = False
                End If
                If Not r.IsDBNull(12) Then
                    index = pmethod.FindString(RTrim(r(12)))
                    pmethod.SelectedIndex = index
                End If

                If Not r.IsDBNull(13) Then Me.chequeref.Text = r(13)
                If Not r.IsDBNull(14) Then Me.recieptno.Text = r(14)
                If Not r.IsDBNull(15) Then Me.ramt.Text = r(15)
                If Not r.IsDBNull(16) Then Me.discount2.Text = r(16)
                '  MessageBox.Show(r(17))
                If Not r.IsDBNull(17) Then Me.beingpart.Rtf = r(17)
               
                If r(19) > 0 Then
                    partpay.Visible = True
                End If

                If Not r.IsDBNull(19) Then Me.partbalace.Text = r(19)
                If Not r.IsDBNull(20) Then Me.glcode2.Text = r(20)
                If r(18) = True Then
                    partpay.Visible = False
                End If
                enablecontrols()
            Else
                LoadinvoiceRecord()
                enablecontrols()
            End If
            Me.Refresh()
            '  MsgBox(addnew)
            r.Close()
        End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in Load receipt data")
        'End Try
    End Sub

    Sub enablecontrols()
        'billcode,descr,issuedate,invoiceno,glcode,Amtword,salesrep,pmethod,stax,itotal,netdue,collectedfrom,paid,chequeref,recieptno,ramt,discount2 
        Me.descr.Enabled = True
        salesrep.Enabled = True
        invoiceno.Enabled = True
        glcode.Enabled = True
        Amtword.Enabled = True
        issuedate.Enabled = True
        pmethod.Enabled = True
        collectedfrom.Enabled = True
        discount2.Enabled = True
        Me.issuedate.Enabled = True
        Me.partbalace.Enabled = True

    End Sub
    Sub disablecontrols()
        Me.descr.Enabled = False
        salesrep.Enabled = False
        invoiceno.Enabled = False
        glcode.Enabled = False
        Amtword.Enabled = False
        issuedate.Enabled = False
        pmethod.Enabled = False
        collectedfrom.Enabled = False
        discount2.Enabled = False
        Me.issuedate.Enabled = False
        Me.partbalace.Enabled = False
    End Sub
    Sub loadgriddata()
        Dim i2 As Integer
        For i2 = i2 To saleinvoicegrid.RowCount - 1
            saleinvoicegrid.Rows.Clear()
        Next
        Dim gg2 As String = "select pcode,eqty,uprice,tax,discount,amt,invoiceno from sinvoicegrid where invoiceno = '" & invoiceno.Text & "'"

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
                        saleinvoicegrid.Rows(row).Cells(1).Value = Val(r(1))
                        saleinvoicegrid.Rows(row).Cells(2).Value = Val(r(2))
                        saleinvoicegrid.Rows(row).Cells(3).Value = Val(r(3))
                        saleinvoicegrid.Rows(row).Cells(4).Value = Val(r(4))
                        saleinvoicegrid.Rows(row).Cells(5).Value = Val(r(5))
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
    Sub delsalesinvoicereceipt()
        Dim cSQL5 As String = "DELETE FROM salesreceipt WHERE" _
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
    Public Sub InsertRecord()  'Subroutine to insert a record into the database               Format(issuedate.Value, "MM/dd/yyyy")                                                                                                                                                                                                          billcode,descr,issuedate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,                                                                                                          collectedfrom,paid,pmethod,chequeref,recieptno,ramt,discount2,beingpart                                                                                                                                                                                                                               ',accountname,accountno,bankname,branch,sortno
        If Val(partbalace.Text) > Val(ramt.Text) Then
            MessageBox.Show("Part Payment Balance cannot be greater than receipt amount")
            partbalace.Focus()
            Return
        Else

            If partpay.Checked = True Then
                'MessageBox.Show("PART")
                If paid.Checked = False Then
                    paid.Checked = True
                    posting.Checked = True
                End If
                ' MessageBox.Show(Format(issuedate.Value, "yyyy-MM-dd"))
                MDIParent1.statusmsg2.Text = Format(issuedate.Value, "yyyy-MM-dd")
                cSQL = "INSERT INTO salesreceipt(billcode,descr,issuedate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,collectedfrom,paid,pmethod,chequeref,recieptno,ramt,discount2,beingpart,code1,partbalace,glcode2)" & _
                    "VALUES('" & Billcode.Text & "','" & descr.Text & "','" & Format(issuedate.Value, "yyyy-MM-dd") & "','" & RTrim(invoiceno.Text) + "P" & "','" & glcode.Text & "','" & Amtword.Rtf & "','" & salesrep.Text & "','" & stax.Text & "','" & itotal.Text & "','" & CDec(netdue.Text) & "','" & collectedfrom.Text & "','" & IIf(paid.Checked = True, "True", "False") & "','" & pmethod.Text & "','" & chequeref.Text & "','" & recieptno.Text & "','" & CDec(ramt.Text) & "','" & discount2.Text & "','" & beingpart.Rtf & "','" & compcode & "','" & CDec(partbalace.Text) & "','" & glcode2.Text & "')"
                Try
                    Using CCNN As New SqlConnection(My.Settings.cnnstring)
                        Dim Cd As SqlCommand = CCNN.CreateCommand
                        Cd.CommandText = cSQL
                        Cd.CommandType = CommandType.Text
                        CCNN.Open()
                        Cd.ExecuteNonQuery()
                        UPDATEOGATAB()
                        posttogl()
                        MessageBox.Show("Record updated Sucessfully")
                        saveaudit("Insert record in salesreceipt for Partpayment Invoice No: " + RTrim(invoiceno.Text) + "P " + " In " + Me.Text)
                    End Using

                    If paid.Checked = True Then
                        stopinvoice()
                        UPDATEOGATAB()
                        updatepartbalrecord()
                        partpay.Checked = False
                        partpay.Visible = False


                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                'MessageBox.Show("fFULL")
                delsalesinvoicereceipt()
                'MessageBox.Show(Format(issuedate.Value, "yyyy-MM-dd"))
                MDIParent1.statusmsg2.Text = Format(issuedate.Value, "yyyy-MM-dd")
                cSQL = "INSERT INTO salesreceipt(billcode,descr,issuedate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,collectedfrom,paid,pmethod,chequeref,recieptno,ramt,discount2,beingpart,code1,partbalace,glcode2) VALUES('" & Billcode.Text & "','" & descr.Text & "','" & Format(issuedate.Value, "yyyy-MM-dd") & "','" & invoiceno.Text & "','" & glcode.Text & "','" & Amtword.Rtf & "','" & salesrep.Text & "','" & stax.Text & "','" & itotal.Text & "','" & CDec(netdue.Text) & "','" & collectedfrom.Text & "','" & IIf(paid.Checked = True, "True", "False") & "','" & pmethod.Text & "','" & chequeref.Text & "','" & recieptno.Text & "','" & CDec(ramt.Text) & "','" & discount2.Text & "','" & beingpart.Rtf & "','" & compcode & "','" & CDec(partbalace.Text) & "','" & glcode2.Text & "')"
                Try
                    Using CCNN As New SqlConnection(My.Settings.cnnstring)
                        Dim Cd As SqlCommand = CCNN.CreateCommand
                        Cd.CommandText = cSQL
                        Cd.CommandType = CommandType.Text
                        CCNN.Open()
                        Cd.ExecuteNonQuery()
                    End Using
                    If paid.Checked = True Then
                        stopinvoice()
                        UPDATEOGATAB()
                    End If
                    MessageBox.Show("Record Save Sucessfully")
                    saveaudit("Insert new record in salesreceipt for Invoice No: " + Trim(invoiceno.Text) + " In " + Me.Text)
                    posttogl()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
       
    End Sub
    Sub updatepartbalrecord()
        Try
            cSQL = "UPDATE salesreceipt SET" _
                   & " paid = '" & True & "' " & " WHERE" & " invoiceno = '" & Me.invoiceno.Text & "'"
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
    Sub UPDATEOGATAB()
        Try
            cSQL = "UPDATE oganisationtab SET" _
                   & " paidtodate += '" & Me.ramt.Text & "'  " & " WHERE" & " rtrim(ogaid) = '" & RTrim(Me.Billcode.Text) & "'"

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

        Try
            Dim cSQL2 As String = "UPDATE oganisationtab SET" _
                   & " cbalance += '" & Me.ramt.Text & "'  " & " WHERE" & " rtrim(ogaid) = '" & RTrim(Me.Billcode.Text) & "'"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL2
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        savetovendor()
    End Sub
    Sub stopinvoice()
        Try
            cSQL = "UPDATE salesinvoice SET" _
                   & " paid = '" & True & "' " & " WHERE" & " invoiceno = '" & Me.invoiceno.Text & "'"
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
    Sub savetovendor()
        ',linvoicedate,linvoicepay,laspdate,lastpamt
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Cd3.CommandText = "UPDATE custvendtab SET" _
                                & " laspdate = '" & issuedate.Value & "', " & " lastpamt = '" & CDec(ramt.Text) & "' " & " WHERE" & " rtrim(custvendid) = '" & RTrim(Billcode.Text) & "'"
                CCNN.Open()
                Cd3.ExecuteNonQuery()
                CCNN.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in sales invoice post to client register table")
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

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub invoiceno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles invoiceno.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not invoiceno.Text = String.Empty) Then
                invoiceno.Refresh()
                loadgriddata()
                LoadreceiptRecord()
                invoiceno.Refresh()
            End If
        End If
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

        Amtword.Text = wAmount
        'Display the result
        Return wAmount
    End Function

    Private Sub ramt_TextChanged(sender As Object, e As EventArgs) Handles ramt.TextChanged
        Try
            AmountInWords(ramt.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If (Not invoiceno.Text = String.Empty) Then
            My.Settings.reportsqlstr = "Printreceipt"
            Dim viewreport2 As New viewreport
            viewreport2.MdiParent = MDIParent1
            rptrangecode = invoiceno.Text
            viewreport2.Text = "Print Receipt"
            viewreport2.Show()
        End If 'And paid.Checked = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            FontDialog1.ShowDialog()
            Amtword.SelectionFont = FontDialog1.Font
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            FontDialog1.ShowDialog()
            beingpart.SelectionFont = FontDialog1.Font
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        posting.Checked = False
        ToolStripButton3.Enabled = True
    End Sub

    Private Sub invoiceno_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles invoiceno.PreviewKeyDown

    End Sub

    Private Sub invoiceno_TextChanged(sender As Object, e As EventArgs) Handles invoiceno.TextChanged

    End Sub

    Private Sub ramt_Validating(sender As Object, e As CancelEventArgs) Handles ramt.Validating
        If CDec(ramt.Text) > CDec(netdue.Text) Then
            MessageBox.Show("Receipt amount cannot be greater than net due ")
            ramt.Focus()
            Return
        End If
        partbalace.Text = CDec(netdue.Text) - ramt.Text
        AmountInWords(ramt.Text)
    End Sub

    Private Sub paid_CheckedChanged(sender As Object, e As EventArgs) Handles paid.CheckedChanged
        If Val(partbalace.Text) > 0 Then
            MessageBox.Show("Part payment balance, has not been paid ")
            paid.Checked = False
            partbalace.Focus()
            Return
        End If
        posting.Checked = True
        'ramt.Text = netdue.Text
    End Sub

    Private Sub partpay_CheckedChanged(sender As Object, e As EventArgs) Handles partpay.CheckedChanged
        If Val(partbalace.Text) > 0 Then
            ramt.Text = 0.0
            ramt.Text = partbalace.Text
            partbalace.Text = 0.0
            recieptno.Text = ""
            chequeref.Text = ""

        Else
            MessageBox.Show("No Part payment balance Found ")
        End If




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
    Sub posttogl()
        'SELECT headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post FROM transtab
        MDIParent1.statusmsg2.Text = "Transtab IN"
        If partpay.Checked = True Then
            cSQL = "INSERT INTO transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)" & _
                        "VALUES('" & Billcode.Text & "','" & descr.Text & "','" & RTrim(invoiceno.Text) + "P" & "','" & salesrep.Text & "','" & "RC" & "','" & 0.0 & "','" & 0.0 & "','" & CDec(ramt.Text) & "','" & Format(issuedate.Value, "yyyy-MM-dd") & "','" & glcode.Text & "','" & glcode2.Text & "','" & posting.Checked & "')"

            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Post to GL invoiceno: " + Trim(invoiceno.Text) + " In " + Me.Text)
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            MDIParent1.statusmsg2.Text = "Transtab out"
        End If
        If partpay.Checked = False Then
            cSQL = "INSERT INTO transtab(headcode,hdescr,transcode,tdescr,typecode,qty,uprice,total,transdate,acctcredit,acctdebit,post)" & _
                        "VALUES('" & Billcode.Text & "','" & descr.Text & "','" & invoiceno.Text & "','" & salesrep.Text & "','" & "RC" & "','" & 0.0 & "','" & 0.0 & "','" & CDec(ramt.Text) & "','" & Format(issuedate.Value, "yyyy-MM-dd") & "','" & glcode.Text & "','" & glcode2.Text & "','" & posting.Checked & "')"

            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandText = cSQL
                    Cd.CommandType = CommandType.Text
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Post to GL invoiceno: " + Trim(invoiceno.Text) + " In " + Me.Text)
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            MDIParent1.statusmsg2.Text = "Transtab IN"
        End If

    End Sub

    Private Sub partbalace_TextChanged(sender As Object, e As EventArgs) Handles partbalace.TextChanged

    End Sub
End Class