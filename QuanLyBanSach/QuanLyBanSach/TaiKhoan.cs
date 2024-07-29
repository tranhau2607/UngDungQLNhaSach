using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanSach;
using WindowsFormsApplication2.Utilities;

namespace QuanLyBanSach
{
    public class TaiKhoan
    {
        public string TenDN { get; set; }
        public string MatKhau { get; set; }

        public TaiKhoan()
        {

        }
        public TaiKhoan(string u, string p)
        {
            TenDN = u;
            MatKhau = p;
        }
        public int LoginTestt(string Username, string password)
        {
            string passwordmd5 = Password.Create_MD5(password);
            string query = "SELECT COUNT(*) FROM TaiKhoan WHERE  TenDN = '"+Username+"' AND Passwords_MD5 = '"+passwordmd5+"'";
            string ConStr = Properties.Settings.Default.ConStr;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int result = (int)cmd.ExecuteScalar();
            int kt = 0;
            if (result != 0)
            {
                string query2 = "SELECT COUNT(*) FROM TaiKhoan WHERE  TenDN = @Username and VaiTro='Admin'";
                SqlCommand command2 = new SqlCommand(query2, con);
                command2.Parameters.AddWithValue("@Username", Username);
                kt = (int)command2.ExecuteScalar();
                if (kt == 1)
                    return 1;//Tra ve trang Admin
                else
                    return 2;//Tra ve trang User
            }
            return kt;
        }
    }
}
