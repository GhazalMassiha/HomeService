namespace Core_HomeService.Domain.Core.UserAgg.DTOs.ExpertDTOs
{
    public class ExpertUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string CardNumber { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
