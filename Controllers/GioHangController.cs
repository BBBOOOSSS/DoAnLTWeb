using DoAnLTWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Controllers
{
    public class GioHangController : Controller
    {
        private MyDB db = new MyDB();
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult ThemGioHang(int id, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.ID_PR == id);
            if (sanpham == null)
            {
                sanpham = new Giohang(id);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.Soluong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Sum(n => n.Soluong);
            }
            return tsl;
        }
        private int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return tsl;

        }
        private double TongTien()
        {
            double tt = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                tt = lstGiohang.Sum(n => n.Thanhtien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<Giohang> lstGioHang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGioHang);
        }
        public ActionResult GioHangPartial()
        {

            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<Giohang> LstGiohang = Laygiohang();
            Giohang sanpham = LstGiohang.SingleOrDefault(n => n.ID_PR == id);
            if (sanpham != null)
            {
                LstGiohang.RemoveAll(n => n.ID_PR == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGiohang(int id, FormCollection collection)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.ID_PR == id);
            if (sanpham != null)
            {
                sanpham.Soluong = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("Giohang");
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("GetListLoaiSP","PR");
            }
            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(lstGiohang);
        }

        public ActionResult DatHang(Output output)
        {
            Output op = new Output();
            User Us = new User();
            Product s = new Product();

            List<Giohang> gh = Laygiohang();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", output.ngaygiao);

            Us.ID_User = Us.ID_User;
            op.ngaydat = DateTime.Now;
            op.ngaygiao = DateTime.Parse(ngaygiao);
            op.giaohang = false;
            op.thanhtoan = false;

            db.Outputs.Add(op);
            db.SaveChanges();
            foreach (var item in gh)
            {
                OutputDetail opd = new OutputDetail();
                opd.ID_OutputDetail = op.ID_Output;
                opd.ID_PR = item.ID_PR;
                opd.Soluong = item.Soluong;
                opd.DonGia = (decimal)item.Thanhtien;
                s = db.Products.Single(n => n.ID_PR == item.ID_PR);
                s.Soluong -= opd.Soluong;
                db.SaveChanges();
                db.OutputDetails.Add(opd);
            }

            db.SaveChanges();
            Session["Giohang"] = null;
            return RedirectToAction("XacnhanDonhang", "GioHang");

        }
        public ActionResult XacnhanDonhang()
        {
            return View();
        }
    }

}