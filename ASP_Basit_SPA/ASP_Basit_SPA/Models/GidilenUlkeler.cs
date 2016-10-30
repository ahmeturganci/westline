namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GidilenUlkeler")]
    public partial class GidilenUlkeler
    {
        public int Id { get; set; }

        public int? KisiId { get; set; }

        public int? UlkeId { get; set; }

        public virtual Kisi Kisi { get; set; }

        public virtual Ulke Ulke { get; set; }
    }
}
