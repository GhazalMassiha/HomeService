using System.ComponentModel.DataAnnotations;
using Core_HomeService.Domain.Core.UserAgg.Enums;

namespace HomeService_EndPoimt.MVC.Models.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفاً نام کاربری را وارد کنید.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "نام کاربری باید بین ۳ تا ۵۰ کاراکتر باشد.")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفاً رمز عبور را وارد کنید.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تأیید رمز عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تأیید آن یکسان نیستند.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "نقش")]
        [Required(ErrorMessage = "لطفاً نقش خود را انتخاب کنید.")]
        public UserRoleEnum Role { get; set; }
    }
}
