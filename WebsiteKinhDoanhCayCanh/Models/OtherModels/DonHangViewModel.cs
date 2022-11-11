using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models.OtherModels
{
    public class DonHangViewModel
    {
        public LinQ.DonHang DonHang { get; set; }
        public List<CTDH> CTDH { get; set; }
    }
}