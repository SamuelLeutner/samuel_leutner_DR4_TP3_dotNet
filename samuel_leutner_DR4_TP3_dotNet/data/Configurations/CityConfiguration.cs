using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using samuel_leutner_DR4_TP3_dotNet.Models;

namespace samuel_leutner_DR4_TP3_dotNet.data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(c => c.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.CountryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new City { Id = 1, Name = "Guarapuava", CountryId = 1 },
                new City { Id = 2, Name = "Curitiba", CountryId = 1 },
                new City { Id = 3, Name = "New York", CountryId = 2 },
                new City { Id = 4, Name = "Los Angeles", CountryId = 2 },
                new City { Id = 5, Name = "Toronto", CountryId = 3 },
                new City { Id = 6, Name = "London", CountryId = 4 },
                new City { Id = 7, Name = "Paris", CountryId = 5 }
            );
        }
    }
}
