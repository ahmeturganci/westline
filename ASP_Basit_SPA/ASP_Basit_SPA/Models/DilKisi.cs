namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DilKisi")]
    public partial class DilKisi
    {
        public int Id { get; set; }

        public int? KisiId { get; set; }

        public int? DilId { get; set; }

        public virtual Dil Dil { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
