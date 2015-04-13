Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class QuanLySV

    Dim dt As New DataTable
    Dim connect As String = "workstation id=anps02253.mssql.somee.com;packet size=4096;user id=anptps02253_SQLLogin_1;pwd=Abc12345;data source=anps02253.mssql.somee.com;persist security info=False;initial catalog=anps02253"
    Dim Ket_noi As SqlConnection = New SqlConnection(connect)
    Private Sub QuanLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlAdapter As New SqlDataAdapter("select * from SinhVien", Ket_noi)

        Try
            sqlAdapter.Fill(dt)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = dt
        Ket_noi.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Bạn hãy điền đày đủ thông tin", vbOKOnly + vbCritical, "Thông báo")

        Else
            Ket_noi.Open()
            Dim edid As String = "insert into SinhVien Values (@MaSV,@HovaTenSV,@NgaySinh,@DiaChi,@DienThoai,@Lop_MaLop)"
            Dim com As SqlCommand = New SqlCommand(edid, Ket_noi)
            Try
                com.Parameters.AddWithValue("@MaSV", TextBox1.Text)
                com.Parameters.AddWithValue("@HovaTenSV", TextBox2.Text)
                com.Parameters.AddWithValue("@NgaySinh", TextBox3.Text)
                com.Parameters.AddWithValue("@DiaChi", TextBox4.Text)
                com.Parameters.AddWithValue("@DienThoai", TextBox5.Text)
                com.Parameters.AddWithValue("@Lop_MaLop", TextBox6.Text)

                com.ExecuteNonQuery()

                Ket_noi.Close()
                MessageBox.Show("Thêm thành công", "Thông Báo")
            Catch ex As Exception
                MessageBox.Show("Thêm không thành công", "Thông Báo")
            End Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()

            dt.Clear()
            DataGridView1.DataSource = dt
            DataGridView1.DataSource = Nothing
            LoadData()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        TextBox1.Text = DataGridView1.Item(0, index).Value
        TextBox2.Text = DataGridView1.Item(1, index).Value
        TextBox3.Text = DataGridView1.Item(2, index).Value
        TextBox4.Text = DataGridView1.Item(3, index).Value
        TextBox5.Text = DataGridView1.Item(4, index).Value
        TextBox6.Text = DataGridView1.Item(5, index).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Ket_noi.Open()

        Dim ed As String = "UPDATE SinhVien SET Lop_MaLop=@Lop_MaLop , HovaTenSV =@HovaTenSV,NgaySinh=@NgaySinh,DiaChi=@DiaChi,DienThoai=@DienThoai WHERE MaSV = @MaSV"
        Dim com1 As New SqlCommand(ed, Ket_noi)
        Try
            com1.Parameters.AddWithValue("@MaSV", TextBox1.Text)
            com1.Parameters.AddWithValue("@HovaTenSV", TextBox2.Text)
            com1.Parameters.AddWithValue("@NgaySinh", TextBox3.Text)
            com1.Parameters.AddWithValue("@DiaChi", TextBox4.Text)
            com1.Parameters.AddWithValue("@DienThoai", TextBox5.Text)
            com1.Parameters.AddWithValue("@Lop_MaLop", TextBox6.Text)

            com1.ExecuteNonQuery()

            Ket_noi.Close()
            MessageBox.Show("Sửa thành công", "Thông Báo")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công", "Thông Báo")
        End Try
        dt.Clear()
        DataGridView1.DataSource = dt
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub
    Private Sub LoadData()
        Dim sqlAdapter As New SqlDataAdapter("select * from SinhVien", Ket_noi)

        Try
            sqlAdapter.Fill(dt)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = dt
        Ket_noi.Close()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (MessageBox.Show("Bạn có chắc chắn muốn thoát !!!", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            TrangChinh.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Ket_noi.Open()
        Dim dk As Integer = DataGridView1.CurrentCell.RowIndex
        Dim tes As String = DataGridView1.Item(0, dk).Value
        Dim stradd As String = "Delete from SinhVien Where MaSV =@MaSV"
        Dim com As New SqlCommand(stradd, Ket_noi)
        Try
            com.Parameters.AddWithValue("@MaSV", tes)
            com.ExecuteNonQuery()
            Ket_noi.Close()
        Catch ex As Exception

        End Try
        dt.Clear()
        DataGridView1.DataSource = dt
        DataGridView1.DataSource = Nothing
        LoadData()

    End Sub
End Class