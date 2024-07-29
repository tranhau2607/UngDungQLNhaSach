namespace QuanLyBanSach
{
    partial class Form_LoaiSach
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_LoaiSach_Xoa = new System.Windows.Forms.Button();
            this.btn_LoaiSach_Sua = new System.Windows.Forms.Button();
            this.btn_LoaiSach_Them = new System.Windows.Forms.Button();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(16, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(690, 315);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_LoaiSach_Xoa);
            this.panel2.Controls.Add(this.btn_LoaiSach_Sua);
            this.panel2.Controls.Add(this.btn_LoaiSach_Them);
            this.panel2.Controls.Add(this.txtTheLoai);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(13, 358);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 145);
            this.panel2.TabIndex = 5;
            // 
            // btn_LoaiSach_Xoa
            // 
            this.btn_LoaiSach_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LoaiSach_Xoa.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoaiSach_Xoa.Image = global::QuanLyBanSach.Properties.Resources.iconXoa;
            this.btn_LoaiSach_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LoaiSach_Xoa.Location = new System.Drawing.Point(568, 75);
            this.btn_LoaiSach_Xoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_LoaiSach_Xoa.Name = "btn_LoaiSach_Xoa";
            this.btn_LoaiSach_Xoa.Size = new System.Drawing.Size(101, 48);
            this.btn_LoaiSach_Xoa.TabIndex = 7;
            this.btn_LoaiSach_Xoa.Text = "Xóa";
            this.btn_LoaiSach_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LoaiSach_Xoa.UseVisualStyleBackColor = true;
            this.btn_LoaiSach_Xoa.Click += new System.EventHandler(this.btn_LoaiSach_Xoa_Click);
            // 
            // btn_LoaiSach_Sua
            // 
            this.btn_LoaiSach_Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LoaiSach_Sua.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoaiSach_Sua.Image = global::QuanLyBanSach.Properties.Resources.iconSua2;
            this.btn_LoaiSach_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LoaiSach_Sua.Location = new System.Drawing.Point(346, 75);
            this.btn_LoaiSach_Sua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_LoaiSach_Sua.Name = "btn_LoaiSach_Sua";
            this.btn_LoaiSach_Sua.Size = new System.Drawing.Size(103, 48);
            this.btn_LoaiSach_Sua.TabIndex = 6;
            this.btn_LoaiSach_Sua.Text = "Sửa";
            this.btn_LoaiSach_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LoaiSach_Sua.UseVisualStyleBackColor = true;
            this.btn_LoaiSach_Sua.Click += new System.EventHandler(this.btn_LoaiSach_Sua_Click);
            // 
            // btn_LoaiSach_Them
            // 
            this.btn_LoaiSach_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_LoaiSach_Them.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoaiSach_Them.Image = global::QuanLyBanSach.Properties.Resources.iconThem;
            this.btn_LoaiSach_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LoaiSach_Them.Location = new System.Drawing.Point(116, 75);
            this.btn_LoaiSach_Them.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_LoaiSach_Them.Name = "btn_LoaiSach_Them";
            this.btn_LoaiSach_Them.Size = new System.Drawing.Size(114, 48);
            this.btn_LoaiSach_Them.TabIndex = 5;
            this.btn_LoaiSach_Them.Text = "Thêm";
            this.btn_LoaiSach_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LoaiSach_Them.UseVisualStyleBackColor = true;
            this.btn_LoaiSach_Them.Click += new System.EventHandler(this.btn_LoaiSach_Them_Click);
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTheLoai.Location = new System.Drawing.Point(116, 4);
            this.txtTheLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTheLoai.Multiline = true;
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.Size = new System.Drawing.Size(553, 47);
            this.txtTheLoai.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(24, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Loại Sách";
            // 
            // Form_LoaiSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 516);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_LoaiSach";
            this.Text = "LoaiSach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_LoaiSach_FormClosing);
            this.Load += new System.EventHandler(this.Form_LoaiSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_LoaiSach_Xoa;
        private System.Windows.Forms.Button btn_LoaiSach_Sua;
        private System.Windows.Forms.Button btn_LoaiSach_Them;
        private System.Windows.Forms.TextBox txtTheLoai;
        private System.Windows.Forms.Label label10;
    }
}