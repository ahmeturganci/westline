namespace ASP_Basit_SPA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IngilizceSeviye")]
    public partial class IngilizceSeviye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IngilizceSeviye()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string SeviyeAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
