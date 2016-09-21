namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Belge")]
    public partial class Belge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Belge()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string OgrenciBelgeUrl { get; set; }

        [StringLength(100)]
        public string TranskriptUrl { get; set; }

        [StringLength(100)]
        public string SabikaKaydiUrl { get; set; }

        [StringLength(100)]
        public string FotografUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
