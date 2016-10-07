namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ucu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ucu()
        {
            KisiUcus = new HashSet<KisiUcu>();
        }

        public int Id { get; set; }

        public DateTime? GidisTarih { get; set; }

        [StringLength(50)]
        public string GidisSehir { get; set; }

        [StringLength(50)]
        public string GidisHavaalaniKod { get; set; }

        [StringLength(50)]
        public string VarisSehir { get; set; }

        [StringLength(50)]
        public string VarisHavaalaniKod { get; set; }

        [StringLength(50)]
        public string UcusKod { get; set; }

        public TimeSpan? KalkisSaat { get; set; }

        public TimeSpan? VarisSaat { get; set; }

        public bool? GunDegisim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KisiUcu> KisiUcus { get; set; }
    }
}
