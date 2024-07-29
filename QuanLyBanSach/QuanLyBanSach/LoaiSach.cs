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
    public partial class Form_LoaiSach : Form
    {
        ConnectTheLoai theloai = new ConnectTheLoai();
        public Form_LoaiSach()
        {
            InitializeComponent();
        }
        DataSet ds_TheLoai = new DataSet();
        DataColumn[] key_TheLoai = new DataColumn[1];
        SqlDataAdapter da_TheLoai;
        void showTheLoai(string TenTL)
        {
            string sql;
            if (TenTL != null)
                sql = "select* from TheLoai where TenTL like N'%" + TenTL + "%'";
            else
                sql = "select* from TheLoai";
            ds_TheLoai.Tables.Clear();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);

            da_TheLoai = new SqlDataAdapter(sql, con);
            da_TheLoai.Fill(ds_TheLoai, "TheLoai");
            dataGridView1.DataSource = ds_TheLoai.Tables["TheLoai"];
            key_TheLoai[0] = ds_TheLoai.Tables["TheLoai"].Columns[0];
            ds_TheLoai.Tables["TheLoai"].PrimaryKey = key_TheLoai;
        }
        private void Form_LoaiSach_Load(object sender, EventArgs e)
        {
            showTheLoai(null);
        }
        int testTheLoai()
        {
            if(txtTheLoai.Text.Length==0)
            {
                MessageBox.Show("Vui lòng nhập tên thể loại");
                return 0;
            }
            return 1;
        }
        private void btn_LoaiSach_Them_Click(object sender, EventArgs e)
        {
            if(testTheLoai()==1)
            {
                int rs=theloai.addTheLoai(txtTheLoai.Text);
                if(rs>0)
                {
                    MessageBox.Show("Thêm thể loại thành công!");
                    txtTheLoai.Clear();
                    showTheLoai(null);
                }
                else
                    MessageBox.Show("Thêm thể loại thất bại!");
            }
            else
                MessageBox.Show("Vui lòng nhập Tên thể loại");
            
        }

        private void btn_LoaiSach_Xoa_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string MaTL = row.Cells["MaTL"].Value.ToString();
            int rs = theloai.deleteTheLoai(MaTL);
            if(rs>0)
            {
                MessageBox.Show("Xóa thể loại thành công!");
                showTheLoai(null);
                txtTheLoai.Clear();
            }   
            else
                MessageBox.Show("Xóa thể loại thất bại!");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            txtTheLoai.Text = row.Cells["TenTL"].Value.ToString();
           
        }

        private void btn_LoaiSach_Sua_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            string MaTL = row.Cells["MaTL"].Value.ToString();

            if (txtTheLoai.Text.Length!=0)
            {
                int rs = theloai.updateTheLoai(txtTheLoai.Text,MaTL);
                if (rs > 0)
                {
                    MessageBox.Show("Cập nhật thể loại thành công!");
                    showTheLoai(null);
                    txtTheLoai.Clear();
                    MaTL = null;
                }
                else
                    MessageBox.Show("Cập nhật thể loại thất bại!");
            }
            else
                MessageBox.Show("Vui lòng nhập Tên thể loại");

        }

        private void Form_LoaiSach_FormClosing(object sender, FormClosingEventArgs e)
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
