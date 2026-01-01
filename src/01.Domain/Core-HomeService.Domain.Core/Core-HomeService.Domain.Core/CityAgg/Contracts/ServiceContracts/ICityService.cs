using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CityAgg.DTOs;

namespace Core_HomeService.Domain.Core.CityAgg.Contracts.ServiceContracts
{
    public interface ICityService
    {
        Task<CityDto?> GetById(int id, CancellationToken cancellationToken);
        Task<CityWithProvinceDto?> GetByIdWithProvince(int id, CancellationToken cancellationToken);
        Task<List<CityDto>> GetAll(CancellationToken cancellationToken);
        Task<PaginationResult<CityDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<List<CityWithProvinceDto>> GetAllWithProvince(CancellationToken cancellationToken);
        Task<PaginationResult<CityWithProvinceDto>> GetAllWithProvincePaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<List<CityWithProvinceDto>> GetAllByProvinceId(int provinceId, CancellationToken cancellationToken);
        Task<PaginationResult<CityWithProvinceDto>> GetAllByProvinceIdPaged(int page, int pageSize, int provinceId, CancellationToken cancellationToken);
        Task<bool> Create(CityCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Update(int id, CityWithProvinceDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
