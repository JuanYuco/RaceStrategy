using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Infrastructure.Persistence.Configurations
{
    internal class TireByStrategyConfiguration : IEntityTypeConfiguration<TireByStrategy>
    {
        public void Configure(EntityTypeBuilder<TireByStrategy> builder)
        {
            builder.ToTable("TireByStrategy");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TireId).IsRequired();
            builder.Property(c => c.StrategyId).IsRequired();

            builder.HasOne(c => c.Tire)
                .WithMany(v => v.TireByStrategies)
                .HasForeignKey(x => x.TireId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Strategy)
                .WithMany(v => v.TireByStrategies)
                .HasForeignKey(x => x.StrategyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
