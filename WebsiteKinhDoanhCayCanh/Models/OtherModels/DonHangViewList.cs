using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models.OtherModels
{
    public class DonHangViewList
    {
        public List<LinQ.DonHang> listDonHang { get; set; }
        public List<LinQ.DonHang> listDonHangDaGiao { get; set; }
        public List<LinQ.DonHang> listDonHangDangGiao { get; set; }
        public List<LinQ.DonHang> listDonHangDaHuy { get; set; }
        public List<LinQ.CTDH> chiTietDonHangs { get; set; }
    }
}