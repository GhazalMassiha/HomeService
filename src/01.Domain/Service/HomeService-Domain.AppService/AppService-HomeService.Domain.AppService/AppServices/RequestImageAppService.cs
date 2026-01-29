using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestImageAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class RequestImageAppService(IRequestImageService requestImageService): IRequestImageAppService
    {
        public async Task<Result<bool>> Create(RequestImageCreateDto dto, CancellationToken cancellationToken)
        {
            var ok = await requestImageService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("ثبت تصویر ناموفق بود.");

            return Result<bool>.Success("تصویر ثبت شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await requestImageService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("حذف تصویر ناموفق بود.");

            return Result<bool>.Success("تصویر حذف شد.", true);
        }

        public async Task<Result<List<RequestImageDto>>> GetByRequestId(int requestId, CancellationToken cancellationToken)
        {
            var result = await requestImageService.GetByRequestId(requestId, cancellationToken);
            return Result<List<RequestImageDto>>.Success("تصاویر دریافت شدند.", result);
        }
    }
}
