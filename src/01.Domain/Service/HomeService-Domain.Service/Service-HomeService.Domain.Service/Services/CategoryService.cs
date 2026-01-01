using Core_HomeService.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CategoryAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<bool> Create(CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken)
        {
            return await categoryRepository.Create(categoryCreateDto, cancellationToken);
        }

        public async Task<bool> Delete(int categoryId, CancellationToken cancellationToken)
        {
            return await categoryRepository.Delete(categoryId, cancellationToken);
        }

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAll(cancellationToken);
        }

        public async Task<CategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int categoryId, CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken)
        {
            return await categoryRepository.Update(categoryId, categoryCreateDto, cancellationToken);
        }
    }
}
