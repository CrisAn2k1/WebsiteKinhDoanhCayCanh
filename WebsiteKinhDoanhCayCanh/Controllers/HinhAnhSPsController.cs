using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Message;
using WebsiteKinhDoanhCayCanh.Models;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class HinhAnhSPsController : Controller
    {
        private MyDataEF db = new MyDataEF();

        // GET: HinhAnhSPs
        [Authorize]
        public ActionResult Index(string id_SP)
        {
            var hinhAnhSP = db.HinhAnhSP.Where(p => p.id_SP == id_SP).ToList();
            if (hinhAnhSP == null)
            {
                return Redirect("SanPhams/IndexAdmin");
            }
            ViewBag.TenSP = hinhAnhSP.Find(p => p.id_SP == id_SP).SanPham.tenSP;
            return View(hinhAnhSP);
        }

        // GET: HinhAnhSPs/Create
        public ActionResult Create(string id_SP, string duongDan)
        {
            HinhAnhSP hinhAnhSP = new HinhAnhSP();
            hinhAnhSP.id_SP = id_SP;
            hinhAnhSP.duongDan = duongDan;
            db.HinhAnhSP.Add(hinhAnhSP);
            db.SaveChanges();
            Notification.set_flash("Thêm ảnh thành công!", "success");
            return Redirect("/HinhAnhSPs?id_SP=" + id_SP);
        }

        // POST: HinhAnhSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Hinh,duongDan,id_SP")] HinhAnhSP hinhAnhSP)
        {
            if (ModelState.IsValid)
            {
                db.HinhAnhSP.Add(hinhAnhSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_SP = new SelectList(db.SanPham, "id_SP", "tenSP", hinhAnhSP.id_SP);
            return View(hinhAnhSP);
        }

        // GET: HinhAnhSPs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnhSP hinhAnhSP = db.HinhAnhSP.Find(id);
            string idSP = hinhAnhSP.id_SP;
            if (hinhAnhSP == null)
            {
                return HttpNotFound();
            }
            db.HinhAnhSP.Remove(hinhAnhSP);
            db.SaveChanges();
            Notification.set_flash("Xóa ảnh thành công!", "success");
            return Redirect("/HinhAnhSPs?id_SP=" + idSP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Template/img/Product/" + file.FileName));
            return "/Template/img/Product/" + file.FileName;
        }
    }
}
