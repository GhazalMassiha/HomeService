using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class AccountAppService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IAccountAppService
    {
        public async Task<Result<bool>> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
                return Result<bool>.Failure("نام کاربری نمیتواند خالی باشد");

            if (dto.UserName.Length < 3)
                return Result<bool>.Failure("نام کاربری نمیتواند کمتر از 3 کاراکتر باشد");

            if (string.IsNullOrWhiteSpace(dto.Password))
                return Result<bool>.Failure("رمز عبور نمیتواند خالی باشد");

            if (dto.Password.Length < 6)
                return Result<bool>.Failure("رمز عبور نمیتواند کمتر از 6 کاراکتر باشد");

            var exists = await userManager.FindByNameAsync(dto.UserName);
            if (exists != null)
                return Result<bool>.Failure("این نام کاربری قبلاً ثبت شده است.");

            var user = new ApplicationUser
            {
                UserName = dto.UserName,
            };

            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return Result<bool>.Failure(result.Errors.First().Description);

            return Result<bool>.Success("کاربر با موفقیت ثبت شد.", true);
        }

        public async Task<Result<bool>> Login(LoginDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.UserName))
                return Result<bool>.Failure("نام کاربری نمیتواند خالی باشد");

            if (dto.UserName.Length < 3)
                return Result<bool>.Failure("نام کاربری نمیتواند کمتر از 3 کاراکتر باشد");

            if (string.IsNullOrWhiteSpace(dto.Password))
                return Result<bool>.Failure("رمز عبور نمیتواند خالی باشد");

            if (dto.Password.Length < 6)
                return Result<bool>.Failure("رمز عبور نمیتواند کمتر از 6 کاراکتر باشد");

            var result = await signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if (!result.Succeeded)
                return Result<bool>.Failure("نام کاربری یا رمز عبور اشتباه است.");

            return Result<bool>.Success("ورود با موفقیت انجام شد.", true);
        }

        public async Task<Result<bool>> ChangePassword(int userId, ChangePasswordDto dto, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result<bool>.Failure("کاربر یافت نشد.");

            var result = await userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            if (!result.Succeeded)
                return Result<bool>.Failure(string.Join(" | ", result.Errors.Select(e => e.Description)));

            return Result<bool>.Success("رمز عبور با موفقیت تغییر کرد.", true);
        }
    }
}
