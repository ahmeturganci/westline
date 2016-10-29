namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sozlesme")]
    public partial class Sozlesme
    {
        public int Id { get; set; }

        public int? SozlesmeTur { get; set; }

        public bool? Onay { get; set; }

        public int? KullaniciId { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual SozlesmeTur SozlesmeTur1 { get; set; }
    }
}
