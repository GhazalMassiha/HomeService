using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class RequestAppService(IRequestService requestService) : IRequestAppService
    {
        public async Task<Result<bool>> Create(RequestCreateDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return Result<bool>.Failure("عنوان درخواست الزامی است.");

            var ok = await requestService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("ثبت درخواست ناموفق بود.");

            return Result<bool>.Success("درخواست ثبت شد.", true);
        }

        public async Task<Result<bool>> Update(int id, RequestUpdateDto dto, CancellationToken cancellationToken)
        {
            var request = await requestService.GetById(id, cancellationToken);
            if (request == null)
                return Result<bool>.Failure("درخواست یافت نشد.");

            var ok = await requestService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("بروزرسانی درخواست ناموفق بود.");

            return Result<bool>.Success("درخواست بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> UpdateStatus(int id, RequestStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var ok = await requestService.UpdateStatus(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("تغییر وضعیت درخواست ناموفق بود.");

            return Result<bool>.Success("وضعیت درخواست تغییر کرد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await requestService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("حذف درخواست ناموفق بود.");

            return Result<bool>.Success("درخواست حذف شد.", true);
        }

        public async Task<Result<PaginationResult<RequestDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await requestService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<RequestDto>>.Success("درخواست‌ها دریافت شدند.", result);
        }

        public async Task<Result<RequestDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var request = await requestService.GetById(id, cancellationToken);
            if (request == null)
                return Result<RequestDto?>.Failure("درخواست یافت نشد.");

            return Result<RequestDto?>.Success("درخواست دریافت شد.", request);
        }
    }
}
