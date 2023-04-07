using DoAnLTWeb.Models;
using DoAnLTWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private MyDB db = new MyDB();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(LoginViewModel user)
        {
            var Us = user.Login;
            var pw = user.Password;
            var item = db.Users.Where(x => x.Login == Us && x.Password == pw && x.Rols == "admin").FirstOrDefault();
            if(item != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }    
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai.");
                return View(user);
            }    
        }
    }
}