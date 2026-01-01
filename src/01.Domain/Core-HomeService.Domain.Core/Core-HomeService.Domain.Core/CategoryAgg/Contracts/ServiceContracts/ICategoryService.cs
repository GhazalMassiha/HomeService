using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.DTOs;

namespace Core_HomeService.Domain.Core.CategoryAgg.Contracts.ServiceContracts
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetById(int id, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<PaginationResult<CategoryDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<bool> Create(CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken);
        Task<bool> Update(int categoryId, CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken);
        Task<bool> Delete(int categoryId, CancellationToken cancellationToken);
    }
}
