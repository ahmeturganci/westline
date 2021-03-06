namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Il")]
    public partial class Il
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Il()
        {
            Ilces = new HashSet<Ilce>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Ad { get; set; }

        public int? UlkeId { get; set; }

        public int? Oncelik { get; set; }

        public virtual Ulke Ulke { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilce> Ilces { get; set; }
    }
}
