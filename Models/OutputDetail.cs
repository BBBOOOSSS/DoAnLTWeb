namespace DoAnLTWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutputDetail")]
    public partial class OutputDetail
    {
        [Key]
        public int ID_OutputDetail { get; set; }

        public int? ID_PR { get; set; }

        public int? Soluong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGia { get; set; }
    }
}
