using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleSale.Models
{
    public class SimpleSaleContext : DbContext
    {
        public SimpleSaleContext()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        // You can add custom code to this file. Changes will not be overwritten.
        //
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        //
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<SimpleSale.Models.SimpleSaleContext>());

        public DbSet<SimpleSale.Models.Category> Categories { get; set; }

        public DbSet<SimpleSale.Models.Item> Items { get; set; }
        public DbSet<SimpleSale.Models.Reciept> Reciepts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Category>()
           .HasMany(m => m.Items)
           .WithRequired(m => m.Category)
           .HasForeignKey(m => m.CategoryId)
           .WillCascadeOnDelete(true);

            modelBuilder.Entity<Item>()
            .HasRequired(r => r.Category)
            .WithMany(s => s.Items)
            .HasForeignKey(f => f.CategoryId)
    .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}