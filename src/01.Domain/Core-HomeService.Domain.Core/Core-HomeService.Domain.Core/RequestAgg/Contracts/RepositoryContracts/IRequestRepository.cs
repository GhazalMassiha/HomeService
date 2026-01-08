using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.Enums;
using Core_HomeService.Domain.Core.RequestAgg.DTOs;

namespace Core_HomeService.Domain.Core.RequestAgg.Contracts.RepositoryContracts
{
    public interface IRequestRepository
    {
        Task<RequestDto?> GetById(int id, CancellationToken cancellationToken);
        Task<PaginationResult<RequestDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<PaginationResult<RequestDto>> GetByCustomerIdPaged(int page, int pageSize, int customerId, CancellationToken cancellationToken);
        Task<PaginationResult<RequestDto>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken);
        Task<PaginationResult<RequestDto>> GetBySpecialityIdPaged(int page, int pageSize, int specialityId, CancellationToken cancellationToken);
        Task<bool> Create(RequestCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Update(int id, RequestUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> UpdateStatus(int id, RequestStatusUpdateDto dto , CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
