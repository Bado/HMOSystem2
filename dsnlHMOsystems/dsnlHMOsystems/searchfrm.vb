
Imports System.Data

Imports System.Data.SqlClient

Imports System.Runtime.InteropServices

Public Class searchfrm
    Private Idx As Integer
    '<DllImport("user32.dll", SetLastError:=True)> _
    'Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean
    'End Function

    'Private Const SWP_NOSIZE As Integer = &H1
    'Private Const SWP_NOMOVE As Integer = &H2

    'Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    'Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)

    'Public Function MakeTopMost()
    '    SetWindowPos(Me.Handle(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
    'End Function

    'Public Function MakeNormal()
    '    SetWindowPos(Me.Handle(), HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
    'End Function
    Private Sub searchfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.TopMost = True
        CODDY = ""
        Dim i2 As Integer
        For i2 = i2 To answersheettab.RowCount - 1
            answersheettab.Rows.Clear()
        Next

        Dim gg2 As String = gsql
        Try
            Using ccnn As New SqlConnection(My.Settings.cnnstring)
                Dim cd As SqlCommand = ccnn.CreateCommand

                cd.CommandText = gg2
                cd.CommandType = CommandType.Text
                ccnn.Open()
                Dim r As SqlDataReader = cd.ExecuteReader
                If r.HasRows() Then
                    While r.Read
                        ' MessageBox.Show(r(1))
                        Dim row As Integer = answersheettab.Rows.Add
                        answersheettab.Rows(row).Cells(0).Value = r(0)
                        answersheettab.Rows(row).Cells(1).Value = r(1)
                        answersheettab.Rows(row).Cells(2).Value = r(2)
                    End While
                End If

                r.Close()
                Me.Refresh()
            End Using
        Catch ex As Exception
            MDIParent1.statusmsg.Text = ex.Message
        End Try
        'MakeTopMost()
    End Sub

    Private Sub answersheettab_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles answersheettab.CellContentClick
        ' Dim name As String = answersheettab.SelectedCells..SelectedRow.Cells(0).Text
    End Sub
    'My.Settings.callformname
    Private Sub answersheettab_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles answersheettab.CellContentDoubleClick
        CODDY = ""
        If answersheettab.Rows.Count = 0 Then Exit Sub
        Idx = e.RowIndex
        sresultt.Text = Trim(answersheettab.Rows(e.RowIndex).Cells(0).Value)
        DESCC = Trim(answersheettab.Rows(e.RowIndex).Cells(1).Value)
        DESCC1.Text = Trim(answersheettab.Rows(e.RowIndex).Cells(1).Value)
        'Dim ssse As New setupfrm
        'ssse.Code.Text = Stringresult
        CODDY = Trim(sresultt.Text)
        ' MessageBox.Show(CODDY)
        DESCC = Trim(DESCC1.Text)
        'ssse.Code.Refresh()
        Me.Hide()
        Return








    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs)


    End Sub


    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
    '    If RadioButton1.Checked Then
    '        answersheettab.ClearSelection()
    '        For Each row As DataGridViewRow In answersheettab.Rows
    '            For Each cell As DataGridViewCell In row.Cells
    '                If cell.Value.StartsWith(TextBox1.Text, StringComparison.InvariantCultureIgnoreCase) Then
    '                    cell.Selected = True
    '                    '  cell.Style.BackColor = Color.Red
    '                    answersheettab.CurrentCell = answersheettab.SelectedCells(0)
    '                    statusmsg2.Text = "Match .... in progress"
    '                    'Exit For
    '                Else
    '                    statusmsg2.Text = "No Match"
    '                End If
    '            Next
    '        Next
    '        answersheettab.Visible = True
    '    End If
    '    answersheettab.Refresh()

    '    If RadioButton2.Checked Then
    '        answersheettab.ClearSelection()
    '        For Each row As DataGridViewRow In answersheettab.Rows
    '            For Each cell As DataGridViewCell In row.Cells
    '                If cell.Value.StartsWith(TextBox1.Text, StringComparison.InvariantCultureIgnoreCase) Then
    '                    cell.Selected = True
    '                    '   cell.Style.BackColor = Color.Red
    '                    answersheettab.CurrentCell = answersheettab.SelectedCells(0)
    '                    ' row.Cells.Item("ID").Style.BackColor = Color.Red

    '                    'Exit For
    '                End If
    '            Next
    '        Next
    '        answersheettab.Visible = True
    '    End If
    '    answersheettab.Refresh()

    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim temp As Integer = 0
    '    For i As Integer = 0 To answersheettab.RowCount - 1
    '        For j As Integer = 0 To answersheettab.ColumnCount - 1
    '            If answersheettab.Rows(i).Cells(j).Value.ToString = TextBox1.Text Then
    '                MsgBox("Item found")
    '                temp = 1
    '            End If
    '        Next
    '    Next
    '    answersheettab.Refresh()
    '    If temp = 0 Then
    '        MsgBox("Item not found")
    '    End If
    'End Sub



    'Private Sub assignfolder_SelectedIndexChanged(sender As Object, e As EventArgs)

    '    '   answersheettab.ClearSelection()
    '    For Each row As DataGridViewRow In answersheettab.Rows
    '        For Each cell As DataGridViewCell In row.Cells
    '            If cell.Value.StartsWith(assignfolder.SelectedValue, StringComparison.InvariantCultureIgnoreCase) Then
    '                cell.Selected = True
    '                '   cell.Style.BackColor = Color.Red
    '                answersheettab.CurrentCell = answersheettab.SelectedCells(0)
    '                ' row.Cells.Item("ID").Style.BackColor = Color.Red

    '                'Exit For
    '            End If
    '        Next
    '    Next
    '    answersheettab.Visible = True
    '    answersheettab.Refresh()

    'End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'Try
        '    For Each row As DataGridViewRow In answersheettab.Rows
        '        For Each cell As DataGridViewCell In row.Cells
        '            If cell.Value.StartsWith(TextBox1.Text, StringComparison.InvariantCultureIgnoreCase) Then
        '                cell.Selected = True
        '                '   cell.Style.BackColor = Color.Red
        '                answersheettab.CurrentCell = answersheettab.SelectedCells(0)
        '                ' row.Cells.Item("ID").Style.BackColor = Color.Red

        '                'Exit For
        '            End If
        '        Next
        '    Next
        '    answersheettab.Visible = True
        '    answersheettab.Refresh()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        Try
            Dim str As String = TextBox1.Text

            If Me.TextBox1.Text.Trim(" ") = " " Then
            Else
                For i As Integer = 0 To answersheettab.Rows.Count - 1
                    For j As Integer = 0 To Me.answersheettab.Rows(i).Cells.Count - 1
                        If answersheettab.Item(j, i).Value.ToString().ToLower.StartsWith(str.ToLower) Then
                            answersheettab.Rows(i).Selected = True
                            answersheettab.CurrentCell = answersheettab.Rows(i).Cells(j)
                            Exit Try
                        End If
                    Next
                Next i
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try




    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class