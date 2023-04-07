namespace DoAnLTWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [Key]
        public int ID_PR { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        public int? ID_Loai { get; set; }

        [StringLength(100)]
        public string Hinh { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price_Sell { get; set; }

        public int? Soluong { get; set; }

       
    }
}
