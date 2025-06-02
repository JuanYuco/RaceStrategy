using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Infrastructure.Persistence.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Driver");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.TeamId).IsRequired();
            builder.Property(c => c.NationalityId).IsRequired();

            builder.HasOne(c => c.Team)
                .WithMany(v => v.Drivers)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Nationality)
                .WithMany(v => v.Drivers)
                .HasForeignKey(x => x.NationalityId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
