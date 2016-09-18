namespace ASP_Basit_SPA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UrunDB : DbContext
    {
        public UrunDB()
            : base("name=UrunDB")
        {
        }

        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
