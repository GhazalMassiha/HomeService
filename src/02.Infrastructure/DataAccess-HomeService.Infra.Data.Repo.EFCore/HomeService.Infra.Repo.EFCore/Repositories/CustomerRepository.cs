using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.CustomerDTOs;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HomeService.Infra.Repo.EFCore.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public async Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await context.Customers
                .Include(c => c.User)
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Email = c.User.Email,
                    Address = c.Address,
                    CityId = c.User.CityId,
                    ProvinceId = c.User.ProvinceId,
                    AccountBalance = c.User.AccountBalance,
                    ImageUrl = c.User.ImageUrl

                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginationResult<CustomerDto>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = context.Customers
                .Include(c => c.User)
                .AsNoTracking()
                .OrderBy(c => c.Id)
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    FirstName = c.User.FirstName,
                    LastName = c.User.LastName,
                    Email = c.User.Email,
                    Address = c.Address,
                    CityId = c.User.CityId,
                    ProvinceId = c.User.ProvinceId,
                    AccountBalance = c.User.AccountBalance,
                    ImageUrl = c.User.ImageUrl

                });


            return await query.ToPaginatedResult(page, pageSize, cancellationToken);
        }

        public async Task<bool> Update(int id, CustomerUpdateDto dto, CancellationToken cancellationToken)
        {
            var affectedRows = await context.Customers
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(c => c.Address, dto.Address),
                    cancellationToken);

            return affectedRows > 0;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var customer = await context.Customers
                 .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (customer == null)
                return false;

            customer.IsDeleted = true;
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
