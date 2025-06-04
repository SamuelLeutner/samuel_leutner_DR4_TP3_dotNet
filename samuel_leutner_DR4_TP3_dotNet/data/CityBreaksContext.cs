namespace samuel_leutner_DR4_TP3_dotNet.data
{
    using Microsoft.EntityFrameworkCore;
    using samuel_leutner_DR4_TP3_dotNet.data.Configurations;
    using samuel_leutner_DR4_TP3_dotNet.Models;

    public class CityBreaksContext : DbContext
    {
        public CityBreaksContext(DbContextOptions<CityBreaksContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Property> Properties { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
        }
    }
}