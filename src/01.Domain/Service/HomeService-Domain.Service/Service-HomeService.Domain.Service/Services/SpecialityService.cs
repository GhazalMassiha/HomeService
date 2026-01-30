using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class SpecialityService(ISpecialityRepository specialityRepository) : ISpecialityService
    {
        public async Task<bool> Create(SpecialityCreateDto specialityCreateDto, CancellationToken cancellationToken)
        {
            return await specialityRepository.Create(specialityCreateDto, cancellationToken);
        }

        public async Task<bool> Delete(int specialityId, CancellationToken cancellationToken)
        {
            return await specialityRepository.Delete(specialityId, cancellationToken);
        }

        public async Task<List<SpecialityDto>> GetAll(CancellationToken cancellationToken)
        {
            return await specialityRepository.GetAll(cancellationToken);
        }

        public async Task<PaginationResult<SpecialityDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await specialityRepository.GetAllPaged(page , pageSize, cancellationToken);
        }

        public async Task<List<SpecialityDto>> GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            return await specialityRepository.GetByCategoryId(categoryId, cancellationToken);
        }

        public async Task<PaginationResult<SpecialityDto>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken)
        {
            return await specialityRepository.GetByCategoryIdPaged(page, pageSize, categoryId, cancellationToken);
        }

        public async Task<SpecialityDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await specialityRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int specialityId, SpecialityCreateDto specialityCreateDto, CancellationToken cancellationToken)
        {
            return await specialityRepository.Update(specialityId, specialityCreateDto, cancellationToken);
        }
    }
}
