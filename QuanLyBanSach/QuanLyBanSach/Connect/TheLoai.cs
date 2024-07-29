using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class TheLoai
    {
        public string MaTL { get; set; }
        public string TenTL { get; set; }
    }
    public class ConnectTheLoai
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        List<TheLoai> listTheLoai = new List<TheLoai>();
        public int addTheLoai(string TenTL)
        {   
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "select count(*) from TheLoai where TenTL=N'"+TenTL+"'";
                cmd.CommandText = sql;
                cmd.Connection = con;
                int kt = (int)cmd.ExecuteScalar();
                if (kt == 0)
                {
                    sql = "insert into TheLoai(TenTL) values(N'" + TenTL + "');";
                    cmd.CommandText = sql;
                    rs = cmd.ExecuteNonQuery();
                }
                con.Close();
                return rs;
            }
            catch
            {
                return 0;
            }

        }
        public int deleteTheLoai(string MaTL)
        {
           
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "delete from TheLoai where MaTL=" + MaTL + ";";
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
        public int updateTheLoai(string TenTL,string MaTL)
        {
            int rs = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "update TheLoai set TenTL=N'"+TenTL+"' where MaTL="+MaTL+"";
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
