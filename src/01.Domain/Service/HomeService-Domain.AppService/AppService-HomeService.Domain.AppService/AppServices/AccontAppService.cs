using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Enums;
using Core_HomeService.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class AccountAppService(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IAccountAppService
    {
        public async Task<Result<bool>> Register(RegisterDto dto)
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
                IsProfileCompleted = false
            };

            var createResult = await userManager.CreateAsync(user, dto.Password);
            if (!createResult.Succeeded)
                return Result<bool>.Failure(createResult.Errors.First().Description);

            string roleName;

            switch (dto.Role)
            {
                case UserRoleEnum.Customer:
                    roleName = "Customer";

                    await context.Customers.AddAsync(new Customer
                    {
                        UserId = user.Id
                    });
                    break;

                case UserRoleEnum.Expert:
                    roleName = "Expert";

                    await context.Experts.AddAsync(new Expert
                    {
                        UserId = user.Id,
                        Rating = 0
                    });
                    break;

                default:
                    await userManager.DeleteAsync(user);
                    return Result<bool>.Failure("نقش انتخاب شده معتبر نیست.");
            }

            await userManager.AddToRoleAsync(user, roleName);
            await context.SaveChangesAsync();

            return Result<bool>.Success("ثبت‌نام انجام شد. لطفاً اطلاعات پروفایل خود را تکمیل کنید.", true);
        }


        public async Task<Result<bool>> Login(LoginDto dto)
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

        public async Task<Result<bool>> ChangePassword(int userId, ChangePasswordDto dto)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return Result<bool>.Failure("کاربر یافت نشد.");

            var result = await userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            if (!result.Succeeded)
                return Result<bool>.Failure(string.Join(" | ", result.Errors.Select(e => e.Description)));

            return Result<bool>.Success("رمز عبور با موفقیت تغییر کرد.", true);
        }

        public async Task<Result<bool>> Logout()
        {
            await signInManager.SignOutAsync();
            return Result<bool>.Success("خروج با موفقیت انجام شد.", true);
        }
    }
}
