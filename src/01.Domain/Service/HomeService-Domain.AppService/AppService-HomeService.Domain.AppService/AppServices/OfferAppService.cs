using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.OfferAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class OfferAppService(IOfferService offerService) : IOfferAppService
    {
        public async Task<Result<bool>> Create(OfferCreateDto dto, CancellationToken cancellationToken)
        {
            if (dto.Price <= 0)
                return Result<bool>.Failure("مبلغ پیشنهاد باید بیشتر از صفر باشد.");

            var ok = await offerService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("ثبت پیشنهاد ناموفق بود.");

            return Result<bool>.Success("پیشنهاد ثبت شد.", true);
        }

        public async Task<Result<bool>> Update(int id, OfferUpdateDto dto, CancellationToken cancellationToken)
        {
            var offer = await offerService.GetById(id, cancellationToken);
            if (offer == null)
                return Result<bool>.Failure("پیشنهاد یافت نشد.");

            var ok = await offerService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("بروزرسانی پیشنهاد ناموفق بود.");

            return Result<bool>.Success("پیشنهاد بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> UpdateStatus(int id, OfferStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var ok = await offerService.UpdateStatus(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("تغییر وضعیت پیشنهاد ناموفق بود.");

            return Result<bool>.Success("وضعیت پیشنهاد تغییر کرد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await offerService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("حذف پیشنهاد ناموفق بود.");

            return Result<bool>.Success("پیشنهاد حذف شد.", true);
        }

        public async Task<Result<PaginationResult<OfferDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await offerService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<OfferDto>>.Success("پیشنهادها دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<OfferDto>>> GetByExpertIdPaged(int page, int pageSize, int expertId, CancellationToken cancellationToken)
        {
            var result = await offerService.GetByExpertIdPaged(page, pageSize, expertId, cancellationToken);
            return Result<PaginationResult<OfferDto>>.Success("پیشنهادها دریافت شدند.", result);
        }

        public async Task<Result<OfferDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var offer = await offerService.GetById(id, cancellationToken);
            if (offer == null)
                return Result<OfferDto?>.Failure("پیشنهاد یافت نشد.");

            return Result<OfferDto?>.Success("پیشنهاد دریافت شد.", offer);
        }
    }
}
