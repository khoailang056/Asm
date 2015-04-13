Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class QuanLyLop
    Dim dt As New DataTable
    Dim connect As String = "workstation id=anps02253.mssql.somee.com;packet size=4096;user id=anptps02253_SQLLogin_1;pwd=Abc12345;data source=anps02253.mssql.somee.com;persist security info=False;initial catalog=anps02253"
    Dim Ket_noi As SqlConnection = New SqlConnection(connect)
    Private Sub QuanLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sqlAdapter As New SqlDataAdapter("select * from Lop", Ket_noi)

        Try
            sqlAdapter.Fill(dt)
        Catch ex As Exception

        End Try
        DataGridView2.DataSource = dt
        Ket_noi.Close()
    End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim index As Integer = DataGridView2.CurrentCell.RowIndex
        TextBox1.Text = DataGridView2.Item(0, index).Value
        TextBox2.Text = DataGridView2.Item(1, index).Value
        TextBox3.Text = DataGridView2.Item(2, index).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Bạn hãy điền đày đủ thông tin", vbOKOnly + vbCritical, "Thông báo")

        Else
            Ket_noi.Open()
            Dim edid As String = "insert into Lop Values (@MaLop,@TenLop,@SiSo)"
            Dim com As SqlCommand = New SqlCommand(edid, Ket_noi)
            Try
                com.Parameters.AddWithValue("@MaLop", TextBox1.Text)
                com.Parameters.AddWithValue("@TenLop", TextBox2.Text)
                com.Parameters.AddWithValue("@SiSo", TextBox3.Text)


                com.ExecuteNonQuery()

                Ket_noi.Close()
                MessageBox.Show("Thêm thành công", "Thông Báo")
            Catch ex As Exception
                MessageBox.Show("Thêm không thành công", "Thông Báo")
            End Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()


            dt.Clear()
            DataGridView2.DataSource = dt
            DataGridView2.DataSource = Nothing
            LoadData()
        End If
    End Sub

    Private Sub LoadData()
        Dim sqlAdapter As New SqlDataAdapter("select * from Lop", Ket_noi)

        Try
            sqlAdapter.Fill(dt)
        Catch ex As Exception

        End Try
        DataGridView2.DataSource = dt
        Ket_noi.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Ket_noi.Open()
        Dim dk As Integer = DataGridView2.CurrentCell.RowIndex
        Dim tes As String = DataGridView2.Item(0, dk).Value
        Dim stradd As String = "Delete from Lop Where MaLop =@MaLop"
        Dim com As New SqlCommand(stradd, Ket_noi)
        Try
            com.Parameters.AddWithValue("@MaLop", tes)
            com.ExecuteNonQuery()
            Ket_noi.Close()
        Catch ex As Exception

        End Try
        dt.Clear()
        DataGridView2.DataSource = dt
        DataGridView2.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Ket_noi.Open()

        Dim ed As String = "UPDATE Lop SET TenLop=@TenLop , SiSo =@SiSo WHERE MaLop = @MaLop"
        Dim com1 As New SqlCommand(ed, Ket_noi)
        Try
            com1.Parameters.AddWithValue("@MaLop", TextBox1.Text)
            com1.Parameters.AddWithValue("@TenLop", TextBox2.Text)
            com1.Parameters.AddWithValue("@SiSo", TextBox3.Text)

            com1.ExecuteNonQuery()

            Ket_noi.Close()
            MessageBox.Show("Sửa thành công", "Thông Báo")
        Catch ex As Exception
            MessageBox.Show("Sửa không thành công", "Thông Báo")
        End Try
        dt.Clear()
        DataGridView2.DataSource = dt
        DataGridView2.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (MessageBox.Show("Bạn có chắc chắn muốn thoát !!!", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            TrangChinh.Show()
        End If
    End Sub

    Private Sub QuanLyLop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class