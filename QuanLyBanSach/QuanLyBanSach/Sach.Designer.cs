namespace QuanLyBanSach
{
    partial class Form_Sach
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnAddTacGia = new System.Windows.Forms.Button();
            this.btnAddNXB = new System.Windows.Forms.Button();
            this.btnAddTheLoai = new System.Windows.Forms.Button();
            this.dateNamXB = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNgonNgu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHinhAnh = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbo_TacGia = new System.Windows.Forms.ComboBox();
            this.cbo_NhaXB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_Sach_LoaiSach = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Sach_TenSach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Sach_Xoa = new System.Windows.Forms.Button();
            this.btn_Sach_Sua = new System.Windows.Forms.Button();
            this.btn_Sach_Them = new System.Windows.Forms.Button();
            this.errSoLuong = new System.Windows.Forms.ErrorProvider(this.components);
            this.errGiaBan = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTenSach = new System.Windows.Forms.ErrorProvider(this.components);
            this.errNgonNgu = new System.Windows.Forms.ErrorProvider(this.components);
            this.errNamXB = new System.Windows.Forms.ErrorProvider(this.components);
            this.errHinhAnh = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNgonNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNamXB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 604);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(1187, 271);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnLamMoi);
            this.panel2.Controls.Add(this.btnAddTacGia);
            this.panel2.Controls.Add(this.btnAddNXB);
            this.panel2.Controls.Add(this.btnAddTheLoai);
            this.panel2.Controls.Add(this.dateNamXB);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtNgonNgu);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtHinhAnh);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.cbo_TacGia);
            this.panel2.Controls.Add(this.cbo_NhaXB);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSoLuong);
            this.panel2.Controls.Add(this.txtGiaBan);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbo_Sach_LoaiSach);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_Sach_TenSach);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_Sach_Xoa);
            this.panel2.Controls.Add(this.btn_Sach_Sua);
            this.panel2.Controls.Add(this.btn_Sach_Them);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(0, 279);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 319);
            this.panel2.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(376, 246);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 45);
            this.btnLamMoi.TabIndex = 34;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnAddTacGia
            // 
            this.btnAddTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTacGia.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnAddTacGia.Location = new System.Drawing.Point(736, 94);
            this.btnAddTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTacGia.Name = "btnAddTacGia";
            this.btnAddTacGia.Size = new System.Drawing.Size(31, 25);
            this.btnAddTacGia.TabIndex = 33;
            this.btnAddTacGia.Text = "...";
            this.btnAddTacGia.UseVisualStyleBackColor = true;
            this.btnAddTacGia.Click += new System.EventHandler(this.btnAddTacGia_Click);
            // 
            // btnAddNXB
            // 
            this.btnAddNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNXB.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnAddNXB.Location = new System.Drawing.Point(736, 29);
            this.btnAddNXB.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNXB.Name = "btnAddNXB";
            this.btnAddNXB.Size = new System.Drawing.Size(31, 24);
            this.btnAddNXB.TabIndex = 32;
            this.btnAddNXB.Text = "...";
            this.btnAddNXB.UseVisualStyleBackColor = true;
            this.btnAddNXB.Click += new System.EventHandler(this.btnAddNXB_Click);
            // 
            // btnAddTheLoai
            // 
            this.btnAddTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTheLoai.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnAddTheLoai.Location = new System.Drawing.Point(362, 94);
            this.btnAddTheLoai.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTheLoai.Name = "btnAddTheLoai";
            this.btnAddTheLoai.Size = new System.Drawing.Size(31, 24);
            this.btnAddTheLoai.TabIndex = 29;
            this.btnAddTheLoai.Text = "...";
            this.btnAddTheLoai.UseVisualStyleBackColor = true;
            this.btnAddTheLoai.Click += new System.EventHandler(this.btnAddTheLoai_Click);
            // 
            // dateNamXB
            // 
            this.dateNamXB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNamXB.Location = new System.Drawing.Point(890, 30);
            this.dateNamXB.Name = "dateNamXB";
            this.dateNamXB.Size = new System.Drawing.Size(261, 22);
            this.dateNamXB.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(788, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Năm XB";
            // 
            // txtNgonNgu
            // 
            this.txtNgonNgu.Location = new System.Drawing.Point(486, 165);
            this.txtNgonNgu.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgonNgu.Multiline = true;
            this.txtNgonNgu.Name = "txtNgonNgu";
            this.txtNgonNgu.Size = new System.Drawing.Size(261, 43);
            this.txtNgonNgu.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(381, 174);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "Ngôn ngữ";
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.AutoSize = true;
            this.txtHinhAnh.Location = new System.Drawing.Point(112, 243);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(0, 17);
            this.txtHinhAnh.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(21, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Hình ảnh:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(129, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cbo_TacGia
            // 
            this.cbo_TacGia.FormattingEnabled = true;
            this.cbo_TacGia.Location = new System.Drawing.Point(503, 95);
            this.cbo_TacGia.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_TacGia.Name = "cbo_TacGia";
            this.cbo_TacGia.Size = new System.Drawing.Size(225, 24);
            this.cbo_TacGia.TabIndex = 21;
            this.cbo_TacGia.Click += new System.EventHandler(this.cbo_TacGia_Click);
            // 
            // cbo_NhaXB
            // 
            this.cbo_NhaXB.FormattingEnabled = true;
            this.cbo_NhaXB.Location = new System.Drawing.Point(503, 28);
            this.cbo_NhaXB.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_NhaXB.Name = "cbo_NhaXB";
            this.cbo_NhaXB.Size = new System.Drawing.Size(225, 24);
            this.cbo_NhaXB.TabIndex = 20;
            this.cbo_NhaXB.Click += new System.EventHandler(this.cbo_NhaXB_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(416, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nhà XB";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(890, 95);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoLuong.Multiline = true;
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(261, 38);
            this.txtSoLuong.TabIndex = 18;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(890, 165);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaBan.Multiline = true;
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(261, 40);
            this.txtGiaBan.TabIndex = 17;
            this.txtGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBan_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(791, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Giá Bán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(776, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số Lượng";
            // 
            // cbo_Sach_LoaiSach
            // 
            this.cbo_Sach_LoaiSach.FormattingEnabled = true;
            this.cbo_Sach_LoaiSach.Location = new System.Drawing.Point(129, 94);
            this.cbo_Sach_LoaiSach.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_Sach_LoaiSach.Name = "cbo_Sach_LoaiSach";
            this.cbo_Sach_LoaiSach.Size = new System.Drawing.Size(225, 24);
            this.cbo_Sach_LoaiSach.TabIndex = 8;
            this.cbo_Sach_LoaiSach.Click += new System.EventHandler(this.cbo_Sach_LoaiSach_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(21, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loại Sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(414, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tác Giả";
            // 
            // txt_Sach_TenSach
            // 
            this.txt_Sach_TenSach.Location = new System.Drawing.Point(129, 24);
            this.txt_Sach_TenSach.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Sach_TenSach.Multiline = true;
            this.txt_Sach_TenSach.Name = "txt_Sach_TenSach";
            this.txt_Sach_TenSach.Size = new System.Drawing.Size(225, 40);
            this.txt_Sach_TenSach.TabIndex = 4;
            this.txt_Sach_TenSach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Sach_TenSach_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên Sách";
            // 
            // btn_Sach_Xoa
            // 
            this.btn_Sach_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sach_Xoa.Image = global::QuanLyBanSach.Properties.Resources.iconXoa;
            this.btn_Sach_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sach_Xoa.Location = new System.Drawing.Point(963, 244);
            this.btn_Sach_Xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sach_Xoa.Name = "btn_Sach_Xoa";
            this.btn_Sach_Xoa.Size = new System.Drawing.Size(96, 51);
            this.btn_Sach_Xoa.TabIndex = 2;
            this.btn_Sach_Xoa.Text = "Xóa";
            this.btn_Sach_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sach_Xoa.UseVisualStyleBackColor = true;
            this.btn_Sach_Xoa.Click += new System.EventHandler(this.btn_Sach_Xoa_Click);
            // 
            // btn_Sach_Sua
            // 
            this.btn_Sach_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sach_Sua.Image = global::QuanLyBanSach.Properties.Resources.iconSua2;
            this.btn_Sach_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sach_Sua.Location = new System.Drawing.Point(781, 244);
            this.btn_Sach_Sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sach_Sua.Name = "btn_Sach_Sua";
            this.btn_Sach_Sua.Size = new System.Drawing.Size(113, 51);
            this.btn_Sach_Sua.TabIndex = 1;
            this.btn_Sach_Sua.Text = "Sửa";
            this.btn_Sach_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sach_Sua.UseVisualStyleBackColor = true;
            this.btn_Sach_Sua.Click += new System.EventHandler(this.btn_Sach_Sua_Click);
            // 
            // btn_Sach_Them
            // 
            this.btn_Sach_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sach_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sach_Them.Image = global::QuanLyBanSach.Properties.Resources.iconThem;
            this.btn_Sach_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sach_Them.Location = new System.Drawing.Point(581, 246);
            this.btn_Sach_Them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Sach_Them.Name = "btn_Sach_Them";
            this.btn_Sach_Them.Size = new System.Drawing.Size(115, 47);
            this.btn_Sach_Them.TabIndex = 0;
            this.btn_Sach_Them.Text = "Thêm";
            this.btn_Sach_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sach_Them.UseVisualStyleBackColor = true;
            this.btn_Sach_Them.Click += new System.EventHandler(this.btn_Sach_Them_Click);
            // 
            // errSoLuong
            // 
            this.errSoLuong.ContainerControl = this;
            // 
            // errGiaBan
            // 
            this.errGiaBan.ContainerControl = this;
            // 
            // errTenSach
            // 
            this.errTenSach.ContainerControl = this;
            // 
            // errNgonNgu
            // 
            this.errNgonNgu.ContainerControl = this;
            // 
            // errNamXB
            // 
            this.errNamXB.ContainerControl = this;
            // 
            // errHinhAnh
            // 
            this.errHinhAnh.ContainerControl = this;
            // 
            // Form_Sach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 621);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Sach";
            this.Text = "Sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Sach_FormClosing);
            this.Load += new System.EventHandler(this.Form_Sach_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTenSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNgonNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errNamXB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_Sach_LoaiSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Sach_TenSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Sach_Xoa;
        private System.Windows.Forms.Button btn_Sach_Sua;
        private System.Windows.Forms.Button btn_Sach_Them;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.ComboBox cbo_NhaXB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_TacGia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtHinhAnh;
        private System.Windows.Forms.TextBox txtNgonNgu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateNamXB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errSoLuong;
        private System.Windows.Forms.ErrorProvider errGiaBan;
        private System.Windows.Forms.ErrorProvider errTenSach;
        private System.Windows.Forms.ErrorProvider errNgonNgu;
        private System.Windows.Forms.ErrorProvider errNamXB;
        private System.Windows.Forms.ErrorProvider errHinhAnh;
        private System.Windows.Forms.Button btnAddTacGia;
        private System.Windows.Forms.Button btnAddNXB;
        private System.Windows.Forms.Button btnAddTheLoai;
        private System.Windows.Forms.Button btnLamMoi;
    }
}