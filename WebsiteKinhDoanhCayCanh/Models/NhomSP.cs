namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("NhomSP")]
    public partial class NhomSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomSP()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        public string id_Nhom { get; set; }

        [StringLength(50)]
        public string tenNhom { get; set; }

        [StringLength(10)]
        public string id_CCS { get; set; }

        public virtual CachChamSoc CachChamSoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
        public static List<NhomSP> getAll(string searchKey)
        {
            MyDataEF db = new MyDataEF();
            searchKey = searchKey + "";
            return db.NhomSP.Where(p => p.tenNhom.Contains(searchKey)).ToList();
        }
    }
}
