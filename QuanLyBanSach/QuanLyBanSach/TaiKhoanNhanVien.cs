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
using WindowsFormsApplication2.Utilities;

namespace QuanLyBanSach
{
    public partial class TaiKhoanNhanVien : Form
    {
        public TaiKhoanNhanVien()
        {
            InitializeComponent();
        }
        ConnectTaiKhoan taikhoan = new ConnectTaiKhoan();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        DataSet ds_TK = new DataSet();
        SqlDataAdapter ds_TKNV;
        void showTK(string TenDN)
        {
            string sql;
            sql = "select TenDN, Passwords,Vaitro from TaiKhoan";
            ds_TK.Tables.Clear();
           
            ds_TKNV = new SqlDataAdapter(sql, con);
            ds_TKNV.Fill(ds_TK, "TaiKhoan");
            dataGridView1.DataSource = ds_TK.Tables["TaiKhoan"];
        }
        private void TaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            showTK(null);
        }
        int KiemTraLoi()
        {
            int loi = 0;
            if (txt_TenDN.Text.Length == 0)
            {
                errorProvider1.SetError(txt_TenDN, "Vui lòng nhập tên tên đăng nhập");
                loi++;
            }
            else
                errorProvider1.Clear();
            if (txt_Pass.Text.Length == 0)
            {
                errorProvider2.SetError(txt_Pass, "Vui lòng nhập mật khẩu");
                loi++;
            }
            else
                errorProvider2.Clear();
            if (txt_VT.Text.Length == 0)
            {
                errorProvider2.SetError(txt_Pass, "Vui lòng nhập vai trò");
                loi++;
            }
            else
                errorProvider2.Clear();



            return loi;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == 0)
            {
                TaiKhoanND a = new TaiKhoanND();
                a.TenDN = txt_TenDN.Text;
                a.Passwords = txt_Pass.Text;
                a.Passwords_MD5 = Password.Create_MD5(txt_Pass.Text);
                a.Vaitro = txt_VT.Text;

                int rs = taikhoan.addTaiKhoan(a);
                if (rs != 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công ");

                    txt_TenDN.Clear();
                    txt_Pass.Clear();
                    txt_VT.Clear();

                    showTK(null);
                }
                else
                    MessageBox.Show("Thêm tài khoản thất bại ");
            }
            else
                MessageBox.Show("Thêm tài khoản thất bại ");
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string TenDN = row.Cells["TenDN"].Value.ToString();
            int rs = taikhoan.deleteTaiKhoan(TenDN);
            if (rs != 0)
            {
                MessageBox.Show("Xóa tài khoản thành công!");
                showTK(null);
            }
            else
                MessageBox.Show("Xóa tài khoản thất bại");
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == 0)
            {
                TaiKhoanND a = new TaiKhoanND();
                a.TenDN = txt_TenDN.Text;
                a.Passwords = txt_Pass.Text;
                a.Passwords_MD5 = Password.Create_MD5(txt_Pass.Text);
                a.Vaitro = txt_VT.Text;

                int rs = taikhoan.updateTaiKhoan(a);
                if (rs != 0)
                {
                    MessageBox.Show("Update tài khoản thành công ");

                    txt_Pass.Clear();
                    txt_VT.Clear();

                    showTK(null);
                }
                else
                    MessageBox.Show("Update tài khoản thất bại ");
            }
            else
                MessageBox.Show("Update tài khoản thất bại ");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            txt_TenDN.Text = row.Cells["TenDN"].Value.ToString();
            txt_Pass.Text = row.Cells["Passwords"].Value.ToString();
            txt_VT.Text = row.Cells["VaiTro"].Value.ToString();
            //txt_TenDN.Enabled = false;

        }
    }
}
