namespace WebsiteKinhDoanhCayCanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserVoucher")]
    public partial class UserVoucher
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id_voucher { get; set; }

        [Key]
        [Column(Order = 1)]
        public string id_User { get; set; }

        public int? soLuotConLai { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
