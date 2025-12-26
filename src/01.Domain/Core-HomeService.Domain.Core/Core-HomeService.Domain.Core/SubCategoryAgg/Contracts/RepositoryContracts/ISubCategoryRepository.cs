using Core_HomeService.Domain.Core.SubCategoryAgg.DTOs;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;

namespace Core_HomeService.Domain.Core.SubCategoryAgg.Contracts.RepositoryContracts
{
    public interface ISubCategoryRepository
    {
        Task<SubCategoryDto?> GetById(int id, CancellationToken cancellationToken);
        Task<List<SubCategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<List<SubCategoryDto>> GetByCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<bool> Create(SubCategoryCreateDto subCategoryCreateDto, CancellationToken cancellationToken);
        Task<bool> Update(int subCategoryId, SubCategoryCreateDto subCategoryCreateDto, CancellationToken cancellationToken);
        Task<bool> Delete(int subCategoryId, CancellationToken cancellationToken);
    }
}
