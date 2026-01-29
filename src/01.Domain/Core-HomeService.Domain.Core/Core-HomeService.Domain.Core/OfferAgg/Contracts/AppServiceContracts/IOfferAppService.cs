using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.OfferAgg.DTOs;

namespace Core_HomeService.Domain.Core.OfferAgg.Contracts.AppServiceContracts
{
    public interface IOfferAppService
    {
        Task<Result<bool>> Create(OfferCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, OfferUpdateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> UpdateStatus(int id, OfferStatusUpdateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<PaginationResult<OfferDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<PaginationResult<OfferDto>>> GetByExpertIdPaged(int page, int pageSize, int expertId, CancellationToken cancellationToken);
        Task<Result<OfferDto?>> GetById(int id, CancellationToken cancellationToken);
    }
}
