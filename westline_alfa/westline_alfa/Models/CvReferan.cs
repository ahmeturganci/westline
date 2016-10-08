namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CvReferan
    {
        public int Id { get; set; }

        public int? ReferansId { get; set; }

        public int? CvId { get; set; }

        public virtual Cv Cv { get; set; }

        public virtual Referan Referan { get; set; }
    }
}
