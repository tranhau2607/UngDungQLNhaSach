using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public string TenDN { get; set; }
        public string NgayBan { get; set; }
        public double TongTien { get; set; }
    }
    public class ConnectHoaDon
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        public HoaDon loadHoaDon(string MaHD)
        {
            HoaDon pn = new HoaDon();
            try
            {
                con.Open();
                string sql = "select * from HoaDon where MaHD=" + MaHD + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    pn.MaHD = int.Parse(dr["MaHD"].ToString());
                    pn.TenDN = dr["TenDN"].ToString();
                    pn.NgayBan = dr["NgayBan"].ToString();
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
        public int KiemTraTaiKhoan_DonHang(string TenDN, string MaHD)
        {
            //Kiểm tra Tài khoảng  TenDN có phải là tài khoản đã tạo đơn hàng không 
            con.Open();
            string sql = "if " + MaHD + " in (select MaHD from HoaDon where TenDN='" + TenDN + "') select 1 else select 0 ";
            SqlCommand cmd = new SqlCommand(sql, con);
            int rs = (int)cmd.ExecuteScalar();
            con.Close();
            return rs;
        }
        
        public int addChiTietHoaDon(string MaHD, string MaSach, string SoLuongBan, string GiaBan)
        {
            con.Open();
            int rs = 0;
            string sql = "";
            string kiemtra = "select count(*) from ChiTietHoaDon where MaHD="+MaHD+" and MaSach="+MaSach+";";
           
            SqlCommand cmd = new SqlCommand(kiemtra, con);
            int kt = 0;
            kt = (int)cmd.ExecuteScalar();
            if(kt!=0)
            {
                sql = "update ChiTietHoaDon set SoLuongBan = SoLuongBan + "+SoLuongBan+" where MaHD="+MaHD+" and MaSach="+MaSach+";";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            } 
            else
            {
                sql = "INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan) VALUES(" + MaHD + "," + MaSach + ", " + SoLuongBan + ", " + GiaBan + ");";
                cmd.CommandText = sql;
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            updateTongTien(MaHD);
            return rs;
        }
        public void updateTongTien(string MaHD)
        {
            con.Open();
            int rs = 0;
            string sql = "update HoaDon set TongTien = (select(sum(GiaBan * SoLuongBan)) from ChiTietHoaDon where HoaDon.MaHD = ChiTietHoaDon.MaHD) where MaHD = " + MaHD + ";";
            SqlCommand cmd = new SqlCommand(sql, con);
            rs = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
