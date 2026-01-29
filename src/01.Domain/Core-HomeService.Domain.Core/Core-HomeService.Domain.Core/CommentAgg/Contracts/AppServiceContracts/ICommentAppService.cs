using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CommentAgg.DTOs;

namespace Core_HomeService.Domain.Core.CommentAgg.Contracts.AppServiceContracts
{
    public interface ICommentAppService
    {
        Task<Result<bool>> Create(CommentCreateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Update(int id, CommentUpdateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> UpdateStatus(int id, CommentStatusUpdateDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Delete(int id, CancellationToken cancellationToken);
        Task<Result<PaginationResult<CommentDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<PaginationResult<CommentDto>>> GetAllApprovedPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<Result<CommentDto?>> GetById(int id, CancellationToken cancellationToken);
    }
}
