using Modules.Base.Model;
using System;
using System.Data.Entity;


namespace Modules.Repository
{
    public class ModulesDbContext : DbContext
    {
        public ModulesDbContext() : base("ModulesDb")
        {
            Database.SetInitializer<ModulesDbContext>(new DropCreateDatabaseIfModelChanges<ModulesDbContext>());
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SoilSample> SoilSamples { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SieveParameter> SieveParameters { get; set; }
        public DbSet<SieveMesh> SieveMeshes { get; set; }

        //public DbSet<BaseModel> BaseModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*  modelBuilder.Entity<User>().Map(n => {
                  n.MapInheritedProperties();
                  n.ToTable("Users");
              });
              */
            modelBuilder.Properties<DateTime>()
                        .Configure(property => property.HasColumnType("datetime2"));
        }

    }
}
