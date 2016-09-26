namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adre()
        {
            Iletisims = new HashSet<Iletisim>();
            Lises = new HashSet<Lise>();
            Referans = new HashSet<Referan>();
            Universites = new HashSet<Universite>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string TamAdres { get; set; }

        [StringLength(200)]
        public string AdresSatirIki { get; set; }

        [StringLength(50)]
        public string Sehir { get; set; }

        public int? EyaletId { get; set; }

        [StringLength(50)]
        public string PostaKodu { get; set; }

        public int? UlkeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iletisim> Iletisims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lise> Lises { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Referan> Referans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Universite> Universites { get; set; }
    }
}
