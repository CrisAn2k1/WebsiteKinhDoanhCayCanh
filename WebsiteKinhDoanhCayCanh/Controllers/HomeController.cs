using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Models;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class HomeController : Controller
    {
        private MyDataEF db = new MyDataEF();
        public ActionResult Index()
        {
            var sanpham = db.SanPham;
            return View(sanpham);
        }

        public ActionResult About()
        {           
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}