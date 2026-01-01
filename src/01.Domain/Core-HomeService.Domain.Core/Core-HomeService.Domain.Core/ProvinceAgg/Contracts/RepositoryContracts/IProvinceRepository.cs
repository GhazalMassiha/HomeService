using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.DTOs;

namespace Core_HomeService.Domain.Core.ProvinceAgg.Contracts.RepositoryContracts
{
    public interface IProvinceRepository
    {
        Task<ProvinceDto?> GetById(int id, CancellationToken cancellationToken);
        Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken);
        Task<PaginationResult<ProvinceDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<bool> Create(ProvinceCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Update(int id, ProvinceCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
