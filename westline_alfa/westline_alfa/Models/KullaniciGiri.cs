namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KullaniciGiri
    {
        public int Id { get; set; }

        public int? GirisLogId { get; set; }

        public int? KullaniciId { get; set; }

        public virtual GirisLog GirisLog { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
