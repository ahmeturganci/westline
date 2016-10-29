namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SozlesmeTur")]
    public partial class SozlesmeTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SozlesmeTur()
        {
            Sozlesmes = new HashSet<Sozlesme>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sozlesme> Sozlesmes { get; set; }
    }
}
