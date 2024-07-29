using QuanLyBanSach.Connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class F_NhaXuatBan : Form
    {
        public F_NhaXuatBan()
        {
            InitializeComponent();
        }
        DataSet ds_NXB = new DataSet();
        DataColumn[] key_NXB = new DataColumn[1];
        SqlDataAdapter da_NXB;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        ConnectNhaXuatBan connectNXB = new ConnectNhaXuatBan();

        void showNXB()
        {
            string sql = "select* from NhaXuatBan";
            ds_NXB.Tables.Clear();
            //SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
            da_NXB = new SqlDataAdapter(sql, con);
            da_NXB.Fill(ds_NXB, "NhaXuatBan");
            dataGridView1.DataSource = ds_NXB.Tables["NhaXuatBan"];
            key_NXB[0] = ds_NXB.Tables["NhaXuatBan"].Columns[0];
            ds_NXB.Tables["NhaXuatBan"].PrimaryKey = key_NXB;
        }
        public bool IsEmailAddress(string email)
        {
            try
            {
                if (email.Length != 0)
                {
                    MailAddress emailAddress = new MailAddress(email);
                    return true;
                }
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        int KiemTraLoi()
        {
            int loi = 0;
            if (txtTenNXB.Text.Length == 0)
            {
                errorProvider1.SetError(txtTenNXB, "Vui lòng nhập tên NXB");
                loi++;
            }
            else
                errorProvider1.Clear();
            if (txtDiaChi.Text.Length == 0)
            {
                errorProvider2.SetError(txtDiaChi, "Vui lòng nhập Địa chỉ");
                loi++;
            }
            else
                errorProvider2.Clear();


            if (txtDienThoai.Text.Length == 0)
            {
                errorProvider3.SetError(txtDienThoai, "Vui lòng nhập Số điện thoại");
                loi++;
                if (txtDienThoai.Text.Length != 10)
                {
                    errorProvider3.SetError(txtDienThoai, "Sai định dạng số điện thoại");
                    loi++;
                }
            }
            else
                errorProvider3.Clear();
            if (txtEmail.Text.Length == 0)
            {
                errorProvider4.SetError(txtEmail, "Vui lòng nhập email");
                loi++;
            }
            else
                errorProvider4.Clear();
            if (IsEmailAddress(txtEmail.Text) == false)
            {
                errorProvider4.SetError(txtEmail, "Email không hợp lệ");
                loi++;
            }
            else
                errorProvider4.Clear();
            return loi;
        }
        private void btn_LoaiSach_Them_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == 0)
            {
                NhaXuatBan a = new NhaXuatBan(txtTenNXB.Text, txtEmail.Text, txtDiaChi.Text, txtDienThoai.Text);
                int rs = connectNXB.addNXB(a);
                if (rs != 0)
                {
                    MessageBox.Show("Thêm Nhà xuất bản thành công!");
                    txtTenNXB.Clear();
                    txtEmail.Clear();
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();
                    showNXB();
                }
                else
                    MessageBox.Show("Thêm  Nhà xuất bản thất bại!");
            }

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))//IsControl kiểm tra có p ký tự điều kiển hay không ( Delete,..)
            {
                e.Handled = true;//chặn ký tự nhập vào
                errorProvider3.SetError(txtDienThoai, "Phải nhập số");
            }
            else
                errorProvider3.Clear();
        }

        private void F_NhaXuatBan_Load(object sender, EventArgs e)
        {
            showNXB();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string MaNXB = row.Cells["MaNXB"].Value.ToString();
            int rs = connectNXB.deleteNXB(MaNXB);
            if (rs != 0)
            {
                MessageBox.Show("Xóa thành công!");
                showNXB();
            }
            else
                MessageBox.Show("Xóa không thành công!");
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                NhaXuatBan a = new NhaXuatBan(txtTenNXB.Text, txtEmail.Text, txtDiaChi.Text, txtDienThoai.Text);
                a.MaNXB = row.Cells["MaNXB"].Value.ToString();
                int rs = connectNXB.updateNhaXuatBan(a);
                if (rs != 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    txtTenNXB.Clear();
                    txtEmail.Clear();
                    txtDiaChi.Clear();
                    txtDienThoai.Clear();
                    showNXB();
                }
                else
                    MessageBox.Show("Cập nhật thất bại");

            }
            else
                MessageBox.Show("Cập nhật thất bại");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            NhaXuatBan a = new NhaXuatBan();
            txtTenNXB.Text = row.Cells["TenNXB"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChiNXB"].Value.ToString();
            txtDienThoai.Text = row.Cells["DienThoai"].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenNXB.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
        }

        private void F_NhaXuatBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult r;
            //r = MessageBox.Show("Bạn có muốn thoát ?", "thoát",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button1);
            //if (r == DialogResult.No)
            //    e.Cancel = true;
        }
    }
}
