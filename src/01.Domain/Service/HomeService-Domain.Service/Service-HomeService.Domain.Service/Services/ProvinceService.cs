using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class ProvinceService(IProvinceRepository provinceRepository) : IProvinceService
    {
        public async Task<bool> Create(ProvinceCreateDto dto, CancellationToken cancellationToken)
        {
            return await provinceRepository.Create(dto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await provinceRepository.Delete(id, cancellationToken);
        }

        public async Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken)
        {
            return await provinceRepository.GetAll(cancellationToken);
        }

        public async Task<PaginationResult<ProvinceDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await provinceRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<ProvinceDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await provinceRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int id, ProvinceDto dto, CancellationToken cancellationToken)
        {
            return await provinceRepository.Update(id, dto, cancellationToken);
        }
    }
}
