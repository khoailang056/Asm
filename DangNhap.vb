Imports System.Data.SqlClient

Public Class Login

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim connect As String = "workstation id=anps02253.mssql.somee.com;packet size=4096;user id=anptps02253_SQLLogin_1;pwd=Abc12345;data source=anps02253.mssql.somee.com;persist security info=False;initial catalog=anps02253"

        Dim KetNoi As SqlConnection = New SqlConnection(connect)
        Dim sqlAdapter As New SqlDataAdapter("select * from GiaoVien where MaGV='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "' ", KetNoi)
        Dim dt As New DataTable

        Try
            KetNoi.Open()
            sqlAdapter.Fill(dt)
            If dt.Rows.Count > 0 Then
                MessageBox.Show("kết nối thành công", "Thông báo")
                TrangChinh.Show()
                Me.Hide()
            Else
                MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu", "Thông Báo")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Function Main() As Object
        Throw New NotImplementedException
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
