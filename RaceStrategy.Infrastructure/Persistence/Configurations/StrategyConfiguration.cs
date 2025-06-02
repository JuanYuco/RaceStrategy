using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Infrastructure.Persistence.Configurations
{
    public class StrategyConfiguration : IEntityTypeConfiguration<Strategy>
    {
        public void Configure(EntityTypeBuilder<Strategy> builder)
        {
            builder.ToTable("Strategy");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DriverId).IsRequired();
            builder.Property(c => c.TotalLaps).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();
            builder.Property(c => c.Date).IsRequired();

            builder.HasOne(c => c.Driver)
                .WithMany(v => v.Strategies)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
