using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.DTOs;

namespace Core_HomeService.Domain.Core.SpecialityAgg.Contracts.AppServiceContracts
{
    public interface ISpecialityAppService
    {
        Task<Result<bool>> Create(SpecialityCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, SpecialityCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<List<SpecialityDto>>> GetAll(CancellationToken cancellationToken);
        Task<Result<PaginationResult<SpecialityDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<List<SpecialityDto>>> GetByCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<Result<PaginationResult<SpecialityDto>>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken);
        Task<Result<SpecialityDto?>> GetById(int id, CancellationToken cancellationToken);
    }
}
