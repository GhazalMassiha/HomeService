using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class ApplicationUserRepository(AppDbContext context) : IApplicationUserRepository
    {
        public async Task<bool> Update(int userId, ApplicationUserUpdateDto dto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Users
           .Where(u => u.Id == userId)
           .ExecuteUpdateAsync(setter => setter
               .SetProperty(u => u.FirstName, dto.FirstName)
               .SetProperty(u => u.LastName, dto.LastName)
               .SetProperty(u => u.CityId, dto.CityId)
               .SetProperty(u => u.ProvinceId, dto.ProvinceId)
               .SetProperty(u => u.ImageUrl, dto.ImageUrl),
               cancellationToken);

            return affectedRows > 0;
        }
    }
}
