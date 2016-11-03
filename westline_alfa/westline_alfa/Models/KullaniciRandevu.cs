namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KullaniciRandevu")]
    public partial class KullaniciRandevu
    {
        public int Id { get; set; }

        public int? RandevuId { get; set; }

        public bool? Onay { get; set; }

        public int? KullaniciId { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Randevu Randevu { get; set; }
    }
}
