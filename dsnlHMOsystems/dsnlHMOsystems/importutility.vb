Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web.Services.Description
Public Class importutility
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODETXT As String
    Public impfilename As String
    Public fsave As String
    Public cSQL As String
    Public gstring1 As String
    Public addnew As Boolean
    Public codeee As String
    Public descrrr As String
    Private Sub importutility_Load(sender As Object, e As EventArgs) Handles Me.Load
        mtotal.Text = 0.0
        rtotal.Text = 0.0
        dtotal.Text = 0.0
        listgrid.ReadOnly = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (ComboBox1.Text = String.Empty) Then
            MessageBox.Show("Select import data, to continue")
        Else
            Try
                importstat.Text = "Importing Please Wait.........."
                Dim postname As String = ""
                If impfilename = "Enrollee Table" Then
                    delenrolfirst()
                    postname = "Enrolleetabimp"
                    gstring1 = "SELECT enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,sdate,edate,active,nationalid,NHIS,ogaid,ogaloc,hcpid,hcpname,hcpaddress,hcplga,sectortype,hplan,pnetwork,ugplan,ugmfees,ugyfees,ugstodate,ugbalance,drelated,extra FROM enrolleetabimp order by enrolleeid"
                    BindGrid()
                End If
                If impfilename = "Hospital Table" Then
                    postname = "hcptabimp"
                    gstring1 = "SELECT hcpid,Names,dregister,active,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan,pnetwork FROM Hcptabimp order by hcpid"
                    BindGrid()
                End If
                If impfilename = "Organisation Table" Then
                    postname = "oganisationtabimp"
                    gstring1 = "SELECT ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,bankbranch,accountid,sortcode,sectortype,hcpplan,puprice,punumber,putotal,pugrandtotal,ugplan,Utidefaultfees FROM oganisationtabimp order by ogaid"
                    BindGrid()
                End If
                If impfilename = "Enrollee Family Table" Then
                    postname = "familyinfoimp"
                    gstring1 = "SELECT Enrolleeid,ftype,names,alterHCP,dofb,age,sex FROM Familyinfoimp order by Enrolleeid"
                    BindGrid()
                End If

                Dim ofd As New OpenFileDialog
                If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Exit Sub
                Dim nme As String = ofd.FileName
                Dim safename As String = ofd.SafeFileName
                safename = safename.Substring(0, safename.LastIndexOf("."))
                Import(nme, listgrid, safename, postname)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            importstat.Text = "Done..."
        End If
    End Sub
    Sub BindGrid()
        Try
            Dim constring As String = My.Settings.cnnstring
            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand(gstring1, con)
                    cmd.CommandType = CommandType.Text
                    Using sda As New SqlDataAdapter(cmd)
                        Using ds As New DataSet()
                            sda.Fill(ds)
                            listgrid.DataSource = ds.Tables(0)

                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Impotgrid Table")
        End Try

    End Sub
    Public Shared Function Import(ByVal FileName As String, ByVal dgv As DataGridView, ByVal safefilename As String, ByVal impfilenamevar As String) As Boolean
        Try
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            MyCommand.TableMappings.Add(impfilenamevar, safefilename)
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            dgv.DataSource = DtSet.Tables(0)
            MyConnection.Close()
            Dim expr As String = "SELECT * FROM [Sheet1$]"

            Dim SQLconn As New SqlConnection()
            Dim ConnString As String = My.Settings.cnnstring
            Dim objCmdSelect As OleDbCommand = New OleDbCommand(expr, MyConnection)
            Dim objDR As OleDbDataReader
            SQLconn.ConnectionString = ConnString
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(ConnString)
                bulkCopy.DestinationTableName = safefilename
                Try
                    MyConnection.Open()
                    objDR = objCmdSelect.ExecuteReader
                    bulkCopy.WriteToServer(objDR)
                    objDR.Close()
                    SQLconn.Close()

                    MessageBox.Show("Excel File imported Successfully.")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Using
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        impfilename = ComboBox1.Text.Trim
    End Sub
    Public Sub delenrolfirst()
        Try
            listgrid.DataBindings.Clear()
            Dim i2 As Integer
            For i2 = i2 To listgrid.RowCount - 1
                listgrid.Rows.Clear()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in datagrid- Close and reload form")
        End Try

        cSQL = "DELETE FROM enrolleetabimp"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
                '   MessageBox.Show("Data Import Template Cleared")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Dim cSQL2 As String = "DELETE FROM hcptabimp"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL2
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
                '    MessageBox.Show("Data Import Template Cleared")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim cSQL3 As String = "DELETE FROM oganisationtabimp"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL3
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
                MessageBox.Show("Data Import Template Cleared")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim cSQL33 As String = "DELETE FROM familyinfoimp"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandType = CommandType.Text
                Cd.CommandText = cSQL33
                CCNN.Open()
                Cd.ExecuteNonQuery()
                Me.Refresh()
                MessageBox.Show("Data Import Template Cleared")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try





    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mtotal.Text = 0.0
        rtotal.Text = 0.0
        dtotal.Text = 0.0
        importstat.Text = "Updating Data Please Wait.........."
        If RTrim(ComboBox1.Text.Trim) = "Enrollee Table" Then
            updateenrolle()
        End If
        If RTrim(ComboBox1.Text.Trim) = "Hospital Table" Then
            updatehcp()
        End If
        If RTrim(ComboBox1.Text.Trim) = "Organisation Table" Then
            updateoga()
        End If
        If RTrim(ComboBox1.Text.Trim) = "Enrollee Family Table" Then
            updateenrofamily()
        End If

        welcomeme()
        importstat.Text = "Done.."
    End Sub
    Sub welcomeme()
        Dim unamess As String = My.Settings.loginname
        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Record Proccessed Successfully", frmMSGctrl.MessageType.Notice)
    End Sub
    Sub updateenrofamily()
        mtotal.Text = 0.0
        rtotal.Text = 0.0
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If listgrid.RowCount > 0 Then
                    For i = 0 To listgrid.RowCount - 1
                        If (Not listgrid.Rows(i).Cells(0).Value = String.Empty) Then
                            dtotal.Text = dtotal.Text + 1
                            CheckCodestab.FAMILYINFO3(RTrim(listgrid.Rows(i).Cells(0).Value))
                            'MessageBox.Show(RTrim(CheckCodestab.descvar))
                            If RTrim(CheckCodestab.descvar) = RTrim(listgrid.Rows(i).Cells(0).Value) Then
                                rtotal.Text = rtotal.Text + 1
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.YellowGreen
                            Else
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.White
                                Cd3.CommandText = "INSERT INTO Familyinfo(Enrolleeid,ftype,names,alterHCP,dofb,age,sex)" & _
                                                   "VALUES('" & listgrid.Rows(i).Cells(0).Value & "','" & listgrid.Rows(i).Cells(1).Value & "','" & listgrid.Rows(i).Cells(2).Value & "','" & listgrid.Rows(i).Cells(3).Value & "','" & listgrid.Rows(i).Cells(4).Value & "','" & listgrid.Rows(i).Cells(5).Value & "','" & listgrid.Rows(i).Cells(6).Value & "')"
                                mtotal.Text = mtotal.Text + 1
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()
                            End If
                        End If
                    Next
                    MessageBox.Show("Data Processed Successfully")
                End If
                saveaudit("Import Data to the Enrollee Familyinfo Table  " + " In " + Me.Text)
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Familyinfo Data upload Table")
        End Try
    End Sub
    Sub updateenrolle()
        mtotal.Text = 0.0
        rtotal.Text = 0.0
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If listgrid.RowCount > 0 Then
                    For i = 0 To listgrid.RowCount - 1
                        If (Not listgrid.Rows(i).Cells(0).Value = String.Empty) Then
                            dtotal.Text = dtotal.Text + 1
                            CheckCodestab.enrollname2(RTrim(listgrid.Rows(i).Cells(0).Value))
                            If RTrim(CheckCodestab.descvar) = RTrim(listgrid.Rows(i).Cells(0).Value) Then
                                rtotal.Text = rtotal.Text + 1
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(8).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(9).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(10).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(11).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(12).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(14).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(15).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(16).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(17).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(18).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(19).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(20).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(21).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(22).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(23).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(24).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(25).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(26).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(27).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(28).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(29).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(30).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(31).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(32).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(33).Style.BackColor = Color.YellowGreen
                            Else
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(7).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(8).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(9).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(10).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(11).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(12).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(13).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(14).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(15).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(16).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(17).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(18).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(19).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(20).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(21).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(22).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(23).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(24).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(25).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(26).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(27).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(28).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(29).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(30).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(31).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(32).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(33).Style.BackColor = Color.White
                                Cd3.CommandText = "INSERT INTO enrolleetab(enrolleeid,Surname,Firstname,othernames,sex,Maritalstatus,title,haddress,age,dofb,tel,email,dregister,sdate,edate,active,nationalid,NHIS,ogaid,ogaloc,hcpid,hcpname,hcpaddress,hcplga,sectortype,hplan,pnetwork,ugplan,ugmfees,ugyfees,ugstodate,ugbalance,drelated,extra,ppicture,spicture,childpix1,childpix2,childpix3,childpix4 )" & _
                                                   "VALUES('" & listgrid.Rows(i).Cells(0).Value & "','" & listgrid.Rows(i).Cells(1).Value & "','" & listgrid.Rows(i).Cells(2).Value & "','" & listgrid.Rows(i).Cells(3).Value & "','" & listgrid.Rows(i).Cells(4).Value & "','" & listgrid.Rows(i).Cells(5).Value & "','" & listgrid.Rows(i).Cells(6).Value & "','" & listgrid.Rows(i).Cells(7).Value & "','" & listgrid.Rows(i).Cells(8).Value & "','" & listgrid.Rows(i).Cells(9).Value & "','" & listgrid.Rows(i).Cells(10).Value & "','" & listgrid.Rows(i).Cells(11).Value & "','" & listgrid.Rows(i).Cells(12).Value & "','" & listgrid.Rows(i).Cells(13).Value & "','" & listgrid.Rows(i).Cells(14).Value & "','" & listgrid.Rows(i).Cells(15).Value & "','" & listgrid.Rows(i).Cells(16).Value & "','" & listgrid.Rows(i).Cells(17).Value & "','" & listgrid.Rows(i).Cells(18).Value & "','" & listgrid.Rows(i).Cells(19).Value & "','" & listgrid.Rows(i).Cells(20).Value & "','" & listgrid.Rows(i).Cells(21).Value & "','" & listgrid.Rows(i).Cells(22).Value & "','" & listgrid.Rows(i).Cells(23).Value & "','" & listgrid.Rows(i).Cells(24).Value & "','" & listgrid.Rows(i).Cells(25).Value & "','" & listgrid.Rows(i).Cells(26).Value & "','" & listgrid.Rows(i).Cells(27).Value & "','" & Val(listgrid.Rows(i).Cells(28).Value) & "','" & Val(listgrid.Rows(i).Cells(29).Value) & "','" & Val(listgrid.Rows(i).Cells(30).Value) & "','" & Val(listgrid.Rows(i).Cells(31).Value) & "','" & Val(listgrid.Rows(i).Cells(32).Value) & "','" & Val(listgrid.Rows(i).Cells(33).Value) & "','" & My.Settings.photopath & "','" & My.Settings.photopath & "','" & My.Settings.photopath & "','" & My.Settings.photopath & "','" & My.Settings.photopath & "','" & My.Settings.photopath & "')"
                                mtotal.Text = mtotal.Text + 1
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()
                            End If
                        End If
                    Next
                    MessageBox.Show("Data Processed Successfully")
                End If
                saveaudit("Import Data to the Enrollee Table  " + " In " + Me.Text)
                Me.Refresh()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Data upload Table")
        End Try
    End Sub
    Sub updatehcp()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If listgrid.RowCount > 0 Then
                    For i = 0 To listgrid.RowCount - 1
                        If (Not listgrid.Rows(i).Cells(0).Value = String.Empty) Then
                            dtotal.Text = dtotal.Text + 1
                            CheckCodestab.hcptabname2(RTrim(listgrid.Rows(i).Cells(0).Value))
                            If RTrim(CheckCodestab.descvar) = RTrim(listgrid.Rows(i).Cells(0).Value) Then
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(8).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(9).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(10).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(11).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(12).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(14).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(15).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(16).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(17).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(18).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(19).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(20).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(21).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(22).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(23).Style.BackColor = Color.YellowGreen
                                rtotal.Text = rtotal.Text + 1
                            Else
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(7).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(8).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(9).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(10).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(11).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(12).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(13).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(14).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(15).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(16).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(17).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(18).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(19).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(20).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(21).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(22).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(23).Style.BackColor = Color.White
                                Cd3.CommandText = "INSERT INTO Hcptab(hcpid,Names,dregister,active,NHIS,LGA,state,country,pmethod,tel,email,website,address,glcode,bank,bankbranch,accid,sortcode,Mdnames,mdtel,mdemail,sectortype,hcpplan,pnetwork)" & _
                                                   "VALUES('" & listgrid.Rows(i).Cells(0).Value & "','" & listgrid.Rows(i).Cells(1).Value & "','" & listgrid.Rows(i).Cells(2).Value & "','" & listgrid.Rows(i).Cells(3).Value & "','" & listgrid.Rows(i).Cells(4).Value & "','" & listgrid.Rows(i).Cells(5).Value & "','" & listgrid.Rows(i).Cells(6).Value & "','" & listgrid.Rows(i).Cells(7).Value & "','" & listgrid.Rows(i).Cells(8).Value & "','" & listgrid.Rows(i).Cells(9).Value & "','" & listgrid.Rows(i).Cells(10).Value & "','" & listgrid.Rows(i).Cells(11).Value & "','" & listgrid.Rows(i).Cells(12).Value & "','" & listgrid.Rows(i).Cells(13).Value & "','" & listgrid.Rows(i).Cells(14).Value & "','" & listgrid.Rows(i).Cells(15).Value & "','" & listgrid.Rows(i).Cells(16).Value & "','" & listgrid.Rows(i).Cells(17).Value & "','" & listgrid.Rows(i).Cells(18).Value & "','" & listgrid.Rows(i).Cells(19).Value & "','" & listgrid.Rows(i).Cells(20).Value & "','" & listgrid.Rows(i).Cells(21).Value & "','" & listgrid.Rows(i).Cells(22).Value & "','" & listgrid.Rows(i).Cells(23).Value & "')"
                                mtotal.Text = mtotal.Text + 1
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()

                            End If
                        End If
                    Next

                    MessageBox.Show("Data Processed Successfully")
                End If
                saveaudit("Import Data to the Hospital Table " + " In " + Me.Text)
                Me.Refresh()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Data upload Table")
        End Try
    End Sub
    Sub updateoga()
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd3 As SqlCommand = CCNN.CreateCommand
                Cd3.CommandType = CommandType.Text
                Dim i As Integer
                If listgrid.RowCount > 0 Then
                    For i = 0 To listgrid.RowCount - 1
                        If (Not listgrid.Rows(i).Cells(0).Value = String.Empty) Then
                            dtotal.Text = dtotal.Text + 1
                            CheckCodestab.ogatabname2(RTrim(listgrid.Rows(i).Cells(0).Value))
                            If RTrim(CheckCodestab.descvar) = RTrim(listgrid.Rows(i).Cells(0).Value) Then
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(7).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(8).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(9).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(10).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(11).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(12).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(14).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(15).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(16).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(17).Style.BackColor = Color.YellowGreen
                                listgrid.Rows(i).Cells(18).Style.BackColor = Color.YellowGreen
                                rtotal.Text = rtotal.Text + 1
                            Else
                                listgrid.Rows(i).Cells(0).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(1).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(2).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(3).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(4).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(5).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(6).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(7).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(8).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(9).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(10).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(11).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(12).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(13).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(14).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(15).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(16).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(17).Style.BackColor = Color.White
                                listgrid.Rows(i).Cells(18).Style.BackColor = Color.White
                                Cd3.CommandText = "INSERT INTO oganisationtab(ogaid,oganames,active,dregister,lga,state,country,tel,email,website,sperson,address,glcode,bank,bankbranch,accountid,sortcode,sectortype,hcpplan)" & _
                                                   "VALUES('" & listgrid.Rows(i).Cells(0).Value & "','" & listgrid.Rows(i).Cells(1).Value & "','" & listgrid.Rows(i).Cells(2).Value & "','" & listgrid.Rows(i).Cells(3).Value & "','" & listgrid.Rows(i).Cells(4).Value & "','" & listgrid.Rows(i).Cells(5).Value & "','" & listgrid.Rows(i).Cells(6).Value & "','" & listgrid.Rows(i).Cells(7).Value & "','" & listgrid.Rows(i).Cells(8).Value & "','" & listgrid.Rows(i).Cells(9).Value & "','" & listgrid.Rows(i).Cells(10).Value & "','" & listgrid.Rows(i).Cells(11).Value & "','" & listgrid.Rows(i).Cells(12).Value & "','" & listgrid.Rows(i).Cells(13).Value & "','" & listgrid.Rows(i).Cells(14).Value & "','" & listgrid.Rows(i).Cells(15).Value & "','" & listgrid.Rows(i).Cells(16).Value & "','" & listgrid.Rows(i).Cells(17).Value & "','" & listgrid.Rows(i).Cells(18).Value & "')"
                                mtotal.Text = mtotal.Text + 1
                                CCNN.Open()
                                Cd3.ExecuteNonQuery()
                                CCNN.Close()
                            End If
                        End If
                    Next

                    MessageBox.Show("Data Processed Successfully")
                End If
                saveaudit("Import Data to the Oganisation Table " + " In " + Me.Text)
                Me.Refresh()

            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Occurs in Data upload Table")
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        delenrolfirst()

    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class