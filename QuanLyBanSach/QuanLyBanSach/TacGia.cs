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
    public partial class F_TacGia : Form
    {
        public F_TacGia()
        {
            InitializeComponent();
        }
        DataSet ds_TacGia = new DataSet();
        DataColumn[] key_TacGia = new DataColumn[1];
        SqlDataAdapter da_TacGia;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        ConnectTacGia connectTacGia = new ConnectTacGia();
        
        void showTacGia()
        {
            string sql= "select* from TacGia";
            ds_TacGia.Tables.Clear();
            //SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
            da_TacGia = new SqlDataAdapter(sql, con);
            da_TacGia.Fill(ds_TacGia, "TacGia");
            dataGridView1.DataSource = ds_TacGia.Tables["TacGia"];
            key_TacGia[0] = ds_TacGia.Tables["TacGia"].Columns[0];
            ds_TacGia.Tables["TacGia"].PrimaryKey = key_TacGia;
        }
        private void TacGia_Load(object sender, EventArgs e)
        {
            showTacGia();
        }
        public bool IsEmailAddress(string email)
        {
            try
            {
                if(email.Length!=0)
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
            if (txtTenTG.Text.Length == 0)
            {
                errorProvider1.SetError(txtTenTG, "Vui lòng nhập tên tác giả");
                loi++;
            }
            else
                errorProvider1.Clear();
            if (txtNamSinh.Text.Length == 0)
            {
                errorProvider2.SetError(txtNamSinh, "Vui lòng nhập năm sinh");
                loi++;
            }
            else if (int.Parse(txtNamSinh.Text) > DateTime.Now.Year)
            {
                errorProvider2.SetError(txtNamSinh, "Năm sinh không hợp lệ");
                loi++;
            }
            else
                errorProvider2.Clear();

            if (txtNamMat.Text.Length!=0)
            {
                if (int.Parse(txtNamSinh.Text) >= int.Parse(txtNamMat.Text)|| int.Parse(txtNamMat.Text)>= DateTime.Now.Year)
                {
                    errorProvider3.SetError(txtNamMat, "Năm mất không hợp lệ");
                    loi++;
                }
                else
                    errorProvider3.Clear();
            }    
         
            if (IsEmailAddress(txtLienLac.Text) == false)
            {
                errorProvider4.SetError(txtLienLac, "Email không hợp lệ");
                loi++;
            }
            else
                errorProvider4.Clear();
            return loi;
        }
        private void btn_LoaiSach_Them_Click(object sender, EventArgs e)
        {    
            if(KiemTraLoi()==0)
            {
                TacGia a = new TacGia(txtTenTG.Text,txtLienLac.Text,txtNamSinh.Text,txtNamMat.Text);
                int rs = connectTacGia.addTacGia(a);
                if (rs!=0)
                {
                    MessageBox.Show("Thêm tác giả thành công!");
                    txtTenTG.Clear();
                    txtLienLac.Clear();
                    txtNamMat.Clear();
                    txtNamSinh.Clear();
                    showTacGia();
                }    
                else
                    MessageBox.Show("Thêm tác giả thất bại!");
            }    

        }

        private void btn_LoaiSach_Xoa_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string MaTG = row.Cells["MaTG"].Value.ToString();
            int rs = connectTacGia.deleteTacGia(MaTG);
            if (rs != 0)
            {
                MessageBox.Show("Xóa thành công!");
                showTacGia();
            }
            else
                MessageBox.Show("Xóa không thành công!");
        }

        private void btn_LoaiSach_Sua_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                TacGia a = new TacGia(txtTenTG.Text,txtLienLac.Text,txtNamSinh.Text,txtNamMat.Text);
                a.MaTG= row.Cells["MaTG"].Value.ToString();
                int rs = connectTacGia.updateTacGia(a);
                if (rs != 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    txtTenTG.Clear();
                    txtLienLac.Clear();
                    txtNamMat.Clear();
                    txtNamSinh.Clear();
                    showTacGia();
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
            TacGia a = new TacGia();
           
           txtLienLac.Text = row.Cells["LienLac"].Value.ToString();
            txtTenTG.Text = row.Cells["TenTG"].Value.ToString();
            txtNamSinh.Text = row.Cells["NamSinh"].Value.ToString();
           txtNamMat.Text = row.Cells["NamMat"].Value.ToString();
        }

        private void F_TacGia_FormClosing(object sender, FormClosingEventArgs e)
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
            txtTenTG.Clear();
            txtLienLac.Clear();
            txtNamMat.Clear();
            txtNamSinh.Clear();
        }
    }
}
