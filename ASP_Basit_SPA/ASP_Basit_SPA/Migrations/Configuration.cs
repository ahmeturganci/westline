using System.Data.Entity.Migrations;

namespace ASP_Basit_SPA.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<ASP_Basit_SPA.UrunDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UrunDB context)
        {

            context.Urun.AddOrUpdate(p => p.UrunAd,
                new Urun { UrunAd = "Telefon", UrunFiyat = 750, UrunMiktar = 522 },
                new Urun { UrunAd = "silgi", UrunFiyat = 50, UrunMiktar = 15 },
                new Urun { UrunAd = "don", UrunFiyat = 70, UrunMiktar = 52 },
                new Urun { UrunAd = "denemeLik eþya", UrunFiyat = 720, UrunMiktar = 53 },
                new Urun { UrunAd = "bilmiyom", UrunFiyat = 750, UrunMiktar = 5 });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
