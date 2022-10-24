namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        public int id_DanhGia { get; set; }

        public int? soSao { get; set; }

        public DateTime? ngayDG { get; set; }

        [StringLength(1)]
        public string trangThai { get; set; }

        [StringLength(128)]
        public string id_User { get; set; }

        [StringLength(10)]
        public string id_SP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
