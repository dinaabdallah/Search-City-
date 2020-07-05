namespace Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBCities : DbContext
    {
        
        public DBCities(): base("name=DBCities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBCities, Migrations.Configuration>());
            //Database.SetInitializer<DBCities>(new CreateDatabaseIfNotExists<DBCities>()); 
        }


        public  DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Countries>()
                .Property(p => p.CountryCode)
                .HasColumnType("CHAR")
                .HasMaxLength(30);

            modelBuilder.Entity<Countries>()
                .Property(p => p.alternateCountry)
                .HasColumnType("CHAR")
                .HasMaxLength(2);

        }

    }
    
}