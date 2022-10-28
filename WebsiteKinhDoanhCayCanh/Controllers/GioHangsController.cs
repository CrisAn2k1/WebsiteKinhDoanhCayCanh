using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WebsiteKinhDoanhCayCanh.Message;
using WebsiteKinhDoanhCayCanh.Models;

namespace WebsiteKinhDoanhCayCanh.Controllers
{
    public class GioHangsController : Controller
    {

        private MyDataEF db = new MyDataEF();

        public List<GioHang> layGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(string id, string strURL)
        {
            List<GioHang> lstGioHang = layGioHang();
            GioHang sanPham = lstGioHang.Find(n => n.iIdSanPham == id);
            if (sanPham == null)
            {
                sanPham = new GioHang(id);
                lstGioHang.Add(sanPham);
                Notification.set_flash("Đã thêm sản phẩm vào giỏ hàng!", "success");
                return Redirect(strURL);
            }
            else
            {
                //sanPham.updateGiamGia(id);
                sanPham.iSoLuong++;
                Notification.set_flash("Đã thêm sản phẩm vào giỏ hàng!", "success");
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(n => n.iSoLuong);
            }
            return tsl;
        }

        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Count;
            }
            return tsl;
        }

        private double TongTien()
        {
            double tt = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tt = lstGioHang.Sum(n => n.dThanhTien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = layGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return PartialView();
        }

        /*        public ActionResult XoaGioHang(string id)
                {
                    List<GioHang> lstGioHang = layGioHang();
                    GioHang sanPham = lstGioHang.SingleOrDefault(n => n.iIdSanPham == id);
                    if (sanPham != null)
                    {
                        lstGioHang.RemoveAll(n => n.iIdSanPham == id);
                        //Notification.set_flash("Đã xoá sản phẩm khỏi giỏ hàng!", "success");
                        //Notification.set_flash("Deleted form cart!", "success");
                        return RedirectToAction("GioHang");
                    }
                    return RedirectToAction("GioHang");
                }*/
        public ActionResult XoaGiohang(string iIdSanPham)
        {

            List<GioHang> lstGiohang = layGioHang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.iIdSanPham == iIdSanPham);
            if (lstGiohang != null)
            {
                lstGiohang.RemoveAll(n => n.iIdSanPham == iIdSanPham);
                Notification.set_flash("Đã xoá sản phẩm khỏi giỏ hàng!", "success");
                Notification.set_flash("Deleted form cart!", "success");
                return RedirectToAction("GioHang");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapNhatGioHang(string id, FormCollection collection)
        {
            List<GioHang> lstGioHang = layGioHang();
            GioHang sanPham = lstGioHang.SingleOrDefault(n => n.iIdSanPham == id);
            if (sanPham != null)
            {
                SanPham sp = db.SanPham.FirstOrDefault(s => s.id_SP == id);
                var soLuong = int.Parse(collection["quantity"].ToString());
                if (sp.soLuong < soLuong)
                    return RedirectToAction("GioHang");
                sanPham.iSoLuong = soLuong;
                //sanPham.giamGia = double.Parse((soLuong * sp.GiamGia).ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> lstGioHang = layGioHang();
            lstGioHang.Clear();
            Notification.set_flash("Đã xoá tất cả sản phẩm trong giỏ hàng!", "success");
            return RedirectToAction("GioHang");
        }


        //Dặt hàng
        [HttpGet]
        public ActionResult DatHang()
        {
            if (TongTien() == 0)
            {
                var tong = TongTien();
                return RedirectToAction("GioHang");
            }
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "SanPhams");
            }

            List<GioHang> lstGioHang = layGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            return View(lstGioHang);
        }
        public ActionResult DatHang(FormCollection collection)
        {

            DonHang dh = new DonHang();
            Models.LinQ.User kh = (Models.LinQ.User)Session["TaiKhoan"];
            //SanPham s = new SanPham();
            List<GioHang> gh = layGioHang();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            dh.id_User = kh.Id;
            dh.ngayDat = DateTime.Now;
            dh.ngayDat = DateTime.Parse(ngaygiao);
            dh.trangThaiGiaoHang = "0";
            dh.trangThaiThanhToan = "0";
            dh.tongTien = ((int)TongTien());

            db.DonHang.Add(dh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                CTDH ctdh = new CTDH();
                ctdh.id_DH = dh.id_DH;
                ctdh.id_SP = item.iIdSanPham;
                ctdh.soLuong = item.iSoLuong;
                ctdh.thanhTien = ((long)item.dThanhTien);
                SanPham sanPham = db.SanPham.Single(n => n.id_SP == item.iIdSanPham);
                sanPham.soLuong -= item.iSoLuong;
                db.SaveChanges();
                db.CTDH.Add(ctdh);
                db.SaveChanges();
            }
            Session["GioHang"] = null;

            /*            String content = System.IO.File.ReadAllText(Server.MapPath("~/Content/sendmail.html"));
                        content = content.Replace("{{CustomerName}}", kh.Name);
                        content = content.Replace("{{Phone}}", kh.PhoneNumber);
                        content = content.Replace("{{Email}}", kh.Email);
                        content = content.Replace("{{Address}}", kh.Address);
                        content = content.Replace("{{NgayDat}}", dh.NgayDat.ToString());
                        content = content.Replace("{{NgayGiao}}", dh.NgayGiao.ToString());
                        content = content.Replace("{{Total}}", dh.TongTien.ToString() + " VNĐ");
                        var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                        new common.MailHelper().sendMail(kh.Email, "Đơn hàng mới từ Điện Tử Chính Hãng - ATC", content);
                        return RedirectToAction("XacNhanDonHang", "GioHang");*/
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }

        public ActionResult XacNhanDonHang()
        {
            Notification.set_flash("Đặt hàng thành công!", "success");
            return Redirect("/");
        }

    }
}