using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CityAgg.DTOs;

namespace Core_HomeService.Domain.Core.CityAgg.Contracts.AppServiceContracts
{
    public interface ICityAppService
    {
        Task<Result<bool>> Create(CityCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, CityWithProvinceDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<List<CityDto>>> GetAll(CancellationToken cancellationToken);
        Task<Result<PaginationResult<CityDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<List<CityWithProvinceDto>>> GetAllWithProvince(CancellationToken cancellationToken);
        Task<Result<PaginationResult<CityWithProvinceDto>>> GetAllWithProvincePaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<List<CityWithProvinceDto>>> GetAllByProvinceId(int provinceId, CancellationToken cancellationToken);
        Task<Result<PaginationResult<CityWithProvinceDto>>> GetAllByProvinceIdPaged(int page, int pageSize, int provinceId, CancellationToken cancellationToken);
        Task<Result<CityDto?>> GetById(int id, CancellationToken cancellationToken);
        Task<Result<CityWithProvinceDto?>> GetByIdWithProvince(int id, CancellationToken cancellationToken);
    }
}
