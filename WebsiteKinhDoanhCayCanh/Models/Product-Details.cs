using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models
{
    public class Product_Details
    {
        public SanPham SanPham { get; set; }
        public PagedList.PagedList<BinhLuan> BinhLuan { get; set; }
        public PagedList.PagedList<DanhGia> DanhGia { get; set; }
    }
}