namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Universite")]
    public partial class Universite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Universite()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        public int? Sinif { get; set; }

        [StringLength(50)]
        public string Bolum { get; set; }

        [StringLength(50)]
        public string OkulNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AcilisTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? KapanisTarihi { get; set; }

        public int? Adres { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        public virtual Adre Adre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
