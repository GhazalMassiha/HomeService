using Core_HomeService.Domain.Core.ImageAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestImageAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class RequestImageService(IRequestImageRepository requestImageRepository) : IRequestImageService
    {
        public async Task<bool> Create(RequestImageCreateDto dto, CancellationToken cancellationToken)
        {
            return await requestImageRepository.Create(dto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await requestImageRepository.Delete(id, cancellationToken);
        }

        public async Task<List<RequestImageDto>> GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            return await requestImageRepository.GetByRequestId(requestId, cancellationToken);
        }
    }
}
