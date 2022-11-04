namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuan = new HashSet<BinhLuan>();
            CTCapNhat = new HashSet<CTCapNhat>();
            CTDH = new HashSet<CTDH>();
            DanhGia = new HashSet<DanhGia>();
            HinhAnhSP = new HashSet<HinhAnhSP>();
        }

        [Key]
        [StringLength(10)]
        public string id_SP { get; set; }

        [StringLength(50)]
        public string tenSP { get; set; }

        [StringLength(250)]
        public string mota { get; set; }

        public long? gia { get; set; }

        public int? soLuong { get; set; }

        [StringLength(10)]
        public string DVT { get; set; }

        public int? phanTramGiamGia { get; set; }

        [StringLength(10)]
        public string id_Nhom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTCapNhat> CTCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnhSP> HinhAnhSP { get; set; }

        public virtual NhomSP NhomSP { get; set; }

        public virtual ThongTinThemVeSP ThongTinThemVeSP { get; set; }

        // Mot so chuc nang rieng biet

        public static List<SanPham> getAll(string searchKey)
        {
            MyDataEF db = new MyDataEF();
            searchKey = searchKey + "";
            return db.SanPham.Where(p => p.tenSP.Contains(searchKey) && p.soLuong > 0).ToList();
        }

        public static List<SanPham> getSanPhamTheoLoai(string maNhomSP)
        {
            MyDataEF db = new MyDataEF();
            return db.SanPham.Where(p => p.id_Nhom == maNhomSP && p.soLuong > 0).ToList();
        }

        public static List<SanPham> getSanPhamTheoLoai_Search(string maNhomSP, string searchKey)
        {
            searchKey = searchKey.ToLower();
            MyDataEF db = new MyDataEF();
            var listNhom_SP = db.SanPham.Where(p => p.id_Nhom == maNhomSP && p.soLuong > 0).ToList();
            var kq = listNhom_SP.Where(p => p.tenSP.ToLower().Contains(searchKey)).ToList();
            return kq;
        }
    }
}
