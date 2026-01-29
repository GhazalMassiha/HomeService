using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestImageAgg.DTOs;

namespace Core_HomeService.Domain.Core.ImageAgg.Contracts.AppServiceContracts
{
    public interface IRequestImageAppService
    {
        Task<Result<bool>> Create(RequestImageCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<List<RequestImageDto>>> GetByRequestId(int requestId, CancellationToken cancellationToken);
    }
}
