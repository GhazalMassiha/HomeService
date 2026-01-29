using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CommentAgg.DTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class CommentAppService(ICommentService commentService) : ICommentAppService
    {
        public async Task<Result<bool>> Create(CommentCreateDto dto, CancellationToken cancellationToken)
        {
            if (dto.Rating < 1 || dto.Rating > 5)
                return Result<bool>.Failure("امتیاز باید بین 1 تا 5 باشد.");

            if (string.IsNullOrWhiteSpace(dto.Text))
                return Result<bool>.Failure("متن نظر الزامی است.");

            var ok = await commentService.Create(dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("ثبت نظر ناموفق بود.");

            return Result<bool>.Success("نظر با موفقیت ثبت شد.", true);
        }

        public async Task<Result<bool>> Update(int id, CommentUpdateDto dto, CancellationToken cancellationToken)
        {
            var comment = await commentService.GetById(id, cancellationToken);
            if (comment == null)
                return Result<bool>.Failure("نظر یافت نشد.");

            var ok = await commentService.Update(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("بروزرسانی نظر ناموفق بود.");

            return Result<bool>.Success("نظر بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> UpdateStatus(int id, CommentStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var ok = await commentService.UpdateStatus(id, dto, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("تغییر وضعیت نظر ناموفق بود.");

            return Result<bool>.Success("وضعیت نظر تغییر کرد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await commentService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("حذف نظر ناموفق بود.");

            return Result<bool>.Success("نظر حذف شد.", true);
        }

        public async Task<Result<PaginationResult<CommentDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await commentService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<CommentDto>>.Success("نظرات دریافت شدند.", result);
        }

        public async Task<Result<PaginationResult<CommentDto>>> GetAllApprovedPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await commentService.GetAllApprovedPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<CommentDto>>.Success("نظرات تأیید شده دریافت شدند.", result);
        }

        public async Task<Result<CommentDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await commentService.GetById(id, cancellationToken);
            if (result == null)
                return Result<CommentDto?>.Failure("نظر یافت نشد.");

            return Result<CommentDto?>.Success("نظر دریافت شد.", result);
        }
    }
}
