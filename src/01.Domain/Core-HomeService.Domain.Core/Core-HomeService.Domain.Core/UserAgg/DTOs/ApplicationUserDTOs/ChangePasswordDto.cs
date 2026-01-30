namespace Core_HomeService.Domain.Core.UserAgg.DTOs.ApplicationUserDTOs
{
    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
