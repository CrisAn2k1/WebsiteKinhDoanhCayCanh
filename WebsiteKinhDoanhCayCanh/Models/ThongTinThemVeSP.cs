namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinThemVeSP")]
    public partial class ThongTinThemVeSP
    {
        [Key]
        [StringLength(10)]
        public string id_SP { get; set; }

        [StringLength(255)]
        public string congDung { get; set; }

        [StringLength(255)]
        public string cachTrong { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
