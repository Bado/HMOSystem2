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
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Office.Interop
Public Class jobappraiser
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
 
    Private Sub jobappraiser_Load(sender As Object, e As EventArgs) Handles Me.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        'hcpid,Names,dregister,active,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        'IH = Me.Height
        itemgrid.EnableHeadersVisualStyles = False
        itemgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        itemgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        itemgrid.ColumnHeadersHeight = 30
        itemgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        rewardgrid.EnableHeadersVisualStyles = False
        rewardgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        rewardgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        rewardgrid.ColumnHeadersHeight = 30
        rewardgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        signgrid.EnableHeadersVisualStyles = False
        signgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        signgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        signgrid.ColumnHeadersHeight = 30
        signgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        clearrec()

        Try
            Dim col As New CalendarColumn()
            col.DataPropertyName = "ddate"
            col.HeaderText = "Date"
            Dim loc As Integer =
            signgrid.Columns.IndexOf(signgrid.Columns("ddate"))
            signgrid.Columns.RemoveAt(loc)
            signgrid.Columns.Insert(loc, col)

        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try
        BindGrid()
        loadstaffsearchcombo()
        loadPOSITIONcombo()
        loadgrid()
        disablecontrols()

    End Sub
    Public Sub saverec()
        Dim result = MsgBox("Continue Saving.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then
            If My.Settings.newrec = True Then
                UpdategencodeRecord()
                InsertRecord()
            End If
            If My.Settings.newrec = False Then
                InsertRecord()
            End If

            Me.Refresh()
            staffid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM appraisaltab WHERE" _
            & " staffid = '" & Me.staffid.Text & "' and appref = '" & Me.appref.Text & "'"
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
            End Try


            Dim cSQL2 As String = "DELETE FROM evalsignatory WHERE" _
                        & " staffid = '" & Me.staffid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for Evaluation Ref Code: " + Trim(appref.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'

        clearrec()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                'SELECT staffid,names,appref,tdate,appdesc,evadetail,maxmark,mark,respond,totalmark,percentscore,rating,staffagree,staffcomment,sdateresp FROM appraisaltab
                Cd.CommandText = " Select staffid,names,appref,tdate,totalmark,percentscore,rating,staffagree,staffcomment,sdateresp FROM appraisaltab WHERE" _
                & " staffid = '" & Me.staffid.Text & "' and appref = '" & Me.appref.Text & "'"

                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.Names.Text = RTrim(r(1))
                    If Not r.IsDBNull(3) Then Me.tdate.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.totalmark.Text = r(4)
                    If Not r.IsDBNull(5) Then Me.percentscore.Text = r(5)
                    If Not r.IsDBNull(6) Then Me.rating.Text = r(6)
                    If Not r.IsDBNull(7) Then
                        If r(7) = "A" Then
                            staffagreea.Checked = True
                        End If
                        If r(7) = "D" Then
                            staffagreed.Checked = True
                        End If
                    End If
                    If Not r.IsDBNull(8) Then Me.staffcomment.Text = r(8)
                    Me.sdateresp.Value = r(9)
                    retrievitemgrid()
                    My.Settings.newrec = True
                    enablecontrols()
                    Me.Refresh()
                    TabControl1.Refresh()
                Else
                    My.Settings.newrec = False
                    enablecontrols()

                End If
                Me.Refresh()
                '  MsgBox(addnew)
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub retrievitemgrid()
        Dim i2 As Integer
        For i2 = i2 To itemgrid.RowCount - 1
            itemgrid.Rows.Clear()
        Next
        Dim gg2 As String = "select appdesc,evadetail,maxmark,mark,respond FROM evaappraisdetail where staffid = '" & Me.staffid.Text & "' and appref = '" & Me.appref.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = itemgrid.Rows.Add
                        itemgrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        itemgrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        itemgrid.Rows(row).Cells(2).Value = RTrim(r(2))
                        itemgrid.Rows(row).Cells(3).Value = RTrim(r(3))
                        itemgrid.Rows(row).Cells(4).Value = RTrim(r(4))
                    End While
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()

        Dim i23 As Integer
        For i23 = i23 To signgrid.RowCount - 1
            signgrid.Rows.Clear()
        Next
        Dim gg23 As String = "select staffid,position,tdate,appref FROM evalsignatory where staffid = '" & Me.staffid.Text & "' and appref = '" & Me.appref.Text & "'"
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand
                cd.CommandText = gg23
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = signgrid.Rows.Add
                        signgrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        signgrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        signgrid.Rows(row).Cells(2).Value = r(2)
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
    Sub delrec2()
        cSQL = "DELETE FROM appraisaltab WHERE" _
           & " staffid = '" & Me.staffid.Text & "' and appref = '" & Me.appref.Text & "'"
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
        End Try

        Dim cSQL2 As String = "DELETE FROM evalsignatory WHERE" _
                    & " staffid = '" & Me.staffid.Text & "'"
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
    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database                                                                                                                                                                                                                             dregister,active,NHIS,                                                      LGA,state,country,pmethod,tel,                                                                                                                  email,website,address,                                                                                              glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan
        If (Not rating.Text = String.Empty) Then
            MessageBox.Show(Format(tdate.Value, "yyyy-MM-dd"))
        delrec2()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                    Cd3.CommandText = "INSERT INTO appraisaltab(staffid,names,appref,tdate,totalmark,percentscore,rating,staffagree,staffcomment,sdateresp)" & _
                                              "VALUES('" & staffid.Text & "','" & Names.Text & "','" & appref.Text & "','" & Format(tdate.Value, "yyyy-MM-dd") & "','" & totalmark.Text & "','" & percentscore.Text & "','" & rating.Text & "','" & IIf(staffagreea.Checked = True, "A", "D") & "','" & staffcomment.Text & "','" & Format(sdateresp.Value, "yyyy-MM-dd") & "')"
                CCNN.Open()
                Cd3.ExecuteNonQuery()
                CCNN.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in appraisal1 Table")
        End Try

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If itemgrid.RowCount > 0 Then
                    For i = 0 To itemgrid.RowCount - 1 '   '
                        Cd3.CommandText = "INSERT INTO evaappraisdetail(staffid,appref,appdesc,evadetail,maxmark,mark,respond)" & _
                                          "VALUES('" & staffid.Text & "','" & appref.Text & "','" & itemgrid.Rows(i).Cells(0).Value & "','" & itemgrid.Rows(i).Cells(1).Value & "','" & Val(itemgrid.Rows(i).Cells(2).Value) & "','" & Val(itemgrid.Rows(i).Cells(3).Value) & "','" & itemgrid.Rows(i).Cells(4).Value & "')"
                        CCNN.Open()
                        Cd3.ExecuteNonQuery()
                        CCNN.Close()
                    Next
                End If
         
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in appraisal1 Table")
        End Try


        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i2 As Integer
                If signgrid.RowCount > 0 Then
                    For i2 = 0 To signgrid.RowCount - 1
                        If (Not signgrid.Rows(i2).Cells(0).Value = String.Empty) Then
                            Cd3.CommandText = "INSERT INTO evalsignatory(staffid,position,tdate,appref)" & _
                                              "VALUES('" & signgrid.Rows(i2).Cells(0).Value & "','" & signgrid.Rows(i2).Cells(1).Value & "','" & signgrid.Rows(i2).Cells(2).Value & "','" & appref.Text & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                        End If
                    Next
                End If
                saveaudit("Save/Update Evaluation record for ref no: " + Trim(appref.Text) + " In " + Me.Text)
                Me.Refresh()
                MessageBox.Show("Record Saved Successfully")
                clearrec()
                Me.Refresh()
            End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Occurs in appraisal2 Table")
            End Try
        Else
            MessageBox.Show("Collate Appraisal before saving")
        End If
    End Sub
    Sub loadgrid()
        Dim i2 As Integer
        For i2 = i2 To itemgrid.RowCount - 1
            itemgrid.Rows.Clear()
        Next
        Dim gg2 As String = "select appdesc,evadetail,maxmark from evalitem "

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        Dim row As Integer = itemgrid.Rows.Add
                        itemgrid.Rows(row).Cells(0).Value = RTrim(r(0))
                        itemgrid.Rows(row).Cells(1).Value = RTrim(r(1))
                        itemgrid.Rows(row).Cells(2).Value = RTrim(r(2))
                      
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
    Sub loadstaffsearchcombo()
        'Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select a.staffid,rtrim(a.surname) + ' ' + rtrim(a.firstname) + ' ' + rtrim(a.othernames) as names from stafftab a,useracct b where a.staffid=b.userid and b.appraise = '" & True & "' and a.staffid != '" & "ADMIN" & "' order by a.staffid"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Staffidv.DataSource = ds.Tables(0)
            Staffidv.ValueMember = "staffid"
            Staffidv.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadPOSITIONcombo()
        '   Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select staffid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F5" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            pos.DataSource = ds.Tables(0)
            pos.ValueMember = "code1"
            pos.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to CODESTAB Position ! "
        End Try
    End Sub
    Sub BindGrid()
        Try
            Dim gstring1 As String = "Select code,desc1,begin1,end1 from reward order by code"
            Dim constring As String = My.Settings.cnnstring
            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand(gstring1, con)
                    cmd.CommandType = CommandType.Text
                    Using sda As New SqlDataAdapter(cmd)
                        Using ds As New DataSet()
                            sda.Fill(ds)
                            rewardgrid.DataSource = ds.Tables(0)
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Reward Table")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,dengage from stafftab where staffid != '" & "ADMIN" & "' and suspended = '" & False & "' order by staffid"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            '  sfrm.Show()
            staffid.Text = CODDY
            staffid.Refresh()
            Me.Refresh()
            Names.Text = DESCC
            If (Not staffid.Text = String.Empty) Then
                staffid.Refresh()
                '  LoadRecord()
                staffid.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            gsql = ""
            DESCC = ""
            OPTRR = publicvarmodule.OPT
            gsql = "SELECT distinct appref,names,tdate FROM appraisaltab order by appref,tdate"
            'gsql = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from stafftab where staffid != '" & "ADMIN" & "' order by staffid"
            Dim sfrm As New searchfrm
            ' sfrm.MdiParent = MDIParent1
            sfrm.ShowDialog()
            '  sfrm.Show()

            appref.Refresh()
            Me.Refresh()

            If (Not staffid.Text = String.Empty) Then
                appref.Refresh()
                appref.Text = CODDY
                LoadRecord()
                appref.Refresh()
            Else
                MessageBox.Show("Select Staffid to continue")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim tott2 As Double = 0.0
            Dim tott As Double = 0.0
            Dim tott3 As Double = 0.0
            For index As Integer = 0 To itemgrid.RowCount - 1
                If itemgrid.Rows.Count = 0 Then Exit Sub
                tott += Convert.ToDouble(itemgrid.Rows(index).Cells(3).Value)
                totalmark.Text = tott
                tott2 += Convert.ToDouble(itemgrid.Rows(index).Cells(2).Value)
                percentscore.Text = totalmark.Text / tott2 * 100
            Next
            getreward()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub getreward()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = "SELECT Code, Desc1, Begin1, End1 FROM Reward WHERE" _
                & " Begin1 <= '" & percentscore.Text & "' and End1 >= '" & percentscore.Text & "'"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    Me.rating.Text = r(1)
                End If
                Me.Refresh()
                r.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub clearrec()
        percentscore.Text = 0.0
        totalmark.Text = 0.0
        ' Names.Text = ""
        ' appref.Text = ""
        tdate.Text = Now
        rating.Text = ""
        sdateresp.Text = Now
        staffcomment.Text = ""
        loadgrid()
        Dim i2 As Integer
        For i2 = i2 To signgrid.RowCount - 1
            signgrid.Rows.Clear()
        Next
    End Sub
    Sub enablecontrols()
        percentscore.Enabled = True
        totalmark.Enabled = True
        Names.Enabled = True
        ' appref.Enabled = True
        tdate.Enabled = True
        rating.Enabled = True
        sdateresp.Enabled = True
        staffcomment.Enabled = True
    End Sub
    Sub disablecontrols()
        percentscore.Enabled = False
        totalmark.Enabled = False
        Names.Enabled = False
        tdate.Enabled = False
        rating.Enabled = False
        sdateresp.Enabled = False
        staffcomment.Enabled = False
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        percentscore.Text = 0.0
        totalmark.Text = 0.0
        staffid.Text = ""
        Names.Text = ""
        appref.Text = ""
        tdate.Text = Now
        rating.Text = ""
        sdateresp.Text = Now
        staffcomment.Text = ""
        loadgrid()
        Dim i2 As Integer
        For i2 = i2 To signgrid.RowCount - 1
            signgrid.Rows.Clear()
        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        delrec()
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
    Private Sub appref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles appref.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not appref.Text = String.Empty) And (Not staffid.Text = String.Empty) Then
                LoadRecord()
                Names.Focus()
            End If
        End If
        'appraisaltab(staffid,names,appref
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Public Sub UpdategencodeRecord() '****This procedures,updates,CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        Dim apprefvar As Integer = Str(Val(LTrim(appref.Text.Trim)) + 1)
        Try
            Dim cSQL As String = "UPDATE digitsettings SET appraisalref = '" & apprefvar & "'"
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
   
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'appraisalref
        Dim gg2 As String = "select companyid,appraisalref from digitsettings"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    r.Read()
                    appref.Text = RTrim(r(1)).Trim
                    LoadRecord()
                End If
                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        Me.Refresh()
    End Sub

    Private Sub itemgrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles itemgrid.CellContentClick

    End Sub

    Private Sub staffid_TextChanged(sender As Object, e As EventArgs) Handles staffid.TextChanged

    End Sub

    Private Sub itemgrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles itemgrid.CellEndEdit
        Try
            Dim tott2 As Double = 0.0
            Dim tott As Double = 0.0
            Dim tott3 As Double = 0.0
            For index As Integer = 0 To itemgrid.RowCount - 1
                If itemgrid.Rows.Count = 0 Then Exit Sub
                If itemgrid.Rows(index).Cells(3).Value > itemgrid.Rows(index).Cells(2).Value Then
                    MessageBox.Show("Mark obtain cannot be greater than maximum mark")
                End If
       
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class