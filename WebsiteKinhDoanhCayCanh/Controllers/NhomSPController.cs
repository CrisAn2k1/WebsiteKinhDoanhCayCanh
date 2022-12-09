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
using WebsiteKinhDoanhCayCanh.Models.OtherModels;
using NhomSP = WebsiteKinhDoanhCayCanh.Models.NhomSP;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class NhomSPController : Controller
    {
        private MyDataEF db = new MyDataEF();
        ApplicationDbContext data = new ApplicationDbContext();

        public void SetViewBag(string selectedId = null)
        {
            var dao = new CCSListView();
            ViewBag.id_CCS = new SelectList(dao.listAll(), "id_CCS", "tenCCS", selectedId);
        }
        // GET: NhomSP
        [Authorize]
        /*public ActionResult Index(int? page, string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            //var all_loaiSP = db.LoaiSP.ToList();
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(NhomSP.getAll(searchString).ToPagedList(pageNum, pageSize));
        }*/
        public ActionResult Index(string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            //var all_loaiSP = db.LoaiSP.ToList();            
            return View(NhomSP.getAll(searchString));
        }

        // GET: Details
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            //ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", "tenCCS ");
            SetViewBag();
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Nhom,tenNhom,id_CCS")] NhomSP nhomSP)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                if (db.NhomSP.Where(p => p.id_Nhom == nhomSP.id_Nhom).FirstOrDefault() != null)
                {
                    Notification.set_flash("Mã nhóm cây đã tồn tại!", "error");
                    return View(nhomSP);
                }
                else
                {
                    db.NhomSP.Add(nhomSP);
                    db.SaveChanges();
                    Notification.set_flash("Thêm nhóm cây thành công", "success");
                    return RedirectToAction("Index");
                }

            }
            //ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", nhomSP.id_CCS);
            SetViewBag();
            return View(nhomSP);
        }

        // GET: Edit
        [Authorize]
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
            ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", "tenCCS");
            return View(nhomSP);
        }

        // POST: Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
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
                Notification.set_flash("Cập nhật nhóm cây thành công", "success");
                return RedirectToAction("Index");
            }
            ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", nhomSP.id_CCS);
            return View(nhomSP);
        }

        // POST: /Delete
        [Authorize]
        public ActionResult Delete(string id)
        {
            NhomSP nhomSP = db.NhomSP.Find(id);

            try
            {
                if (!AuthAdmin())
                    return RedirectToAction("Error401", "Admin");
                Notification.set_flash("Đã xoá nhóm cây \' " + nhomSP.tenNhom + " \'!", "success");
                db.NhomSP.Remove(nhomSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Notification.set_flash("Không thể xoá nhóm cây \' " + nhomSP.tenNhom + " \'!", "error");
                return RedirectToAction("Index");
            }


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