namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SayfaDurum")]
    public partial class SayfaDurum
    {
        public int Id { get; set; }

        public int? KullaniciId { get; set; }

        public int? SayfaId { get; set; }

        public bool? Durum { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Sayfa Sayfa { get; set; }
    }
}
