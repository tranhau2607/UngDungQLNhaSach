using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class Layout : Form
    {
        public Layout()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btn_Sach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Sach());
            label3.Text = btn_Sach.Text;
        }

        private void btn_LoaiSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_LoaiSach());
            label3.Text = btn_LoaiSach.Text;
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyHoaDon());
            label3.Text = btn_HoaDon.Text;
        }

        private void btn_PhieuNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyPhieuNhap());
            label3.Text = btn_PhieuNhap.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_NhaXuatBan());
            label3.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_TacGia());
            label3.Text = button2.Text;
        }

        private void Layout_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ?", "thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
            Login f = new Login();
            this.Hide();
            f.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Login f = new Login();
            this.Hide();
            f.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            
        }
    }
}
