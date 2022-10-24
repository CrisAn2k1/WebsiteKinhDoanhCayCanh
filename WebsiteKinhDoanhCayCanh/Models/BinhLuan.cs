namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        public int id_BinhLuan { get; set; }

        public DateTime? ngayDangBinhLuan { get; set; }

        [StringLength(250)]
        public string noiDung { get; set; }

        [StringLength(10)]
        public string trangThai { get; set; }

        [StringLength(128)]
        public string id_User { get; set; }

        [StringLength(10)]
        public string id_SP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
