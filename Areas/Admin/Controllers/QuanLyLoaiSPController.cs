using DoAnLTWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    public class QuanLyLoaiSPController : Controller
    {
        private MyDB db = new MyDB();
        // GET: Admin/QuanLyLoaiSP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Loai loai)
        {
            var name = db.Loais.FirstOrDefault(x => x.DisplayName == loai.DisplayName);
            if (name != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Loais.Add(loai);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult GetList()
        {
            var List = db.Loais.ToList();
            return Json(new { data = List }, JsonRequestBehavior.AllowGet);
            //return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var id_sp = db.Products.Where(x => x.ID_Loai == id).FirstOrDefault();

            if (id_sp != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var ID = db.Loais.Where(x => x.ID_Loai == id).FirstOrDefault();
                db.Loais.Remove(ID);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            
        }

        public ActionResult Edit(int? id)
        {
            var data = db.Loais.FirstOrDefault(x => x.ID_Loai == id);

            return Json(data, JsonRequestBehavior.AllowGet);
            // return Json(new { data = sdata }, JsonRequestBehavior.AllowGet);
            // return Json(new { result = "Redirect", url = Url.Action("Edit", "Product") });
        }

        public JsonResult UpdateLoaiSP(Loai loai)

        {
            var vali = db.Loais.Where(x => x.DisplayName == loai.DisplayName && x.ID_Loai == loai.ID_Loai).FirstOrDefault();
            if (vali != null)
            {
                //dùng row để update lại giá trị theo ý mình
                var row = db.Loais.Find(loai.ID_Loai);
                row.DisplayName = loai.DisplayName;

                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
                

            }
            else
            {
                var valiname = db.Loais.Where(x => x.DisplayName == loai.DisplayName).FirstOrDefault();
                if (valiname != null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(loai).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                
            }


        }
    }
}