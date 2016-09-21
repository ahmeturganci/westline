namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pasaport")]
    public partial class Pasaport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pasaport()
        {
            ds160 = new HashSet<ds160>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string No { get; set; }

        public int? AldigiUlke { get; set; }

        [StringLength(50)]
        public string AldigiSehir { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PasaportBaslangic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PasaportBitis { get; set; }

        public bool? PasaportKayipCalinti { get; set; }

        [StringLength(50)]
        public string PasaportUcretKisi { get; set; }

        [StringLength(50)]
        public string PasaportUcretKisiAkraba { get; set; }

        [StringLength(50)]
        public string PasaportUcretKisiAkrabaNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ds160> ds160 { get; set; }
    }
}
