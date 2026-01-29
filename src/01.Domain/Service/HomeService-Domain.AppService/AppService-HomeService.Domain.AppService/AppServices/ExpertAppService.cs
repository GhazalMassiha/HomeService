using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ExpertDTOs;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class ExpertAppService(IExpertService expertService, IApplicationUserService applicationUserService) : IExpertAppService
    {
        public async Task<Result<ExpertDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var expert = await expertService.GetById(id, cancellationToken);
            if (expert == null)
                return Result<ExpertDto?>.Failure("متخصص یافت نشد.");

            return Result<ExpertDto?>.Success("متخصص دریافت شد.", expert);
        }

        public async Task<Result<PaginationResult<ExpertDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await expertService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<ExpertDto>>.Success("لیست متخصصان دریافت شد.", result);
        }

        public async Task<Result<bool>> Update(int id, ExpertUpdateDto expertDto, ApplicationUserUpdateDto userDto, CancellationToken cancellationToken)
        {
            var expertUpdated = await expertService.Update(id, expertDto, cancellationToken);
            if (!expertUpdated)
                return Result<bool>.Failure("بروزرسانی اطلاعات متخصص ناموفق بود.");

            var userUpdated = await applicationUserService.Update(id, userDto, cancellationToken);
            if (!userUpdated)
                return Result<bool>.Failure("بروزرسانی اطلاعات کاربری ناموفق بود.");

            return Result<bool>.Success("اطلاعات متخصص بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await expertService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("حذف متخصص ناموفق بود.");

            return Result<bool>.Success("متخصص حذف شد.", true);
        }
    }
}
