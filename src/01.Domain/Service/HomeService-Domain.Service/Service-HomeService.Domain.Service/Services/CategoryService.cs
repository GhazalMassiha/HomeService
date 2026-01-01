using Core_HomeService.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CategoryAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<bool> Create(CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int categoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int categoryId, CategoryCreateDto categoryCreateDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
