using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnLTWeb.Models
{
    public class Giohang
    {
        private MyDB db = new MyDB();


        public int ID_PR { get; set; }
        public string DisplayName { get; set; }

        public int ID_Loai { get; set; }


        public string Hinh { get; set; }


        public decimal Price_Sell { get; set; }

        public int Soluong { get; set; }

        public Double Thanhtien
        {
            get { return (double)(Soluong * Price_Sell); }
        }

        public Giohang(int id)
        {
            ID_PR = id;
            Product product = db.Products.Single(n => n.ID_PR == ID_PR);
            DisplayName = product.DisplayName;
            Hinh = product.Hinh;
            Price_Sell = (decimal)double.Parse(product.Price_Sell.ToString());
            Soluong = 1;
        }
    }
}