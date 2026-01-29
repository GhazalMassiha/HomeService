using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.CustomerDTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await customerRepository.Delete(id, cancellationToken);
        }

        public async Task<PaginationResult<CustomerDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await customerRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await customerRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int id, CustomerUpdateDto dto, CancellationToken cancellationToken)
        {
            return await customerRepository.Update(id, dto, cancellationToken);
        }
    }
}
