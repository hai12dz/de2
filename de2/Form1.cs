using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace de2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connectionString = @"Data Source=hai\SQLEXPRESS;Initial Catalog=DuLieu;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT TenChatLieu FROM tblChatLieu", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxChatLieu.Items.Add(reader["TenChatLieu"].ToString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=hai\SQLEXPRESS;Initial Catalog=DuLieu;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MaChatLieu, TenChatLieu FROM tblChatLieu", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxChatLieu.Items.Add(new
                    {
                        MaChatLieu = reader["MaChatLieu"].ToString(),
                        TenChatLieu = reader["TenChatLieu"].ToString()
                    });
                }
            }
        }

        private void textBoxDonGiaBanTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDonGiaBanDen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Bắt đầu xây dựng câu lệnh SQL với điều kiện mặc định
            string query = @"
    SELECT 
        h.MaHang, 
        h.TenHang, 
        c.TenChatLieu, 
        h.DonGiaNhap, 
        h.DonGiaBan, 
        h.SoLuong
    FROM 
        tblHang h
    JOIN 
        tblChatLieu c ON h.MaChatLieu = c.MaChatLieu
    WHERE 1=1";

            // Kiểm tra và thêm điều kiện cho Mã Hàng (LIKE)
            if (!string.IsNullOrEmpty(textBoxMaHang.Text))
            {
                query += " AND h.MaHang LIKE @MaHang";
            }

            // Kiểm tra và thêm điều kiện cho Tên Hàng (LIKE)
            if (!string.IsNullOrEmpty(textBoxTenHang.Text))
            {
                query += " AND h.TenHang LIKE @TenHang";
            }

            // Kiểm tra và thêm điều kiện cho Chất Liệu (ComboBox)
            if (comboBoxChatLieu.SelectedItem != null)
            {
                query += " AND c.TenChatLieu = @ChatLieu";
            }

            // Kiểm tra và thêm điều kiện cho Đơn giá từ (>=)
            if (!string.IsNullOrEmpty(textBoxDonGiaBanTu.Text))
            {
                query += " AND h.DonGiaBan >= @DonGiaBanTu";
            }

            // Kiểm tra và thêm điều kiện cho Đơn giá đến (<=)
            if (!string.IsNullOrEmpty(textBoxDonGiaBanDen.Text))
            {
                query += " AND h.DonGiaBan <= @DonGiaBanDen";
            }

            // Mở kết nối đến cơ sở dữ liệu và thực hiện tìm kiếm
            using (SqlConnection connection = new SqlConnection(@"Data Source=hai\SQLEXPRESS;Initial Catalog=DuLieu;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số vào câu lệnh SQL
                if (!string.IsNullOrEmpty(textBoxMaHang.Text))
                    command.Parameters.AddWithValue("@MaHang", "%" + textBoxMaHang.Text + "%");

                if (!string.IsNullOrEmpty(textBoxTenHang.Text))
                    command.Parameters.AddWithValue("@TenHang", "%" + textBoxTenHang.Text + "%");

                if (comboBoxChatLieu.SelectedItem != null)
                    command.Parameters.AddWithValue("@ChatLieu", comboBoxChatLieu.SelectedItem.ToString());

                if (!string.IsNullOrEmpty(textBoxDonGiaBanTu.Text))
                    command.Parameters.AddWithValue("@DonGiaBanTu", Convert.ToDecimal(textBoxDonGiaBanTu.Text));

                if (!string.IsNullOrEmpty(textBoxDonGiaBanDen.Text))
                    command.Parameters.AddWithValue("@DonGiaBanDen", Convert.ToDecimal(textBoxDonGiaBanDen.Text));

                // Mở kết nối và thực thi câu lệnh
                SqlDataAdapter adt = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adt.Fill(dt);

                // Hiển thị kết quả trong DataGridView
                dataGridViewHienThi.DataSource = dt;
            }
        }

        private void btnInRaExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu có dữ liệu trong DataGridView
            if (dataGridViewHienThi.Rows.Count > 0)
            {
                // Tạo đối tượng Excel
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;

                // Tạo workbook và worksheet
                var workBook = excelApp.Workbooks.Add();
                var workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets[1];

                // Lặp qua cột DataGridView và thêm tiêu đề vào Excel
                for (int i = 0; i < dataGridViewHienThi.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = dataGridViewHienThi.Columns[i].HeaderText;
                }

                // Lặp qua các dòng và thêm dữ liệu vào Excel
                for (int i = 0; i < dataGridViewHienThi.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewHienThi.Columns.Count; j++)
                    {
                        var cellValue = dataGridViewHienThi.Rows[i].Cells[j].Value;
                        workSheet.Cells[i + 2, j + 1] = cellValue != null ? cellValue.ToString() : string.Empty;

                    }
                }

                // Lưu file Excel (tuỳ chỉnh tên file hoặc yêu cầu lưu)
                string filePath = @"E:\zalo\trucquan\ktragiuaky\xuatFile\DanhSachMatHang.xlsx"; // Đổi đường dẫn nếu cần
                workBook.SaveAs(filePath);
                workBook.Close();
                excelApp.Quit();

                MessageBox.Show("Đã xuất dữ liệu ra Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridViewHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị Tên Chất Liệu từ cột TênChấtLiệu của dòng đã chọn
                string tenChatLieu = dataGridViewHienThi.Rows[e.RowIndex].Cells["TenChatLieu"].Value.ToString();

                // Tạo câu lệnh SQL để đếm số mặt hàng có chất liệu giống nhau
                string query = "SELECT COUNT(*) FROM tblHang h JOIN tblChatLieu c ON h.MaChatLieu = c.MaChatLieu WHERE c.TenChatLieu = @TenChatLieu";

                // Mở kết nối và thực hiện truy vấn
                using (SqlConnection connection = new SqlConnection(@"Data Source=hai\SQLEXPRESS;Initial Catalog=DuLieu;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenChatLieu", tenChatLieu);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Hiển thị thông báo với số lượng mặt hàng có chất liệu giống nhau
                    MessageBox.Show($"Có {count} mặt hàng có chất liệu '{tenChatLieu}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

     
    }
}
