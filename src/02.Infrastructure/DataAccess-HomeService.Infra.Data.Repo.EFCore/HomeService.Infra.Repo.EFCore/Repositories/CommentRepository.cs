using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CommentAgg.DTOs;
using Core_HomeService.Domain.Core.CommentAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class CommentRepository(AppDbContext context) : ICommentRepository
    {
        public async Task<CommentDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Comments
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    RequestId = c.RequestId,
                    ExpertId = c.ExpertId,
                    CustomerId = c.CustomerId,
                    Rating = c.Rating,
                    Text = c.Text,
                    IsApproved = c.IsApproved

                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginationResult<CommentDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Comments
                .AsNoTracking()
                .OrderByDescending(c => c.Id)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    RequestId = c.RequestId,
                    ExpertId = c.ExpertId,
                    CustomerId = c.CustomerId,
                    Rating = c.Rating,
                    Text = c.Text,
                    IsApproved = c.IsApproved

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<PaginationResult<CommentDto>> GetAllApprovedPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Comments
                .AsNoTracking()
                .OrderByDescending(c => c.Id)
                .Where(c => c.IsApproved == true)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    RequestId = c.RequestId,
                    ExpertId = c.ExpertId,
                    CustomerId = c.CustomerId,
                    Rating = c.Rating,
                    Text = c.Text,
                    IsApproved = c.IsApproved

                });

            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Create(CommentCreateDto dto, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                RequestId = dto.RequestId,
                ExpertId = dto.ExpertId,
                CustomerId = dto.CustomerId,
                Rating = dto.Rating,
                Text = dto.Text,
                IsApproved = dto.IsApproved
            };

            await context.Comments.AddAsync(comment, cancellationToken);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> Update(int id, CommentUpdateDto dto, CancellationToken cancellationToken)
        {
            var affected = await context.Comments
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(c => c.Rating, dto.Rating)
                    .SetProperty(c => c.Text, dto.Text),
                    cancellationToken);

            return affected > 0;
        }

        public async Task<bool> UpdateStatus(int id, CommentStatusUpdateDto dto, CancellationToken cancellationToken)
        {
            var affected = await context.Comments
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(c => c.IsApproved, dto.IsApproved),
                    cancellationToken);

            return affected > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Comments
                 .Where(c => c.Id == id)
                 .ExecuteUpdateAsync(setter => setter
                 .SetProperty(c => c.IsDeleted, true),
                     cancellationToken);

            return affectedRows > 0;
        }
    }
}
