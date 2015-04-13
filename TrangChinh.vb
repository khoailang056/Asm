Public Class TrangChinh

    Private Sub TrangChinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub QuảnLýSinhViênToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýSinhViênToolStripMenuItem.Click
        QuanLySV.Show()
        Me.Hide()
    End Sub

    Private Sub QuảnLýLớpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuảnLýLớpToolStripMenuItem.Click
        QuanLyLop.Show()
        Me.Hide()
    End Sub

    Private Sub ThoátToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThoátToolStripMenuItem.Click
        If (MessageBox.Show("Bạn có chắc chắn muốn thoát !!!", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            Global.System.Windows.Forms.Application.Exit()
        End If
    End Sub
End Class