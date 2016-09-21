namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KisiReferan
    {
        public int Id { get; set; }

        public int? KisiId { get; set; }

        public int? ReferansId { get; set; }

        public virtual Kisi Kisi { get; set; }

        public virtual Referan Referan { get; set; }
    }
}
