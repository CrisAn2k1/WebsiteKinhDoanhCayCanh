using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Models;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class BinhLuansController : Controller
    {
        private MyDataEF db = new MyDataEF();

        // GET: BinhLuans
        [Authorize]
        public ActionResult Index()
        {
            //int pageSize = 12;
            //int pageNum = page ?? 1;
            //var binhLuan = db.BinhLuan.Where(p => p.id_SP == id_SP).ToList().ToPagedList(pageNum, pageSize);
            var binhLuan = db.BinhLuan.ToList();
            return View(binhLuan);
        }

        //// GET: BinhLuans/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BinhLuan binhLuan = db.BinhLuan.Find(id);
        //    if (binhLuan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(binhLuan);
        //}

        //// GET: BinhLuans/Create
        //public ActionResult Create()
        //{
        //    ViewBag.id_SP = new SelectList(db.SanPham, "id_SP", "tenSP");
        //    return View();
        //}

        // POST: BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string content, string id, [Bind(Include = "id_BinhLuan,ngayDangBinhLuan,noiDung,trangThai,id_User,id_SP")] BinhLuan binhLuan)
        {
            // khong xet valid MaKH vi bang user dang nhap
            ModelState.Remove("id_User");
            if (!ModelState.IsValid)
            {
                ViewBag.id_SP = new SelectList(db.SanPham, "id_SP", "tenSP", binhLuan.id_SP);
                return View(binhLuan);
            }

            // get login user id
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            binhLuan.id_User = user.Id;
            binhLuan.id_SP = id;
            binhLuan.noiDung = content;
            binhLuan.ngayDangBinhLuan = DateTime.Now;
            binhLuan.trangThai = true;
            db.BinhLuan.Add(binhLuan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: BinhLuans/Edit/5
        public ActionResult Hidden(int? id)
        {
            BinhLuan binhLuan = db.BinhLuan.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            binhLuan.trangThai = !binhLuan.trangThai;
            db.SaveChanges();
            return Redirect("/BinhLuans");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
