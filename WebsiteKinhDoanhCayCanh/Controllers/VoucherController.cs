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
    public class VoucherController : Controller
    {
        // GET: Voucher
        private MyDataEF db = new MyDataEF();
        ApplicationDbContext data = new ApplicationDbContext();


        [Authorize]
        /*public ActionResult Index(int? page, string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            //var all_loaiSP = db.LoaiSP.ToList();
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(Voucher.getAll(searchString).ToPagedList(pageNum, pageSize));
        }*/


        public ActionResult Index(string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            //var all_loaiSP = db.LoaiSP.ToList();            
            return View(Voucher.getAll(searchString));
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
            Voucher voucher = db.Voucher.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // GET: Create
        [Authorize]
        public ActionResult Create()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            //ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", "id_CCS ");
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_voucher,tenVoucher,noiDung,phanTramGiamGia,thoiGianBatDau,thoiGianKetThuc")] Voucher voucher)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                if (db.Voucher.Where(p => p.id_voucher == voucher.id_voucher).FirstOrDefault() != null)
                {
                    Notification.set_flash("Mã voucher đã tồn tại!", "error");
                    return RedirectToAction("Create", "Voucher");
                }
                else
                {
                    db.Voucher.Add(voucher);
                    db.SaveChanges();
                    Notification.set_flash("Thêm voucher thành công!", "success");
                    return RedirectToAction("Index");
                }

            }

            ViewBag.Discount = voucher.phanTramGiamGia;
            return View(voucher);
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
            Voucher voucher = db.Voucher.Find(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            //ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", "id_CCS ");
            return View(voucher);
        }

        // POST: Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_voucher,tenVoucher,noiDung,phanTramGiamGia,thoiGianBatDau,thoiGianKetThuc")] Voucher voucher)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.Entry(voucher).State = EntityState.Modified;
                db.SaveChanges();
                Notification.set_flash("Cập nhật voucher thành công!", "success");
                return RedirectToAction("Index");
            }
            //ViewBag.id_CachChamSoc = new SelectList(db.CachChamSoc, "id_CCS", nhomSP.id_CCS);
            return View(voucher);
        }

        // POST: /Delete
        [Authorize]
        public ActionResult Delete(string id)
        {

            Voucher voucher = db.Voucher.Find(id);
            try
            {
                if (!AuthAdmin())
                    return RedirectToAction("Error401", "Admin");
                Notification.set_flash("Đã xoá voucher \' " + voucher.tenVoucher + " \'!", "success");
                db.Voucher.Remove(voucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Notification.set_flash("Không thể xoá voucher \' " + voucher.tenVoucher + " \'!", "error");
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