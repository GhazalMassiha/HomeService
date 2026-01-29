using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ExpertDTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class ExpertService(IExpertRepository expertRepository) : IExpertService
    {
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await expertRepository.Delete(id, cancellationToken);
        }

        public async Task<PaginationResult<ExpertDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await expertRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<ExpertDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await expertRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int id, ExpertUpdateDto dto, CancellationToken cancellationToken)
        {
            return await expertRepository.Update(id, dto, cancellationToken);
        }
    }
}
