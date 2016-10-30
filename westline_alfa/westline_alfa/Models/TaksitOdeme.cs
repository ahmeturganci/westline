namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaksitOdeme")]
    public partial class TaksitOdeme
    {
        public int Id { get; set; }

        public int? KullaniciId { get; set; }

        public int? TaksitId { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Taksit Taksit { get; set; }
    }
}
