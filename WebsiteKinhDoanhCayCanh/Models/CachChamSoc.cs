namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("CachChamSoc")]
    public partial class CachChamSoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CachChamSoc()
        {
            NhomSP = new HashSet<NhomSP>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "Số ký tự tối đa là 10!")]
        [Required(ErrorMessage = "Chưa nhập mã cách chăm sóc!")]
        public string id_CCS { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Chưa nhập tên cách chăm sóc!")]
        public string tenCCS { get; set; }

        
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string tuoiNuoc { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string dat { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string anhSang { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string viTriDatCay { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Nhập thiếu!")]
        public string duongChat { get; set; }        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomSP> NhomSP { get; set; }
        public static List<CachChamSoc> getAll(string searchKey)
        {
            MyDataEF db = new MyDataEF();
            searchKey = searchKey + "";
            return db.CachChamSoc.Where(p => p.id_CCS.Contains(searchKey)).ToList();
        }
    }
}
