using QuanLyBanSach.Connect;
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

namespace QuanLyBanSach
{
    public partial class QuanLyHoaDon : Form
    {
        public QuanLyHoaDon()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        ConnectHoaDon connectHD = new ConnectHoaDon();

        SqlDataAdapter da_HoaDon;
        DataSet ds_HD = new DataSet();
        
        void loadMaHD()
        {
            ds_HD.Tables.Clear();
            string sql = "select * from HoaDon";
            da_HoaDon = new SqlDataAdapter(sql, con);
            da_HoaDon.Fill(ds_HD, "HoaDon");
            cboHD.DataSource = ds_HD.Tables[0];
            cboHD.DisplayMember = "MaHD";
            cboHD.ValueMember = "MaHD";
        }
        void loadSach()
        {
            DataSet ds = new DataSet();
            string sql = "Select * from Sach";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "Sach");
            cboMaSP.DataSource = ds.Tables[0];
            cboMaSP.DisplayMember = "TenSach";
            cboMaSP.ValueMember = "MaSach";
        }
        public void loadDonGia(string MaSP)
        {
            con.Open();
            string sql = "select GiaBan from Sach where MaSach='" + MaSP + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            txtGiaBan.Text = cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void cboHD_Click(object sender, EventArgs e)
        {
            loadMaHD();
        }

        void updateThanhTien_TrenTextBox(string SoLuong)
        {
            if (SoLuong != "")
            {
                con.Open();
                string MaSP = cboMaSP.SelectedValue.ToString();
                string sql = "select GiaBan*" + SoLuong + " from Sach where MaSach='" + MaSP + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                txtTongTien.Text = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            else
                txtTongTien.Text = "0";
        }
        void updateThanhTien(string MaHD)
        {
            string update = "update HoaDon set TongTien = (select(sum(GiaBan * Soluong)) from ChiTietHoaDon where HoaDon.MaHD = ChiTietHoaDon.MaHD)";
            update += "Where MaHD='" + MaHD + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.ExecuteNonQuery();
        }
        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            txtTongTien.Enabled = false;
            txt_NV.Enabled = false;
            txtMaHD.Enabled = false;
            txt_NV.Text = Properties.Settings.Default.UserName;
            dateNgayBan.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtTongTien.Text = "0";
            txtGiaBan.Enabled = false;
            loadMaHD();
            loadSach();
            loadChiTietHoaDon(null);
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            DataRow insert_new = ds_HD.Tables["HoaDon"].NewRow();
            insert_new["NgayBan"] = dateNgayBan.Value.ToString("yyyy/MM/dd");
            insert_new["TenDN"] = Properties.Settings.Default.UserName;
            ds_HD.Tables["HoaDon"].Rows.Add(insert_new);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da_HoaDon);
            da_HoaDon.Update(ds_HD, "HoaDon");
            MessageBox.Show("Thành công");
        }



        DataSet ds_CTHD = new DataSet();
        DataColumn[] key = new DataColumn[1];
        SqlDataAdapter da_CTHoaDon;
        void loadChiTietHoaDon(string mahd)
        {
            ds_CTHD.Tables.Clear();
            string sql;
            if (mahd != null)
            {
                sql = "SELECT ChiTietHoaDon.*,sach.TenSach FROM ChiTietHoaDon,Sach where ChiTietHoaDon.MaSach=Sach.MaSach and MaHD='" + mahd + "'";
            }
            else
                sql = "SELECT ChiTietHoaDon.*,sach.TenSach FROM ChiTietHoaDon,Sach where ChiTietHoaDon.MaSach=Sach.MaSach";

            da_CTHoaDon = new SqlDataAdapter(sql, con);
            da_CTHoaDon.Fill(ds_CTHD, "ChiTietHoaDon");
            dataGridView1.DataSource = ds_CTHD.Tables["ChiTietHoaDon"];
            key[0] = ds_CTHD.Tables["ChiTietHoaDon"].Columns[0];

        }



        private void cboHD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string MaHD = cboHD.SelectedValue.ToString();
            HoaDon hd = new HoaDon();
            hd = connectHD.loadHoaDon(MaHD);
            txtMaHD.Text = hd.MaHD.ToString();
            txtTongTien.Text = hd.TongTien.ToString();
            dateNgayBan.Text = hd.NgayBan;
            dataGridView1.DataSource = null;
            loadChiTietHoaDon(MaHD);
        }

        private void cboMaSP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadDonGia(cboMaSP.SelectedValue.ToString());
            txtMaSach.Text = cboMaSP.SelectedValue.ToString();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            updateThanhTien_TrenTextBox(txtSoLuong.Text);
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(txtSoLuong, "Phải nhập số");
            }
            else
                errorProvider1.Clear();
        }
        public int kiemTraMaSPTonTai_CTSP(string MaSP)
        {
            // con.Open();
            string MaHD = cboHD.SelectedValue.ToString();
            string sql = "select count(*) from ChiTietHoaDon where MaSach='" + MaSP + "' and MaHD='" + MaHD + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kt = 0;
            kt = (int)cmd.ExecuteScalar();
            //con.Close();
            return kt;
        }

       

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            string MaHD = cboHD.SelectedValue.ToString();
            string TenDN = Properties.Settings.Default.UserName;

            if (MaHD.Length == 0 || TenDN.Length == 0 || txtGiaBan.TextLength == 0 || txtSoLuong.TextLength == 0)
            {
                if (txtSoLuong.TextLength == 0)
                    errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng");
                MessageBox.Show("Thêm chi tiết hóa đơn thất bại");
                return;
            }
            int kt = connectHD.KiemTraTaiKhoan_DonHang(TenDN, MaHD);
            //Kiểm tra Tài khoảng  TenDN có phải là tài khoản đã tạo đơn hàng không 
            if (kt == 1) //nếu đúng thì được phép thêm 
            {
                string MaSach = cboMaSP.SelectedValue.ToString();

                int rs = connectHD.addChiTietHoaDon(MaHD, MaSach, txtSoLuong.Text, txtGiaBan.Text);
                if (rs != 0)
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công");
                    loadChiTietHoaDon(MaHD);
                }
                else
                    MessageBox.Show("Thêm chi tiết hóa đơn thất bại");
            }
            else //nếu sai thì xuất ra lỗi
                MessageBox.Show("Bạn không phải nhân viên đã thêm hóa đơn này");
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thanh toán và in hóa đơn", "Xác nhận"
                              , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                                    
                    string MaHD = cboHD.SelectedValue.ToString();
                    if (MaHD.Length!=0)
                    {
                        printPreviewDialog.Document = printDocument;
                        printPreviewDialog.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Tạo hóa đơn thất bại", "Không thể tạo hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }
        
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ConnectCTHD connectChiTiet = new ConnectCTHD();
            List<CTHD> listCTHD = connectChiTiet.getCTHD(cboHD.Text);
            e.Graphics.DrawString("Hóa Đơn", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 45));


            e.Graphics.DrawString("Mã Hóa Đơn: " + cboHD.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 100));

            e.Graphics.DrawString("Nhân Viên: " + txt_NV.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 140));

            e.Graphics.DrawString("Tổng Tiền: " + txtTongTien.Text + " đ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 180));

            e.Graphics.DrawString("Ngày Bán: " + dateNgayBan.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 220));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("Chi Tiết Hóa Đơn", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(300, 300));
            e.Graphics.DrawString("Tên sách", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 360));
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 360));
            e.Graphics.DrawString("Giá Bán", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(590, 360));
            e.Graphics.DrawString("Thành TIền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 360));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 400));

            int y = 0;
            foreach (var item in listCTHD)
            {
                
                e.Graphics.DrawString(item.TenSach, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 440+y));
                e.Graphics.DrawString(item.SoLuongBan.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 440 + y));
                e.Graphics.DrawString(item.GiaBan.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(590, 440 + y));
                e.Graphics.DrawString(item.ThanhTien.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 440 + y));
                y = y + 50;
            }


        }
    }
}
