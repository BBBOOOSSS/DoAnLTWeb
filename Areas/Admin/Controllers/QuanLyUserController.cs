using DoAnLTWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    public class QuanLyUserController : Controller
    {
        private MyDB db = new MyDB();
        // GET: Admin/QuanLyUser
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList()
        {
            var List = db.Users.ToList();
            return Json(new { data = List }, JsonRequestBehavior.AllowGet);
            //return Json(List, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create(User user)
        {
            var name = db.Users.FirstOrDefault(x => x.DisplayName == user.DisplayName);
            if (name != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult Delete(int id)
        {
            var ID = db.Users.Where(x => x.ID_User == id).FirstOrDefault();
            db.Users.Remove(ID);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int? id)
        {
            var data = db.Users.FirstOrDefault(x => x.ID_User == id);

            return Json(data, JsonRequestBehavior.AllowGet);
            // return Json(new { data = sdata }, JsonRequestBehavior.AllowGet);
            // return Json(new { result = "Redirect", url = Url.Action("Edit", "Product") });
        }

        public JsonResult UpdateUser(User user)

        {
            var vali = db.Users.Where(x => x.DisplayName == user.DisplayName && x.ID_User == user.ID_User).FirstOrDefault();
            if (vali != null)
            {
                //dùng row để update lại giá trị theo ý mình
                var row = db.Users.Find(user.ID_User);
                row.DisplayName = user.DisplayName;

                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);


            }
            else
            {
                var valiname = db.Users.Where(x => x.DisplayName == user.DisplayName).FirstOrDefault();
                if (valiname != null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }

            }


        }
    }
}