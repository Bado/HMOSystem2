
Public Class frmMSGctrl
    Dim message_que As New List(Of String)

    Private Sub size_vaildation()
        Me.Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 200, -155)
        Open_timer.Enabled = True
        Open_timer.Start()
    End Sub
    Private Sub frmMSGctrl_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 200, -155)
        Me.ShowInTaskbar = False
        'Show_msg("Notice - School Hours Update", "Today School will finish at 2:30PM in preperation for Parent Teacher interviews." & vbCrLf & "Please remind your parents of their interview times.", MessageType.Information)
        'Show_msg("Message - Blocked Application", "The application ""VLC"" was terminated, it is not allowed during school hours.", MessageType.Warning)
        Show_msg("Message - Blocked Application", "The application ""VLC"" was terminated, it is not allowed during school hours.", MessageType.YellowTheme)
        'Show_msg("Evacuate The School", "Fire Drill In Progress.", MessageType.RedAlert)
    End Sub
    Public Enum MessageType
        Warning
        Information
        Notice
        RedAlert
        YellowTheme
    End Enum
    Public Sub Show_msg(ByVal title As String, ByVal text As String, ByVal typeM As MessageType)
        size_vaildation()
        Select Case (typeM)
            Case MessageType.Warning
                left_pan_colour.BackColor = Color.DarkOrange
                main_pan_colour.BackColor = Color.Bisque
                lbl_text.ForeColor = Color.Black
                lbl_title.ForeColor = Color.Black
            Case MessageType.Information
                left_pan_colour.BackColor = Color.YellowGreen
                main_pan_colour.BackColor = Color.Azure
                lbl_text.ForeColor = Color.Black
                lbl_title.ForeColor = Color.Black
            Case MessageType.Notice
                left_pan_colour.BackColor = Color.SkyBlue
                main_pan_colour.BackColor = Color.Azure
                lbl_text.ForeColor = Color.Black
                lbl_title.ForeColor = Color.Black
            Case MessageType.RedAlert
                left_pan_colour.BackColor = Color.Black
                main_pan_colour.BackColor = Color.Red
                lbl_text.ForeColor = Color.Black
                lbl_title.ForeColor = Color.Black
            Case MessageType.YellowTheme
                left_pan_colour.BackColor = Color.Yellow
                main_pan_colour.BackColor = Color.LightYellow
                lbl_text.ForeColor = Color.Black
                lbl_title.ForeColor = Color.Black
        End Select
        lbl_title.Text = title
        lbl_text.Text = text
    End Sub
    Private Sub Open_timer_Tick(sender As System.Object, e As System.EventArgs) Handles Open_timer.Tick
        If Me.Location.Y = 0 Then
            Open_timer.Stop()
            proxy_timer.Enabled = True
            proxy_timer.Start()
        Else
            Me.Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 200, Me.Location.Y + 1)
        End If
    End Sub
    Private Sub Close_timer_Tick(sender As System.Object, e As System.EventArgs) Handles Close_timer.Tick
        If Me.Location.Y = -155 Then
            Me.Close()
        Else
            Me.Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 200, Me.Location.Y - 1)
        End If
    End Sub
    Private Sub proxy_timer_Tick(sender As System.Object, e As System.EventArgs) Handles proxy_timer.Tick
        proxy_timer.Stop()
        Close_timer.Enabled = True
        Close_timer.Start()
    End Sub
    Private Sub frmMSGctrl_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        proxy_timer.Stop()
    End Sub
    Private Sub frmMSGctrl_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        proxy_timer.Start()
    End Sub
    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Location = New Point(My.Computer.Screen.Bounds.Width / 2 - 200, -155)
        Me.Close()
    End Sub

    Private Sub lbl_text_Click(sender As Object, e As EventArgs) Handles lbl_text.Click

    End Sub
End Class
