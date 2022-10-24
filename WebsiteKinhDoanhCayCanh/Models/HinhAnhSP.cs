namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnhSP")]
    public partial class HinhAnhSP
    {
        [Key]
        public int id_Hinh { get; set; }

        [StringLength(250)]
        public string duongDan { get; set; }

        [StringLength(10)]
        public string id_SP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
