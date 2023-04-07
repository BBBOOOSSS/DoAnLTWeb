using DoAnLTWeb.Models;
using DoAnLTWeb.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Controllers
{
    public class HomeController : Controller
    {
        private MyDB db = new MyDB();
        public ActionResult Index()
        {

            var list = db.Products.ToList();
            //return Json(new { data = list }, JsonRequestBehavior.AllowGet);


                        ////return Json(list, JsonRequestBehavior.AllowGet);
            return View(list);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Detail(int id)
        {
            var D_product = db.Products.Where(m => m.ID_PR == id).First();
            return View(D_product);
        }
    }
}