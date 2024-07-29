using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class NhaXuatBan
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        public NhaXuatBan(string t, string e, string dc, string sdt)
        {
            TenNXB = t;
            Email = e;
            DiaChi = dc;
            DienThoai = sdt;
        }
        public NhaXuatBan()
        {
        }
    }
    public class ConnectNhaXuatBan
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
     
        public int addNXB(NhaXuatBan a)
        {
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "insert into NhaXuatBan(TenNXB,Email,DiaChiNXB,DienThoai) values(N'"+a.TenNXB+ "','" + a.Email + "',N'" + a.DiaChi + "','" + a.DienThoai + "')";
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
        public int deleteNXB(string MaNXB)
        {
            try
            {
                int rs = 0;
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "delete NhaXuatBan where MaNXB=" + MaNXB + ";";
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
        public int updateNhaXuatBan(NhaXuatBan a)
        {
            int rs = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "update NhaXuatBan set TenNXB=N'" + a.TenNXB + "',Email='" + a.Email + "',DiaChiNXB=N'" + a.DiaChi + "',DienThoai='" + a.DienThoai + "' where MaNXB=" + a.MaNXB+";";
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
