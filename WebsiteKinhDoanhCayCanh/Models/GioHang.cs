using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models
{
    public class GioHang
    {
        private MyDataEF db = new MyDataEF();
        [Display(Name = "Mã sản phẩm")]
        public string iIdSanPham { set; get; }

        [Display(Name = "Tên sản phẩm")]
        public string sTenSanPham { set; get; }

        [Display(Name = "Ảnh")]
        public string sHinh { set; get; }

        [Display(Name = "Giá bán")]
        public double dGia { set; get; }

        [Display(Name = "Giảm giá")]
        public int igiamGia { set; get; }

        [Display(Name = "Số lượng")]
        public int iSoLuong { set; get; }

        [Display(Name = "Thành tiền")]
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
