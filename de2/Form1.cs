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
        // Khai báo các đối tượng toàn cục
        private string connectionString = @"Data Source=hai\SQLEXPRESS;Initial Catalog=DuLieu;Integrated Security=True;Encrypt=False";
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adt;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseObjects();
            LoadChatLieuComboBox();
        }

        private void InitializeDatabaseObjects()
        {
            // Khởi tạo các đối tượng SqlConnection và SqlCommand để sử dụng trong các phương thức khác
            connection = new SqlConnection(connectionString);
        }

        private void LoadChatLieuComboBox()
        {
            try
            {
                connection.Open();
                command = new SqlCommand("SELECT TenChatLieu FROM tblChatLieu", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxChatLieu.Items.Add(reader["TenChatLieu"].ToString());
                }
            }
            finally
            {
                connection.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Không cần khai báo lại connection trong này
            try
            {
                connection.Open();
                command = new SqlCommand("SELECT MaChatLieu, TenChatLieu FROM tblChatLieu", connection);
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
            finally
            {
                connection.Close();
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

            if (!string.IsNullOrEmpty(textBoxMaHang.Text))
                query += " AND h.MaHang LIKE @MaHang";

            if (!string.IsNullOrEmpty(textBoxTenHang.Text))
                query += " AND h.TenHang LIKE @TenHang";

            if (comboBoxChatLieu.SelectedItem != null)
                query += " AND c.TenChatLieu = @ChatLieu";

            if (!string.IsNullOrEmpty(textBoxDonGiaBanTu.Text))
                query += " AND h.DonGiaBan >= @DonGiaBanTu";

            if (!string.IsNullOrEmpty(textBoxDonGiaBanDen.Text))
                query += " AND h.DonGiaBan <= @DonGiaBanDen";

            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);

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

                adt = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adt.Fill(dt);

                dataGridViewHienThi.DataSource = dt;
          
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnInRaExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewHienThi.Rows.Count > 0)
            {
                var excelApp = new Excel.Application();
                excelApp.Visible = true;

                var workBook = excelApp.Workbooks.Add();
                var workSheet = (Excel.Worksheet)workBook.Sheets[1];

                // Thêm tiêu đề
                workSheet.Cells[1, 2] = "Đào Minh Hải";
                workSheet.Range["B1:H1"].Merge();
                workSheet.Range["B1:H1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workSheet.Range["B1:H1"].Font.Size = 13;
                workSheet.Range["B1:H1"].Font.Bold = true;
                workSheet.Range["B1:H1"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                workSheet.Cells[2, 2] = "Địa Chỉ: VIETNAMESE";
                workSheet.Range["B2:H2"].Merge();
                workSheet.Range["B2:H2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workSheet.Range["B2:H2"].Font.Size = 10;
                workSheet.Range["B2:H2"].Font.Bold = true;

                workSheet.Cells[4, 2] = "HÓA ĐƠN BÁN HÀNG";
                workSheet.Range["B4:H4"].Merge();
                workSheet.Range["B4:H4"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workSheet.Range["B4:H4"].Font.Size = 13;
                workSheet.Range["B4:H4"].Font.Bold = true;
                workSheet.Range["B4:H4"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                // Thêm tiêu đề cột
                workSheet.Cells[6, 2] = "STT";
                workSheet.Cells[6, 3] = "Tên Hàng";
                workSheet.Cells[6, 4] = "Tên Chất Liệu";
                workSheet.Cells[6, 5] = "Số Lượng";
                workSheet.Cells[6, 6] = "Đơn Giá Bán";
                workSheet.Cells[6, 7] = "Ghi Chú";
                workSheet.Cells[6, 8] = "Thành Tiền";
                workSheet.Range["B6:H6"].Font.Bold = true;
                workSheet.Range["B6:H6"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Điền dữ liệu từ DataGridView
                decimal totalAmount = 0;
                for (int i = 0; i < dataGridViewHienThi.Rows.Count-1; i++)
                {
                    workSheet.Cells[i + 7, 2] = (i + 1).ToString();
                    workSheet.Cells[i + 7, 3] = dataGridViewHienThi.Rows[i].Cells["TenHang"].Value?.ToString();
                    workSheet.Cells[i + 7, 4] = dataGridViewHienThi.Rows[i].Cells["TenChatLieu"].Value?.ToString();
                    workSheet.Cells[i + 7, 5] = dataGridViewHienThi.Rows[i].Cells["SoLuong"].Value?.ToString();
                    workSheet.Cells[i + 7, 6] = dataGridViewHienThi.Rows[i].Cells["DonGiaBan"].Value?.ToString();
                    workSheet.Cells[i + 7, 7] = ""; // Để trống cho ghi chú nếu cần

                    // Tính toán "Thành Tiền"
                    decimal soLuong = Convert.ToDecimal(dataGridViewHienThi.Rows[i].Cells["SoLuong"].Value);
                    decimal donGiaBan = Convert.ToDecimal(dataGridViewHienThi.Rows[i].Cells["DonGiaBan"].Value);
                    decimal thanhTien = soLuong * donGiaBan;
                    workSheet.Cells[i + 7, 8] = thanhTien.ToString("N2"); // Định dạng thành tiền

                    totalAmount += thanhTien; // Cộng dồn vào tổng tiền
                }

                // Tính tổng tiền
                int lastRow = dataGridViewHienThi.Rows.Count + 8;
                workSheet.Cells[lastRow, 7] = "TỔNG TIỀN:";
                workSheet.Cells[lastRow, 8].Value = totalAmount; // Ghi tổng tiền
                workSheet.Cells[lastRow, 8].Font.Bold = true;

                // Tự động điều chỉnh độ rộng cột
                workSheet.Columns.AutoFit();

                // Lưu file
                string filePath = @"E:\zalo\trucquan\ktragiuaky\xuatFile\DanhSachMatHang.xlsx"; // Đổi đường dẫn nếu cần
                workBook.SaveAs(filePath);

                MessageBox.Show("Lưu thành công tại " + filePath);

                // Đóng các đối tượng
                workBook.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            else
            {
                MessageBox.Show("Không có danh sách hàng để in.");
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
            if (e.RowIndex >= 0)
            {
                string tenChatLieu = dataGridViewHienThi.Rows[e.RowIndex].Cells["TenChatLieu"].Value.ToString();
                string query = "SELECT COUNT(*) FROM tblHang h JOIN tblChatLieu c ON h.MaChatLieu = c.MaChatLieu WHERE c.TenChatLieu = @TenChatLieu";

                try
                {
                    connection.Open();
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenChatLieu", tenChatLieu);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    MessageBox.Show($"Có {count} mặt hàng có chất liệu '{tenChatLieu}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
