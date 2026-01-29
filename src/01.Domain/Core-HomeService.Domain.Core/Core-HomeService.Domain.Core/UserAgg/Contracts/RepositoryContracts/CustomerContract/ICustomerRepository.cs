using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.DTOs.CustomerDTOs;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.CustomerContract
{
    public interface ICustomerRepository
    {
        Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken);
        Task<PaginationResult<CustomerDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<bool> Update(int id, CustomerUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
