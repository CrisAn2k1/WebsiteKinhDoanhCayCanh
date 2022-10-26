using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
    public class DanhGiasController : Controller
    {
        private MyDataEF db = new MyDataEF();

        // GET: DanhGias
        public ActionResult Index()
        {
            var danhGia = db.DanhGia.Include(d => d.SanPham);
            return View(danhGia.ToList());
        }

        // GET: DanhGias/Create
        public ActionResult Create()
        {
            ViewBag.id_SP = new SelectList(db.SanPham, "id_SP", "tenSP");
            return View();
        }

        // POST: DanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int numberStar, string id, [Bind(Include = "id_DanhGia,soSao,ngayDG,trangThai,id_User,id_SP")] DanhGia danhGia)
        {
            ModelState.Remove("id_User");
            if (!ModelState.IsValid)
            {
                ViewBag.id_SP = new SelectList(db.SanPham, "id_SP", "tenSP", danhGia.id_SP);
                return View(danhGia);
            }

            //Lay login user id
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            danhGia.id_User = user.Id;
            danhGia.id_SP = id;
            danhGia.soSao = numberStar;
            danhGia.ngayDG = DateTime.Now;
            db.DanhGia.Add(danhGia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DanhGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGia.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // POST: DanhGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGia danhGia = db.DanhGia.Find(id);
            db.DanhGia.Remove(danhGia);
            db.SaveChanges();
            return RedirectToAction("Index");
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
