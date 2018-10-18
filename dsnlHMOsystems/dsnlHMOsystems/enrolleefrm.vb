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
Imports System.IO

Public Class enrolleefrm
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Public inc As Integer
    Public MaxRows As Integer
    Public ugmfeesvar As Integer
    ''Dim con As SqlConnection = My.Settings.cnnstring 'New MySqlConnection("data source=localhost;database=students;user id=root;password=root")
    'Dim con As New SqlConnection(My.Settings.cnnstring)
    'Dim ds As DataSet = New DataSet
    'Dim dataadapter As New SqlDataAdapter("select * from users", con)
    'Dim cmd As MySqlCommand = New MySqlCommand()
    'Dim dv As DataView
    'Dim cm As CurrencyManager
    'Dim datareader As MySqlDataReader
    ''Private dtt As New enrolleetabset()
    Private Sub enrolleefrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        authorisgrid.EnableHeadersVisualStyles = False
        authorisgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        authorisgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        authorisgrid.ColumnHeadersHeight = 30
        authorisgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        familygrid.EnableHeadersVisualStyles = False
        familygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        familygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        familygrid.ColumnHeadersHeight = 30
        familygrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing

        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = "SELECT ugmfees FROM digitsettings"
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    ugmfeesvar = r(0)
                    Me.Refresh()
                    r.Close()
                End If
            End Using
            '   MessageBox.Show(plink)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        'Try
        '    Dim col2 As New CalendarColumn()
        '    col2.DataPropertyName = "dofb"
        '    col2.HeaderText = "Date_of_Birth"
        '    Dim loc2 As Integer =
        '    familygrid.Columns.IndexOf(familygrid.Columns("dofb"))
        '    familygrid.Columns.RemoveAt(loc2)
        '    familygrid.Columns.Insert(loc2, col2)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        disablecontrols()
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
        disablecontrols()
        loadenrolsearchcombo()
        loadhcpsearchcombo()
        loadpnsearchcombo()
        loadlgasearchcombo()
        loadhcptabsearchcombo()
        OGALOADCOMBO()

        Dim connetionString2 As String = Nothing
        Dim connection2 As SqlConnection
        Dim command2 As SqlCommand
        Dim adapter2 As New SqlDataAdapter()
        Dim ds2 As New DataSet()
        Dim ii As Integer = 0
        Dim sql2 As String = Nothing
        connetionString2 = My.Settings.cnnstring
        'connetionString = "Data Source=BADO-PC\SQLEXPRESS;Initial Catalog=dsnloemarker;Integrated Security=True"
        sql2 = "select code1,descr from CODESTAB where option1 = '" & "F12" & "'"
        connection2 = New SqlConnection(connetionString2)
        Try
            connection2.Open()
            command2 = New SqlCommand(sql2, connection2)
            adapter2.SelectCommand = command2
            adapter2.Fill(ds2)
            adapter2.Dispose()
            command2.Dispose()
            connection2.Close()
            sectortype.DataSource = ds2.Tables(0)
            sectortype.ValueMember = "code1"
            sectortype.DisplayMember = "descr"

        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection sectortype ! "
        End Try
        clearrec()
        disablecontrols()
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
            enrolleeid.Focus() '***Reset the default contol focus as 
            If result = vbNo Then
                Me.Close()
            End If
        End If
    End Sub
    Public Sub delrec()
        Dim result = MsgBox("Continue Deleting.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM enrolleetab WHERE" _
            & " enrolleeid = '" & Me.enrolleeid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    saveaudit("Delete record for code: " + Trim(enrolleeid.Text) + " In " + Me.Text)
                    '  MessageBox.Show("Record Deleted Sucessfully")
                    clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try


            Dim cSQL2 As String = "DELETE FROM Familyinfo WHERE" _
            & " enrolleeid = '" & Me.enrolleeid.Text & "'"
            Try
                Using CCNN As New SqlConnection(My.Settings.cnnstring)
                    Dim Cd As SqlCommand = CCNN.CreateCommand
                    Cd.CommandType = CommandType.Text
                    Cd.CommandText = cSQL2
                    CCNN.Open()
                    Cd.ExecuteNonQuery()
                    '   saveaudit("Delete record for code: " + Trim(enrolleeid.Text) + " In " + Me.Text)
                    MessageBox.Show("Record Deleted Sucessfully")
                    'clearrec()
                    Me.Refresh()
                End Using
            Catch ex As Exception
            End Try
        End If
        '   MessageBox.Show("Update Data instead")
    End Sub
    Public Sub LoadRecord() '***This procedures handles the loading of a record from the Base  and option1='" & F5 & "'
        clearrec()
        ' enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,
        Dim index As Integer

        'Try
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            Dim Cd As SqlCommand = CCNN.CreateCommand

            Cd.CommandText = " Select enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,sdate,edate,active,nationalid,NHIS,ogaid,ogaloc,ppicture,spicture,childpix1,childpix2,childpix3,childpix4,otherillness,illness1,illness2,illness3,illness4,illness5,illness6,illness7,illness8,illness9,illness10,illness11,illness12,illness13,illness14,illness15,illness16,illness17 ,illness18,illness19,illness20,hcpid,hcpname,hcpaddress,hcplga,sectortype,hplan,pnetwork,ugplan,ugmfees,ugyfees,ugstodate,ugbalance,drelated,extra,lpay FROM enrolleetab WHERE" _
            & " rtrim(enrolleeid) = '" & RTrim(enrolleeid.Text) & "'"

            Cd.CommandType = CommandType.Text

            CCNN.Open()
            Dim r As SqlDataReader = Cd.ExecuteReader
            If r.HasRows = True Then
                r.Read()

                If Not r.IsDBNull(1) Then Me.Surname.Text = RTrim(r(1))
                If Not r.IsDBNull(2) Then Me.Firstname.Text = r(2)
                If Not r.IsDBNull(3) Then Me.othernames.Text = r(3)
                ' If Not r.IsDBNull(6) Then Me.title.Text = r(6)

                If Not r.IsDBNull(6) Then
                    index = title.FindString(RTrim(r(6)))
                    title.SelectedIndex = index
                End If
                If Not r.IsDBNull(4) Then
                    index = sex1.FindString(RTrim(r(4)))
                    sex1.SelectedIndex = index
                End If
                If Not r.IsDBNull(5) Then
                    index = Maritalstatus.FindString(RTrim(r(5)))
                    Maritalstatus.SelectedIndex = index
                End If
                '  If Not r.IsDBNull(5) Then Me.Maritalstatus.Text = r(5)
                If Not r.IsDBNull(7) Then Me.haddress.Text = r(7)
                If Not r.IsDBNull(8) Then Me.age1.Text = r(8)

                If Not r.IsDBNull(9) Then Me.dofb1.Value = r(9)
                If Not r.IsDBNull(10) Then Me.tel.Text = r(10)
                If Not r.IsDBNull(11) Then Me.email.Text = r(11)
                If Not r.IsDBNull(12) Then Me.dregister.Value = r(12)
                'sdate, edate, active, nationalid, NHIS, ogaid, ogaloc, ppicture, spicture, childpix1, childpix2, childpix3, 
                'childpix4, otherillness, illness1, illness2, illness3, illness4, illness5, illness6, illness7, illness8, '
                'illness9, illness10, illness11, illness12, illness13, illness14, illness15, illness16, illness17, illness18,'
                If Not r.IsDBNull(13) Then Me.sdate.Value = r(13)
                If Not r.IsDBNull(14) Then Me.edate.Value = r(14)

                If Not r.IsDBNull(15) Then
                    If r(15) = True Then
                        If Not r.IsDBNull(15) Then Me.active.Checked = True
                    End If
                End If
                If Not r.IsDBNull(16) Then Me.nationalid.Text = r(16)
                If Not r.IsDBNull(17) Then Me.NHIS.Text = r(17)
                ' MessageBox.Show(RTrim(r(18)))
                If Not r.IsDBNull(18) Then Me.ogaid.SelectedValue = RTrim(r(18)) ''
                ogacode.Text = RTrim(r(18))
                If Not r.IsDBNull(19) Then Me.ogaloc.Text = r(19)


                If Not r.IsDBNull(26) Then Me.otherillness.Text = r(26)
                If Not r.IsDBNull(27) Then
                    If r(27) = True Then
                        If Not r.IsDBNull(27) Then Me.illness1.Checked = True
                    End If
                End If
                If Not r.IsDBNull(28) Then
                    If r(28) = True Then
                        If Not r.IsDBNull(28) Then Me.illness2.Checked = True
                    End If
                End If
                If Not r.IsDBNull(29) Then
                    If r(29) = True Then
                        If Not r.IsDBNull(29) Then Me.illness3.Checked = True
                    End If
                End If
                If Not r.IsDBNull(30) Then
                    If r(30) = True Then
                        If Not r.IsDBNull(30) Then Me.illness4.Checked = True
                    End If
                End If
                If Not r.IsDBNull(31) Then
                    If r(31) = True Then
                        If Not r.IsDBNull(31) Then Me.illness5.Checked = True
                    End If
                End If
                If Not r.IsDBNull(32) Then
                    If r(32) = True Then
                        If Not r.IsDBNull(32) Then Me.illness6.Checked = True
                    End If
                End If
                If Not r.IsDBNull(33) Then
                    If r(33) = True Then
                        If Not r.IsDBNull(33) Then Me.illness7.Checked = True
                    End If
                End If
                If Not r.IsDBNull(34) Then
                    If r(34) = True Then
                        If Not r.IsDBNull(34) Then Me.illness8.Checked = True
                    End If
                End If
                If Not r.IsDBNull(35) Then
                    If r(35) = True Then
                        If Not r.IsDBNull(35) Then Me.illness9.Checked = True
                    End If
                End If
                If Not r.IsDBNull(36) Then
                    If r(36) = True Then
                        If Not r.IsDBNull(36) Then Me.illness10.Checked = True
                    End If
                End If
                If Not r.IsDBNull(37) Then
                    If r(37) = True Then
                        If Not r.IsDBNull(37) Then Me.illness11.Checked = True
                    End If
                End If
                If Not r.IsDBNull(38) Then
                    If r(38) = True Then
                        If Not r.IsDBNull(38) Then Me.illness12.Checked = True
                    End If
                End If
                If Not r.IsDBNull(39) Then
                    If r(39) = True Then
                        If Not r.IsDBNull(39) Then Me.illness13.Checked = True
                    End If
                End If
                If Not r.IsDBNull(40) Then
                    If r(40) = True Then
                        If Not r.IsDBNull(40) Then Me.illness14.Checked = True
                    End If
                End If
                If Not r.IsDBNull(41) Then
                    If r(41) = True Then
                        If Not r.IsDBNull(41) Then Me.illness15.Checked = True
                    End If
                End If
                If Not r.IsDBNull(42) Then
                    If r(42) = True Then
                        If Not r.IsDBNull(42) Then Me.illness16.Checked = True
                    End If
                End If
                If Not r.IsDBNull(43) Then
                    If r(43) = True Then
                        If Not r.IsDBNull(43) Then Me.illness17.Checked = True
                    End If
                End If
                If Not r.IsDBNull(44) Then
                    If r(44) = True Then
                        If Not r.IsDBNull(44) Then Me.illness18.Checked = True
                    End If
                End If
                If Not r.IsDBNull(45) Then
                    If r(45) = True Then
                        If Not r.IsDBNull(45) Then Me.illness19.Checked = True
                    End If
                End If
                If Not r.IsDBNull(46) Then
                    If r(46) = True Then
                        If Not r.IsDBNull(46) Then Me.illness20.Checked = True
                    End If
                End If

                If Not r.IsDBNull(47) Then Me.hcpid.SelectedValue = r(47)
                hcpcode.Text = r(47)
                If Not r.IsDBNull(48) Then Me.hcpname.Text = r(48)
                If Not r.IsDBNull(49) Then Me.hcpaddress.Text = r(49)
                If Not r.IsDBNull(50) Then Me.hcplga.SelectedValue = r(50)
                hcplga.Refresh()
                'If Not r.IsDBNull(50) Then
                '    index = hcplga.FindString(RTrim(r(50)))
                '    hcplga.SelectedIndex = index
                'End If
                If Not r.IsDBNull(51) Then Me.sectortype.SelectedValue = r(51)
                If Not r.IsDBNull(52) Then Me.hplan.SelectedValue = RTrim(r(52))
                plancode.Text = RTrim(r(52))
                If Not r.IsDBNull(53) Then Me.pnetwork.SelectedValue = r(53)
                If Not r.IsDBNull(54) Then
                    If RTrim(r(54)) = "ugplan1" Then ugplan1.Checked = True
                    If RTrim(r(54)) = "ugplan2" Then ugplan2.Checked = True
                End If
                If Not r.IsDBNull(55) Then Me.ugmfees.Text = r(55)
                If Not r.IsDBNull(56) Then Me.ugyfees.Text = r(56)
                If Not r.IsDBNull(57) Then Me.ugstodate.Text = r(57)
                If Not r.IsDBNull(58) Then Me.ugbalance.Text = r(58)
                If Not r.IsDBNull(59) Then Me.drelated.Text = r(59)
                If Not r.IsDBNull(60) Then Me.extra.Text = r(60)
                If Not r.IsDBNull(61) Then Me.lpay.Text = r(61)
                My.Settings.newrec = True
                enablecontrols()
                Surname.Focus()
                loadcodegenhst()
                'loadpix()
                loadpictures()
                Me.Refresh()
                TabControl1.Refresh()
                retrievnewfamily()
                Surname.Focus()
            Else
                My.Settings.newrec = False
                enablecontrols()
                Surname.Focus()
                NEWpopupfamilyrec()
            End If
            Me.Refresh()
            '  MsgBox(addnew)
            enrolleeid.Enabled = False
            r.Close()
        End Using

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try


    End Sub
    Sub updatepopupfamilyrec()
        'ftype,names,alterHCP,dofb,age,sex,Enrolleeid

    End Sub
    Sub NEWpopupfamilyrec()
        For i As Integer = 0 To 0
            'familygrid.Rows.Add("Spouse")
            'familygrid.Rows.Add("Child (1)")
            'familygrid.Rows.Add("Child (2)")
            'familygrid.Rows.Add("Child (3)")
            'familygrid.Rows.Add("Child (4)")
            familygrid.Rows.Add("Spouse", "", "", " /  /  ", 0, "", "10")
            familygrid.Rows.Add("Child1", "", "", " /  /  ", 0, "", "20")
            familygrid.Rows.Add("Child2", "", "", " /  /  ", 0, "", "30")
            familygrid.Rows.Add("Child3", "", "", " /  /  ", 0, "", "40")
            familygrid.Rows.Add("Child4", "", "", " /  /  ", 0, "", "50")
            familygrid.Rows.Add("Child5", "", "", " /  /  ", 0, "", "60")
        Next
    End Sub
    Public Sub InsertRecord()  'Subroutine to insert a record into the database 
        Dim ugplanvar As String
        If ugplan1.Checked = True Then
            ugplanvar = "ugplan1"
        End If
        If ugplan2.Checked = True Then
            ugplanvar = "ugplan2"
        End If
        Dim spcss As String = My.Settings.imgaepath + "\" + "spics.jpg"
        MessageBox.Show(Format(dofb1.Value, "yyyy-MM-dd")) '"dd/MM/yyyy"
        Try
            cSQL = "INSERT INTO enrolleetab(enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,sdate,edate,active,nationalid,NHIS,ogaid,ogaloc,otherillness,hcpid,hcpname,hcpaddress,hcplga,sectortype,hplan,pnetwork,ugplan,ugmfees,ugyfees,ugstodate,ugbalance,drelated,extra,lpay) VALUES('" & enrolleeid.Text.Trim & "','" & Surname.Text.Trim & "','" & Firstname.Text.Trim & "','" & othernames.Text.Trim & "','" & RTrim(sex1.Text) & "','" & RTrim(Maritalstatus.Text) & "','" & RTrim(title.Text) & "','" & haddress.Text & "','" & age1.Text & "','" & Format(dofb1.Value, "yyyy-MM-dd") & "','" & tel.Text.Trim & "','" & email.Text & "','" & Format(dregister.Value, "yyyy-MM-dd") & "','" & Format(sdate.Value, "yyyy-MM-dd") & "','" & Format(edate.Value, "yyyy-MM-dd") & "','" & active.Checked & "','" & nationalid.Text.Trim & "','" & NHIS.Text & "','" & RTrim(ogaid.SelectedValue) & "','" & ogaloc.Text & "','" & otherillness.Text.Trim & "','" & RTrim(hcpid.SelectedValue) & "','" & hcpname.Text & "','" & hcpaddress.Text & "','" & hcplga.SelectedValue & "','" & sectortype.SelectedValue & "','" & plancode.Text & "','" & pnetwork.SelectedValue & "','" & IIf(ugplan1.Checked = True, "ugplan1", "ugplan2") & "','" & ugmfees.Text & "','" & ugyfees.Text & "','" & ugstodate.Text & "','" & ugbalance.Text & "','" & Val(drelated.Text) & "','" & Val(extra.Text) & "','" & Val(lpay.Text) & "');"

            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                saveaudit("Insert new record for Enrollee code: " + RTrim(enrolleeid.Text) + " In " + Me.Text)
                MessageBox.Show("Record Save Sucessfully")
                '  enrolleeid.Text = ""
                'clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        saveillment()
        savenewfamily()
        updateimage()
        clearrec()
        loadenrolsearchcombo()
    End Sub
    Sub updateimage()
        '    MessageBox.Show("Saving image")
        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE enrolleetab SET ppicture = @ppicture3 where enrolleeid = '" & enrolleeid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                ppicture1.Image.Save(ms, ppicture1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@ppicture3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '   MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE enrolleetab SET spicture = @spicture3 where enrolleeid = '" & enrolleeid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                spicture1.Image.Save(ms, spicture1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@spicture3", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '  MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE enrolleetab SET childpix1 = @childpix13 where enrolleeid = '" & enrolleeid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                childpix1p.Image.Save(ms, childpix1p.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@childpix13", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '  MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)
                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE enrolleetab SET childpix2 = @childpix23 where enrolleeid = '" & enrolleeid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                childpix2p.Image.Save(ms, childpix2p.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@childpix23", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                ' MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE enrolleetab SET childpix3 = @childpix33 where enrolleeid = '" & enrolleeid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                childpix3p.Image.Save(ms, childpix3p.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@childpix33", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '   MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using con As New SqlConnection(My.Settings.cnnstring)

                con.Open()
                'Dim sql As String = "INSERT INTO student VALUES(@rollno,@name,@photo)"
                Dim sql As String = "UPDATE enrolleetab SET childpix4 = @childpix43 where enrolleeid = '" & enrolleeid.Text & "'"

                Dim cmd As New SqlCommand(sql, con)
                Dim ms As New MemoryStream()
                childpix4p.Image.Save(ms, childpix4p.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SqlParameter("@childpix43", SqlDbType.Image)
                p.Value = data
                cmd.Parameters.Add(p)
                cmd.ExecuteNonQuery()
                '  MessageBox.Show("record has been saved", "Save", MessageBoxButtons.OK)
                con.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

    End Sub
    Sub saveillment()
        MessageBox.Show(Format(dofb1.Value, "yyyy-MM-dd"))
        Try
            Dim cSQL As String = "UPDATE enrolleetab SET surname = '" & Me.Surname.Text & _
           "' ,illness1 = '" & illness1.Checked & _
           "' ,illness2 = '" & illness2.Checked & _
           "' ,illness3 = '" & illness3.Checked & _
           "' ,illness4 = '" & illness4.Checked & _
           "',illness5 = '" & illness5.Checked & _
          "' ,illness6 = '" & illness6.Checked & _
          "' ,illness7 = '" & illness7.Checked & _
          "' ,illness8 = '" & illness8.Checked & _
           "',illness9 = '" & illness9.Checked & _
           "',illness10 = '" & illness10.Checked & _
          "' ,illness11 = '" & illness11.Checked & _
           "',illness12 = '" & illness12.Checked & _
           "',illness13 = '" & illness13.Checked & _
           "',illness14 = '" & illness14.Checked & _
           "' ,illness15 = '" & illness15.Checked & _
          "' ,illness16 = '" & illness16.Checked & _
          "' ,illness17 = '" & illness17.Checked & _
          "',illness18 = '" & illness18.Checked & _
           "',illness19 = '" & illness19.Checked & _
            "',illness20 = '" & illness20.Checked & _
              "',ugbalance = '" & ugbalance.Text & "' where  enrolleeid = '" & enrolleeid.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                '  enrolleeid.Text = "" Text
                ' clearrec()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub UpdateRecord() '****This procedures updates  CODE1,company,address,web,tel.email                       a record from the Database by using the Sql statement

        Try
            Dim cSQL3 As String = "UPDATE enrolleetab SET surname = '" & Me.Surname.Text & _
          "',firstname = '" & Me.Firstname.Text & _
          "',othernames = '" & Me.othernames.Text & _
           "',sex = '" & RTrim(sex1.Text) & _
            "',Maritalstatus = '" & RTrim(Maritalstatus.Text) & _
            "',title = '" & RTrim(Me.title.Text) & _
            "',haddress = '" & Me.haddress.Text & _
            "',age = '" & Me.age1.Text & _
            "',dofb = '" & Format(dofb1.Value, "yyyy-MM-dd") & _
           "' ,tel = '" & Me.tel.Text & _
           "' ,email = '" & email.Text & _
           "' ,dregister = '" & Format(dregister.Value, "yyyy-MM-dd") & _
            "',sdate = '" & Format(sdate.Value, "yyyy-MM-dd") & _
            "',edate = '" & Format(edate.Value, "yyyy-MM-dd") & _
            "',active = '" & active.Checked & _
            "',nationalid = '" & nationalid.Text & _
            "',NHIS = '" & Val(Me.NHIS.Text) & _
            "',ogaid = '" & Me.ogaid.SelectedValue & _
            "',ogaloc = '" & ogaloc.Text & _
            "',ppicture = '" & RTrim(ppicture.Text) & _
            "',spicture = '" & RTrim(spicture.Text) & _
            "',childpix1 = '" & RTrim(childpix1.Text) & _
           "' ,childpix2 = '" & RTrim(childpix2.Text) & _
           "' ,childpix3 = '" & RTrim(childpix3.Text) & _
            "',childpix4 = '" & RTrim(childpix4.Text) & _
           "' ,otherillness = '" & otherillness.Text & _
            "',hcpid = '" & Me.hcpid.SelectedValue & _
            "',hcpname = '" & hcpname.Text & _
           "',hcpaddress = '" & hcpaddress.Text & _
           "' ,hcplga = '" & hcplga.SelectedValue & _
          "' ,sectortype = '" & sectortype.SelectedValue & _
          "' ,hplan = '" & hplan.SelectedValue & _
          "',pnetwork = '" & pnetwork.SelectedValue & _
           "',ugplan = '" & IIf(ugplan1.Checked = True, "ugplan1", "ugplan2") & _
            "',ugmfees = '" & ugmfees.Text & _
           "',ugyfees = '" & ugyfees.Text & _
        "',ugstodate = '" & ugstodate.Text & _
              "',drelated = '" & Val(drelated.Text) & _
            "',extra = '" & Val(extra.Text) & _
            "',lpay = '" & Val(lpay.Text) & _
           "',ugbalance = '" & ugbalance.Text & "' where  enrolleeid= '" & enrolleeid.Text & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = cSQL3
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                MessageBox.Show("Record Updated Sucessfully")
                saveaudit("Update record for code: " + Trim(enrolleeid.Text) + " In " + Me.Text)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        saveillment()
        'Try

        '    Using CCNN As New SqlConnection(My.Settings.cnnstring)
        '        Dim Cd3 As SqlCommand = CCNN.CreateCommand
        '        Cd3.CommandType = CommandType.Text
        '        CCNN.Open()
        '        Dim i As Integer
        '        If familygrid.RowCount > 0 Then
        '            For i = 0 To familygrid.RowCount - 1
        '                MessageBox.Show(familygrid.Rows(i).Cells(0).Value)
        '                MessageBox.Show(familygrid.Rows(i).Cells(1).Value)
        '                MessageBox.Show(familygrid.Rows(i).Cells(2).Value)
        '                MessageBox.Show(familygrid.Rows(i).Cells(3).Value)
        '                Cd3.CommandText = "insert into Familyinfo(ftype,names,alterHCP,dofb,age,sex,Enrolleeid) values ('" & familygrid.Rows(i).Cells(0).Value & "','" & familygrid.Rows(i).Cells(1).Value & "','" & familygrid.Rows(i).Cells(2).Value & "','" & familygrid.Rows(i).Cells(3).Value & "','" & familygrid.Rows(i).Cells(4).Value & "','" & familygrid.Rows(i).Cells(5).Value & "','" & familygrid.Rows(i).Cells(6).Value & "','" & enrolleeid.Text & "');"
        '                Cd3.ExecuteNonQuery()
        '            Next
        '        End If
        '        Me.Refresh()
        '    End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Occurs in Default1 Table")
        'Finally

        'End Try
        savenewfamily()
        updateimage()


        clearrec()
        loadenrolsearchcombo()
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
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenEmail(email.Text)
    End Sub






    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim lrevar As New DownupWiz
        lrevar.gstring1 = "Select Enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,Sex,Maritalstatus,Title,Age,Dofb,Tel,Email,dregister as Date_Register,sdate as Start_Date,edate as End_Date,active as Inactive,nationalid,NHIS as NHIS_ID,ogaid,ogaloc,hcpid,hcpname,ugbalance as Yearly_Banalce FROM enrolleetab order by enrolleeid"
        lrevar.ltitle.Text = "Enrollee List"
        lrevar.BindGrid()
        lrevar.MdiParent = MDIParent1
        lrevar.Show()
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub enrolleeid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles enrolleeid.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If (Not enrolleeid.Text = String.Empty) Then
                LoadRecord()
            End If
        End If
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        clearrec()
        enrolleeid.Enabled = True
        loadenrolsearchcombo()
        loadhcpsearchcombo()
        loadpnsearchcombo()
        loadlgasearchcombo()
        loadhcptabsearchcombo()
        OGALOADCOMBO()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        saverec()
        loadenrolsearchcombo()
        loadhcpsearchcombo()
        loadpnsearchcombo()
        loadlgasearchcombo()
        loadhcptabsearchcombo()
        OGALOADCOMBO()
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

    Public Sub clearrec()
        Try
            'MsgBox("CLEAR")
            Me.enrolleeid.Focus()
            'Me.enrolleeid.Text = ""
            Me.Surname.Text = ""
            Me.Firstname.Text = ""
            Me.othernames.Text = ""
            plancode.Text = ""
            hcpcode.Text = ""
            Me.lpay.Text = 0.0
            ogacode.Text = ""
            Me.drelated.Text = 0.0
            Me.extra.Text = 0.0
            Me.haddress.Text = ""
            Me.age1.Text = ""
            Me.dofb1.Value = Today
            Me.tel.Text = ""
            Me.email.Text = ""
            Me.dregister.Text = Today
            Me.sdate.Value = Today
            Me.edate.Value = Today
            Me.active.Checked = False
            Me.nationalid.Text = ""
            Me.NHIS.Text = ""
            ' Me.ogaid.Text = ""
            Me.ogaloc.Text = ""
            Me.ppicture.Text = ""
            Me.spicture.Text = ""
            Me.childpix1.Text = ""
            Me.childpix2.Text = ""
            Me.childpix3.Text = ""
            Me.childpix4.Text = ""
            ppicture1.Image = Nothing
            spicture1.Image = Nothing
            childpix1p.Image = Nothing
            childpix2p.Image = Nothing
            childpix3p.Image = Nothing
            childpix4p.Image = Nothing
            Me.otherillness.Text = ""
            Me.illness1.Checked = False
            Me.illness2.Checked = False
            Me.illness3.Checked = False
            Me.illness4.Checked = False
            Me.illness5.Checked = False
            Me.illness6.Checked = False
            Me.illness7.Checked = False
            Me.illness8.Checked = False
            Me.illness9.Checked = False
            Me.illness10.Checked = False
            Me.illness11.Checked = False
            Me.illness12.Checked = False
            Me.illness13.Checked = False
            Me.illness14.Checked = False
            Me.illness15.Checked = False
            Me.illness16.Checked = False
            Me.illness17.Checked = False
            Me.illness18.Checked = False
            Me.illness19.Checked = False
            Me.illness20.Checked = False
            'Me.hcpid.Text = ""
            Me.hcpname.Text = ""
            Me.hcpaddress.Text = ""
            '  Me.hcplga.Text = ""
            '  Me.sectortype.Text = ""
            'Me.hplan.Text = ""
            ' Me.pnetwork.Text = ""
            ugplan2.Checked = False
            Me.ugmfees.Text = "0.00"
            Me.ugyfees.Text = "0.00"
            Me.ugstodate.Text = "0.00"
            Me.ugbalance.Text = "0.00"
            Dim I As Integer
            For I = I To familygrid.RowCount - 1
                familygrid.Rows.Clear()
            Next

            Dim T As Integer
            For T = T To hcphst.RowCount - 1
                hcphst.Rows.Clear()
            Next

            Dim TT As Integer
            For TT = TT To authorisgrid.RowCount - 1
                authorisgrid.Rows.Clear()
            Next

            Me.Refresh()
        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        End Try
    End Sub
    Private Sub disablecontrols()
        Me.Surname.Enabled = False
        Me.Firstname.Enabled = False
        Me.othernames.Enabled = False
        Me.title.Enabled = False
        Me.sex1.Enabled = False
        Me.Maritalstatus.Enabled = False
        Me.title.Enabled = False
        Me.haddress.Enabled = False
        Me.lpay.Enabled = False
        Me.age1.Enabled = False
        Me.dofb1.Enabled = False
        Me.tel.Enabled = False
        Me.email.Enabled = False
        Me.dregister.Enabled = False
        Me.sdate.Enabled = False
        Me.edate.Enabled = False
        Me.active.Enabled = False
        Me.nationalid.Enabled = False
        Me.NHIS.Enabled = False
        Me.ogaid.Enabled = False
        Me.ogaloc.Enabled = False
        Me.ppicture.Enabled = False
        Me.spicture.Enabled = False
        Me.childpix1.Enabled = False
        Me.childpix2.Enabled = False
        Me.childpix3.Enabled = False
        Me.childpix4.Enabled = False
        ppicture1.Image = Nothing
        spicture1.Image = Nothing
        childpix1p.Image = Nothing
        childpix2p.Image = Nothing
        childpix3p.Image = Nothing
        childpix4p.Image = Nothing
        Me.otherillness.Enabled = False
        Me.illness1.Enabled = False
        Me.illness2.Enabled = False
        Me.illness3.Enabled = False
        Me.illness4.Enabled = False
        Me.illness5.Enabled = False
        Me.illness6.Enabled = False
        Me.illness7.Enabled = False
        Me.illness8.Enabled = False
        Me.illness9.Enabled = False
        Me.illness10.Enabled = False
        Me.illness11.Enabled = False
        Me.illness12.Enabled = False
        Me.illness13.Enabled = False
        Me.illness14.Enabled = False
        Me.illness15.Enabled = False
        Me.illness16.Enabled = False
        Me.illness17.Enabled = False
        Me.illness18.Enabled = False
        Me.illness19.Enabled = False
        Me.illness20.Enabled = False
        Me.hcpid.Enabled = False
        Me.hcpname.Enabled = False
        Me.hcpaddress.Enabled = False
        Me.hcplga.Enabled = False
        Me.sectortype.Enabled = False
        Me.hplan.Enabled = False
        Me.pnetwork.Enabled = False
        ugplan2.Enabled = False
        Me.ugmfees.Enabled = False
        Me.ugyfees.Enabled = False
        Me.ugstodate.Enabled = False
        Me.ugbalance.Enabled = False
        Me.drelated.Enabled = False
        Me.extra.Enabled = False


    End Sub
    Private Sub enablecontrols()
        Me.Surname.Enabled = True
        Me.Firstname.Enabled = True
        Me.othernames.Enabled = True
        Me.title.Enabled = True
        Me.sex1.Enabled = True
        Me.Maritalstatus.Enabled = True
        Me.title.Enabled = True
        Me.haddress.Enabled = True
        Me.age1.Enabled = True
        Me.dofb1.Enabled = True
        Me.tel.Enabled = True
        Me.email.Enabled = True
        Me.lpay.Enabled = True
        Me.dregister.Enabled = True
        Me.sdate.Enabled = True
        Me.edate.Enabled = True
        Me.active.Enabled = True
        Me.nationalid.Enabled = True
        Me.NHIS.Enabled = True
        Me.ogaid.Enabled = True
        Me.ogaloc.Enabled = True
        Me.ppicture.Enabled = True
        Me.spicture.Enabled = True
        Me.childpix1.Enabled = True
        Me.childpix2.Enabled = True
        Me.childpix3.Enabled = True
        Me.childpix4.Enabled = True
        ppicture1.Image = Nothing
        spicture1.Image = Nothing
        childpix1p.Image = Nothing
        childpix2p.Image = Nothing
        childpix3p.Image = Nothing
        childpix4p.Image = Nothing
        Me.otherillness.Enabled = True
        Me.illness1.Enabled = True
        Me.illness2.Enabled = True
        Me.illness3.Enabled = True
        Me.illness4.Enabled = True
        Me.illness5.Enabled = True
        Me.illness6.Enabled = True
        Me.illness7.Enabled = True
        Me.illness8.Enabled = True
        Me.illness9.Enabled = True
        Me.illness10.Enabled = True
        Me.illness11.Enabled = True
        Me.illness12.Enabled = True
        Me.illness13.Enabled = True
        Me.illness14.Enabled = True
        Me.illness15.Enabled = True
        Me.illness16.Enabled = True
        Me.illness17.Enabled = True
        Me.illness18.Enabled = True
        Me.illness19.Enabled = True
        Me.illness20.Enabled = True
        Me.hcpid.Enabled = True
        Me.hcpname.Enabled = True
        Me.hcpaddress.Enabled = True
        Me.hcplga.Enabled = True
        Me.sectortype.Enabled = True
        Me.hplan.Enabled = True
        Me.pnetwork.Enabled = True
        ugplan2.Enabled = True
        Me.ugmfees.Enabled = True
        Me.ugyfees.Enabled = True
        Me.ugstodate.Enabled = True
        Me.ugbalance.Enabled = True
        Me.drelated.Enabled = True
        Me.extra.Enabled = True
    End Sub
    Sub loadenrolsearchcombo()
        ' Searchtool.SelectedIndex = -1
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
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
            Searchtool.DataSource = ds.Tables(0)
            Searchtool.ValueMember = "enrolleeid"
            Searchtool.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadhcpsearchcombo()
        'Dim connetionString As String = Nothing
        'Dim connection As SqlConnection
        'Dim command As SqlCommand
        'Dim adapter As New SqlDataAdapter()
        'Dim ds As New DataSet()
        'Dim i As Integer = 0
        'Dim sql As String = Nothing
        'connetionString = My.Settings.cnnstring
        ''sql = "select enrolleeid,surnrame from enrolleetab"
        'sql = "select code1,descr from premiumplan"

        'connection = New SqlConnection(connetionString)
        'Try
        '    connection.Open()
        '    command = New SqlCommand(sql, connection)
        '    adapter.SelectCommand = command
        '    adapter.Fill(ds)
        '    adapter.Dispose()
        '    command.Dispose()
        '    connection.Close()
        '    hplan.DataSource = ds.Tables(0)
        '    hplan.ValueMember = "code1"
        '    hplan.DisplayMember = "descr"
        'Catch ex As Exception
        '    MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        'End Try
    End Sub
    Sub loadpnsearchcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select code1,descr from CODESTAB where option1 = '" & "F14" & "'"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            pnetwork.DataSource = ds.Tables(0)
            pnetwork.ValueMember = "code1"
            pnetwork.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadlgasearchcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
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
            hcplga.DataSource = ds.Tables(0)
            hcplga.ValueMember = "code1"
            hcplga.DisplayMember = "descr"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to enrolleetab ! "
        End Try
    End Sub
    Sub loadhcptabsearchcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select hcpid,rtrim(Names)  as names from Hcptab order by Names"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            hcpid.DataSource = ds.Tables(0)
            hcpid.ValueMember = "hcpid"
            hcpid.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ! "
        End Try
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles ppicture1.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            ppicture1.Image = Image.FromFile(strfilename)

            OpenFD.Reset()
        End If
        ppicture.Text = strfilename
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles spicture1.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            spicture1.Image = Image.FromFile(strfilename)

            OpenFD.Reset()
        End If
        spicture.Text = strfilename
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles childpix1p.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix1p.Image = Image.FromFile(strfilename)

            OpenFD.Reset()
        End If
        childpix1.Text = strfilename
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles childpix2p.Click
        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix2p.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        childpix2.Text = strfilename
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles childpix3p.Click
        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix3p.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        childpix3.Text = strfilename
    End Sub
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles childpix4p.Click

        Dim strfilename As String = ""
        OpenFD.InitialDirectory = My.Settings.photopath
        OpenFD.Title = "Open an image"
        OpenFD.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim didwork As Integer = OpenFD.ShowDialog
        If didwork <> DialogResult.Cancel Then
            strfilename = OpenFD.FileName
            childpix4p.Image = Image.FromFile(strfilename)
            OpenFD.Reset()
        End If
        childpix4.Text = strfilename
    End Sub
    Sub loadcodegenhst()


        Dim i2 As Integer
        For i2 = i2 To authorisgrid.RowCount - 1
            authorisgrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT codegen,gendate,smsto,hcpid,hcpname,email,reason FROM authorisgrid2 where" _
                             & " enrolleeid = '" & Me.enrolleeid.Text & "'"

        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    '   MessageBox.Show("Has row")
                    While r.Read
                        Dim row As Integer = authorisgrid.Rows.Add
                        authorisgrid.Rows(row).Cells(0).Value = r(0)
                        authorisgrid.Rows(row).Cells(1).Value = r(1)
                        authorisgrid.Rows(row).Cells(2).Value = r(2)
                        authorisgrid.Rows(row).Cells(3).Value = r(3)
                        authorisgrid.Rows(row).Cells(4).Value = r(4)
                        authorisgrid.Rows(row).Cells(5).Value = r(5)
                        authorisgrid.Rows(row).Cells(6).Value = r(6)
                        authorisgrid.Refresh()
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
    Sub retrievnewfamily()

        Dim i2 As Integer
        For i2 = i2 To familygrid.RowCount - 1
            familygrid.Rows.Clear()
        Next
        Dim gg2 As String = "SELECT ftype,names,alterHCP,dofb,age,sex,Enrolleeid FROM Familyinfo where" _
                             & " enrolleeid = '" & Me.enrolleeid.Text & "'"
        'Dim index As Integer

        'If Not r.IsDBNull(18) Then
        '    index = ogaid.FindString(RTrim(r(18)))
        '    ogaid.SelectedIndex = index
        'End If
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    '          MessageBox.Show("Has row")
                    While r.Read
                        Dim row As Integer = familygrid.Rows.Add
                        familygrid.Rows(row).Cells(0).Value = r(0)
                        familygrid.Rows(row).Cells(1).Value = r(1)
                        familygrid.Rows(row).Cells(2).Value = r(2)
                        familygrid.Rows(row).Cells(3).Value = r(3)
                        familygrid.Rows(row).Cells(4).Value = RTrim(r(4))
                        familygrid.Rows(row).Cells(5).Value = RTrim(r(5))
                        familygrid.Refresh()
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
    Sub delfamily()
        cSQL = "DELETE FROM Familyinfo WHERE" _
                  & " enrolleeid = '" & Me.enrolleeid.Text & "'"
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
    End Sub
    Sub savenewfamily()

        delfamily()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text

                Dim i As Integer

                If familygrid.RowCount > 0 Then
                    For i = 0 To familygrid.RowCount - 1
                        If Not familygrid.Rows(i).Cells(0).Value = String.Empty Then
                            MDIParent1.statusmsg2.Text = (familygrid.Rows(i).Cells(1).Value)
                            Cd3.CommandText = "INSERT INTO Familyinfo(Enrolleeid,ftype,names,alterHCP,dofb,age,sex) VALUES('" & enrolleeid.Text & "','" & familygrid.Rows(i).Cells(0).Value & "','" & familygrid.Rows(i).Cells(1).Value & "','" & familygrid.Rows(i).Cells(2).Value & "','" & familygrid.Rows(i).Cells(3).Value & "','" & familygrid.Rows(i).Cells(4).Value & "','" & familygrid.Rows(i).Cells(5).Value & "')"
                            CCNN.Open()
                            Cd3.ExecuteNonQuery()
                            CCNN.Close()
                            '  saveaudit("Save/Update Family record for code: " + Trim(Enrolleeid.Text) + " In " + Me.Text)
                        End If
                    Next
                End If

                Me.Refresh()
                '  MessageBox.Show("Batch Save/Update Sucessfully")
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Inserting Record family GRID")
        End Try
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


    Private Sub Searchtool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Searchtool.SelectedIndexChanged
        Try
            '   clearrec()

            enrolleeid.Text = Searchtool.SelectedValue.ToString
            enrolleeid.Enabled = True
            enrolleeid.Focus()
            If (Not enrolleeid.Text = String.Empty) Then
                '  LoadRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub loadpix()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand

                Cd.CommandText = " Select enrolleeid,ppicture,spicture,childpix1,childpix2,childpix3,childpix4 FROM enrolleetab WHERE" _
                & " rtrim(enrolleeid) = '" & RTrim(enrolleeid.Text) & "'"

                Cd.CommandType = CommandType.Text

                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows = True Then
                    r.Read()
                    If Not r.IsDBNull(1) Then Me.ppicture.Text = r(1)
                    If Not r.IsDBNull(2) Then Me.spicture.Text = r(2)
                    If Not r.IsDBNull(3) Then Me.childpix1.Text = r(3)
                    If Not r.IsDBNull(4) Then Me.childpix2.Text = r(4)
                    If Not r.IsDBNull(5) Then Me.childpix3.Text = r(5)
                    If Not r.IsDBNull(6) Then Me.childpix4.Text = r(6)
                    ppicture1.Image = Image.FromFile(RTrim(Me.ppicture.Text))
                    spicture1.Image = Image.FromFile(RTrim(Me.spicture.Text))
                    childpix1p.Image = Image.FromFile(RTrim(Me.childpix1.Text))
                    childpix2p.Image = Image.FromFile(RTrim(Me.childpix2.Text))
                    childpix3p.Image = Image.FromFile(RTrim(Me.childpix3.Text))
                    childpix4p.Image = Image.FromFile(RTrim(Me.childpix4.Text))
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub hcpid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hcpid.SelectedIndexChanged
        Try
            hcpname.Text = hcpid.Text.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ugmfees_TextChanged(sender As Object, e As EventArgs) Handles ugmfees.TextChanged

        If Not IsNumeric(ugmfees.Text) Then
            MessageBox.Show("Entered numeric values to continue")
        End If

    End Sub
    Sub OGALOADCOMBO()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select ogaid,rtrim(ogaNames)  as names from oganisationtab order by ogaid"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ogaid.DataSource = ds.Tables(0)
            ogaid.ValueMember = "ogaid"
            ogaid.DisplayMember = "names"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to oganisationtab ! "
        End Try
    End Sub

    Private Sub hplan_Click(sender As Object, e As EventArgs) Handles hplan.Click
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select CODE1,DESCR from ogaplangrid WHERE rtrim(ogaid) = '" & RTrim(ogaid.SelectedValue) & "' order by CODE1"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            hplan.DataSource = ds.Tables(0)
            hplan.ValueMember = "CODE1"
            hplan.DisplayMember = "DESCR"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ogaplangrid ! "
        End Try
        gethpplan()
    End Sub

    Private Sub hplan_MouseClick(sender As Object, e As MouseEventArgs) Handles hplan.MouseClick
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = My.Settings.cnnstring
        'sql = "select enrolleeid,surnrame from enrolleetab"
        sql = "select CODE1,DESCR from ogaplangrid WHERE rtrim(ogaid) = '" & RTrim(ogaid.SelectedValue) & "' order by CODE1"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            hplan.DataSource = ds.Tables(0)
            hplan.ValueMember = "CODE1"
            hplan.DisplayMember = "DESCR"
        Catch ex As Exception
            MDIParent1.statusmsg.Text = "Can not open connection to ogaplangrid ! "
        End Try
        gethpplan()
    End Sub
    Sub gethpplan()
        Dim dd As String = " Select ogaid,Ugplan,Utidefaultfees FROM oganisationtab WHERE" _
   & " rtrim(ogaid) = '" & RTrim(ogaid.Text) & "'"
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
                    Else
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
    Private Sub hplan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hplan.SelectedIndexChanged
        plancode.Text = hplan.SelectedValue
        '    If Not ogaid.SelectedValue = String.Empty Then

        '  End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' ppicture1.Image = Nothing
        spicture1.Image = Nothing
        spicture.Text = My.Settings.imgaepath + "\" + "spics.jpg"


        'childpix1p.Image = Nothing
        'childpix2p.Image = Nothing
        'childpix3p.Image = Nothing
        'childpix4p.Image = Nothing
    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        childpix1p.Image = Nothing
        childpix1.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        childpix2p.Image = Nothing
        childpix2.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        childpix3p.Image = Nothing
        childpix3.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        childpix4p.Image = Nothing
        childpix4.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub
    Private Sub dofb1_ValueChanged(sender As Object, e As EventArgs) Handles dofb1.ValueChanged
        Dim dob As Date = Me.dofb1.Value
        Dim age As Integer = Convert.ToInt32(DateDiff(DateInterval.Year, dob, Date.Today))
        age1.Text = age
    End Sub

    Private Sub ogaid_Validating(sender As Object, e As CancelEventArgs) Handles ogaid.Validating
        ogacode.Text = ogaid.SelectedValue
        ogaloc.Text = ogaid.Text
    End Sub

    Private Sub hcpid_Validating(sender As Object, e As CancelEventArgs) Handles hcpid.Validating
        hcpcode.Text = hcpid.SelectedValue
        '   ogaloc.Text = ogaid.Text
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            ppicture1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            spicture1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix1p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix2p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix3p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            childpix4p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
    End Sub
    Private Sub ugplan1_CheckedChanged(sender As Object, e As EventArgs) Handles ugplan1.CheckedChanged
        ugmfees.Text = ugmfeesvar
    End Sub

    Private Sub ugplan2_CheckedChanged(sender As Object, e As EventArgs) Handles ugplan2.CheckedChanged
        ugmfees.Text = 0.0
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ppicture1.Image = Nothing
        ppicture.Text = My.Settings.imgaepath + "\" + "spics.jpg"
    End Sub

    Private Sub enrolleeid_TextChanged(sender As Object, e As EventArgs) Handles enrolleeid.TextChanged

    End Sub
    Sub loadpictures()
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)
                cn.Open()
                Dim sql As String = "Select * from enrolleetab where enrolleeid = " + enrolleeid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("ppicture"), Byte())
                    Dim ms As New MemoryStream(data)
                    ppicture1.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from enrolleetab where enrolleeid = " + enrolleeid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("spicture"), Byte())
                    Dim ms As New MemoryStream(data)
                    spicture1.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from enrolleetab where enrolleeid = " + enrolleeid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("childpix1"), Byte())
                    Dim ms As New MemoryStream(data)
                    childpix1p.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try

        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from enrolleetab where enrolleeid = " + enrolleeid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("childpix2"), Byte())
                    Dim ms As New MemoryStream(data)
                    childpix2p.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from enrolleetab where enrolleeid = " + enrolleeid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("childpix3"), Byte())
                    Dim ms As New MemoryStream(data)
                    childpix3p.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try
        Try
            Using cn As New SqlConnection(My.Settings.cnnstring)


                cn.Open()
                Dim sql As String = "Select * from enrolleetab where enrolleeid = " + enrolleeid.Text
                Dim cmd As New SqlCommand(sql, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    ' TextBox1.Text = dr("name").ToString()
                    Dim data As Byte() = DirectCast(dr("childpix4"), Byte())
                    Dim ms As New MemoryStream(data)
                    childpix4p.Image = Image.FromStream(ms)
                End If
                cn.Close()
            End Using

        Catch ex As Exception
            '   Me.statuspoint.Text = ex.Message
        Finally
        End Try


    End Sub
End Class