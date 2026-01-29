using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.SubCategoryAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class SpecialityAppService(ISpecialityService specialityService) : ISpecialityAppService
    {
        public async Task<Result<bool>> Create(SpecialityCreateDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return Result<bool>.Failure("نام تخصص الزامی است.");

            var ok = await specialityService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در ایجاد تخصص.");

            return Result<bool>.Success("تخصص با موفقیت ایجاد شد.", true);
        }

        public async Task<Result<bool>> Update(int id, SpecialityCreateDto dto, CancellationToken cancellationToken)
        {
            var speciality = await specialityService.GetById(id, cancellationToken);
            if (speciality == null)
                return Result<bool>.Failure("تخصص یافت نشد.");

            var ok = await specialityService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در بروزرسانی تخصص.");

            return Result<bool>.Success("تخصص بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await specialityService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در حذف تخصص.");

            return Result<bool>.Success("تخصص حذف شد.", true);
        }

        public async Task<Result<List<SpecialityDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await specialityService.GetAll(cancellationToken);
            return Result<List<SpecialityDto>>.Success("تخصص‌ها دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<SpecialityDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await specialityService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<SpecialityDto>>.Success("تخصص‌ها دریافت شدند.", result);
        }

        public async Task<Result<List<SpecialityDto>>> GetByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var result = await specialityService.GetByCategoryId(categoryId, cancellationToken);
            return Result<List<SpecialityDto>>.Success("تخصص‌ها دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<SpecialityDto>>> GetByCategoryIdPaged(int page, int pageSize, int categoryId, CancellationToken cancellationToken)
        {
            var result = await specialityService.GetByCategoryIdPaged(page, pageSize, categoryId, cancellationToken);
            return Result<PaginationResult<SpecialityDto>>.Success("تخصص‌ها دریافت شدند.", result);
        }

        public async Task<Result<SpecialityDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var speciality = await specialityService.GetById(id, cancellationToken);
            if (speciality == null)
                return Result<SpecialityDto?>.Failure("تخصص یافت نشد.");

            return Result<SpecialityDto?>.Success("تخصص دریافت شد.", speciality);
        }
    }
}
