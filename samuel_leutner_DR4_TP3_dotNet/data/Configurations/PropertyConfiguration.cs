using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using samuel_leutner_DR4_TP3_dotNet.Models;

namespace samuel_leutner_DR4_TP3_dotNet.data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name)
              .HasMaxLength(255)
              .IsRequired();

            builder.Property(p => p.PricePerNight)
                .HasColumnType("DECIMAL(18,2)")
                .IsRequired();

            builder.Property(p => p.DeletedAt)
                .IsRequired(false);

            builder.HasOne(p => p.City)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
              new Property { Id = 1, Name = "Hotel Central", PricePerNight = 150.00m, CityId = 1 },
              new Property { Id = 2, Name = "Pousada do Lago", PricePerNight = 120.50m, CityId = 1 },
              new Property { Id = 3, Name = "Apartamento Batel", PricePerNight = 200.00m, CityId = 2 },
              new Property { Id = 4, Name = "Luxury Condo Times Square", PricePerNight = 500.00m, CityId = 3 },
              new Property { Id = 5, Name = "Hollywood Hills Villa", PricePerNight = 750.00m, CityId = 4 },
              new Property { Id = 6, Name = "Downtown Studio", PricePerNight = 180.00m, CityId = 5 },
              new Property { Id = 7, Name = "Cozy Flat near Big Ben", PricePerNight = 300.00m, CityId = 6 },
              new Property { Id = 8, Name = "Eiffel Tower View Apartment", PricePerNight = 450.00m, CityId = 7 }
          );
        }
    }
}
