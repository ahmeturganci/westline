namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Taksit")]
    public partial class Taksit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taksit()
        {
            TaksitOdemes = new HashSet<TaksitOdeme>();
        }

        public int Id { get; set; }

        public double? Miktar { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SonOdeme { get; set; }

        public bool? Odendi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaksitOdeme> TaksitOdemes { get; set; }
    }
}
