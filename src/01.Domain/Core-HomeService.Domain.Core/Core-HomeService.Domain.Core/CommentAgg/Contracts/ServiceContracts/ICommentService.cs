using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.DTOs;

namespace Core_HomeService.Domain.Core.CommentAgg.Contracts.ServiceContracts
{
    public interface ICommentService
    {
        Task<CommentDto?> GetById(int id, CancellationToken cancellationToken);
        Task<PaginationResult<CommentDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<PaginationResult<CommentDto>> GetAllApprovedPaged(int page, int pageSize, CancellationToken cancellationToken);
        Task<bool> Create(CommentCreateDto dto, CancellationToken cancellationToken);
        Task<bool> Update(int id, CommentUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> UpdateStatus(int id, CommentStatusUpdateDto dto, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
