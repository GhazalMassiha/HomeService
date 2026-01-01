using Core_HomeService.Domain.Core.RequestAgg.Enums;

namespace Core_HomeService.Domain.Core.RequestAgg.DTOs
{
    public class RequestCreateDto
    {
        public int CustomerId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;
        public DateTime CreatedAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
    }
}
