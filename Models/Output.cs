namespace DoAnLTWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Output")]
    public partial class Output
    {
        [Key]
        public int ID_Output { get; set; }

        public int? ID_User { get; set; }

        
        public bool? giaohang { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ngaydat { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ngaygiao { get; set; }

        
        public bool? thanhtoan { get; set; }
    }
}
