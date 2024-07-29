using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTL { get; set; }
        public string MaNXB { get; set; }
        public string MaTG { get; set; }
        public string SoLuongTon { get; set; }
        public string GiaBan { get; set; }
        public string HinhAnh { get; set; }
        public string NgonNgu { get; set; }
        public string NamXuatBan { get; set; }
    }

    public class ConnectSach
    {
        List<Sach> listSach = new List<Sach>();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        
        public List<Sach> getSach()
        {
            string sql = "select * from Sach";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                Sach sach = new Sach();


                sach.MaSach = da["MaSach"].ToString();
                sach.TenSach = da["TenSach"].ToString();
                sach.GiaBan = da["GiaBan"].ToString();
                sach.MaTL= da["MaTL"].ToString();
                sach.MaNXB = da["MaNXB"].ToString();
                sach.MaTG = da["MaTG"].ToString();
                sach.SoLuongTon= da["SoLuongTon"].ToString();
                sach.HinhAnh = da["HinhAnh"].ToString();
                sach.NgonNgu = da["NgonNgu"].ToString();
                sach.NamXuatBan = da["NamXuatBan"].ToString();
                listSach.Add(sach);
            }
            con.Close();
            return listSach;
        }

        public int addSach(Sach a)
        {
            int rs = 0;
            con.Open();
            string sql = "INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)";
            sql += "VALUES( N'"+a.TenSach+ "'," + a.GiaBan + ", '" + a.MaTL + "', '" + a.MaNXB + "', '" + a.MaTG + "', " + a.SoLuongTon + ", '" + a.HinhAnh + "', N'" + a.NgonNgu + "', '" + a.NamXuatBan + "');";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs;
        }
        public int deleteSach(string MaSach)
        {
            int rs = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "	delete from Sach where MaSach=" + MaSach + "";
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
        public int updateSach(Sach a)
        {
            int rs = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string sql = "update Sach set TenSach=N'"+ a.TenSach + "',GiaBan="+ a.GiaBan +",MaTL="+ a.MaTL +",MaNXB="+ a.MaNXB + ",MaTG="+ a.MaTG +",SoLuongTon="+ a.SoLuongTon +",HinhAnh='"+ a.HinhAnh +"',NgonNgu=N'"+ a.NgonNgu +"',NamXuatBan='"+ a.NamXuatBan + "' where MaSach="+ a.MaSach + "";
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
