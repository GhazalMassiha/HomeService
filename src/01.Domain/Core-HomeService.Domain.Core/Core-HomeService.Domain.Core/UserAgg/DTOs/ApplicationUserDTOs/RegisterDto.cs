using Core_HomeService.Domain.Core.UserAgg.Enums;

namespace Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
