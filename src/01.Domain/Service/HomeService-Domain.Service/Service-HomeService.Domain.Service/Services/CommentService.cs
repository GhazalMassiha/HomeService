using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CommentAgg.DTOs;

namespace Service_HomeService.Domain.Service.Services
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        public async Task<bool> Create(CommentCreateDto dto, CancellationToken cancellationToken)
        {
            return await commentRepository.Create(dto, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await commentRepository.Delete(id, cancellationToken);
        }

        public async Task<PaginationResult<CommentDto>> GetAllApprovedPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await commentRepository.GetAllApprovedPaged(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<CommentDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await commentRepository.GetAllPaged(page, pageSize, cancellationToken);
        }

        public async Task<CommentDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await commentRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(int id, CommentUpdateDto dto, CancellationToken cancellationToken)
        {
            return await commentRepository.Update(id, dto, cancellationToken);
        }

        public async Task<bool> UpdateStatus(int id, CommentStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            return await commentRepository.UpdateStatus(id, dto, cancellationToken);
        }
    }
}
