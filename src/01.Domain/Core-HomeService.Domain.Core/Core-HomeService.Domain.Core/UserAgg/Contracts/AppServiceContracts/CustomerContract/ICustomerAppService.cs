using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.DTOs.CustomerDTOs;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.CustomerContract
{
    public interface ICustomerAppService
    {
        Task<Result<CustomerDto?>> GetById(int id, CancellationToken cancellationToken);
        Task<Result<PaginationResult<CustomerDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, CustomerUpdateDto customerDto, ApplicationUserUpdateDto userDto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
    }
}
