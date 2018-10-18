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
Public Class CustvendSetup

    Private Sub CustvendSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130

        custvendhst.EnableHeadersVisualStyles = False
        custvendhst.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        custvendhst.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        custvendhst.ColumnHeadersHeight = 30
        custvendhst.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        loadstaTEcombo()
        loadlgacombo()
        loadCOUNTRYcombo()
        loadbankcombo()
        loadglcodecombo()
        disablecontrols()
        If custvendswith = "C" Then
            cvv.Text = "Customer"
            '  Searchtool.SelectedItem = -1
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
                typec.Checked = True
                typev.Enabled = False
            Catch ex As Exception
                MDIParent1.statusmsg.Text = "Can not open connection ! "
            End Try

        Else
            typev.Checked = True
            typec.Enabled = False
            cvv.Text = "Vendor"
            '  Searchtool.SelectedItem = -1
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
        End If
        custvendhst.Visible = False
        custvendhst2.Visible = False
    End Sub
    Sub GETCODEE()
        If custvendswith = "C" Then
            cvv.Text = "Customer"
            '  Searchtool.SelectedItem = -1
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
                typec.Checked = True
                typev.Enabled = False
            Catch ex As Exception
                MDIParent1.statusmsg.Text = "Can not open connection ! "
            End Try

        Else
            typev.Checked = True
            typec.Enabled = False
            cvv.Text = "Vendor"
            '  Searchtool.SelectedItem = -1
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
        End If
    End Sub
    Public Sub saverec()
        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            If My.Settings.newrec = True Then
                UpdateRecord()
            End If
            If My.Settings.newrec = False Then
                InsertRecord()
            End If

            Me.Refresh()
            custvendid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            Dim cSQL As String = "DELETE FROM custvendtab WHERE" _
            & " custvendid = '" & Me.custvendid.Text & "'"

            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record of Code: " + Trim(custvendid.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
        '   MessageBox.Show("Update Data instead")
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        Dim index As Integer
        Dim index2 As Integer
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT custvendid,Names,custvendtype,address,lga,dreg,cvtype ,website,email ,spersontel,sperson ,state,country,bankid,scode,bbranch,acctid,accttype,glcode,cbalance,customersince,linvoicedate,linvoicepay,laspdate,lastpamt FROM custvendtab WHERE" _
                & " rtrim(custvendid) = '" & RTrim(custvendid.Text) & "'"

                Cd.CommandType = CommandType.Text  'SELECT custvendid,Names,custvendtype FROM custvendtab order by custvendtype,custvendid
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.Names.Text = RTrim(r(1))
                    If RTrim(r(2)) = "C" Then
                        typec.Checked = True
                    End If
                    If RTrim(r(2)) = "V" Then
                        typev.Checked = True
                    End If
                    If Not r.IsDBNull(3) Then Me.address.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.lga.SelectedValue = RTrim(r(4))
                    If Not r.IsDBNull(5) Then Me.dreg.Value = r(5)
                    If Not r.IsDBNull(6) Then
                        index = cvtype.FindString(RTrim(r(6)))
                        cvtype.SelectedIndex = index
                    End If
                    If Not r.IsDBNull(7) Then Me.website.Text = r(7)
                    If Not r.IsDBNull(8) Then Me.email.Text = r(8)
                    If Not r.IsDBNull(9) Then Me.spersontel.Text = r(9)
                    If Not r.IsDBNull(10) Then Me.sperson.Text = r(10)
                    If Not r.IsDBNull(11) Then Me.state.SelectedValue = RTrim(r(11))
                    If Not r.IsDBNull(12) Then Me.country.SelectedValue = RTrim(r(12))
                    If Not r.IsDBNull(13) Then Me.bankid.SelectedValue = RTrim(r(13))
                    If Not r.IsDBNull(14) Then Me.scode.Text = r(14)
                    If Not r.IsDBNull(15) Then Me.bbranch.Text = r(15)
                    If Not r.IsDBNull(16) Then Me.acctid.Text = r(16)
                    If Not r.IsDBNull(17) Then
                        index2 = accttype.FindString(RTrim(r(17)))
                        accttype.SelectedIndex = index2
                    End If
                    If Not r.IsDBNull(18) Then Me.glcode.SelectedValue = RTrim(r(18))
                    If Not r.IsDBNull(19) Then Me.cbalance.Text = r(19)
                    If Not r.IsDBNull(20) Then customersince.Value = r(20)
                    ' invoicedate,linvoicepay,laspdate,lastpamt
                    'MessageBox.Show("in")
                    If Not r.IsDBNull(21) Then invoicedate.Text = r(21)
                    If Not r.IsDBNull(22) Then linvoicepay.Text = CDec(r(22))
                    If Not r.IsDBNull(23) Then laspdate.Text = r(23)
                    If Not r.IsDBNull(24) Then lastpamt.Text = CDec(r(24))
                    'MessageBox.Show("out")
                    My.Settings.newrec = True
                    enablecontrols()
                    Names.Focus()
                    loadheadhistory()
                    TabControl1.Refresh()
                    Me.Refresh()
                Else
                    My.Settings.newrec = False
                    enablecontrols()
                    Names.Focus()
                    'gethistorygrid()
                End If
                Me.Refresh()
                r.Close()
            End Using
            If typec.Checked Then
                custvendhst.Visible = True
                custvendhst2.Visible = False
            End If
            If typev.Checked Then
                custvendhst.Visible = False
                custvendhst2.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub loadheadhistory()
        If typec.Checked = True Then
            Dim i2 As Integer
            For i2 = i2 To custvendhst.RowCount - 1
                custvendhst.Rows.Clear()
            Next
            Dim gg2 As String = "select tdate,receipt,payment,headcode FROM headtodate where rtrim(headcode) = '" & RTrim(custvendid.Text) & "'"

            Try
                Using ccnn As New SqlConnection(My.Settings.cnnstring)
                    Dim cd As SqlCommand = ccnn.CreateCommand

                    cd.CommandText = gg2
                    cd.CommandType = CommandType.Text
                    ccnn.Open()
                    Dim r As SqlDataReader = cd.ExecuteReader
                    If r.HasRows() Then
                        While r.Read
                            Dim row As Integer = custvendhst.Rows.Add
                            custvendhst.Rows(row).Cells(0).Value = r(0)
                            custvendhst.Rows(row).Cells(1).Value = r(1)
                            custvendhst.Rows(row).Cells(2).Value = r(2)
                        End While
                    End If
                    r.Close()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg.Text = ex.Message
            End Try
            Me.Refresh()
        End If
        If typev.Checked = True Then
            Dim i2 As Integer
            For i2 = i2 To custvendhst2.RowCount - 1
                custvendhst2.Rows.Clear()
            Next
            Dim gg2 As String = "select tdate,receipt,payment,headcode FROM headtodate where rtrim(headcode) = '" & RTrim(custvendid.Text) & "'"

            Try
                Using ccnn As New SqlConnection(My.Settings.cnnstring)
                    Dim cd As SqlCommand = ccnn.CreateCommand

                    cd.CommandText = gg2
                    cd.CommandType = CommandType.Text
                    ccnn.Open()
                    Dim r As SqlDataReader = cd.ExecuteReader
                    If r.HasRows() Then
                        While r.Read
                            Dim row As Integer = custvendhst2.Rows.Add
                            custvendhst2.Rows(row).Cells(0).Value = r(0)
                            custvendhst2.Rows(row).Cells(1).Value = r(1)
                            custvendhst2.Rows(row).Cells(2).Value = r(2)
                        End While
                    End If
                    r.Close()
                    Me.Refresh()
                End Using
            Catch ex As Exception
                MDIParent1.statusmsg.Text = ex.Message
            End Try
            Me.Refresh()
        End If


    End Sub

    Public Sub InsertRecord()

        Try
            Dim cSQL2 As String = "INSERT INTO custvendtab(custvendid,Names,custvendtype,address,lga,dreg,cvtype ,website,email ,spersontel,sperson ,state,country,bankid,scode,bbranch,acctid,accttype,glcode,cbalance,customersince) VALUES('" & custvendid.Text.Trim & "','" & Names.Text.Trim & "','" & IIf(typec.Checked = True, "C", "V") & "','" & address.Text.Trim & "','" & RTrim(lga.SelectedValue) & "','" & Format(dreg.Value, "yyyy-MM-dd") & "','" & RTrim(cvtype.Text) & "','" & website.Text & "','" & email.Text & "','" & spersontel.Text & "','" & sperson.Text.Trim & "','" & RTrim(state.SelectedValue) & "','" & RTrim(country.SelectedValue) & "','" & RTrim(bankid.SelectedValue) & "','" & scode.Text & "','" & bbranch.Text & "','" & acctid.Text & "','" & RTrim(accttype.Text) & "','" & RTrim(glcode.SelectedValue) & "','" & cbalance.Text & "','" & Format(customersince.Value, "yyyy-MM-dd") & "');"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL2
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Insert new record for code : " + RTrim(custvendid.Text) + " In " + Me.Text)
                MessageBox.Show("Record Save Sucessfully")
                '  staffid.Text = ""
                'clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        clearrec()
        GETCODEE()
    End Sub
    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement
        Try
            Dim cSQL3 As String = "UPDATE custvendtab SET Names = '" & Me.Names.Text & _
               "',custvendtype = '" & IIf(typec.Checked = True, "C", "V") & _
          "',address = '" & Me.address.Text & _
             "',lga = '" & RTrim(Me.lga.SelectedValue) & _
           "',dreg = '" & Format(dreg.Value, "yyyy-MM-dd") & _
            "',cvtype = '" & RTrim(cvtype.Text) & _
            "',website = '" & Me.website.Text & _
            "',email = '" & Me.email.Text & _
            "',spersontel = '" & spersontel.Text & _
           "' ,sperson = '" & Me.sperson.Text & _
           "' ,state = '" & RTrim(state.SelectedValue) & _
           "' ,country = '" & Me.country.Text & _
            "',bankid = '" & RTrim(bankid.SelectedValue) & _
            "',scode = '" & Me.scode.Text & _
            "',bbranch = '" & bbranch.Text & _
            "',acctid = '" & acctid.Text & _
            "',accttype = '" & RTrim(accttype.Text) & _
            "',glcode = '" & RTrim(Me.glcode.SelectedValue) & _
            "',cbalance = '" & cbalance.Text & _
           "',customersince = '" & Format(customersince.Value, "yyyy-MM-dd") & "' where  custvendid = '" & custvendid.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL3
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Updated Sucessfully")
                saveaudit("Update record for Code: " + Trim(custvendid.Text) + " In " + Me.Text)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        clearrec()
    End Sub
   
    
    Private Sub typec_CheckedChanged(sender As Object, e As EventArgs) Handles typec.CheckedChanged
        cvv.Text = "Customer"
        Searchtool.SelectedItem = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
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
    End Sub
    Private Sub typev_CheckedChanged(sender As Object, e As EventArgs) Handles typev.CheckedChanged
        cvv.Text = "Vendor"
        Searchtool.SelectedItem = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        ' connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
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
    End Sub
    Public Sub clearrec()
        custvendid.Focus()
        Me.Names.Text = ""
        Me.address.Text = ""
        Me.lga.SelectedIndex = -1
        Me.dreg.Value = Now
        cvtype.SelectedIndex = -1
        Me.website.Text = ""
        Me.email.Text = ""
        Me.spersontel.Text = ""
        Me.sperson.Text = ""
        Me.state.SelectedIndex = -1
        Me.country.SelectedIndex = -1
        Me.bankid.SelectedIndex = -1
        Me.scode.Text = ""
        Me.bbranch.Text = ""
        accttype.SelectedIndex = -1
        Me.glcode.SelectedIndex = -1
        Me.cbalance.Text = 0.0
        Me.customersince.Value = Now
    End Sub
    Sub enablecontrols()
        Me.Names.Enabled = True
        Me.address.Enabled = True
        Me.lga.Enabled = True
        Me.dreg.Enabled = True
        cvtype.Enabled = True
        Me.website.Enabled = True
        Me.email.Enabled = True
        Me.spersontel.Enabled = True
        Me.sperson.Enabled = True
        Me.state.Enabled = True
        Me.country.Enabled = True
        Me.bankid.Enabled = True
        Me.scode.Enabled = True
        Me.bbranch.Enabled = True
        accttype.Enabled = True
        Me.glcode.Enabled = True
        Me.cbalance.Enabled = True
        Me.customersince.Enabled = True
    End Sub

    Sub disablecontrols()
        Me.Names.Enabled = False
        Me.address.Enabled = False
        Me.lga.Enabled = False
        Me.dreg.Enabled = False
        cvtype.Enabled = False
        Me.website.Enabled = False
        Me.email.Enabled = False
        Me.spersontel.Enabled = False
        Me.sperson.Enabled = False
        Me.state.Enabled = False
        Me.country.Enabled = False
        Me.bankid.Enabled = False
        Me.scode.Enabled = False
        Me.bbranch.Enabled = False
        accttype.Enabled = False
        Me.glcode.Enabled = False
        Me.cbalance.Enabled = False
        Me.customersince.Enabled = False
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenEmail(email.Text)
    End Sub

    Public Function OpenEmail(ByVal EmailAddress As String, _
  Optional ByVal Subject As String = "", _
  Optional ByVal Body As String = "") _
  As Boolean

        Dim bAns As Boolean = True
        Dim sParams As String
        sParams = EmailAddress
        If LCase(Strings.Left(sParams, 7)) <> "mailto:" Then _
            sParams = "mailto:" & sParams

        If Subject <> "" Then sParams = sParams & _
              "?subject=" & Subject

        If Body <> "" Then
            sParams = sParams & IIf(Subject = "", "?", "&")
            sParams = sParams & "body=" & Body
        End If
        Try
            System.Diagnostics.Process.Start(sParams)
        Catch
            bAns = False
        End Try

        Return bAns

    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Process.Start(website.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub loadstaTEcombo()
        Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F1" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            state.DataSource = ds.Tables(0)
            state.ValueMember = "code1"
            state.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB STATE ! "
        End Try
    End Sub
    Sub loadlgacombo()
        '  Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F2" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            lga.DataSource = ds.Tables(0)
            lga.ValueMember = "code1"
            lga.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB LGA ! "
        End Try
    End Sub
    Sub loadCOUNTRYcombo()

        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F11" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            country.DataSource = ds.Tables(0)
            country.ValueMember = "code1"
            country.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB COUNTRY ! "
        End Try
    End Sub
    Sub loadbankcombo()
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
            bankid.DataSource = ds.Tables(0)
            bankid.ValueMember = "bankcode"
            bankid.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Sub loadglcodecombo()
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
            glcode.DataSource = ds.Tables(0)
            glcode.ValueMember = "accode"
            glcode.DisplayMember = "descriptn"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection ! "
        End Try
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clearrec()
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

    Private Sub custvendid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles custvendid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not custvendid.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
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

    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
       
    End Sub

    Private Sub custvendid_TextChanged(sender As Object, e As EventArgs) Handles custvendid.TextChanged

    End Sub

    Private Sub bankid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles bankid.SelectedIndexChanged

    End Sub

    Private Sub Searchtool_Validating(sender As Object, e As CancelEventArgs) Handles Searchtool.Validating
        Try
            custvendid.Text = Searchtool.SelectedValue.ToString
            Names.Text = Searchtool.Text
            custvendid.Focus()
            'LoadRecord()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class