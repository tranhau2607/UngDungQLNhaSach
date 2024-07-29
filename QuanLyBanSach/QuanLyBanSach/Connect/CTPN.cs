using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.Connect
{
    public class CTPN
    {
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public double GiaNhap { get; set; }
        public double TongTien
        {
            get { return GiaNhap * SoLuong; }
        }
    }
    public class ConnectCPN
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConStr);
        public List<CTPN> getCTPN(string maPN)
        {

            List<CTPN> listCTPN = new List<CTPN>();
            string sql = "select TenSach,SoLuong,GiaNhap from Sach, ChiTietPhieuNhap where Sach.MaSach=ChiTietPhieuNhap.MaSach and MaPN =" + maPN + "";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                CTPN cthd = new CTPN();
                cthd.TenSach = da["TenSach"].ToString();
                cthd.SoLuong = int.Parse(da["SoLuong"].ToString());
                cthd.GiaNhap = double.Parse(da["GiaNhap"].ToString());

                listCTPN.Add(cthd);
            }
            con.Close();
            return listCTPN;
        }
    }
}
