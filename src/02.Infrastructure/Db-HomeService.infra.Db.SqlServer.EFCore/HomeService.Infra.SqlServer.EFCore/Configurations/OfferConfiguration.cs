using Core_HomeService.Domain.Core.OfferAgg.Entities;
using Core_HomeService.Domain.Core.OfferAgg.Enums;
using Core_HomeService.Domain.Core.RequestAgg.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Price)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(o => o.Text)
                   .HasMaxLength(2000);

            builder.Property(r => r.Status)
                   .HasConversion<string>()
                   .HasDefaultValue(OfferStatusEnum.Pending)
                   .HasSentinel(OfferStatusEnum.Pending);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(o => o.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();
        }
    }
}
