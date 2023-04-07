
using DoAnLTWeb.Models;
using DoAnLTWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnLTWeb.Areas.Admin.Controllers
{
    public class QuanLySPController : Controller
    {
        private MyDB db = new MyDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListLoaiSP()
        {
            var list = db.Loais.ToList();
            //return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(Product product)
        {
            var name = db.Products.FirstOrDefault(x => x.DisplayName == product.DisplayName);
            if (name != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Products.Add(product);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetList()
        {
            //var List = db.Products.ToList();
            //return Json(new { data = List }, JsonRequestBehavior.AllowGet);
            var list = (from p in db.Products
                        join c in db.Loais
                        on p.ID_Loai equals c.ID_Loai
                        orderby p.DisplayName descending
                        select new ProductViewModels()
                        {
                            ID_PR = p.ID_PR,
                            DisplayName = p.DisplayName,
                            TenLoaiSP = c.DisplayName,
                            Hinh = p.Hinh,
                            Price_Sell = p.Price_Sell,
                            Soluong = p.Soluong,
                        }).ToList();

            // return Json(list, JsonRequestBehavior.AllowGet);
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }
        
        public JsonResult Delete(int id)
        {
            var ID = db.Products.Where(x => x.ID_PR == id).FirstOrDefault();
            db.Products.Remove(ID);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int? id)
        {
            var data = db.Products.FirstOrDefault(x => x.ID_PR == id);

            return Json(data, JsonRequestBehavior.AllowGet);
            // return Json(new { data = sdata }, JsonRequestBehavior.AllowGet);
            // return Json(new { result = "Redirect", url = Url.Action("Edit", "Product") });
        }

        public JsonResult UpdateSP(Product product)

        {
            var vali = db.Products.Where(x => x.DisplayName == product.DisplayName && x.ID_PR == product.ID_PR).FirstOrDefault();
            if (vali != null)
            {
                //dùng row để update lại giá trị theo ý mình
                var row = db.Products.Find(product.ID_PR);
                row.DisplayName = product.DisplayName;
                row.ID_Loai = product.ID_Loai;
                row.Hinh = product.Hinh;
                row.Soluong = product.Soluong;
                row.Price_Sell = product.Price_Sell;
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);


            }
            else
            {
                var valiname = db.Products.Where(x => x.DisplayName == product.DisplayName).FirstOrDefault();
                if (valiname != null)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }

            }


        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Public/ImageProduct/" + file.FileName));
            return "/Public/ImageProduct/" + file.FileName;
        }
    }
}