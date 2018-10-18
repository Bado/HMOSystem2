Imports System.Data.SqlClient
Module CheckCodestab
    Public descvar As String = ""
    Public gsql As String

    Enum enumObjectType
        StrType = 0
        IntType = 1
        DblType = 2
    End Enum
    Public Function CheckDBNull(ByVal obj As Object, _
   Optional ByVal ObjectType As enumObjectType = enumObjectType.StrType) As Object
        Dim objReturn As Object
        ' MessageBox.Show(obj)
        objReturn = obj
        If ObjectType = enumObjectType.StrType And IsDBNull(obj) Then
            objReturn = ""
        ElseIf ObjectType = enumObjectType.IntType And IsDBNull(obj) Then
            objReturn = 0
        ElseIf ObjectType = enumObjectType.DblType And IsDBNull(obj) Then
            objReturn = 0.0
        End If
        Return objReturn
    End Function
    Public Function premiumplan(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT code1,descr,type FROM premiumplan WHERE" & " code1 = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function enrolleetabcheck(ByVal CODEE As String) As String
        '  MessageBox.Show(CODEE)
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT surname,enrolleeid FROM enrolleetab WHERE rtrim(enrolleeid) = '" & RTrim(CODEE) & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.HasRows Then
                sumr.Read()
                descvar = sumr(1)
               
            End If
            sumr.Close()
        End Using
        Return CODEE
    End Function
    Public Function gethcpaccode(ByVal CODEE As String) As String

        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT hcpid,glcode Q    hcptab WHERE rtrim(hcpid) = '" & RTrim(CODEE) & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.HasRows Then
                sumr.Read()
                descvar = sumr(1)
            End If
            sumr.Close()
        End Using
        Return CODEE
    End Function
    Public Function Ailmenttypedefault(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT code1,descr,amount FROM Ailmenttypedefault WHERE" & " code1 = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function payitemsSearch(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT itemcode,itemdescr FROM payitems WHERE" & " itemcode = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function enrollname(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "select enrolleeid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from enrolleetab WHERE" & " enrolleeid = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function enrollname2(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "select rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names,enrolleeid from enrolleetab WHERE" & " enrolleeid = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function hcptabname2(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "select names,hcpid from hcptab WHERE" & " hcpid = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function FAMILYINFO3(ByVal CODEE As String) As String

        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT  ftype,names,alterHCP,dofb,age,sex,Enrolleeid FROM Familyinfo WHERE" & " Enrolleeid = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function

    Public Function ogatabname2(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "select oganames,ogaid from oganisationtab WHERE" & " ogaid = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function

    Public Function stafftabname(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "select staffid,rtrim(surname) + ' ' + rtrim(firstname) + ' ' + rtrim(othernames) as names from stafftab WHERE" & " staffid = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function oganisationnames(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT ogaid,oganames FROM oganisationtab WHERE" & " code1 = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    ' If Not r.IsDBNull(2) Then CheckCodestab.premiumplan(r(2))
    '       Me.subject.Text = CheckCodestab.descvar
    '


    Public Function CALLCODESTAB(ByVal scoddy As String, ByVal opt As String) As String

        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT code1,descr,option1 FROM codestab WHERE" & " CODE1 = '" & scoddy & "'" & " and " & " option1 = '" & opt & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
                scoddy = sumr(1)
            End If
            sumr.Close()
        End Using
        Return scoddy
        Return opt

    End Function
    Public Function TAXREGION(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT TAXREGION,REGIONNAME FROM TAXRGN WHERE" & " TAXREGION = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    Public Function bankdesc(ByVal CODEE As String) As String
        Using CCNN As New SqlConnection(My.Settings.cnnstring)
            gsqlCODE = "SELECT bankcode,names,branch FROM BANKSETUP WHERE" & " bankcode = '" & CODEE & "'"
            Dim sumSQL As String = gsqlCODE
            Dim sumCd As SqlCommand = CCNN.CreateCommand
            sumCd.CommandText = sumSQL
            sumCd.CommandType = CommandType.Text
            CCNN.Open()
            Dim sumr As SqlDataReader = sumCd.ExecuteReader
            If sumr.Read = True Then
                descvar = sumr(1)
            End If
            sumr.Close()
            '
        End Using
        Return CODEE
    End Function
    'How to disable a Menu Item
    ' For Each mnu As ToolStripMenuItem In Me.MS.Items
    '        If mnu.Name = "File" Then
    '            For Each mnu1 As Object In mnu.DropDownItems
    '                If mnu1.Name = "OpenFile" Then
    ''  mnu1.Enabled = False
    '                End If
    '            Next
    '        End If
    '    Next
End Module
