using DoAnLTWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        private MyDB db = new MyDB();
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(User user)
        {
            

            User user1 = new User();

            
            user1.DisplayName = user.DisplayName;
            user1.Login = user.Login;
            user1.Password = user.Password;
            user1.Address = user.Address;
            user1.Phone = user.Phone;
            user1.Rols = "customer";

            db.Users.Add(user1);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(User user)
        {
            var Us = user.Login;
            var pw = user.Password;
            var item = db.Users.Where(x => x.Login == Us && x.Password == pw ).FirstOrDefault();
            if (item != null)
            {
                Session["TaiKhoan"] = Us;
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai.");
                return View(user);
            }
                //var ten = collection["Login"];
                //var matkhau = collection["Passwprd"];
                //User user = db.Users.SingleOrDefault(n => n.Login == ten && n.Password == matkhau);
                //if (user != null)
                //{
                //    ViewBag.ThongBao = "Chức mừng đăng nhập thành công";
                //    Session["TaiKhoan"] = user;
                //}
                //else
                //{
                //    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                //}
                //return RedirectToAction("Index", "Home");
            }

    }
}