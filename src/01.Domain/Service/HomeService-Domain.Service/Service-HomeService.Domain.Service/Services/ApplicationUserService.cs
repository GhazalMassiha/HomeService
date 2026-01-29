using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class ApplicationUserService(IApplicationUserRepository applicationUserRepository) : IApplicationUserService
    {
        public async Task<bool> Update(int userId, ApplicationUserUpdateDto dto, CancellationToken cancellationToken)
        {
            return await applicationUserRepository.Update(userId, dto, cancellationToken);
        }
    }
}
