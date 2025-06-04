using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using samuel_leutner_DR4_TP3_dotNet.Models;

namespace samuel_leutner_DR4_TP3_dotNet.data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(c => c.CountryCode)
                .HasMaxLength(3)
                .IsRequired();

            builder.HasData(
                 new Country { Id = 1, CountryCode = "BRA", CountryName = "Brazil" },
                 new Country { Id = 2, CountryCode = "USA", CountryName = "United States" },
                 new Country { Id = 3, CountryCode = "CAN", CountryName = "Canada" },
                 new Country { Id = 4, CountryCode = "GBR", CountryName = "United Kingdom" },
                 new Country { Id = 5, CountryCode = "FRA", CountryName = "France" }
             );
        }
    }
}