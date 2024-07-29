using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanSach.Connect;
namespace QuanLyBanSach.Connect
{
    public class CTHD
    {
        public string TenSach { get; set; }
        public int SoLuongBan { get; set; }
        public double GiaBan { get; set; }
        public double ThanhTien 
        {
            get { return SoLuongBan * GiaBan; }
        }
    }
    public class ConnectCTHD
    {
        List<CTHD> listCTHD = new List<CTHD>();
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);

        public List<CTHD> getCTHD(string MaHD)
        {
            string sql = "select TenSach,SoLuongBan,ChiTietHoaDon.GiaBan from Sach, ChiTietHoaDon where Sach.MaSach=ChiTietHoaDon.MaSach and MaHD="+MaHD+"";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                CTHD cthd = new CTHD();

                //cthd.MaHD = int.Parse(da["MaHD"].ToString());
                cthd.TenSach = da["TenSach"].ToString();
                cthd.SoLuongBan = int.Parse(da["SoLuongBan"].ToString());
                cthd.GiaBan = double.Parse(da["GiaBan"].ToString());

                listCTHD.Add(cthd);
            }
            con.Close();
            return listCTHD;
        } 
    }
}
