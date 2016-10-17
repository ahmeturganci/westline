namespace westline_alfa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ds160
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ds160()
        {
            Kisis = new HashSet<Kisi>();
        }

        public int Id { get; set; }

        public int? DogumYeri { get; set; }

        public int? VatandasUlke { get; set; }

        [StringLength(50)]
        public string VatandasNo { get; set; }

        [StringLength(50)]
        public string IkinciUlkeVatandasNo { get; set; }

        [StringLength(50)]
        public string AbdSsn { get; set; }

        public bool? AmerikadaBulunduMu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AmerikaBulunduguTarih { get; set; }

        [StringLength(50)]
        public string AmerikaBulunduguSure { get; set; }

        public bool? OncedenAmerikaVizesiAldı { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OncedenAmerikaVizesiTarih { get; set; }

        [StringLength(50)]
        public string OncedenAmerikaVizeNo { get; set; }

        public bool? OncedenAmerikaVizeRet { get; set; }

        [StringLength(150)]
        public string OncedenAmerikaVizeRetNedeni { get; set; }

        public bool? AmerikaVatandasGocmenBasvuru { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BabaDogumTarihi { get; set; }

        public bool? BabaAmerikadaMi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AnneDogumTarihi { get; set; }

        public bool? AnneAmerikadaMi { get; set; }

        [StringLength(200)]
        public string AmerikaAkrabaBilgi { get; set; }

        public int? PasaportId { get; set; }

        public bool? SonBesYilYurtdisiGitti { get; set; }

        public bool? AskerlikYapti { get; set; }

        public bool? TutuklanmaSicil { get; set; }

        public virtual Il Il { get; set; }

        public virtual Pasaport Pasaport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kisi> Kisis { get; set; }
    }
}
