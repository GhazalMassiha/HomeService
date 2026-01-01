using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class RequestService(IRequestRepository requestRepository) : IRequestService
    {
        public async Task<bool> Create(RequestCreateDto dto, CancellationToken cancellationToken)
        {
            return await requestRepository.Create(dto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await requestRepository.Delete(id, cancellationToken);
        }

        public async Task<PaginationResult<RequestDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await requestRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<RequestDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await requestRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int id, RequestUpdateDto dto, CancellationToken cancellationToken)
        {
            return await requestRepository.Update(id, dto, cancellationToken);
        }

        public async Task<bool> UpdateStatus(int id, RequestStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            return await requestRepository.UpdateStatus(id, dto, cancellationToken);
        }
    }
}
