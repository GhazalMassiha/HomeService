using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class IdentityUserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            var userRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>(){

                    RoleId = 1,
                    UserId = 1
                }
            };
            builder.HasData(userRoles);
        }
    }
}
