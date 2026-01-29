using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class ProvinceAppService(IProvinceService provinceService) : IProvinceAppService
    {
        public async Task<Result<bool>> Create(ProvinceCreateDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return Result<bool>.Failure("نام استان الزامی است.");

            var ok = await provinceService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در ایجاد استان.");

            return Result<bool>.Success("استان با موفقیت ایجاد شد.", true);
        }

        public async Task<Result<bool>> Update(int id, ProvinceDto dto, CancellationToken cancellationToken)
        {
            var province = await provinceService.GetById(id, cancellationToken);
            if (province == null)
                return Result<bool>.Failure("استان یافت نشد.");

            var ok = await provinceService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در بروزرسانی استان.");

            return Result<bool>.Success("استان بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await provinceService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در حذف استان.");

            return Result<bool>.Success("استان حذف شد.", true);
        }

        public async Task<Result<List<ProvinceDto>>> GetAll(CancellationToken cancellationToken)
        {
            var provinces = await provinceService.GetAll(cancellationToken);
            return Result<List<ProvinceDto>>.Success("استان‌ها دریافت شدند.", provinces);
        }

        public async Task<Result<PaginationResult<ProvinceDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await provinceService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<ProvinceDto>>.Success("استان‌ها دریافت شدند.", result);
        }

        public async Task<Result<ProvinceDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var province = await provinceService.GetById(id, cancellationToken);
            if (province == null)
                return Result<ProvinceDto?>.Failure("استان یافت نشد.");

            return Result<ProvinceDto?>.Success("استان دریافت شد.", province);
        }
    }
}
