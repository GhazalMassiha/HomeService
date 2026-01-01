using Core_HomeService.Domain.Core.ImageAgg.DTOs;
using Core_HomeService.Domain.Core.RequestImageAgg.DTOs;

namespace Core_HomeService.Domain.Core.ImageAgg.Contracts.ServiceContracts
{
    public interface IRequestImageService
    {
        Task<List<RequestImageDto>> GetByRequestId(int requestId, CancellationToken cancellationToken);
        Task<bool> Create(RequestImageCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
