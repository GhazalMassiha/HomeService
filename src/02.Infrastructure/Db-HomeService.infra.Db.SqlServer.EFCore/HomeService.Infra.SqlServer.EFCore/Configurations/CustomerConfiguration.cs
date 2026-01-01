using Core_HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Address)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(r => r.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAdd();

            builder.HasOne(c => c.User)
                   .WithOne(u => u.Customer)
                   .HasForeignKey<Customer>(c => c.UserId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Requests)
                   .WithOne(r => r.Customer)
                   .HasForeignKey(r => r.CustomerId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Comments)
                   .WithOne(co => co.Customer)
                   .HasForeignKey(co => co.CustomerId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
