using Core_HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.AccountBalance)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(u => u.City)
                   .WithMany(c => c.Users)
                   .HasForeignKey(u => u.CityId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Province)
                   .WithMany()
                   .HasForeignKey(u => u.ProvinceId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);


            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
             new ApplicationUser
             {
                 Id = 1,
                 UserName = "admin",
                 NormalizedUserName = "ADMIN",
                 PasswordHash = hasher.HashPassword(null, "Admin123456"),
                 Email = "admin@gmail.com",
                 NormalizedEmail = "ADMIN@GMAIL.COM",
                 FirstName = "admin",
                 LastName = "admin",
                 CityId = 1,
                 ProvinceId = 1,
                 IsProfileCompleted = true,
                 EmailConfirmed = true,
                 SecurityStamp = Guid.NewGuid().ToString("D"),
                 ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                 LockoutEnabled = false
             });
        }
    }
}
