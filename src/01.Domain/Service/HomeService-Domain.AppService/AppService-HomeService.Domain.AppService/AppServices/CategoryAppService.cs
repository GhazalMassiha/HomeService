using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CategoryAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public async Task<Result<bool>> Create(CategoryCreateDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return Result<bool>.Failure("نام دسته‌بندی الزامی است.");

            var ok = await categoryService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در ایجاد دسته‌بندی.");

            return Result<bool>.Success("دسته‌بندی با موفقیت ایجاد شد.", true);
        }

        public async Task<Result<bool>> Update(int id, CategoryCreateDto dto, CancellationToken cancellationToken)
        {
            var existing = await categoryService.GetById(id, cancellationToken);
            if (existing == null)
                return Result<bool>.Failure("دسته‌بندی یافت نشد.");

            var ok = await categoryService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در بروزرسانی دسته‌بندی.");

            return Result<bool>.Success("دسته‌بندی بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await categoryService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در حذف دسته‌بندی.");

            return Result<bool>.Success("دسته‌بندی حذف شد.", true);
        }

        public async Task<Result<List<CategoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await categoryService.GetAll(cancellationToken);
            return Result<List<CategoryDto>>.Success("دسته‌بندی‌ها دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<CategoryDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await categoryService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<CategoryDto>>.Success("دسته‌بندی‌ها دریافت شدند.", result);
        }

        public async Task<Result<CategoryDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await categoryService.GetById(id, cancellationToken);
            if (result == null)
                return Result<CategoryDto?>.Failure("دسته‌بندی یافت نشد.");

            return Result<CategoryDto?>.Success("دسته‌بندی دریافت شد.", result);
        }
    }
}
