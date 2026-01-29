using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ApplicationUserContract
{
    public interface IApplicationUserRepository
    {
        Task<bool> Update(int userId, ApplicationUserUpdateDto dto, CancellationToken cancellationToken);
    }
}
