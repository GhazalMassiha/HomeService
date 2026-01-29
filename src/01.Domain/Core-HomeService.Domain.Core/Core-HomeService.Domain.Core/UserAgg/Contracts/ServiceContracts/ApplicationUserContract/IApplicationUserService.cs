using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ApplicationUserContract
{
    public interface IApplicationUserService
    {
        Task<bool> Update(int userId, ApplicationUserUpdateDto dto, CancellationToken cancellationToken);
    }
}
