namespace de2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxChatLieu = new System.Windows.Forms.ComboBox();
            this.textBoxTenHang = new System.Windows.Forms.TextBox();
            this.textBoxDonGiaBanDen = new System.Windows.Forms.TextBox();
            this.textBoxDonGiaBanTu = new System.Windows.Forms.TextBox();
            this.textBoxMaHang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnInRaExcel = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dataGridViewHienThi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm hàng hóa";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxChatLieu);
            this.panel1.Controls.Add(this.textBoxTenHang);
            this.panel1.Controls.Add(this.textBoxDonGiaBanDen);
            this.panel1.Controls.Add(this.textBoxDonGiaBanTu);
            this.panel1.Controls.Add(this.textBoxMaHang);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(44, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 156);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxChatLieu
            // 
            this.comboBoxChatLieu.FormattingEnabled = true;
            this.comboBoxChatLieu.Location = new System.Drawing.Point(599, 105);
            this.comboBoxChatLieu.Name = "comboBoxChatLieu";
            this.comboBoxChatLieu.Size = new System.Drawing.Size(158, 24);
            this.comboBoxChatLieu.TabIndex = 13;
            // 
            // textBoxTenHang
            // 
            this.textBoxTenHang.Location = new System.Drawing.Point(599, 48);
            this.textBoxTenHang.Name = "textBoxTenHang";
            this.textBoxTenHang.Size = new System.Drawing.Size(158, 22);
            this.textBoxTenHang.TabIndex = 12;
            // 
            // textBoxDonGiaBanDen
            // 
            this.textBoxDonGiaBanDen.Location = new System.Drawing.Point(328, 105);
            this.textBoxDonGiaBanDen.Name = "textBoxDonGiaBanDen";
            this.textBoxDonGiaBanDen.Size = new System.Drawing.Size(150, 22);
            this.textBoxDonGiaBanDen.TabIndex = 11;
            this.textBoxDonGiaBanDen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDonGiaBanDen_KeyPress);
            // 
            // textBoxDonGiaBanTu
            // 
            this.textBoxDonGiaBanTu.Location = new System.Drawing.Point(156, 105);
            this.textBoxDonGiaBanTu.Name = "textBoxDonGiaBanTu";
            this.textBoxDonGiaBanTu.Size = new System.Drawing.Size(108, 22);
            this.textBoxDonGiaBanTu.TabIndex = 10;
            this.textBoxDonGiaBanTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDonGiaBanTu_KeyPress);
            // 
            // textBoxMaHang
            // 
            this.textBoxMaHang.Location = new System.Drawing.Point(133, 38);
            this.textBoxMaHang.Name = "textBoxMaHang";
            this.textBoxMaHang.Size = new System.Drawing.Size(270, 22);
            this.textBoxMaHang.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(480, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "(VNĐ)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "(VNĐ) đến:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đơn giá bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Chất liệu";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(135, 345);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(98, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnInRaExcel
            // 
            this.btnInRaExcel.Location = new System.Drawing.Point(358, 345);
            this.btnInRaExcel.Name = "btnInRaExcel";
            this.btnInRaExcel.Size = new System.Drawing.Size(112, 23);
            this.btnInRaExcel.TabIndex = 3;
            this.btnInRaExcel.Text = "In ra Excel";
            this.btnInRaExcel.UseVisualStyleBackColor = true;
            this.btnInRaExcel.Click += new System.EventHandler(this.btnInRaExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(557, 345);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dataGridViewHienThi
            // 
            this.dataGridViewHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHienThi.Location = new System.Drawing.Point(44, 425);
            this.dataGridViewHienThi.Name = "dataGridViewHienThi";
            this.dataGridViewHienThi.RowHeadersWidth = 51;
            this.dataGridViewHienThi.RowTemplate.Height = 24;
            this.dataGridViewHienThi.Size = new System.Drawing.Size(758, 330);
            this.dataGridViewHienThi.TabIndex = 5;
            this.dataGridViewHienThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHienThi_CellDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 805);
            this.Controls.Add(this.dataGridViewHienThi);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnInRaExcel);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnInRaExcel;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dataGridViewHienThi;
        private System.Windows.Forms.ComboBox comboBoxChatLieu;
        private System.Windows.Forms.TextBox textBoxTenHang;
        private System.Windows.Forms.TextBox textBoxDonGiaBanDen;
        private System.Windows.Forms.TextBox textBoxDonGiaBanTu;
        private System.Windows.Forms.TextBox textBoxMaHang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

