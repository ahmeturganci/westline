namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deger")]
    public partial class Deger
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Icerik { get; set; }

        public int? InputId { get; set; }

        public int? KisiId { get; set; }

        public bool? Onay { get; set; }

        public virtual Input Input { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
