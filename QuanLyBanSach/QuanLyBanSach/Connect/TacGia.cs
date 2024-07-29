using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class TacGia
    {
        public string MaTG { get; set; }
        public string TenTG { get;set;}
        public string LienLac { get; set; }
        public string NamSinh { get; set; }
        public string NamMat { get; set; }
        public TacGia(string t,string l,string ns, string m)
        {
            TenTG = t;
            LienLac = l;
            NamSinh = ns;
            NamMat = m;
        }

        public TacGia()
        {
        }
    }
   
    public class ConnectTacGia
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        List<TacGia> listTacGia = new List<TacGia>();
        public int addTacGia(TacGia a)
        {
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                if (a.NamMat == "")
                    a.NamMat = "NULL";
                string sql = "insert into TacGia(TenTG,LienLac,NamSinh,NamMat) values(N'"+a.TenTG+ "','"+a.LienLac+ "',"+a.NamSinh+ ","+a.NamMat+");";
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

        public int deleteTacGia(string MaTC)
        {
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "delete from TacGia where MaTG=" + MaTC + ";";
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
        public int updateTacGia(TacGia a)
        {
            int rs = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                if (a.NamMat == "")
                    a.NamMat = "NULL";
                string sql = "update TacGia set TenTG=N'"+a.TenTG+ "',LienLac='" + a.LienLac + "',NamSinh=" + a.NamSinh + ",NamMat=" + a.NamMat + " where MaTG=" + a.MaTG+ ";";
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

