using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WebsiteKinhDoanhCayCanh.Message;
using WebsiteKinhDoanhCayCanh.Models;
using WebsiteKinhDoanhCayCanh.Others;


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

        public ActionResult ThemGioHang(string id, string strURL, int soLuong)
        {

            List<GioHang> lstGioHang = layGioHang();
            GioHang sanPham = lstGioHang.Find(n => n.iIdSanPham == id);
            if (sanPham == null)
            {
                if (soLuong > 1)
                {
                    sanPham = new GioHang(id);
                    sanPham.iSoLuong = soLuong;
                    lstGioHang.Add(sanPham);
                    Notification.set_flash("Đã thêm sản phẩm vào giỏ hàng!", "success");
                    return Redirect(strURL);
                }
                else
                {
                    sanPham = new GioHang(id);
                    sanPham.iSoLuong = 1;
                    lstGioHang.Add(sanPham);
                    Notification.set_flash("Đã thêm sản phẩm vào giỏ hàng!", "success");
                    return Redirect(strURL);
                }

            }
            else
            {
                //sanPham.updateGiamGia(id)
                Notification.set_flash("Đã có sản phẩm này trong giỏ hàng!", "warning");
                return Redirect(strURL);
            }
        }

        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tsl = lstGioHang.Sum(n => n.iSoLuong);
            }
            return tsl;
        }

        private int TongSoSanPham()
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
        private double ApDungVoucher()
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
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoSanPham = TongSoSanPham();
            return View(lstGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoSanPham = TongSoSanPham();
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

                if (soLuong > sp.soLuong)
                {
                    if (sp.soLuong >= 100)
                    {
                        sanPham.iSoLuong = 100;
                        Notification.set_flash("Chỉ được mua tối đa 100 sản phẩm cùng loại !", "warning");
                        return RedirectToAction("GioHang");
                    }
                    else
                    {
                        sanPham.iSoLuong = (int)sp.soLuong;
                        Notification.set_flash("Sản phẩm hiện có chỉ còn lại: " + sp.soLuong + " !", "warning");
                        return RedirectToAction("GioHang");
                    }
                }
                else
                {
                    if (soLuong <= 100)
                    {
                        sanPham.iSoLuong = soLuong;
                        Notification.set_flash("Cập nhật giỏ hàng thành công!", "success");
                    }
                    else
                    {
                        sanPham.iSoLuong = 100;
                        Notification.set_flash("Chỉ được mua tối đa 100 sản phẩm cùng loại !", "warning");
                        return RedirectToAction("GioHang");
                    }
                }
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
            ViewBag.TongSoLuongSanPham = TongSoLuongSanPham();
            ViewBag.TongTien = TongTien();
            ViewBag.TongSoSanPham = TongSoSanPham();
            //try
            //{
            //    var a = Request["Voucher"].ToString() + "";
            //}
            //catch (Exception)
            //{
            //    return View(lstGioHang);
            //}
            return View(lstGioHang);
        }

        public ActionResult DatHang(FormCollection collection)
        {

            DonHang dh = new DonHang();
            Models.LinQ.User kh = (Models.LinQ.User)Session["TaiKhoan"];
            //SanPham s = new SanPham();
            List<GioHang> gh = layGioHang();
            var ngaygiao = String.Format("{0:dd/MM/yyyy hh:mm tt}", collection["NgayGiao"]);
            dh.id_User = kh.Id;
            dh.ngayDat = DateTime.Now;
            dh.ngayGiao = DateTime.Parse(ngaygiao);
            dh.trangThaiGiaoHang = "0";
            dh.trangThaiThanhToan = false;
            dh.phuongThucThanhToan = "0";
            dh.diaChiGiao = Request["txtAddress"].ToString() + "";
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

            String content = System.IO.File.ReadAllText(Server.MapPath("~/Others/Checkout.html"));
            content = content.Replace("{{CustomerName}}", kh.FullName);
            content = content.Replace("{{Phone}}", kh.PhoneNumber);
            content = content.Replace("{{Email}}", kh.Email);
            content = content.Replace("{{Address}}", dh.diaChiGiao);
            content = content.Replace("{{NgayDat}}", dh.ngayDat.ToString());
            content = content.Replace("{{NgayGiao}}", String.Format("{0:dd/MM/yyyy}", dh.ngayGiao).ToString());
            content = content.Replace("{{Total}}", String.Format("{0:0,0}", dh.tongTien).ToString());
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            new MailHelper().sendMail(kh.Email, "Đơn hàng mới từ Cây Cảnh AT - Trees", content);

            Notification.set_flash("Đặt hàng thành công!", "success");
            //return RedirectToAction("XemDonHang", "GioHang");
            return RedirectToAction("Index", "Home");
            // return RedirectToAction("XacNhanDonHang", "GioHang");
        }

        public ActionResult XacNhanDonHang()
        {
            Notification.set_flash("Đặt hàng thành công!", "success");
            return Redirect("/");
        }

        /*
         * ================================================================================================================================
            Thanh toan MOMO
         */
        public ActionResult ThanhToan(FormCollection collection)
        {
            if (TongTien() >= 45000000)
            {
                Notification.set_flash("Số tiền quá quá cao! Vui lòng chọn thanh toán khi nhận hàng!", "warning");
                return RedirectToAction("DatHang", "GioHangs");
            }

            List<GioHang> gioHang = Session["GioHang"] as List<GioHang>;
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectKey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Đơn Hàng Từ Cây Cảnh AT-Trees";
            string returnUrl = "https://localhost:44351/GioHangs/ReturnUrl";
            string notifyurl = "http://ba1adf48beba.ngrok.io/GioHangs/NotifyUrl";

            string amount = gioHang.Sum(n => n.dThanhTien).ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            string rawHash =
                "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            string signature = crypto.signSHA256(rawHash, serectKey);
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
            };
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        public ActionResult ReturnUrl(FormCollection collection)
        {
            string param = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature") - 1);
            param = Server.UrlDecode(param);
            MoMoSecurity crypto = new MoMoSecurity();
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string signature = crypto.signSHA256(param, serectkey);
            if (signature != Request["signature"].ToString())
            {
                ViewBag.message = "Thông tin Request không hợp lệ";
                return View();
            }
            if (!Request.QueryString["errorCode"].Equals("0"))
            {
                ViewBag.message = "Thanh toán thất bại";
            }
            else
            {
                DonHang dh = new DonHang();
                Models.LinQ.User kh = (Models.LinQ.User)Session["TaiKhoan"];
                //SanPham s = new SanPham();
                List<GioHang> gh = layGioHang();
                var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
                dh.id_User = kh.Id;
                dh.ngayDat = DateTime.Now;
                dh.ngayGiao = DateTime.Now;
                dh.trangThaiGiaoHang = "0";
                dh.trangThaiThanhToan = true;
                dh.phuongThucThanhToan = "0";
                dh.tongTien = (long?)TongTien();
                if (dh.tongTien != 0)
                {
                    db.DonHang.Add(dh);
                    db.SaveChanges();
                }
                foreach (var item in gh)
                {
                    CTDH ctdh = new CTDH();
                    ctdh.id_DH = dh.id_DH;
                    ctdh.id_SP = item.iIdSanPham;
                    ctdh.soLuong = item.iSoLuong;
                    ctdh.thanhTien = (long?)item.dThanhTien;
                    SanPham sanPham = db.SanPham.Single(n => n.id_SP == item.iIdSanPham);
                    sanPham.soLuong -= item.iSoLuong;
                    db.SaveChanges();
                    db.CTDH.Add(ctdh);
                    db.SaveChanges();
                }
                Session["GioHang"] = null;
                if (dh.tongTien != 0)
                {
                    String content = System.IO.File.ReadAllText(Server.MapPath("~/Others/Checkout.html"));
                    content = content.Replace("{{CustomerName}}", kh.FullName);
                    content = content.Replace("{{Phone}}", kh.PhoneNumber);
                    content = content.Replace("{{Email}}", kh.Email);
                    content = content.Replace("{{Address}}", dh.diaChiGiao);
                    content = content.Replace("{{NgayDat}}", dh.ngayDat.ToString());
                    content = content.Replace("{{NgayGiao}}", String.Format("{0:dd/MM/yyyy}", dh.ngayGiao).ToString());
                    content = content.Replace("{{Total}}", String.Format("{0:0,0}", dh.tongTien).ToString());
                    var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    new MailHelper().sendMail(kh.Email, "Đơn hàng mới từ Cây Cảnh AT - Trees", content);
                }
                Notification.set_flash("Thanh toán thành công!", "success");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("DatHang", "GioHangs");
        }

        [HttpPost]
        public JsonResult NotifyUrl()
        {
            string param = "";
            param =
                "partner_code=" + Request["partner_code"] +
                "&access_key=" + Request["access_key"] +
                "&amount=" + Request["amount"] +
                "&order_id=" + Request["order_id"] +
                "&order_info=" + Request["order_info"] +
                "&order_type=" + Request["order_type"] +
                "&transaction_id=" + Request["transaction_id"] +
                "&message=" + Request["message"] +
                "&response_time=" + Request["response_time"] +
                "&status_code=" + Request["status_code"];
            param = Server.UrlDecode(param);
            MoMoSecurity crypto = new MoMoSecurity();
            string serectkey = ConfigurationManager.AppSettings["serectkey"].ToString();
            string signature = crypto.signSHA256(param, serectkey);
            if (signature != Request["signature"].ToString())
            {

            }
            string status_code = Request["status_code"].ToString();
            if ((status_code != "0"))
            {

            }
            else
            {

            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}