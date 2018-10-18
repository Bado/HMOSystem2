
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
Public Class paybills
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String

    Private Sub paybills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        saleinvoicegrid.EnableHeadersVisualStyles = False
        saleinvoicegrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        saleinvoicegrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        saleinvoicegrid.ColumnHeadersHeight = 30
        saleinvoicegrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        Searchtool.SelectedItem = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        sql = "SELECT custvendid,Names FROM custvendtab where custvendtype ='" & "V" & "' order by custvendtype,custvendid"
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
            getsettingcode()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub getcustaddress()
        ' Dim gg2 As String = "select hcpid,Names,address FROM Hcptab WHERE rtrim(hcpid) = '" & RTrim(Billcode.Text) & "'"
        Dim gg2 As String = "SELECT custvendid,Names,address FROM custvendtab where custvendtype ='" & "V" & "' and rtrim(custvendid) = '" & RTrim(Billcode.Text) & "' order by custvendtype,custvendid"
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

        Me.autobatch.Text = Str(Val(autobatch.Text) + 1)
        Try
            Dim cSQL As String = "UPDATE digitsettings SET invoiceno = '" & Me.autobatch.Text & "'"
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
        discount2.Text = 0
        glcode.Text = ""
        Amtword.Text = ""
        cinvoice.Text = ""
        Dim T As Integer
        For T = T To saleinvoicegrid.RowCount - 1
            saleinvoicegrid.Rows.Clear()
        Next

        Me.Refresh()
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

            cSQL = "DELETE FROM payinvoice WHERE" _
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

            Dim cSQL2 As String = "DELETE FROM pinvoicegrid WHERE" _
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
                Cd.CommandText = "SELECT billcode,descr,tdate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,discount2,cinvoice,paid FROM payinvoice WHERE" _
                & " billcode = '" & Billcode.Text & "' and tdate = '" & Format(tdate.Value, "yyyy-MM-dd") & "' and rtrim(invoiceno) = '" & RTrim(invoiceno.Text) & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.descr.Text = RTrim(r(1))
                    tdate.Value = r(2)
                    If Not r.IsDBNull(3) Then Me.invoiceno.Text = RTrim(r(3))
                    If Not r.IsDBNull(4) Then Me.glcode.Text = RTrim(r(4))
                    If Not r.IsDBNull(5) Then Me.Amtword.Text = RTrim(r(5))
                    If Not r.IsDBNull(6) Then Me.salesrep.Text = r(6)
                    If Not r.IsDBNull(7) Then Me.stax.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.itotal.Text = r(8)
                    If Not r.IsDBNull(9) Then Me.netdue.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.discount2.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.cinvoice.Text = r(11)
                    If r(12) = True Then
                        paystat.Text = "PAID"
                        ToolStripButton3.Enabled = False
                    End If
                    loadgriddata()
                    My.Settings.newrec = True
                    enablecontrols()
                    invoiceno.Focus()
                    '  MessageBox.Show("exist")
                Else
                    My.Settings.newrec = False
                    '   clearrec()
                    enablecontrols()
                    invoiceno.Focus()
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
        Amtword.Enabled = True
      
        discount2.Enabled = True
        Me.tdate.Enabled = True
        salesrep.Enabled = True
        glcode.Enabled = True
    End Sub
    Sub disablecontrols()
        itotal.Enabled = False
        discount2.Enabled = False
        stax.Enabled = False
        netdue.Enabled = False
        Me.descr.Enabled = False
        Amtword.Enabled = False
    
    End Sub
    Sub delfirst()
        ' 'SELECT billcode,pcode,eqty,uprice,tax,discou2nt,amt FROM pinvoicegrid
        Dim cSQL5 As String = "DELETE FROM pinvoicegrid WHERE" _
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
    Sub delpayinvoice()
        Dim cSQL5 As String = "DELETE FROM payinvoice WHERE" _
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
        delpayinvoice()
        cSQL = "INSERT INTO payinvoice(billcode,descr,tdate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,discount2,cincoice)" & _
            "VALUES('" & Billcode.Text & "','" & descr.Text & "','" & Format(tdate.Value, "yyyy-MM-dd") & "','" & invoiceno.Text & "','" & glcode.Text & "','" & Amtword.Text & "','" & salesrep.Text & "','" & stax.Text & "','" & itotal.Text & "','" & netdue.Text & "','" & discount2.Text & "','" & cinvoice.Text & "')"

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
            InsertRecordgrid()
            '  UpdategencodeRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'If Not r.IsDBNull(3) Then CheckCodestab.CALLCODESTAB(r(3), "F8")
            'Me.qsection.Text = CheckCodestab.descvar
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
                ' MsgBox(Payvalgrid.RowCount) SELECT                                                                                                                                                                                                   billcode,descr,invoicetopic,tdate,invoiceno,glcode,                                                                                                         Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM payinvoice pinvoicegrid
                If saleinvoicegrid.RowCount > 0 Then
                    For i = 0 To saleinvoicegrid.RowCount - 1 ''saleinvoicegrid.Rows(i).Cells(0).Value
                        '     MessageBox.Show()
                        If saleinvoicegrid.Rows(i).Cells(1).Value > 0 Then
                            CheckCodestab.premiumplan(saleinvoicegrid.Rows(i).Cells(0).Value)
                            PREMI = CheckCodestab.descvar
                            Cd3.CommandText = "INSERT INTO pinvoicegrid(pcode,eqty,uprice,tax,discount,amt,invoiceno,pdescr) VALUES('" & saleinvoicegrid.Rows(i).Cells(0).Value & "','" & Val(saleinvoicegrid.Rows(i).Cells(1).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(2).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(3).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(4).Value) & "','" & Val(saleinvoicegrid.Rows(i).Cells(5).Value) & "','" & invoiceno.Text & "','" & PREMI & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update invoiceno code: " + Trim(invoiceno.Text) + " In " + Me.Text)
                Me.Refresh()
                MessageBox.Show("Record Save/Update Sucessfully")
            End Using
            ' getgriddesc()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in invoice Table")
        End Try
    End Sub
    Sub loadgriddata()
        Dim i2 As Integer
        For i2 = i2 To saleinvoicegrid.RowCount - 1
            saleinvoicegrid.Rows.Clear()
        Next
        Dim gg2 As String = "select pcode,eqty,uprice,tax,discount,amt,invoiceno from pinvoicegrid where invoiceno = '" & invoiceno.Text & "'"

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
    End Sub

 

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AmountInWords(netdue.Text)
    End Sub
    'Private Function Replace(nAmount As String, tempDecValue As String, Empty As String) As String
    '    Throw New NotImplementedException
    'End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '    "SELECT billcode,descr,invoicetopic,tdate,invoiceno,glcode,Amtword,salesrep,stax,itotal,netdue,addressto,signby FROM payinvoice WHERE" _
        '            & " billcode = '" & Billcode.Text & "' and tdate = '" & tdate.Value & "' and rtrim(invoiceno) = '" & RTrim(invoiceno.Text) & "'"

        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct invoiceno,billcode,tdate FROM payinvoice order by invoiceno"
            Dim sfrm As New searchfrm
            sfrm.MdiParent = MDIParent1
            ' sfrm.ShowDialog()
            sfrm.Show()
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

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
        ToolStripButton3.Enabled = True
        getsettingcode()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select accode,descriptn,actype from accode order by accode"
            Dim sfrm As New searchfrm
            sfrm.MdiParent = MDIParent1
            ' sfrm.ShowDialog()
            sfrm.Show()
            glcode.Text = CODDY
            glcode.Refresh()
            Me.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub saleinvoicegrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles saleinvoicegrid.CellEndEdit
        Try
            Dim tott2 As Integer = 0
            Dim tott As Integer = 0
            Dim tott3 As Integer = 0
            For index As Integer = 0 To saleinvoicegrid.RowCount - 1
                If saleinvoicegrid.Rows.Count = 0 Then Exit Sub
                Dim Idx = e.RowIndex

                saleinvoicegrid.Rows(e.RowIndex).Cells(5).Value = Val(saleinvoicegrid.Rows(e.RowIndex).Cells(1).Value) * Val(saleinvoicegrid.Rows(e.RowIndex).Cells(2).Value)
                If saleinvoicegrid.Rows(e.RowIndex).Cells(3).Value > 0 Then
                    saleinvoicegrid.Rows(e.RowIndex).Cells(5).Value = Val(saleinvoicegrid.Rows(e.RowIndex).Cells(1).Value) * Val(saleinvoicegrid.Rows(e.RowIndex).Cells(2).Value)
                End If
                tott += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(5).Value)
                itotal.Text = tott
                tott2 += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(5).Value / 100 * saleinvoicegrid.Rows(index).Cells(3).Value)
                stax.Text = tott2
                tott3 += Convert.ToInt32(saleinvoicegrid.Rows(index).Cells(5).Value / 100 * saleinvoicegrid.Rows(index).Cells(4).Value)
                discount2.Text = tott3
                Dim taxval As Double = Val(itotal.Text) - Val(stax.Text)
                netdue.Text = taxval + Val(discount2.Text)
            Next

            'itotal.Text += Convert.ToInt32(Val(saleinvoicegrid.Rows(e.RowIndex).Cells(5).Value))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub invoiceno_TextChanged(sender As Object, e As EventArgs) Handles invoiceno.TextChanged

    End Sub
    Private Sub saleinvoicegrid_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles saleinvoicegrid.CellLeave
      
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
        'rptrangecode = ""
        'If (Not invoiceno.Text = String.Empty) Then
        '    My.Settings.reportsqlstr = "Prininvoice"
        '    Dim viewreport2 As New viewreport
        '    viewreport2.MdiParent = MDIParent1
        '    rptrangecode = invoiceno.Text
        '    viewreport2.Text = "Print Invoice "
        '    viewreport2.Show()
        'End If

    End Sub

    Private Sub netdue_TextChanged(sender As Object, e As EventArgs) Handles netdue.TextChanged
        AmountInWords(netdue.Text)
    End Sub
End Class