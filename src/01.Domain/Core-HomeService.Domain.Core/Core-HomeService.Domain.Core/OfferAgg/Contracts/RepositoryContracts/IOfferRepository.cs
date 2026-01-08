using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.DTOs;

namespace Core_HomeService.Domain.Core.OfferAgg.Contracts.RepositoryContracts
{
    public interface IOfferRepository
    {
        Task<OfferDto?> GetById(int id, CancellationToken cancellationToken);
        Task<PaginationResult<OfferDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<PaginationResult<OfferDto>> GetByExpertIdPaged(int page, int pageSize, int expertId, CancellationToken cancellationToken);
        Task<bool> Create(OfferCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Update(int id, OfferUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> UpdateStatus(int id, OfferStatusUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
