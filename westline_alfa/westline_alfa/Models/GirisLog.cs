namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GirisLog")]
    public partial class GirisLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GirisLog()
        {
            KullaniciGiris = new HashSet<KullaniciGiri>();
        }

        public int Id { get; set; }

        public DateTime? Tarih { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KullaniciGiri> KullaniciGiris { get; set; }
    }
}
