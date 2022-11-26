using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Message;
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

        public ActionResult ChinhSachMuaHang()
        {
            return View();
        }

        public ActionResult ChinhSachBaoHanh()
        {
            return View();
        }
        public ActionResult CachChamSoc()
        {
            return View();
        }
        public ActionResult DetailsCCS(string id)
        {
            /*var cach = db.CachChamSoc;*/
            CachChamSoc ccs = db.CachChamSoc.Find(id);
            return View(ccs);
        }
    }
}