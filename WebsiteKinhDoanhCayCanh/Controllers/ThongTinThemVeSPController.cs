using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using WebsiteKinhDoanhCayCanh.Models;
using WebsiteKinhDoanhCayCanh.Message;
using System.Data.Entity;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class ThongTinThemVeSPController : Controller
    {
        // GET: ThongTinThemVeSP
        private MyDataEF db = new MyDataEF();
        ApplicationDbContext data = new ApplicationDbContext();
        // GET: NhomSP
        public ActionResult Index(int? page)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            //ViewBag.Keyword = searchString;
            //var all_loaiSP = db.LoaiSP.ToList();
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(ThongTinThemVeSP.getAll().ToPagedList(pageNum, pageSize));
        }

        // GET: Details
        public ActionResult Details(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinThemVeSP thongTinThemVeSP = db.ThongTinThemVeSP.Find(id);
            if (thongTinThemVeSP == null)
            {
                return HttpNotFound();
            }
            return View(thongTinThemVeSP);
        }

        // GET: Create
        public ActionResult Create()
        {
            /*            if (!AuthAdmin())
                            return RedirectToAction("Error401", "Admin");
                        //ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS");
                        return View();*/

            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung", "cachTrong");
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string congdung, string cachtrong, string id, [Bind(Include = "id_SP,congDung,cachTrong")] ThongTinThemVeSP thongTinThemVeSP)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP,  "congDung" , thongTinThemVeSP.id_SP);

                return RedirectToAction("thongTinThemVeSP");
            }
            thongTinThemVeSP.id_SP = id;
            thongTinThemVeSP.congDung = congdung;
            thongTinThemVeSP.cachTrong = cachtrong;

            db.ThongTinThemVeSP.Add(thongTinThemVeSP);
            db.SaveChanges();
            return View(thongTinThemVeSP);
        }

        // GET: Edit
        public ActionResult Edit(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinThemVeSP thongTinThemVeSP = db.ThongTinThemVeSP.Find(id);
            if (thongTinThemVeSP == null)
            {
                return HttpNotFound();
            }
            return View(thongTinThemVeSP);
        }

        // POST: Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_SP,congDung,cachTrong")] ThongTinThemVeSP thongTinThemVeSP)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.Entry(thongTinThemVeSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTinThemVeSP);
        }
        // GET: /Delete
        public ActionResult Delete(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinThemVeSP thongTinThemVeSP = db.ThongTinThemVeSP.Find(id);
            if (thongTinThemVeSP == null)
            {
                return HttpNotFound();
            }
            return View(thongTinThemVeSP);
        }

        // POST: /Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ThongTinThemVeSP thongTinThemVeSP = db.ThongTinThemVeSP.Find(id);
            if (db.ThongTinThemVeSP.Where(p => p.id_SP == thongTinThemVeSP.id_SP).FirstOrDefault() != null)
            {
                Notification.set_flash("Không thể xoá loại \' " + thongTinThemVeSP.SanPham.tenSP + " \'!", "error");
                return RedirectToAction("Index");
            }
            Notification.set_flash("Đã xoá loại \' " + thongTinThemVeSP.SanPham.tenSP + " \'!", "success");
            db.ThongTinThemVeSP.Remove(thongTinThemVeSP);
            db.SaveChanges();
            return RedirectToAction("Index");
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