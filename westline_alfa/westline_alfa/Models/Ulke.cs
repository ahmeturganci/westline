namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ulke")]
    public partial class Ulke
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ulke()
        {
            Ils = new HashSet<Il>();
        }

        public int Id { get; set; }

        [StringLength(255)]
        public string Ad { get; set; }

        public int? Oncelik { get; set; }

        [StringLength(255)]
        public string tr_TR { get; set; }

        [Required]
        [StringLength(255)]
        public string en_US { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Il> Ils { get; set; }
    }
}
