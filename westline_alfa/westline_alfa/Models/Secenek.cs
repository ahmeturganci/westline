namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Secenek")]
    public partial class Secenek
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Icerik { get; set; }

        public int? InputId { get; set; }

        public virtual Input Input { get; set; }
    }
}
