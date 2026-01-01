using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.OfferAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class OfferService(IOfferRepository offerRepository) : IOfferService
    {
        public async Task<bool> Create(OfferCreateDto dto, CancellationToken cancellationToken)
        {
            return await offerRepository.Create(dto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await offerRepository.Delete(id, cancellationToken);
        }

        public async Task<PaginationResult<OfferDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await offerRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<OfferDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await offerRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int id, OfferUpdateDto dto, CancellationToken cancellationToken)
        {
            return await offerRepository.Update(id, dto, cancellationToken);
        }

        public async Task<bool> UpdateStatus(int id, OfferStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            return await offerRepository.UpdateStatus(id, dto, cancellationToken);
        }
    }
}
