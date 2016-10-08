namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cv")]
    public partial class Cv
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cv()
        {
            CvReferans = new HashSet<CvReferan>();
        }

        public int Id { get; set; }

        public int? KisiId { get; set; }

        [StringLength(50)]
        public string Hedef { get; set; }

        [StringLength(50)]
        public string CalismakIstenilenIs { get; set; }

        public bool? Askerlik { get; set; }

        public bool? MedeniDurum { get; set; }

        [StringLength(50)]
        public string Hobiler { get; set; }

        public int? ReferansId { get; set; }

        public virtual Kisi Kisi { get; set; }

        public virtual Kisi Kisi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CvReferan> CvReferans { get; set; }
    }
}
