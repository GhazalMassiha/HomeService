using Core_HomeService.Domain.Core.CategoryAgg.DTOs;
using Core_HomeService.Domain.Core.CategoryAgg.Entities;

namespace Core_HomeService.Domain.Core.CategoryAgg.Contracts.RepositoryContracts
{
    public interface ICategoryRepository
    {
        Task<CategoryDto?> GetById(int id, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<bool> Create(CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken);
        Task<bool> Update(int categoryId, CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken);
        Task<bool> Delete(int categoryId, CancellationToken cancellationToken);
    }
}
