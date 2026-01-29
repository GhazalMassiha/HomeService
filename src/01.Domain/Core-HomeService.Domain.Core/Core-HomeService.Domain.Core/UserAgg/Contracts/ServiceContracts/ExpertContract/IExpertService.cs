using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ExpertDTOs;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ExpertContract
{
    public interface IExpertService
    {
        Task<ExpertDto?> GetById(int id, CancellationToken cancellationToken);
        Task<PaginationResult<ExpertDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<bool> Update(int id, ExpertUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
