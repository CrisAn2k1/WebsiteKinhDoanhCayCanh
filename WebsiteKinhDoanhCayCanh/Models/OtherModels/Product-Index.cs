using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteKinhDoanhCayCanh.Models.OtherModels
{
    public class Product_Index
    {
        public PagedList.PagedList<SanPham> SanPhams { get; set; }
    }
}