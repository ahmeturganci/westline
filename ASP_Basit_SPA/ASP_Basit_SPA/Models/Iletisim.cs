namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Iletisim")]
    public partial class Iletisim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Iletisim()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        public int? AdresId { get; set; }

        [StringLength(70)]
        public string Skype { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        public virtual Adre Adre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
