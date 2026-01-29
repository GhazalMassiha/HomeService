using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ExpertDTOs;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.ExpertContract
{
    public interface IExpertAppService
    {
        Task<Result<ExpertDto?>> GetById(int id, CancellationToken cancellationToken);
        Task<Result<PaginationResult<ExpertDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, ExpertUpdateDto expertDto, ApplicationUserUpdateDto userDto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
    }
}
