namespace Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs
{
    public class ApplicationUserUpdateDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
