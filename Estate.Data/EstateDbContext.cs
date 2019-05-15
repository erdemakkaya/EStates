using Estate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estate.Data
{
    public class EstateDbContext:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryFeature> CategoryFeature { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<GeoLocation> GeoLocation { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyFeature> PropertyFeature { get; set; }
        public DbSet<User> User { get; set; }


        public EstateDbContext()
            : base(@"Data Source = DESKTOP-0CI0TQT\EAKKAYA; Initial Catalog = EstateDB; Persist Security Info=True;User ID = sa; Password=sa12345;MultipleActiveResultSets=True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EstateDbContext, Migrations.Configuration>());
        }
    }
}
