namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KisiUcu
    {
        public int Id { get; set; }

        public int? KisiId { get; set; }

        public int? UcusId { get; set; }

        public bool? isDonus { get; set; }

        public virtual Kisi Kisi { get; set; }

        public virtual Ucu Ucu { get; set; }
    }
}
