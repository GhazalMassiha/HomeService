using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.SpecialityAgg.DTOs;

namespace Core_HomeService.Domain.Core.SpecialityAgg.Contracts.ServiceContracts
{
    public interface ISpecialityService
    {
        Task<SpecialityDto?> GetById(int id, CancellationToken cancellationToken);
        Task<List<SpecialityDto>> GetAll(CancellationToken cancellationToken);
        Task<PaginationResult<SpecialityDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<List<SpecialityDto>> GetByCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<PaginationResult<SpecialityDto>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken);
        Task<bool> Create(SpecialityCreateDto specialityCreateDto, CancellationToken cancellationToken);
        Task<bool> Update(int specialityId, SpecialityCreateDto specialityCreateDto, CancellationToken cancellationToken);
        Task<bool> Delete(int specialityId, CancellationToken cancellationToken);
    }
}
