using ClosedXML.Excel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteKinhDoanhCayCanh.Models;
using WebsiteKinhDoanhCayCanh.Models.LinQ;
using WebsiteKinhDoanhCayCanh.Models.OtherModels;
using DataTable = System.Data.DataTable;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class DonHangsController : Controller
    {
        private MyDataEF db = new MyDataEF();
        private MyDBDataContext data = new MyDBDataContext();
        private ApplicationDbContext dataUser = new ApplicationDbContext();
        // GET: DonHangs
        [Authorize]
        public ActionResult Index(int? page)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            var all_donHang = data.DonHangs.ToList();
            //ViewBag.Keyword = searchString;

            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(all_donHang.OrderByDescending(p => p.ngayDat).ToPagedList(pageNum, pageSize));

        }

        // GET: DonHangs/Details
        public ActionResult Details(int? id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.LinQ.DonHang donHang = data.DonHangs.FirstOrDefault(d => d.id_DH == id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            List<Models.CTDH> ctdh = db.CTDH.Where(c => c.id_DH == donHang.id_DH).ToList();
            DonHangViewModel donHangViewModel = new DonHangViewModel()
            {
                DonHang = donHang,
                CTDH = ctdh
            };
            return View(donHangViewModel);
        }



        // GET: DonHangs/Create
        public ActionResult Create()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.MaKH = new SelectList(data.Users, "Id", "Email");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_DH,ngayDat,ngayGiao,trangThaiThanhToan,trangThaiGiaoHang,phuongThucThanhToan,tongTien,diaChiGiao,id_User,id_Voucher")] Models.DonHang donHang)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.DonHang.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donHang);
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.DonHang donHang = db.DonHang.Find(id);

            var user = data.Users.Where(p => p.Id == donHang.id_User).FirstOrDefault();

            ViewBag.TenKH = user.FullName;
            ViewBag.DiaChi = user.Address;

            //DonHangViewModel donHangViewModel = data.DonHangs.Where(p => p.MaDH == id).FirstOrDefault();
            if (donHang == null)
            {
                return HttpNotFound();
            }
            //  ViewBag.MaKH = new SelectList(data.AspNetUsers, "Id", "Email");
            return View(donHang);
        }

        // POST: DonHangs/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_DH,ngayDat,ngayGiao,trangThaiThanhToan,trangThaiGiaoHang,phuongThucThanhToan,tongTien,diaChiGiao,id_User,id_Voucher")] Models.DonHang donHang)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult DoanhThu(int? page)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            var all_donHang = data.DonHangs.Where(t => t.trangThaiThanhToan == true && t.trangThaiGiaoHang.ToString() == "1").ToList();
            int pageSize = 7;
            int pageNum = page ?? 1;
            return View(all_donHang.ToPagedList(pageNum, pageSize));
        }

        [Authorize]
        public FileResult Export()
        {
            DataTable dt = new DataTable("Grib");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("STT"),
                new DataColumn("Ngày"),
                new DataColumn("Doanh Thu"),
            }); ;
            var emps = data.DonHangs.Where(t => t.trangThaiThanhToan == true && t.trangThaiGiaoHang == '1').GroupBy(p => p.ngayDat).Distinct().Select(g => new
            {
                Pla = String.Format("{0:dd/MM/yyyy}", g.Key).ToString(),
                Total = g.Sum(t => t.tongTien)
            });
            int i = 1;
            foreach (var emp in emps)
            {
                dt.Rows.Add(i++, emp.Pla, String.Format("{0:0,0}", emp.Total) + " VNĐ");
            }
            dt.Rows.Add();
            dt.Rows.Add("", "Tổng Doanh Thu", String.Format("{0:0,0}", emps.Sum(p => p.Total)) + " VNĐ");
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Doanh-Thu.xlsx");
                }
            }
        }




        public bool AuthAdmin()
        {
            var user = dataUser.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return false;
            var userExist = user.Roles.FirstOrDefault(r => r.UserId == user.Id);
            if (userExist == null)
                return false;
            if (userExist.RoleId != "1")
                return false;
            return true;
        }


        public ActionResult XemDonMua()
        {

            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }

            ApplicationUser userLogin = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            List<Models.LinQ.DonHang> all_donHang = data.DonHangs.Where(p => p.id_User == userLogin.Id).ToList();
            ViewBag.numberDonHang = all_donHang.Count; //  count tất cả đơn hàng

            List<Models.LinQ.DonHang> all_donHangDangGiao = data.DonHangs.Where(p => p.trangThaiGiaoHang.ToString() == "0" && p.id_User == userLogin.Id).ToList();
            ViewBag.numberDonHangDangGiao = all_donHangDangGiao.Count;

            List<Models.LinQ.DonHang> all_donHangDaGiao = data.DonHangs.Where(p => p.trangThaiGiaoHang.ToString() == "1" && p.id_User == userLogin.Id).ToList();
            ViewBag.numberDonHangDaGiao = all_donHangDaGiao.Count;

            List<Models.LinQ.DonHang> all_donHangDaHuy = data.DonHangs.Where(p => p.trangThaiGiaoHang.ToString() == "2" && p.id_User == userLogin.Id).ToList();
            ViewBag.numberDonHangDaHuy = all_donHangDaHuy.Count;

            List<Models.LinQ.CTDH> all_chiTietDonHang = data.CTDHs.ToList();
            DonHangViewList donHangViewList = new DonHangViewList()
            {
                listDonHang = all_donHang,
                listDonHangDaGiao = all_donHangDaGiao,
                listDonHangDangGiao = all_donHangDangGiao,
                listDonHangDaHuy = all_donHangDaHuy,
                chiTietDonHangs = all_chiTietDonHang
            };
            return View(donHangViewList);
        }
    }
}