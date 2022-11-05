namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTCapNhat")]
    public partial class CTCapNhat
    {
        [Key]
        public long id_CTCN { get; set; }

        [Required]
        [StringLength(128)]
        public string id_User { get; set; }

        [Required]
        [StringLength(10)]
        public string id_SP { get; set; }

        public DateTime? ngayCapNhat { get; set; }

        [StringLength(50)]
        public string thaoTac { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}