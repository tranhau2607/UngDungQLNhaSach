using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class TaiKhoanND
    {
        public string TenDN { get; set; }
        public string Passwords { get; set; }
        public string Passwords_MD5 { get; set; }
        public string Vaitro { get; set; }
        
    }
    public class ConnectTaiKhoan
    {
        List<TaiKhoanND> listTaiKhoan = new List<TaiKhoanND>();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);

        public List<TaiKhoanND> getTaiKhoan()
        {
            string sql = "select TenDN, Passwords,Vaitro from TaiKhoan";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                TaiKhoanND taikhoan = new TaiKhoanND();


                taikhoan.TenDN = da["TenDN"].ToString();
                taikhoan.Passwords = da["Passwords"].ToString();
                taikhoan.Vaitro = da["Vaitro"].ToString();

                listTaiKhoan.Add(taikhoan);
            }
            con.Close();
            return listTaiKhoan;
        }

        public int addTaiKhoan(TaiKhoanND a)
        {
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "INSERT INTO TaiKhoan(TenDN, Passwords,Passwords_MD5,Vaitro)VALUES(N'" + a.TenDN + "',N'" + a.Passwords + "',N'" + a.Passwords_MD5 + "',N'" + a.Vaitro + "');";
                cmd.CommandText = sql;
                cmd.Connection = con;
                rs = cmd.ExecuteNonQuery();
                con.Close();
                return rs;
            }
            catch
            {
                return 0;
            }

        }

        public int deleteTaiKhoan(string TenDN)
        {
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "delete from TaiKhoan where TenDN='" + TenDN + "';";
                cmd.CommandText = sql;
                cmd.Connection = con;
                rs = cmd.ExecuteNonQuery();
                con.Close();
                return rs;
            }
            catch
            {
                return 0;
            }

        }
        public int updateTaiKhoan(TaiKhoanND a)
        {
            int rs = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "update TaiKhoan set Passwords='" + a.Passwords + "',Passwords_MD5='" + a.Passwords_MD5 + "',Vaitro='" + a.Vaitro + "' where TenDN='" + a.TenDN + "';";
                cmd.CommandText = sql;
                cmd.Connection = con;
                rs = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                return 0;
            }
            return rs;
        }
    }
}
