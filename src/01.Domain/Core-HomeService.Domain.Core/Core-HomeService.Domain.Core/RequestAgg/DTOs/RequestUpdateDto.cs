using Core_HomeService.Domain.Core.RequestAgg.Enums;

namespace Core_HomeService.Domain.Core.RequestAgg.DTOs
{
    public class RequestUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ScheduledAt { get; set; }
    }
}
