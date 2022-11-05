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
        /*MyDBContextDataContext context = new MyDBContextDataContext();*/
        public ActionResult Index()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            //var kh = context.Users.ToList();
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
    }
}