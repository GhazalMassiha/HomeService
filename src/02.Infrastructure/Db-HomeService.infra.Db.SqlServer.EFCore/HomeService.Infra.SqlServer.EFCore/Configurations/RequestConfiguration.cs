using Core_HomeService.Domain.Core.OfferAgg.Enums;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.Description)
                   .HasMaxLength(2000);

            builder.Property(r => r.Status)
                   .HasConversion<string>()
                   .HasDefaultValue(RequestStatusEnum.Pending)
                   .HasSentinel(RequestStatusEnum.Pending);

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd(); 

            builder.HasOne(r => r.Province)
                   .WithMany(p => p.Requests)
                   .HasForeignKey(r => r.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.City)
                   .WithMany(c => c.Requests)
                   .HasForeignKey(r => r.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Offers)
                   .WithOne(o => o.Request)
                   .HasForeignKey(o => o.RequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Comments)
                   .WithOne(co => co.Request)
                   .HasForeignKey(co => co.RequestId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Images)
                   .WithOne(i => i.Request)
                   .HasForeignKey(i => i.RequestId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
