using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Message;
using WebsiteKinhDoanhCayCanh.Models;
using WebsiteKinhDoanhCayCanh.Models.LinQ;
using NhomSP = WebsiteKinhDoanhCayCanh.Models.NhomSP;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class NhomSPController : Controller
    {
        private MyDataEF db = new MyDataEF();
        ApplicationDbContext data = new ApplicationDbContext();
        // GET: NhomSP
        public ActionResult Index(int? page, string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            //var all_loaiSP = db.LoaiSP.ToList();
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(NhomSP.getAll(searchString).ToPagedList(pageNum, pageSize));
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
            NhomSP nhomSP = db.NhomSP.Find(id);
            if (nhomSP == null)
            {
                return HttpNotFound();
            }
            return View(nhomSP);
        }

        // GET: Create
        public ActionResult Create()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", "id_CCS ");
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Nhom,tenNhom,id_CCS")] NhomSP nhomSP)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.NhomSP.Add(nhomSP);
                db.SaveChanges();
                Notification.set_flash("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", nhomSP.id_CCS);
            return View(nhomSP);
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
            NhomSP nhomSP = db.NhomSP.Find(id);
            if (nhomSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", "id_CCS ");
            return View(nhomSP);
        }

        // POST: Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Nhom,tenNhom,id_CCS")] NhomSP nhomSP)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.Entry(nhomSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", nhomSP.id_CCS);
            return View(nhomSP);
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
            NhomSP nhomSP = db.NhomSP.Find(id);
            if (nhomSP == null)
            {
                return HttpNotFound();
            }
            return View(nhomSP);
        }

        // POST: /Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            NhomSP nhomSP = db.NhomSP.Find(id);
            if (db.SanPham.Where(p => p.id_Nhom == nhomSP.id_Nhom).FirstOrDefault() != null)
            {
                Notification.set_flash("Không thể xoá loại \' " + nhomSP.tenNhom + " \'!", "error");
                return RedirectToAction("Index");
            }
            Notification.set_flash("Đã xoá loại \' " + nhomSP.tenNhom + " \'!", "success");
            db.NhomSP.Remove(nhomSP);
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