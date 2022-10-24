namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuan = new HashSet<BinhLuan>();
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
        public virtual ICollection<CTDH> CTDH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnhSP> HinhAnhSP { get; set; }

        public virtual NhomSP NhomSP { get; set; }

        public virtual ThongTinThemVeSP ThongTinThemVeSP { get; set; }
    }
}
