using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Infrastructure.Persistence.Configurations
{
    public class TireConfiguration : IEntityTypeConfiguration<Tire>
    {
        public void Configure(EntityTypeBuilder<Tire> builder)
        {
            builder.ToTable("Tire");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Type).IsRequired().HasMaxLength(50);
            builder.Property(c => c.EstimatedLaps).IsRequired();
            builder.Property(c => c.Performance).IsRequired();
            builder.Property(c => c.ConsumedPerLap).IsRequired();
        }
    }
}
