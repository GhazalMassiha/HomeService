using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CityAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.CityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CityAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class CityAppService(ICityService cityService) : ICityAppService
    {
        public async Task<Result<bool>> Create(CityCreateDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return Result<bool>.Failure("نام شهر الزامی است.");

            var ok = await cityService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در ایجاد شهر.");

            return Result<bool>.Success("شهر با موفقیت ایجاد شد.", true);
        }


        public async Task<Result<bool>> Update(int id, CityWithProvinceDto dto, CancellationToken cancellationToken)
        {
            var city = await cityService.GetById(id, cancellationToken);
            if (city == null)
                return Result<bool>.Failure("شهر یافت نشد.");

            var ok = await cityService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در بروزرسانی شهر.");

            return Result<bool>.Success("شهر با موفقیت بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await cityService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("خطا در حذف شهر.");

            return Result<bool>.Success("شهر با موفقیت حذف شد.", true);
        }

        public async Task<Result<List<CityDto>>> GetAll(CancellationToken cancellationToken)
        {
            var cities = await cityService.GetAll(cancellationToken);
            return Result<List<CityDto>>.Success("شهرها دریافت شدند.", cities);
        }

        public async Task<Result<PaginationResult<CityDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await cityService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<CityDto>>.Success("شهرها دریافت شدند.", result);
        }

        public async Task<Result<List<CityWithProvinceDto>>> GetAllWithProvince(CancellationToken cancellationToken)
        {
            var result = await cityService.GetAllWithProvince(cancellationToken);
            return Result<List<CityWithProvinceDto>>.Success("شهرها دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<CityWithProvinceDto>>> GetAllWithProvincePaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await cityService.GetAllWithProvincePaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<CityWithProvinceDto>>.Success("شهرها دریافت شدند.", result);
        }

        public async Task<Result<List<CityWithProvinceDto>>> GetAllByProvinceId(int provinceId, CancellationToken cancellationToken)
        {
            var result = await cityService.GetAllByProvinceId(provinceId, cancellationToken);
            return Result<List<CityWithProvinceDto>>.Success("شهرها دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<CityWithProvinceDto>>> GetAllByProvinceIdPaged(int page, int pageSize, int provinceId, CancellationToken cancellationToken)
        {
            var result = await cityService.GetAllByProvinceIdPaged(page, pageSize, provinceId, cancellationToken);
            return Result<PaginationResult<CityWithProvinceDto>>.Success("شهرها دریافت شدند.", result);
        }

        public async Task<Result<CityDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var city = await cityService.GetById(id, cancellationToken);
            if (city == null)
                return Result<CityDto?>.Failure("شهر یافت نشد.");

            return Result<CityDto?>.Success("شهر دریافت شد.", city);
        }

        public async Task<Result<CityWithProvinceDto?>> GetByIdWithProvince(int id, CancellationToken cancellationToken)
        {
            var city = await cityService.GetByIdWithProvince(id, cancellationToken);
            if (city == null)
                return Result<CityWithProvinceDto?>.Failure("شهر یافت نشد.");

            return Result<CityWithProvinceDto?>.Success("شهر دریافت شد.", city);
        }
    }
}
