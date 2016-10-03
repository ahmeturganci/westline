namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilce")]
    public partial class Ilce
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Ad { get; set; }

        public int? IlId { get; set; }

        public int? Oncelik { get; set; }

        public virtual Il Il { get; set; }
    }
}
