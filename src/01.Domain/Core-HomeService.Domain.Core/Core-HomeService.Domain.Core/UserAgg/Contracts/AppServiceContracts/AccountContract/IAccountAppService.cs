using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract
{
    public interface IAccountAppService
    {
        Task<Result<bool>> Register(RegisterDto dto, CancellationToken cancellationToken);
        Task<Result<bool>> Login(LoginDto dto, CancellationToken cancellationToken);
    }
}
