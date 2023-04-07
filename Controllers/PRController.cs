using DoAnLTWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Controllers
{
    public class PRController : Controller
    {
        private MyDB db = new MyDB();
        // GET: PR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListLoaiSP()
        {
            var list = db.Products.ToList();
            
            return View(list);
        }
    }
}