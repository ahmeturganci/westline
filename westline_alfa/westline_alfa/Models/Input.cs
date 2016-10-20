namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Input")]
    public partial class Input
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Input()
        {
            Degers = new HashSet<Deger>();
            Seceneks = new HashSet<Secenek>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }

        [StringLength(50)]
        public string Placeholder { get; set; }

        public int? TurId { get; set; }

        public int? Maxlength { get; set; }

        public bool? Zorunlu { get; set; }

        public int? Sayfa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deger> Degers { get; set; }

        public virtual Tur Tur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Secenek> Seceneks { get; set; }
    }
}
