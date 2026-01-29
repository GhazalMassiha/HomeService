using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class AccountAppService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
    ) : IAccountAppService
    {
        public async Task<Result<bool>> Register(RegisterDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                return Result<bool>.Failure("نام کاربری نمیتواند خالی باشد");

            if (dto.Username.Length < 3)
                return Result<bool>.Failure("نام کاربری نمیتواند کمتر از 3 کاراکتر باشد");

            if (string.IsNullOrWhiteSpace(dto.Password))
                return Result<bool>.Failure("رمز عبور نمیتواند خالی باشد");

            if (dto.Password.Length < 6)
                return Result<bool>.Failure("رمز عبور نمیتواند کمتر از 6 کاراکتر باشد");

            var exists = await userManager.FindByNameAsync(dto.Username);
            if (exists != null)
                return Result<bool>.Failure("این نام کاربری قبلاً ثبت شده است.");

            var user = new ApplicationUser
            {
                UserName = dto.Username,
            };

            var result = await userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return Result<bool>.Failure(result.Errors.First().Description);

            return Result<bool>.Success("کاربر با موفقیت ثبت شد.", true);
        }

        public async Task<Result<bool>> Login(string username, string password, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(username))
                return Result<bool>.Failure("نام کاربری نمیتواند خالی باشد");

            if (username.Length < 3)
                return Result<bool>.Failure("نام کاربری نمیتواند کمتر از 3 کاراکتر باشد");

            if (string.IsNullOrWhiteSpace(password))
                return Result<bool>.Failure("رمز عبور نمیتواند خالی باشد");

            if (password.Length < 6)
                return Result<bool>.Failure("رمز عبور نمیتواند کمتر از 6 کاراکتر باشد");

            var result = await signInManager.PasswordSignInAsync(
                username,
                password,
                false,
                false);

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
                return Result<bool>.Failure(result.Errors.First().Description);

            return Result<bool>.Success("رمز عبور با موفقیت تغییر کرد.", true);
        }
    }
}
