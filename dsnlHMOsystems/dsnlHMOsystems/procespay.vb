Imports System.Data.SqlClient
Imports System.Drawing.Printing.PrintDocument
Imports System.Collections
Imports System.Drawing.Printing
Public Class procespay
    Public OPTR As String = My.Settings.OPTRR
    Public optname2 As String = My.Settings.optname
    Public CODE1TXT As String
    Public DESCRTXT As String
    Public DSQL As String
    Public cSQL As String
    Public addnew As Boolean
    Public CODE1ee As String
    Public descrrr As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClearRec()
        ProcessPayNow()
        welcomeme()
    End Sub
    Sub welcomeme()
        Dim unamess As String = My.Settings.loginname
        frmMSGctrl.Show()
        frmMSGctrl.Show_msg("dsnl HMO Manager", "Process Completed Successfully", frmMSGctrl.MessageType.Notice)
    End Sub
    Sub ClearRec()
        Me.statuspoint.Text = "Processing Please wait"
        Dim result = MsgBox("Continue Payroll Processing.......", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation)
        If result = vbYes Then

            cSQL = "DELETE FROM paysum "
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
                    saveaudit("Clear Payroll process Record : ")
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        End If
    End Sub
    Sub checkpayrollstatus()
        Try
            '  Using CCNN As New SqlConnection(My.Settings.CnnString)
            Dim DSQL As String = "SELECT staffid,month,year FROM payroll WHERE" _
            & " month(RUNDATE) = '" & Month(RUNDATE.Value) & "'"
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.Read = True Then
                    MessageBox.Show("Payroll Month and Year Exist - Backup and clear Payroll now?")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ProcessPayNow()
        Me.statuspoint.Text = "Processing Please wait"
        MessageBox.Show(RUNDATE.Value)
        MDIParent1.statusmsg2.Text = "Processing please wait"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                DSQL = "SELECT a.staffid,rtrim(a.surname) + ' ' + rtrim(a.firstname) + ' ' + rtrim(a.othernames) as names,b.itemcode, b.itemdescr, b.itemtype, b.taxable, b.scheme, b.advance, a.glevel, a.dept, a.bankid, a.accountid,0.00 as pamount, '" & Month(RUNDATE.Value) & "' as period,'" & Format(RUNDATE.Value, "yyyy-MM-dd") & "' as paycaldate,'" & Year(RUNDATE.Value) & "' as year,'" & Month(RUNDATE.Value) & "' as month,0.00 as fixedtax,0.00 as totalallowance,0.00 as totaldeduction,0.00 as netpay FROM stafftab a,payitems b Where a.staffid != '" & "ADMIN" & "' and  a.suspended = '" & False & "' and b.pay = '" & True & "'"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    While r.Read()
                        insertintopayroll2(r.Item(0), r.Item(1), r.Item(2), r.Item(3), r.Item(4), r.Item(5), r.Item(6), r.Item(7), r.Item(8), r.Item(9), r.Item(10), r.Item(11), r.Item(12), r.Item(13), r.Item(14), r.Item(15), r.Item(16), r.Item(17), r.Item(18), r.Item(19), r.Item(20))
                        'MessageBox.Show(r.Item(12))
                    End While
                    ' r.Close()
                Else
                    MessageBox.Show("No Record Processed")
                End If
                '    MesgBox("Inserted") pamount,period,paycaldate,year,month
            End Using
        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        End Try
    End Sub
    Sub insertintopayroll2(ByVal staffidvar As String, ByVal Namesvar As String, ByVal picvar As String, ByVal itemdescrvar As String, ByVal pictypevar As String, ByVal taxablevar As Boolean, ByVal schemevar As Boolean, ByVal advancevar As Boolean, ByVal gradelvlvar As String, ByVal deptcodevar As String, ByVal bankidvar As String, ByVal accountidvar As String, ByVal pamountvar As Double, ByVal periodvar As Integer, ByVal paycaldatevar As Date, ByVal yearvar As Integer, ByVal monthvar As Integer, ByVal fixedtaxvar As Double, ByVal allowvar As Double, ByVal deduvar As Double, ByVal netpayvar As Double)
        Me.statuspoint.Text = "Processing please wait......."
        'MessageBox.Show(pamountvar)
        'MessageBox.Show(periodvar)
        'MessageBox.Show(paycaldatevar)
        'MessageBox.Show(yearvar)
        'MessageBox.Show(monthvar)  fixedtaxvar,allowvar,deduvar,netpayvar
        Me.statuspoint.Text = "Processing Please wait"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                DSQL = "INSERT INTO paysum(staffid,Names,pic,itemdescr,pictype,taxable,scheme,advance,gradelvl,deptcode,bankid,accountid,pamount,period,paycaldate,year,month,fixedtax,totalallowance,totaldeduction,netpay)" & _
                    "values('" & staffidvar & "','" & Namesvar & "' ,'" & picvar & "','" & itemdescrvar & "','" & pictypevar & "','" & taxablevar & "','" & schemevar & "','" & advancevar & "','" & gradelvlvar & "','" & deptcodevar & "','" & bankidvar & "','" & accountidvar & "','" & pamountvar & "','" & periodvar & "','" & paycaldatevar & "','" & yearvar & "','" & monthvar & "','" & fixedtaxvar & "','" & allowvar & "','" & deduvar & "','" & netpayvar & "')"

                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Cd.ExecuteNonQuery()
                'MessageBox.Show("Paysum populated")
            End Using
            Me.statuspoint.Text = "Paysum populated"
        Catch ex As Exception
            Me.statuspoint.Text = ex.Message

        End Try
        'Me.statuspoint.Text = "Processing Completed Sucessfully......."
        getpayvalues()
    End Sub

    Sub getpayvalues()
        Me.statuspoint.Text = "Processing Please wait"
        MDIParent1.statusmsg2.Text = "Processing please wait"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "Select Distinct staffid,pic,amount from defaulttab  where amount > 0"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()
                        UpdatePayvalues(r(0), r(1), r(2))
                    Loop
                    '   r.Close()
                Else
                    MDIParent1.statusmsg2.Text = "No defaulttab Record Selected"
                    '      Exit Sub
                End If
            End Using
        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()
            '  MesgBox("Process Completed Successfully")
        End Try
        getloanvalues()


    End Sub
    Sub UpdatePayvalues(ByVal staffidv As String, ByVal itemv As String, ByVal amountv As Double)
        Me.statuspoint.Text = "payroll Updated with values"

        Dim sumSQL As String = "UPDATE paysum SET" _
      & " pamount = '" & amountv & "' " & " WHERE " & " staffid = '" & staffidv & "' and pic = '" & itemv & "' "
        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()
            Me.statuspoint.Text = "payroll Updated with values"
        End Try
        Me.statuspoint.Text = "Processing Please wait"
    End Sub
    Sub getloanvalues()
        Me.statuspoint.Text = "Processing please wait, Updating Loan"
        'SELECT pic,amtcollected,dcollected,sdate,mpayment,pperiod,premaining,paidtoadate FROM loantab
        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim DSQL As String = "Select Distinct staffid,pic,mpayment from loantab where paidtoadate !> amtcollected and amtcollected-paidtoadate !< mpayment"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                ' Me.statuspoint.Text = "Processing"
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()
                        Updateloanvalues(r(0), r(1), r(2))
                    Loop
                    r.Close()
                Else
                    Me.statuspoint.Text = "No Loan Record Selected"
                    '     Exit Sub
                End If

            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()
            Me.statuspoint.Text = "Processing please wait, Updating Loan"
        End Try
        getsummaryvalues()
        Me.statuspoint.Text = "Processing Please wait"
    End Sub
    Sub Updateloanvalues(ByVal staffidv As String, ByVal itemv As String, ByVal amountv As Double)

        Me.statuspoint.Text = "Editing Record "
        Dim sumSQL As String = "UPDATE paysum SET" _
      & " pamount = '" & amountv & "' " & " WHERE " & " staffid = '" & staffidv & "' and pic = '" & itemv & "' "
        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()

                Cd2.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            '  CCNN.Close()
            Me.statuspoint.Text = "Processing Loan Values please wait"
        End Try
        Me.statuspoint.Text = "Processing Please wait"
    End Sub

    Sub getsummaryvalues()

        Me.statuspoint.Text = "Processing please wait, Updating Summary"

        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim DSQL As String = "Select Distinct sum(pamount) as pamount,staffid from paysum where pictype = 'Allow' or pictype='Basic' Group by staffid"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()
                        Updatesummarytab1(r(0), r(1))
                    Loop
                    r.Close()
                End If
            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            ' Me.statuspoint.Text = "Processing please wait, Updating Summary"
            'CCNN.Close()
            '  MesgBox("Process Completed Successfully")
        End Try
        'dedu()
        Me.statuspoint.Text = "Processing Please wait"
        getDEDUCTIONS()
    End Sub

    Sub Updatesummarytab1(ByVal earningsv As Double, ByVal staffidv As String)
        Me.statuspoint.Text = "Editing Record "
        Dim sumSQL As String = "UPDATE summarytab SET" _
      & " totalallowance = '" & earningsv & "' " & " WHERE " & " staffid = '" & staffidv & "' "

        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '  Me.statuspoint.Text = "Record Updated Successfully"  
            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()

        End Try
    End Sub
    Sub getDEDUCTIONS()
        '   If Not IsPostBack Then  
        Me.statuspoint.Text = "Processing please wait"
        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim DSQL3 As String = "Select Distinct sum(pamount) as pamount,staffid from paysum where pictype = 'Dedu' Group by staffid"
                'Dim DSQL3 As String = "Select Distinct sum(pamount) as pamount,staffid from payroll where  itemtype='L' or itemtype='S' or itemtype='D' Group by staffid"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL3
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()

                        DODEDUCTIONS(r(0), r(1))
                    Loop
                    r.Close()
                Else
                    Me.statuspoint.Text = "No Sum Allowance Record Selected"
                    ' Exit Sub
                End If

            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()
            Me.statuspoint.Text = "Processing Deductions please wait"
            '  MesgBox("Process Completed Successfully")
        End Try
        ' End If
        UpdatesummaryNet()
        '  Me.statuspoint.Text = "Processing Please wait"
    End Sub
    Sub DODEDUCTIONS(ByVal earningsv As Double, ByVal staffidv As String)
        Me.statuspoint.Text = "Editing Record "
        Dim sumSQL As String = "UPDATE summarytab SET" _
      & " totaldeduction = fixedtax + '" & earningsv & "' " & " WHERE " & " staffid = '" & staffidv & "' "

        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                '  Me.statuspoint.Text = "Record Updated Successfully"  
            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            'CCNN.Close()
        End Try


    End Sub

    Sub UpdatesummaryNet()
        'MesgBox("Updating Gross")
        Me.statuspoint.Text = "Processing please wait, Updating Summary todate"
        Dim sumSQL As String = "UPDATE summarytab SET netpay = totalallowance-totaldeduction "
        Try
            Using CCNN As New SqlConnection(My.Settings.CnnString)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
                Cd2.Dispose()
            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        
        End Try
        '  Me.statuspoint.Text = "Processing Please wait"
        Updatesummaryinpayroll()
        'MessageBox.Show("Process Completed Successfully")
    End Sub
    Sub Updatesummaryinpayroll()
        Me.statuspoint.Text = "Processing please wait, Updating Summary"
        'MessageBox.Show("Paysum summary update")
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim DSQL As String = "Select staffid,fixedtax,totalallowance,totaldeduction,netpay from summarytab"
                Dim Cd As SqlCommand = CCNN.CreateCommand
                Cd.CommandText = DSQL
                Cd.CommandType = CommandType.Text
                CCNN.Open()
                Dim r As SqlDataReader = Cd.ExecuteReader
                If r.HasRows Then
                    Do While r.Read()
                        getpaysumsumarry(r(0), r(1), r(2), r(3), r(4))
                    Loop
                    r.Close()
                End If
            End Using

        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally

        End Try
        MDIParent1.statusmsg2.Text = "Process Completed Successfully"
        Me.statuspoint.Text = "Process Completed Successfully"
        '  
    End Sub
    Sub getpaysumsumarry(ByVal staffidv As String, ByVal ftaxv As Double, ByVal allowav As Double, ByVal deduv As Double, ByVal netpayv As Double)
        Me.statuspoint.Text = "Editing Record "
        Dim sumSQL As String = "UPDATE paysum SET" _
      & " fixedtax = '" & ftaxv & "'," & " totalallowance = '" & allowav & "'," & " totaldeduction = '" & deduv & "'," & " netpay = '" & netpayv & "' " & " WHERE " & " staffid = '" & staffidv & "'"
        Try
            Using CCNN As New SqlConnection(My.Settings.cnnstring)
                Dim Cd2 As SqlCommand = CCNN.CreateCommand
                Cd2.CommandText = sumSQL
                Cd2.CommandType = CommandType.Text
                CCNN.Open()
                Cd2.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Me.statuspoint.Text = ex.Message
        Finally
            '  CCNN.Close()
            Me.statuspoint.Text = "Processing Loan Values please wait"
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

    Private Sub procespay_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class