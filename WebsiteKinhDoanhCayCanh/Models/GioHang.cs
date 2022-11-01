using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models
{
    public class GioHang
    {
        private MyDataEF db = new MyDataEF();
        public string iIdSanPham { set; get; }
        public string sTenSanPham { set; get; }
        public string sHinh { set; get; }
        public double dGia { set; get; }
        public int igiamGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * (dGia - dGia * ((float)igiamGia / 100)); }
        }
        public GioHang(string Id)
        {
            iIdSanPham = Id;
            SanPham sp = db.SanPham.Single(n => n.id_SP == iIdSanPham);
            sTenSanPham = sp.tenSP;
            HinhAnhSP hsp = db.HinhAnhSP.FirstOrDefault(n => n.id_SP == iIdSanPham);
            sHinh = hsp.duongDan;
            dGia = double.Parse(sp.gia.ToString());
            iSoLuong = (int)sp.soLuong;
            igiamGia = (int)sp.phanTramGiamGia;
        }

    }
}
