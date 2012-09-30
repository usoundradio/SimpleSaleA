namespace SimpleSale.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SimpleSale.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleSale.Models.SimpleSaleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimpleSale.Models.SimpleSaleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
      //        context.Categories.AddOrUpdate(
      //        p=>p.Name
      //         new Category { Name = "Tee-Shirts", UserId="",Items=
      //         {new Item {Name = "", Price= "", UserId = "", Quantity="22", Year="", }},
      //        new Category { Name = "Long Sleeve Shirt" },
      //         new Category { Name = "Pants" },
      //                     new Category { Name = "Shorts" },

      //                     new Category { Name = "Hats" },

      //                     new Category { Name = "Socks" },

      //);
            //
        }
    }
}
