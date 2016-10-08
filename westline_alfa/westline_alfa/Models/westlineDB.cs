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

        public virtual DbSet<AcilDurum> AcilDurums { get; set; }
        public virtual DbSet<Adre> Adres { get; set; }
        public virtual DbSet<Aktivasyon> Aktivasyons { get; set; }
        public virtual DbSet<Belge> Belges { get; set; }
        public virtual DbSet<Cv> Cvs { get; set; }
        public virtual DbSet<CvReferan> CvReferans { get; set; }
        public virtual DbSet<Dil> Dils { get; set; }
        public virtual DbSet<DilKisi> DilKisis { get; set; }
        public virtual DbSet<ds160> ds160 { get; set; }
        public virtual DbSet<GidilenUlkeler> GidilenUlkelers { get; set; }
        public virtual DbSet<Il> Ils { get; set; }
        public virtual DbSet<Ilce> Ilces { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<IngilizceSeviye> IngilizceSeviyes { get; set; }
        public virtual DbSet<Isler> Islers { get; set; }
        public virtual DbSet<Kisi> Kisis { get; set; }
        public virtual DbSet<KisiI> KisiIs { get; set; }
        public virtual DbSet<KisiUcu> KisiUcus { get; set; }
        public virtual DbSet<Lise> Lises { get; set; }
        public virtual DbSet<Pasaport> Pasaports { get; set; }
        public virtual DbSet<Randevu> Randevus { get; set; }
        public virtual DbSet<Referan> Referans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ucu> Ucus { get; set; }
        public virtual DbSet<Ulke> Ulkes { get; set; }
        public virtual DbSet<Universite> Universites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adre>()
                .HasMany(e => e.Iletisims)
                .WithOptional(e => e.Adre)
                .HasForeignKey(e => e.AdresId);

            modelBuilder.Entity<Adre>()
                .HasMany(e => e.Lises)
                .WithOptional(e => e.Adre)
                .HasForeignKey(e => e.AdresId);

            modelBuilder.Entity<Adre>()
                .HasMany(e => e.Referans)
                .WithOptional(e => e.Adre)
                .HasForeignKey(e => e.AdresId);

            modelBuilder.Entity<Adre>()
                .HasMany(e => e.Universites)
                .WithOptional(e => e.Adre)
                .HasForeignKey(e => e.Adres);

            modelBuilder.Entity<ds160>()
                .HasMany(e => e.Kisis)
                .WithOptional(e => e.ds160)
                .HasForeignKey(e => e.DsId);

            modelBuilder.Entity<Il>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Il>()
                .HasMany(e => e.Adres)
                .WithOptional(e => e.Il)
                .HasForeignKey(e => e.EyaletId);

            modelBuilder.Entity<Il>()
                .HasMany(e => e.ds160)
                .WithOptional(e => e.Il)
                .HasForeignKey(e => e.DogumYeri);

            modelBuilder.Entity<Ilce>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<Isler>()
                .HasMany(e => e.KisiIs)
                .WithOptional(e => e.Isler)
                .HasForeignKey(e => e.IsId);

            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Cvs)
                .WithOptional(e => e.Kisi)
                .HasForeignKey(e => e.KisiId);

            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Cvs1)
                .WithOptional(e => e.Kisi1)
                .HasForeignKey(e => e.KisiId);

            modelBuilder.Entity<Referan>()
                .HasMany(e => e.CvReferans)
                .WithOptional(e => e.Referan)
                .HasForeignKey(e => e.ReferansId);

            modelBuilder.Entity<Ucu>()
                .HasMany(e => e.KisiUcus)
                .WithOptional(e => e.Ucu)
                .HasForeignKey(e => e.UcusId);

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
