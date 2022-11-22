using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Models;
using WebsiteKinhDoanhCayCanh.Models.LinQ;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ApplicationDbContext data = new ApplicationDbContext();
        MyDBDataContext context = new MyDBDataContext();
        public ActionResult Index()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            //var kh = context.Users.ToList();
            return View();
        }
        public ActionResult tongsp()
        {
            var sp = context.SanPhams.ToList();
            return View(sp);
        }
        public ActionResult tongnhomsp()
        {
            var snsp = context.NhomSPs.ToList();
            return View(snsp);
        }

        public ActionResult sodonhang()
        {
            var sdh = context.DonHangs.ToList();
            return View(sdh);
        }

        public ActionResult sokh()
        {
            var countAdmin = context.UserRoles.Where(p => p.RoleId == "1").Count();
            var countKH = context.Users.Count() - countAdmin;
            ViewBag.SoKH = countKH;
            return View();

        }
        public ActionResult Error401()
        {
            return View();
        }
        public bool AuthAdmin()
        {
            var user = data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return false;
            var userExist = user.Roles.FirstOrDefault(r => r.UserId == user.Id);
            if (userExist == null)
                return false;
            if (userExist.RoleId != "1")
                return false;
            return true;
        }

        public ActionResult GetDataDoanhThu()
        {
            var data = context.DonHangs.Where(p => p.trangThaiThanhToan == true && p.trangThaiGiaoHang == '1')
                .GroupBy(p => p.ngayGiao)
                .Select(g => new { Ngay = DateTime.Parse(g.Key.ToString()).ToString("dd-MM-yyyy"), tongtien = g.Sum(n => n.tongTien) }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}