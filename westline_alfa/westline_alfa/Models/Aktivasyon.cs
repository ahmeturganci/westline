namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aktivasyon")]
    public partial class Aktivasyon
    {
        public int id { get; set; }

        public int? KullaniciId { get; set; }

        [StringLength(50)]
        public string Kod { get; set; }

        public DateTime? Tarih { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
