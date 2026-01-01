using Core_HomeService.Domain.Core.RequestAgg.Enums;

namespace Core_HomeService.Domain.Core.RequestAgg.DTOs
{
    public class RequestStatusUpdateDto
    {
        public int Id { get; set; }
        public RequestStatusEnum Status { get; set; }
    }
}
