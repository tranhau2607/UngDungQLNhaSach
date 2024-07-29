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
using QuanLyBanSach.Connect;

namespace QuanLyBanSach
{
    public partial class QuanLyPhieuNhap : Form
    {
        public QuanLyPhieuNhap()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        ConnectPhieuNhap connectPN = new ConnectPhieuNhap();

        DataSet ds_PhieuNhap = new DataSet();
        SqlDataAdapter da_PhieuNhap;
        void loadMaPN()
        {
            ds_PhieuNhap.Tables.Clear();
            string sql = "select * from PhieuNhap";
            da_PhieuNhap = new SqlDataAdapter(sql, con);
            da_PhieuNhap.Fill(ds_PhieuNhap, "PhieuNhap");
            cboPhieuNhap.DataSource = ds_PhieuNhap.Tables[0];
            cboPhieuNhap.DisplayMember = "MaPN";
            cboPhieuNhap.ValueMember = "MaPN";
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
        void loadcboNCC()
        {
            DataSet ds = new DataSet();
            string sql = "select * from NhaCC";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "NhaCC");
            cboNCC.DataSource = ds.Tables[0];
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
        }
        public void loadDonGia(string MaSP)
        {
            con.Open();
            string sql = "select GiaBan from Sach where MaSach='" + MaSP + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            txtDonGia.Text = cmd.ExecuteScalar().ToString();
            con.Close();
        }
        void updateThanhTien_TrenTextBox(string SoLuong)
        {
            if (SoLuong != "")
            {
                con.Open();
                string MaSP = cboMaSP.SelectedValue.ToString();
                string sql = "select GiaBan*" + SoLuong + " from Sach where MaSach='" + MaSP + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                txtThanhTien.Text = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            else
                txtThanhTien.Text = "0";
        }
        void updateThanhTien(string MaPN)
        {
            string update = "update PhieuNhap set TongTien = (select(sum(GiaNhap * Soluong)) from ChiTietPhieuNhap where PhieuNhap.MaPN = ChiTietPhieuNhap.MaPN)";
            update += "Where MaPN='" + MaPN + "'";
            SqlCommand cmd = new SqlCommand(update, con);
            cmd.ExecuteNonQuery();
        }
        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            txtThanhTien.Enabled = false;
            txtNhanVien.Enabled = false;
            txtMaPN.Enabled = false;
            txtNhanVien.Text = Properties.Settings.Default.UserName;
            //txtNhanVien.Text = "tandat";
            dateNgayNhap.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtThanhTien.Text = "0";
            loadMaPN();
            loadcboNCC();
            loadSach();
            loadChiTietPhieuNhap(null);
        }

        public string getTenNCC(string MaNCC)
        {
            con.Open();
            string sql = "select TenNCC from NhaCC where MaNCC=" + MaNCC + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            string tenncc = cmd.ExecuteScalar().ToString();
            con.Close();
            return tenncc;
        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            DataRow insert_new = ds_PhieuNhap.Tables["PhieuNhap"].NewRow();
            insert_new["NgayNhap"] = dateNgayNhap.Value.ToString("yyyy/MM/dd");
            insert_new["TenDN"] = Properties.Settings.Default.UserName;
            insert_new["MaNCC"] = cboNCC.SelectedValue.ToString();
            ds_PhieuNhap.Tables["PhieuNhap"].Rows.Add(insert_new);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(da_PhieuNhap);
            da_PhieuNhap.Update(ds_PhieuNhap, "PhieuNhap");
            MessageBox.Show("Thành công");
        }
        DataSet ds_CTPN = new DataSet();
        DataColumn[] key = new DataColumn[1];
        SqlDataAdapter da_CTPN;
        void loadChiTietPhieuNhap(string mapn)
        {
            ds_CTPN.Tables.Clear();
            string sql;
            if (mapn != null)
            {
                sql = "select * from ChiTietPhieuNhap where MaPN='" + mapn + "'";
            }
            else
                sql = "select * from ChiTietPhieuNhap";

            da_CTPN = new SqlDataAdapter(sql, con);
            da_CTPN.Fill(ds_CTPN, "ChiTietPhieuNhap");
            dataGridView1.DataSource = ds_CTPN.Tables["ChiTietPhieuNhap"];
            key[0] = ds_CTPN.Tables["ChiTietPhieuNhap"].Columns[0];

        }
        private void cboPhieuNhap_Click(object sender, EventArgs e)
        {
            loadMaPN();

        }

        private void cboPhieuNhap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string MaPN = cboPhieuNhap.SelectedValue.ToString();
            PhieuNhap pn = new PhieuNhap();
            pn = connectPN.loadPN(MaPN);
            txtMaPN.Text = pn.MaPN.ToString();
            txtThanhTien.Text = pn.TongTien.ToString();
            dateNgayNhap.Text = pn.NgayNhap;
            cboNCC.Text = getTenNCC(pn.MaNCC.ToString());
            dataGridView1.DataSource = null;
            loadChiTietPhieuNhap(MaPN);
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))//IsControl kiểm tra có p ký tự điều kiển hay không ( Delete,..)
            {
                e.Handled = true;//chặn ký tự nhập vào
                errorProvider1.SetError(txtSoLuong, "Phải nhập số");
            }
            else
                errorProvider1.Clear();
        }
        public int kiemTraMaSPTonTai_CTSP(string MaSP)
        {
            // con.Open();
            string MaPN = cboPhieuNhap.SelectedValue.ToString();
            string sql = "select count(*) from ChiTietPhieuNhap where MaSach='" + MaSP + "' and MaPN='" + MaPN + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int kt = 0;
            kt = (int)cmd.ExecuteScalar();
            //con.Close();
            return kt;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            con.Open();
            string MaSP = cboMaSP.SelectedValue.ToString();
            string MaPN = cboPhieuNhap.SelectedValue.ToString();
            int kt = kiemTraMaSPTonTai_CTSP(MaSP);
            string sql = "";
            if (kt == 0)
                sql = "insert into ChiTietPhieuNhap values('" + MaPN + "','" + MaSP + "'," + txtDonGia.Text + "," + txtSoLuong.Text + ");";
            else
                sql = "update ChiTietPhieuNhap set Soluong = Soluong + " + txtSoLuong.Text + " where MaPN = '" + MaPN + "' and MaSP = '" + MaSP + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            int rs = cmd.ExecuteNonQuery();
            if (rs == 1)
            {
                MessageBox.Show("Thêm ChiTietPhieuNhap thành công");
                updateThanhTien(MaPN);
            }
            else
            {
                MessageBox.Show("Thêm ChiTietPhieuNhap thất bại");
            }
            con.Close();
            loadChiTietPhieuNhap(MaPN);
        }

        private void btnThemSP_Click_1(object sender, EventArgs e)
        {
            string MaPN = cboPhieuNhap.SelectedValue.ToString();
            string TenDN = Properties.Settings.Default.UserName;
            if(MaPN.Length==0||TenDN.Length==0||txtDonGia.TextLength==0||txtSoLuong.TextLength==0)
            {
                 if(txtSoLuong.TextLength==0)
                    errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng");
                MessageBox.Show("Thêm chi tiết phiếu nhập thất bại");
                return;
            }    
            int kt=connectPN.KiemTraTaiKhoan_DonHang(TenDN, MaPN);
            //Kiểm tra Tài khoảng  TenDN có phải là tài khoản đã tạo đơn hàng không 
            if(kt==1) //nếu đúng thì được phép thêm 
            {
                string MaSach = cboMaSP.SelectedValue.ToString();

                int rs = connectPN.addChiTietPhieuNhap(MaPN, MaSach, txtSoLuong.Text, txtDonGia.Text);
                if (rs != 0)
                {
                    MessageBox.Show("Thêm chi tiết phiếu nhập thành công");
                    loadChiTietPhieuNhap(MaPN);
                }    
                else
                    MessageBox.Show("Thêm chi tiết phiếu nhập thất bại");
            }
            else //nếu sai thì xuất ra lỗi
                MessageBox.Show("Bạn không phải nhân viên đã thêm đơn hàng này");
        }

        private void printDocumentPN_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ConnectCPN connectChiTiet = new ConnectCPN();
            List<CTPN> listCTPN = connectChiTiet.getCTPN(cboPhieuNhap.Text);
            e.Graphics.DrawString("Phiếu Nhập", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 45));


            e.Graphics.DrawString("Mã Phiếu Nhập: " + cboPhieuNhap.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 100));

            e.Graphics.DrawString("Nhân Viên: " + txtNhanVien.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 140));

            e.Graphics.DrawString("Tổng Tiền: " + txtThanhTien.Text + " đ", new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 180));

            e.Graphics.DrawString("Ngày Nhập: " + dateNgayNhap.Text, new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(25, 220));

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("Chi Tiết Phiếu Nhập", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(300, 300));
            e.Graphics.DrawString("Tên sách", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 360));
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 360));
            e.Graphics.DrawString("Giá Nhập", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(590, 360));
            e.Graphics.DrawString("Thành TIền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 360));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 400));

            int y = 0;
            foreach (var item in listCTPN)
            {

                e.Graphics.DrawString(item.TenSach, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 440 + y));
                e.Graphics.DrawString(item.SoLuong.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 440 + y));
                e.Graphics.DrawString(item.GiaNhap.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(590, 440 + y));
                e.Graphics.DrawString(item.TongTien.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 440 + y));
                y = y + 50;
            }
        }

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thanh toán và in phiếu nhập", "Xác nhận"
                              , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {

                    string MaPN = cboPhieuNhap.SelectedValue.ToString();
                    if (MaPN.Length != 0)
                    {
                        printPreviewDialogPN.Document = printDocumentPN;
                        printPreviewDialogPN.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Tạo phiếu nhập thất bại", "Không thể tạo phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
        }
    }
}
