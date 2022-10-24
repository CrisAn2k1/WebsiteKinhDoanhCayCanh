namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CachChamSoc")]
    public partial class CachChamSoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CachChamSoc()
        {
            NhomSP = new HashSet<NhomSP>();
        }

        [Key]
        [StringLength(10)]
        public string id_CCS { get; set; }

        [Column(TypeName = "text")]
        public string tuoiNuoc { get; set; }

        [Column(TypeName = "text")]
        public string dat { get; set; }

        [Column(TypeName = "text")]
        public string anhSang { get; set; }

        [Column(TypeName = "text")]
        public string viTriDatCay { get; set; }

        [Column(TypeName = "text")]
        public string duongChat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomSP> NhomSP { get; set; }
    }
}
