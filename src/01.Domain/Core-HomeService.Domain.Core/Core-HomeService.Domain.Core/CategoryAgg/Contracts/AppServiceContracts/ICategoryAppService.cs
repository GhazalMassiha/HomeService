using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CategoryAgg.DTOs;

namespace Core_HomeService.Domain.Core.CategoryAgg.Contracts.AppServiceContracts
{
    public interface ICategoryAppService
    {
        Task<Result<bool>> Create(CategoryCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, CategoryCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<List<CategoryDto>>> GetAll(CancellationToken cancellationToken);
        Task<Result<PaginationResult<CategoryDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<CategoryDto?>> GetById(int id, CancellationToken cancellationToken);
    }
}
