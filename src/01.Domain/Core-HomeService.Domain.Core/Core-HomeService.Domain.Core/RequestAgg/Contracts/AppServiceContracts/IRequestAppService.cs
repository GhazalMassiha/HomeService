using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestAgg.DTOs;

namespace Core_HomeService.Domain.Core.RequestAgg.Contracts.AppServiceContracts
{
    public interface IRequestAppService
    {
        Task<Result<bool>> Create(RequestCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, RequestUpdateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> UpdateStatus(int id, RequestStatusUpdateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<PaginationResult<RequestDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<RequestDto?>> GetById(int id, CancellationToken cancellationToken);
    }
}
