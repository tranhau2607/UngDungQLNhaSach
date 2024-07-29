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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            TaiKhoan a = new TaiKhoan();
            int kt = a.LoginTestt(txt_UserName.Text, txt_PassWord.Text);
            if(kt!=0)
            {
                if(checkBox1.Checked)
                {
                    Properties.Settings.Default.UserName = txt_UserName.Text;
                    Properties.Settings.Default.PassWord = txt_PassWord.Text;
                    Properties.Settings.Default.Save();
                }    
               
                if(kt==1)
                {
                    MessageBox.Show("Chào mừng Admin: "+txt_UserName.Text);
                    TaiKhoanNhanVien f = new TaiKhoanNhanVien();
                    this.Hide();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Chào mừng Nhân viên: "+txt_UserName.Text);
                    Layout f = new Layout();
                    this.Hide();
                    f.Show();
                }    
            }
            else
                MessageBox.Show("Sai tài khoảng hoặc mật khẩu");
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?","Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txt_PassWord.PasswordChar = (char)0;
            }
            else
            {
                txt_PassWord.PasswordChar = '*';
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {
            txt_UserName.Text = Properties.Settings.Default.UserName;
            txt_PassWord.Text = Properties.Settings.Default.PassWord;
        }
    }
}
