namespace westline_alfa.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class westlineDB : DbContext
    {
        public westlineDB()
            : base("name=westlineDB")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Aktivasyon> Aktivasyons { get; set; }
        public virtual DbSet<ComboTur> ComboTurs { get; set; }
        public virtual DbSet<Deger> Degers { get; set; }
        public virtual DbSet<GirisLog> GirisLogs { get; set; }
        public virtual DbSet<Il> Ils { get; set; }
        public virtual DbSet<Ilce> Ilces { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<Isler> Islers { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<KullaniciGiri> KullaniciGiris { get; set; }
        public virtual DbSet<KullaniciI> KullaniciIs { get; set; }
        public virtual DbSet<Sayfa> Sayfas { get; set; }
        public virtual DbSet<SayfaDurum> SayfaDurums { get; set; }
        public virtual DbSet<Secenek> Seceneks { get; set; }
        public virtual DbSet<Sozlesme> Sozlesmes { get; set; }
        public virtual DbSet<SozlesmeTur> SozlesmeTurs { get; set; }
        public virtual DbSet<Taksit> Taksits { get; set; }
        public virtual DbSet<TaksitOdeme> TaksitOdemes { get; set; }
        public virtual DbSet<Tur> Turs { get; set; }
        public virtual DbSet<Ulke> Ulkes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Il>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Ilce>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Input>()
                .HasMany(e => e.Degers)
                .WithOptional(e => e.Input)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Input>()
                .HasMany(e => e.Seceneks)
                .WithOptional(e => e.Input)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Isler>()
                .HasMany(e => e.KullaniciIs)
                .WithOptional(e => e.Isler)
                .HasForeignKey(e => e.IsId);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Degers)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.KisiId);

            modelBuilder.Entity<SozlesmeTur>()
                .HasMany(e => e.Sozlesmes)
                .WithOptional(e => e.SozlesmeTur1)
                .HasForeignKey(e => e.SozlesmeTur);

            modelBuilder.Entity<Ulke>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Ulke>()
                .Property(e => e.tr_TR)
                .IsUnicode(false);

            modelBuilder.Entity<Ulke>()
                .Property(e => e.en_US)
                .IsUnicode(false);
        }
    }
}
