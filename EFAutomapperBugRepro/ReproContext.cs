namespace EFAutomapperBugRepro
{
    using Microsoft.EntityFrameworkCore;

    public class ReproContext : DbContext
    {
        public DbSet<Thing> Things { get; set; }

        public DbSet<ThingType> ThingTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThingType>().HasData(
                new ThingType { Id = 1, Name = "Thing type 1" },
                new ThingType { Id = 2, Name = "Thing type 2" });

            modelBuilder.Entity<Thing>().HasData(
                new Thing { Id = 1, Name = "Thing 1", TypeId = 1 },
                new Thing { Id = 2, Name = "Thing 2", TypeId = 2 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFAutomapperBugRepro;Trusted_Connection=True;");
        }
    }

    public class Thing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public ThingType Type { get; set; }
    }

    public class ThingType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}