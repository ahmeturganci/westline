namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UrunAd { get; set; }

        public int UrunFiyat { get; set; }

        public int UrunMiktar { get; set; }
    }
}
