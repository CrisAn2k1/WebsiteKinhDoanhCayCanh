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
    public class SanPhamsController : Controller
    {
        private MyDataEF db = new MyDataEF();

        // GET: SanPhams
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.NhomSP).Include(s => s.ThongTinThemVeSP);
            return View(sanPham.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(string id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }


            foreach (var i in sanPham.BinhLuan)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.id_User);
                i.hoTen = user.FullName;
            }

            // get đánh giá sản phẩm
            ApplicationUser userLogin = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (userLogin != null)
            {
                if (db.DanhGia.Where(p => p.id_User == userLogin.Id && p.id_SP == id).Count() > 0)
                {
                    ViewBag.ttDanhGia = 1;
                }
                else
                {
                    var getDH = db.DonHang.Where(p => p.id_User == userLogin.Id).ToList();
                    foreach (var item in getDH)
                    {
                        var getCTDH = item.CTDH.ToList();
                        if (getCTDH.Where(p => p.id_SP == id).Count() > 0)
                        {
                            ViewBag.ttMuaHang = 1;
                        }
                    }
                    ViewBag.ttDanhGia = 0;
                }
            }
            if (db.DanhGia.Where(p => p.id_SP == id).Count() != 0)
            {
                float star = (float)db.DanhGia.Where(p => p.id_SP == id).Sum(p => p.soSao) / (float)db.DanhGia.Where(p => p.id_SP == id).Count();
                float motSao = (float)db.DanhGia.Where(p => p.soSao == 1 && p.id_SP == id).Count() / (float)db.DanhGia.Where(p => p.id_SP == id).Count();
                float haiSao = (float)db.DanhGia.Where(p => p.soSao == 2 && p.id_SP == id).Count() / (float)db.DanhGia.Where(p => p.id_SP == id).Count();
                float baSao = (float)db.DanhGia.Where(p => p.soSao == 3 && p.id_SP == id).Count() / (float)db.DanhGia.Where(p => p.id_SP == id).Count();
                float bonSao = (float)db.DanhGia.Where(p => p.soSao == 4 && p.id_SP == id).Count() / (float)db.DanhGia.Where(p => p.id_SP == id).Count();
                float namSao = (float)db.DanhGia.Where(p => p.soSao == 5 && p.id_SP == id).Count() / (float)db.DanhGia.Where(p => p.id_SP == id).Count();
                ViewBag.updateStar = star.ToString("0.#");
                ViewBag.motSao = motSao * 100;
                ViewBag.haiSao = haiSao * 100;
                ViewBag.baSao = baSao * 100;
                ViewBag.bonSao = bonSao * 100;
                ViewBag.namSao = namSao * 100;
            }
            else
            {
                ViewBag.updateStar = 0;
                ViewBag.motSao = 0;
                ViewBag.haiSao = 0;
                ViewBag.baSao = 0;
                ViewBag.bonSao = 0;
                ViewBag.namSao = 0;
            }


            int pageSize = 5;
            int pageNum = page ?? 1;

            // get bình luận sp
            Product_Details sp = new Product_Details
            {
                SanPham = sanPham,
                BinhLuan = (PagedList<BinhLuan>)sanPham.BinhLuan.OrderByDescending(p => p.ngayDangBinhLuan).ToPagedList(pageNum, pageSize)
            };
            return View(sp);

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(string id)
        {
            BinhLuansController addbinhluan = new BinhLuansController();
            BinhLuan binhLuan = new BinhLuan();
            if (Request["txtContent"] != null)
            {
                string content = Request["txtContent"].ToString() + " ";
                if (content == " ")
                {
                    return RedirectToAction("Details");
                }
                addbinhluan.Create(content, id, binhLuan);
            }


            DanhGiasController addDanhGia = new DanhGiasController();
            DanhGia danhGia = new DanhGia();
            if (Request["star"] != null)
            {
                String soSao = Request["star"].ToString() + " ";
                if (soSao == " ")
                {
                    return RedirectToAction("Details");
                }
                int SoSao = Int32.Parse(soSao);
                addDanhGia.Create(SoSao, id, danhGia);
            }




            return RedirectToAction("Details");
        }


        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.id_Nhom = new SelectList(db.NhomSP, "id_Nhom", "tenNhom");
            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_SP,tenSP,mota,gia,soLuong,DVT,phanTramGiamGia,id_Nhom")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Nhom = new SelectList(db.NhomSP, "id_Nhom", "tenNhom", sanPham.id_Nhom);
            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung", sanPham.id_SP);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Nhom = new SelectList(db.NhomSP, "id_Nhom", "tenNhom", sanPham.id_Nhom);
            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung", sanPham.id_SP);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_SP,tenSP,mota,gia,soLuong,DVT,phanTramGiamGia,id_Nhom")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Nhom = new SelectList(db.NhomSP, "id_Nhom", "tenNhom", sanPham.id_Nhom);
            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung", sanPham.id_SP);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
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
