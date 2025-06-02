using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Infrastructure.Persistence.Configurations
{
    internal class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.ToTable("Nationality");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(100);
        }
    }
}
