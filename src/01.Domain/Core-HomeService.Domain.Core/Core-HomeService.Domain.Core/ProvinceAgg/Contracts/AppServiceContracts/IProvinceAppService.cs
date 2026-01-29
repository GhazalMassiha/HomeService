using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.DTOs;

namespace Core_HomeService.Domain.Core.ProvinceAgg.Contracts.AppServiceContracts
{
    public interface IProvinceAppService
    {
        Task<Result<bool>> Create(ProvinceCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, ProvinceDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<List<ProvinceDto>>> GetAll(CancellationToken cancellationToken);
        Task<Result<PaginationResult<ProvinceDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<ProvinceDto?>> GetById(int id, CancellationToken cancellationToken);
    }
}
