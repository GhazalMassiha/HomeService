using System.ComponentModel.DataAnnotations;

namespace Core_HomeService.Domain.Core.UserAgg.Enums
{
    public enum UserRoleEnum
    {
        [Display(Name = "مشتری")]
        Customer = 2,

        [Display(Name = "کارشناس")]
        Expert = 3
    }
}
