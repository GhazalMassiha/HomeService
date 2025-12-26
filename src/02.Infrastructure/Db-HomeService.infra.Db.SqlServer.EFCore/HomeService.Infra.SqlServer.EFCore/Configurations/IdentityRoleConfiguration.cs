using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            var roles = new List<IdentityRole<int>>
            {
                new IdentityRole<int>()
            {
                Id = 1,
                ConcurrencyStamp = new string(Guid.NewGuid().ToString()),
                NormalizedName = "ADMIN",
                Name = "Admin",
            },

                new IdentityRole<int>()
            {
                Id = 2,
                ConcurrencyStamp = new string(Guid.NewGuid().ToString()),
                NormalizedName = "CUSTOMER",
                Name = "Customer",
            },
                   new IdentityRole<int>()
            {
                Id = 3,
                ConcurrencyStamp = new string(Guid.NewGuid().ToString()),
                NormalizedName = "EXPERT",
                Name = "Expert",
            }
            };
            builder.HasData(roles);
        }
    }
}
