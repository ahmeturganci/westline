namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Randevu")]
    public partial class Randevu
    {
        public int Id { get; set; }

        public DateTime? AlternatifBir { get; set; }

        public DateTime? AlternatifIki { get; set; }

        public int? KisiId { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
