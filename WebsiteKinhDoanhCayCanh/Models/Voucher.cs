namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Voucher")]
    public partial class Voucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Voucher()
        {
            DonHang = new HashSet<DonHang>();
            UserVoucher = new HashSet<UserVoucher>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "Số ký tự tối đa là 10!")]
        [Required(ErrorMessage = "Nhập mã voucher!")]
        public string id_voucher { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string tenVoucher { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string noiDung { get; set; }

        [Required(ErrorMessage = "Nhập thiếu!")]
        public int? phanTramGiamGia { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public DateTime? thoiGianBatDau { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public DateTime? thoiGianKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserVoucher> UserVoucher { get; set; }

        public static List<Voucher> getAll(string searchKey)
        {
            MyDataEF db = new MyDataEF();
            searchKey = searchKey + "";
            return db.Voucher.Where(p => p.tenVoucher.Contains(searchKey)).ToList();
        }
    }
}
