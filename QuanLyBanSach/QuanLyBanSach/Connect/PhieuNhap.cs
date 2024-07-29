using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class PhieuNhap
    {
       public int MaPN { get; set; }
        public int MaNCC { get; set; }
        public string TenDN { get; set; }
        public string NgayNhap { get; set; }
        public double TongTien { get; set; }
    }
    //public class ChiTietPhieuNhap
    //{
    //    int MaPN { get; set; }
    //    int MaSach { get; set; }
    //    int SoLuong { get; set; }
    //    float GiaNhap { get; set; }
    //}
    public class ConnectPhieuNhap
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        public PhieuNhap loadPN(string MaPN)
        {
            PhieuNhap pn = new PhieuNhap();
            try
            {
                con.Open();
                string sql = "select * from PhieuNhap where MaPN="+MaPN+"";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    pn.MaPN = int.Parse(dr["MaPN"].ToString());
                    pn.MaNCC = int.Parse(dr["MaNCC"].ToString());
                    pn.TenDN = dr["TenDN"].ToString();
                    pn.NgayNhap = dr["NgayNhap"].ToString();
                    if (dr["TongTien"].ToString() == "")
                        pn.TongTien = 0;
                    else
                        pn.TongTien = double.Parse(dr["TongTien"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch
            {
                return null;
            }
           
            return pn;

        }
        public int KiemTraTaiKhoan_DonHang(string TenDN,string MaPN)
        {
            //Kiểm tra Tài khoảng  TenDN có phải là tài khoản đã tạo đơn hàng không 
            con.Open();
            string sql = "if "+MaPN+" in (select MaPN from PhieuNhap where TenDN='"+TenDN+ "') select 1 else select 0 ";
            SqlCommand cmd = new SqlCommand(sql, con);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs;
        }
        public int addChiTietPhieuNhap(string MaPN,string MaSach,string SoLuong,string GiaNhap)
        {
            con.Open();
            int rs = 0;
            string sql = "";
            string kiemtra = "select count(*) from ChiTietPhieuNhap where MaPN=" + MaPN + " and MaSach=" + MaSach + ";";

            SqlCommand cmd = new SqlCommand(kiemtra, con);
            int kt = 0;
            kt = (int)cmd.ExecuteScalar();
            if (kt != 0)
            {
                sql = "update ChiTietPhieuNhap set SoLuong = SoLuong + " + SoLuong + " where MaPN=" + MaPN + " and MaSach=" + MaSach + ";";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }
            else
            {
                sql = "insert into ChiTietPhieuNhap values(" + MaPN + "," + MaSach + "," + SoLuong + "," + GiaNhap + ");";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            updateTongTien(MaPN);
            return rs;
        }
        public void updateTongTien(string MaPN)
        {
            con.Open();
            int rs = 0;
            string sql = "update PhieuNhap set TongTien = (select(sum(GiaNhap * Soluong)) from ChiTietPhieuNhap where PhieuNhap.MaPN = ChiTietPhieuNhap.MaPN) where MaPN = "+MaPN+"";
            SqlCommand cmd = new SqlCommand(sql, con);
            rs = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
