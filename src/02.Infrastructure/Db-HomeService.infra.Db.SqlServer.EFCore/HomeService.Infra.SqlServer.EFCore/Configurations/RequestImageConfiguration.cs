using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class RequestImageConfiguration : IEntityTypeConfiguration<RequestImage>
    {
        public void Configure(EntityTypeBuilder<RequestImage> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(r => r.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAdd();
        }
    }
}
