using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.DTOs;

namespace Core_HomeService.Domain.Core.OfferAgg.Contracts.ServiceContracts
{
    public interface IOfferService
    {
        Task<OfferDto?> GetById(int id, CancellationToken cancellationToken);
        Task<PaginationResult<OfferDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<bool> Create(OfferCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Update(int id, OfferUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> UpdateStatus(int id, OfferStatusUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
