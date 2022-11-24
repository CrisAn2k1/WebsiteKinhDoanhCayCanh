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

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class CachChamSocController : Controller
    {
        // GET: CachChamSoc

        private MyDataEF db = new MyDataEF();
        ApplicationDbContext data = new ApplicationDbContext();

        /*public ActionResult Index(int? page, string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;            
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(CachChamSoc.getAll(searchString).ToPagedList(pageNum, pageSize));
        }*/

        public ActionResult Index(string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;            
            return View(CachChamSoc.getAll(searchString));
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
            CachChamSoc cachChamSoc = db.CachChamSoc.Find(id);
            if (cachChamSoc == null)
            {
                return HttpNotFound();
            }
            return View(cachChamSoc);
        }

        // GET: Create
        public ActionResult Create()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_CCS,tenCCS,tuoiNuoc,dat,anhSang,viTriDatCay,duongChat")] CachChamSoc cachChamSoc)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.CachChamSoc.Add(cachChamSoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cachChamSoc);
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
            CachChamSoc cachChamSoc = db.CachChamSoc.Find(id);
            if (cachChamSoc == null)
            {
                return HttpNotFound();
            }
            return View(cachChamSoc);
        }

        // POST: Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_CCS,tenCCS,tuoiNuoc,dat,anhSang,viTriDatCay,duongChat")] CachChamSoc cachChamSoc)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.Entry(cachChamSoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cachChamSoc);
        }
        // GET: Delete
        public ActionResult Delete(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CachChamSoc cachChamSoc = db.CachChamSoc.Find(id);
            if (cachChamSoc == null)
            {
                return HttpNotFound();
            }
            return View(cachChamSoc);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            CachChamSoc cachChamSoc = db.CachChamSoc.Find(id);        
            db.CachChamSoc.Remove(cachChamSoc);
            Notification.set_flash("Đã xoá  thành công !", "success");
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