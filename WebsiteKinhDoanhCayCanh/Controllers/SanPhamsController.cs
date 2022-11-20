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
using WebsiteKinhDoanhCayCanh.Models.OtherModels;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class SanPhamsController : Controller
    {
        private MyDataEF db = new MyDataEF();
        ApplicationDbContext data = new ApplicationDbContext();
        // GET: SanPhams

        //user 
        public ActionResult Index(int? page, string id_Nhom, string searchString)
        {
            ViewBag.Keyword = searchString;
            ViewBag.idNhom = id_Nhom;
            int pageSize = 12;
            int pageNum = page ?? 1;
            Product_Index search_SP;

            if ((id_Nhom != null && id_Nhom != "") && (searchString != null))
            {
                search_SP = new Product_Index()
                {
                    SanPhams = (PagedList<SanPham>)SanPham.getSanPhamTheoLoai_Search(id_Nhom, searchString).ToPagedList(pageNum, pageSize)
                };
                return View(search_SP);
            }
            else
            {
                if ((id_Nhom != null) && id_Nhom != "")
                {
                    search_SP = new Product_Index()
                    {
                        SanPhams = (PagedList<SanPham>)SanPham.getSanPhamTheoLoai(id_Nhom).ToPagedList(pageNum, pageSize)
                    };
                    return View(search_SP);
                }
                else
                {
                    search_SP = new Product_Index()
                    {
                        SanPhams = (PagedList<SanPham>)SanPham.getAll(searchString).ToPagedList(pageNum, pageSize)
                    };
                    return View(search_SP);

                }
            }

        }

        // GET: SanPhams/Details
        //user
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


        // ADMIN

        [Authorize]
        public ActionResult IndexAdmin(int? page, string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            //var all_sanPham = db.SanPham.ToList();
            int pageSize = 5;
            int pageNum = page ?? 1;
            return View(SanPham.getAllAdmin(searchString).ToPagedList(pageNum, pageSize));
        }

        // GET: SanPhams/Details/5 Admin
        [Authorize]
        public ActionResult DetailsAdmin(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
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
        // GET: SanPhams/Create
        [Authorize]
        public ActionResult Create()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");

            ViewBag.id_Nhom = new SelectList(db.NhomSP, "id_Nhom", "tenNhom");
            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_SP,tenSP,mota,gia,soLuong,DVT,phanTramGiamGia,id_Nhom,trangThai")] SanPham sanPham)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");

            var idUser = System.Web.HttpContext.Current.User.Identity.GetUserId();

            if (ModelState.IsValid && idUser != null)
            {
                db.SanPham.Add(sanPham);

                if (Request["congDung"] != null && Request["cachTrong"] != null)
                {
                    string content1 = Request["congDung"].ToString() + " ";
                    string content2 = Request["cachTrong"].ToString() + " ";
                    if (content1 == " " || content2 == " ")
                    {
                        return RedirectToAction("Create");
                    }
                    ThongTinThemVeSP thongTinThemVeSP = new ThongTinThemVeSP();
                    thongTinThemVeSP.id_SP = sanPham.id_SP;
                    thongTinThemVeSP.cachTrong = content2;
                    thongTinThemVeSP.congDung = content1;
                    db.ThongTinThemVeSP.Add(thongTinThemVeSP);
                }

                HinhAnhSP hinhAnhSP = new HinhAnhSP();
                var srcImg = Request["Hinh"].ToString() + "";
                hinhAnhSP.id_SP = sanPham.id_SP;
                hinhAnhSP.duongDan = srcImg;
                db.HinhAnhSP.Add(hinhAnhSP);

                CTCapNhat ctCapNhat = new CTCapNhat();
                ctCapNhat.id_User = idUser;
                ctCapNhat.id_SP = sanPham.id_SP;
                ctCapNhat.ngayCapNhat = DateTime.Now;
                ctCapNhat.thaoTac = "Create";
                db.CTCapNhat.Add(ctCapNhat);
                sanPham.trangThai = true;
                db.SaveChanges();


                return RedirectToAction("Create");
            }
            return View(sanPham);
        }

        // GET: SanPhams/Edit
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
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

        // POST: Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_SP,tenSP,mota,gia,soLuong,DVT,phanTramGiamGia,id_Nhom,trangThai")] SanPham sanPham)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            var idUser = System.Web.HttpContext.Current.User.Identity.GetUserId();

            if (ModelState.IsValid && idUser != null)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                
                if (Request["congDung"] != null && Request["cachTrong"] != null)
                {
                    string content1 = Request["congDung"].ToString() + " ";
                    string content2 = Request["cachTrong"].ToString() + " ";
                    if (content1 == " " || content2 == " ")
                    {
                        return RedirectToAction("IndexAdmin");
                    }
                    ThongTinThemVeSP thongTinThemVeSP = db.ThongTinThemVeSP.Single(p => p.id_SP == sanPham.id_SP);
                    thongTinThemVeSP.congDung = content1;
                    thongTinThemVeSP.cachTrong = content2;
                }

                CTCapNhat ctCapNhat = new CTCapNhat();
                ctCapNhat.id_User = idUser;
                ctCapNhat.id_SP = sanPham.id_SP;
                ctCapNhat.ngayCapNhat = DateTime.Now;
                ctCapNhat.thaoTac = "Update";
                db.CTCapNhat.Add(ctCapNhat);
                db.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }
            ViewBag.id_Nhom = new SelectList(db.NhomSP, "id_Nhom", "tenNhom", sanPham.id_Nhom);
            ViewBag.id_SP = new SelectList(db.ThongTinThemVeSP, "id_SP", "congDung", sanPham.id_SP);
            return View(sanPham);
        }

        // GET: SanPhams/Delete
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
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

        // POST: SanPhams/Delete
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("IndexAdmin");
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
