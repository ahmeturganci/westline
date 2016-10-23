namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KullaniciI
    {
        public int Id { get; set; }

        public int? KullaniciId { get; set; }

        public int? IsId { get; set; }

        public virtual Isler Isler { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
