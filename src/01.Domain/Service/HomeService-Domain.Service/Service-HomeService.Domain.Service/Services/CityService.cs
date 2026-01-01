using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CityAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CityAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class CityService(ICityRepository cityRepository) : ICityService
    {
        public async Task<bool> Create(CityCreateDto dto, CancellationToken cancellationToken)
        {
            return await cityRepository.Create(dto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await cityRepository.Delete(id, cancellationToken);
        }

        public async Task<List<CityDto>> GetAll(CancellationToken cancellationToken)
        {
            return await cityRepository.GetAll(cancellationToken);
        }

        public async Task<List<CityWithProvinceDto>> GetAllByProvinceId(int provinceId, CancellationToken cancellationToken)
        {
            return await cityRepository.GetAllByProvinceId(provinceId, cancellationToken);
        }

        public async Task<PaginationResult<CityWithProvinceDto>> GetAllByProvinceIdPaged(int page, int pageSize, int provinceId, CancellationToken cancellationToken)
        {
            return await cityRepository.GetAllByProvinceIdPaged(page, pageSize, provinceId, cancellationToken);
        }

        public async Task<PaginationResult<CityDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await cityRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<List<CityWithProvinceDto>> GetAllWithProvince(CancellationToken cancellationToken)
        {
            return await cityRepository.GetAllWithProvince(cancellationToken);
        }

        public async Task<PaginationResult<CityWithProvinceDto>> GetAllWithProvincePaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await cityRepository.GetAllWithProvincePaged(page, pageSize, cancellationToken);
        }

        public async Task<CityDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await cityRepository.GetById(id, cancellationToken);
        }

        public async Task<CityWithProvinceDto?> GetByIdWithProvince(int id, CancellationToken cancellationToken)
        {
            return await cityRepository.GetByIdWithProvince(id, cancellationToken);
        }

        public async Task<bool> Update(int id, CityWithProvinceDto dto, CancellationToken cancellationToken)
        {
            return await cityRepository.Update(id, dto, cancellationToken);
        }
    }
}
