namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kisi")]
    public partial class Kisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kisi()
        {
            Aktivasyons = new HashSet<Aktivasyon>();
            Cvs = new HashSet<Cv>();
            Cvs1 = new HashSet<Cv>();
            DilKisis = new HashSet<DilKisi>();
            GidilenUlkelers = new HashSet<GidilenUlkeler>();
            KisiIs = new HashSet<KisiI>();
            KisiReferans = new HashSet<KisiReferan>();
            KisiUcus = new HashSet<KisiUcu>();
            Randevus = new HashSet<Randevu>();
        }

        public int Id { get; set; }

        [StringLength(60)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string OrtaAd { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        public bool? Pasaport { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }

        public int? IngilizceSeviyeId { get; set; }

        [StringLength(50)]
        public string TcKimlikNo { get; set; }

        [StringLength(50)]
        public string AnneAdi { get; set; }

        [StringLength(50)]
        public string BabaAdi { get; set; }

        public int? IsTercihi { get; set; }

        public int? IletisimId { get; set; }

        public int? AcilDurumId { get; set; }

        public int? UniversiteId { get; set; }

        public int? BelgeId { get; set; }

        public int? LiseId { get; set; }

        public int? DsId { get; set; }

        public bool? kendiIsBuldu { get; set; }

        public bool? AktivasyonOnay { get; set; }

        public bool? AdminOnay { get; set; }

        public virtual AcilDurum AcilDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aktivasyon> Aktivasyons { get; set; }

        public virtual Belge Belge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cv> Cvs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cv> Cvs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DilKisi> DilKisis { get; set; }

        public virtual ds160 ds160 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GidilenUlkeler> GidilenUlkelers { get; set; }

        public virtual Iletisim Iletisim { get; set; }

        public virtual IngilizceSeviye IngilizceSeviye { get; set; }

        public virtual Lise Lise { get; set; }

        public virtual Universite Universite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KisiI> KisiIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KisiReferan> KisiReferans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KisiUcu> KisiUcus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevus { get; set; }
    }
}
