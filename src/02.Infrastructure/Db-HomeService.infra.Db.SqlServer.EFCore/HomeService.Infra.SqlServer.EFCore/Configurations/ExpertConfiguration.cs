using Core_HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class ExpertConfiguration : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CardNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Biography)
                   .HasMaxLength(1000);

            builder.Property(e => e.Rating)
                   .HasDefaultValue(0);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(r => r.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAdd();

            builder.HasOne(e => e.User)
                   .WithOne(u => u.Expert)
                   .HasForeignKey<Expert>(e => e.UserId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Offers)
                   .WithOne(o => o.Expert)
                   .HasForeignKey(o => o.ExpertId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Comments)
                   .WithOne(co => co.Expert)
                   .HasForeignKey(co => co.ExpertId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
