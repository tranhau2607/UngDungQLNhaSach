using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanSach.Connect;

namespace QuanLyBanSach
{
    public partial class Form_Sach : Form
    {
        ConnectSach sach = new ConnectSach();
        public Form_Sach()
        {
            InitializeComponent();
        }

        string ConStr = Properties.Settings.Default.ConStr;
        void loadCboLoai()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
            DataSet ds = new DataSet();
            string sql = "select * from TheLoai";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "TheLoai");
            cbo_Sach_LoaiSach.DataSource = ds.Tables[0];
            cbo_Sach_LoaiSach.DisplayMember = "TenTL";
            cbo_Sach_LoaiSach.ValueMember = "MaTL";
        }
        void loadCboNXB()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
            DataSet ds = new DataSet();
            string sql = "select * from NhaXuatBan";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "NhaXuatBan");
            cbo_NhaXB.DataSource = ds.Tables[0];
            cbo_NhaXB.DisplayMember = "TenNXB";
            cbo_NhaXB.ValueMember = "MaNXB";
        }
        void loadCboTacGia()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
            DataSet ds = new DataSet();
            string sql = "select MaTG,TenTG from TacGia";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "TacGia");
            cbo_TacGia.DataSource = ds.Tables[0];
            cbo_TacGia.DisplayMember = "TenTG";
            cbo_TacGia.ValueMember = "MaTG";
        }
        DataSet ds_Sach = new DataSet();
        DataColumn[] key_Sach = new DataColumn[1];
        SqlDataAdapter da_Sach;
        void showsach(string TenSach)
        {
            string sql;
            if (TenSach!=null)
                sql = "select* from Sach where TenSach like N'%"+ TenSach + "%'";  
            else
                sql = "select* from Sach";
            ds_Sach.Tables.Clear();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
            
            da_Sach = new SqlDataAdapter(sql, con);
            da_Sach.Fill(ds_Sach, "Sach");
            dataGridView2.DataSource = ds_Sach.Tables["Sach"];
            key_Sach[0] = ds_Sach.Tables["Sach"].Columns[0];
            ds_Sach.Tables["Sach"].PrimaryKey = key_Sach;
        }
        private void Form_Sach_Load(object sender, EventArgs e)
        {
            loadCboLoai();
            loadCboNXB();
            loadCboTacGia();
            showsach(null);
        }
        public int TestAddSach()
        {
            int loi = 0;
            if(txt_Sach_TenSach.TextLength==0)
            {
                errTenSach.SetError(txt_Sach_TenSach, "Tên sách không được để trống");
                loi++;
            }
            if (txtNgonNgu.TextLength == 0)
            {
                errTenSach.SetError(txtNgonNgu, "Ngôn ngữ không được để trống");
                loi++;
            }
            if (txtHinhAnh.Text == "")
            {
                errHinhAnh.SetError(txtHinhAnh, "Vui lòng thêm hình ảnh");
                loi++;
            }
            else
                errHinhAnh.Clear();
                
            if (dateNamXB.Value > DateTime.Now)
            {
                errNamXB.SetError(dateNamXB, "Năm xuất bản không hợp lệ!");
                loi++;
            }
            if(int.Parse(txtGiaBan.Text)<=0)
            {
                errGiaBan.SetError(txtGiaBan, "Giá bán phải lớn hơn 0");
                loi++;
            }
            if (int.Parse(txtSoLuong.Text) <= 0)
            {
                errSoLuong.SetError(txtSoLuong, "Số lượng phải lớn hơn 0");
                loi++;
            }
            return loi;
        }
        private void btn_Sach_Them_Click(object sender, EventArgs e)
        {
            if(TestAddSach()== 0)
            {
                Sach a = new Sach();
                a.TenSach = txt_Sach_TenSach.Text;
                a.GiaBan = txtGiaBan.Text;
                a.MaTL = cbo_Sach_LoaiSach.SelectedValue.ToString();
                a.MaNXB = cbo_NhaXB.SelectedValue.ToString();
                a.MaTG = cbo_TacGia.SelectedValue.ToString();
                a.SoLuongTon = txtSoLuong.Text;
                a.HinhAnh = txtHinhAnh.Text;
                a.NgonNgu = txtNgonNgu.Text;
                a.NamXuatBan = dateNamXB.Text;
                int rs = sach.addSach(a);
                if (rs != 0)
                {
                    MessageBox.Show("Thêm sách thành công ");
                    txt_Sach_TenSach.Clear();
                    txtHinhAnh.Text="";
                    txtNgonNgu.Clear();
                    txtGiaBan.Clear();
                    txtSoLuong.Clear();
                    txt_Sach_TenSach.Clear();
                    pictureBox1.Image = null;

                    showsach(null);
                }
                else
                    MessageBox.Show("Thêm sách thất bại ");
            }
            else
                MessageBox.Show("Thêm sách thất bại ");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các cài đặt cho dialog Open File
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp"; // Bộ lọc cho các tệp tin hình ảnh
            openFileDialog.FilterIndex = 1; // Chỉ định bộ lọc mặc định
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName; // Lấy đường dẫn tuyệt đối của tệp tin hình ảnh
                string imageName = Path.GetFileName(imagePath); // Lấy tên tệp tin hình ảnh

                // Hiển thị tên tệp tin lên Label hoặc TextBox
                txtHinhAnh.Text = imageName;

                // Xuất hình ảnh lên PictureBox
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))//IsControl kiểm tra có p ký tự điều kiển hay không ( Delete,..)
            {
                e.Handled = true;//chặn ký tự nhập vào
                errSoLuong.SetError(txtSoLuong, "Phải nhập số");
            }
            else
                errSoLuong.Clear();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))//IsControl kiểm tra có p ký tự điều kiển hay không ( Delete,..)
            {
                e.Handled = true;//chặn ký tự nhập vào
                errGiaBan.SetError(txtGiaBan, "Phải nhập số");
            }
            else
                errGiaBan.Clear();
        }

        private void btn_Sach_Xoa_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView2.Rows[rowIndex];
            string MaSach = row.Cells["MaSach"].Value.ToString();
            int rs = sach.deleteSach(MaSach);
            if (rs != 0)
            {
                MessageBox.Show("Xóa sách thành công!");
                showsach(null);
            }
            else
                MessageBox.Show("Xóa sách thất bại");
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView2.Rows[rowIndex];
            txt_Sach_TenSach.Text = row.Cells["TenSach"].Value.ToString();
            txtHinhAnh.Text = row.Cells["HinhAnh"].Value.ToString();
            txtSoLuong.Text= row.Cells["SoLuongTon"].Value.ToString();
            txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
            txtNgonNgu.Text = row.Cells["NgonNgu"].Value.ToString();
            dateNamXB.Text = row.Cells["NamXuatBan"].Value.ToString();

            //địa chỉ trên máy tính 
            string imagePath = "D:\\Download\\mới nhất\\QuanLyBanSach (1)\\QuanLyBanSach\\QuanLyBanSach\\QuanLyBanSach\\Connect\\ImgSach\\" + txtHinhAnh.Text;
            try
            {
                Image image = Image.FromFile(imagePath);
                if (image != null)
                    pictureBox1.Image = image;
            }
            catch
            {  
            }
        }

        private void btn_Sach_Sua_Click(object sender, EventArgs e)
        {
            if (TestAddSach() == 0)
            {
                int rowIndex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridView2.Rows[rowIndex];
                Sach a = new Sach();
                a.MaSach= row.Cells["MaSach"].Value.ToString();
                a.TenSach = txt_Sach_TenSach.Text;
                a.GiaBan = txtGiaBan.Text;
                a.MaTL = cbo_Sach_LoaiSach.SelectedValue.ToString();
                a.MaNXB = cbo_NhaXB.SelectedValue.ToString();
                a.MaTG = cbo_TacGia.SelectedValue.ToString();
                a.SoLuongTon = txtSoLuong.Text;
                a.HinhAnh = txtHinhAnh.Text;
                a.NgonNgu = txtNgonNgu.Text;
                a.NamXuatBan = dateNamXB.Text;
                int rs = sach.updateSach(a);
                if (rs != 0)
                {
                    MessageBox.Show("Sửa thành công ");
                    txt_Sach_TenSach.Clear();
                    txtHinhAnh.Text = "";
                    txtNgonNgu.Clear();
                    txtGiaBan.Clear();
                    txtSoLuong.Clear();
                    txt_Sach_TenSach.Clear();
                    pictureBox1.Image = null;
                    showsach(null);
                }
                else
                    MessageBox.Show("Sửa thất bại ");
            }
            else
                MessageBox.Show("Sửa thất bại xxx ");
        }

        private void txt_Sach_TenSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            showsach(txt_Sach_TenSach.Text);
        }

        private void btnAddTheLoai_Click(object sender, EventArgs e)
        {
            Form_LoaiSach a = new Form_LoaiSach();
            a.Show();
            loadCboLoai();
        }

        private void cbo_Sach_LoaiSach_Click(object sender, EventArgs e)
        {
            loadCboLoai();
        }

        private void cbo_TacGia_Click(object sender, EventArgs e)
        {
            loadCboTacGia();
        }

        private void cbo_NhaXB_Click(object sender, EventArgs e)
        {
            loadCboNXB();   
        }

        private void btnAddTacGia_Click(object sender, EventArgs e)
        {
            F_TacGia a = new F_TacGia();
            a.Show();
        }

        private void btnAddNXB_Click(object sender, EventArgs e)
        {
            F_NhaXuatBan a = new F_NhaXuatBan();
            a.Show();
        }

        private void Form_Sach_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult r;
            //r = MessageBox.Show("Bạn có muốn thoát ?", "thoát",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button1);
            //if (r == DialogResult.No)
            //    e.Cancel = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txt_Sach_TenSach.Clear();
            txtHinhAnh.Text = "";
            txtNgonNgu.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txt_Sach_TenSach.Clear();
            pictureBox1.Image = null;
        }
    }
}
