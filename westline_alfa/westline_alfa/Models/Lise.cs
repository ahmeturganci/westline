namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lise")]
    public partial class Lise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lise()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        public int? AdresId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Baslangic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Bitis { get; set; }

        [StringLength(50)]
        public string Alan { get; set; }

        public virtual Adre Adre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
