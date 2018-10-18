Public Class Openningbal


    Private Sub Openningbal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MDIParent1.Panel4.Visible = False
        MDIParent1.Panel5.Visible = False
        MDIParent1.Backpanel1.Dock = DockStyle.Left
        MDIParent1.Backpanel1.Width = 130
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)

    End Sub
End Class