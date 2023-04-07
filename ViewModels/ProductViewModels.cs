using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnLTWeb.ViewModels
{
    public class ProductViewModels
    {
        
        public int ID_PR { get; set; }

        
        public string DisplayName { get; set; }

        public int? ID_Loai { get; set; }

        
        public string Hinh { get; set; }

        
        public decimal? Price_Sell { get; set; }

        public int? Soluong { get; set; }

        public string TenLoaiSP { get; set; }
    }
}