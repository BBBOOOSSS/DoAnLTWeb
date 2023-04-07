namespace DoAnLTWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loai")]
    public partial class Loai
    {
        [Key]
        public int ID_Loai { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}
