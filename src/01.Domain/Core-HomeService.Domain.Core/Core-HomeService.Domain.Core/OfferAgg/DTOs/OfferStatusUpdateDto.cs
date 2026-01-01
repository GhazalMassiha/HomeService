using Core_HomeService.Domain.Core.OfferAgg.Enums;

namespace Core_HomeService.Domain.Core.OfferAgg.DTOs
{
    public class OfferStatusUpdateDto
    {
        public int Id { get; set; }
        public OfferStatusEnum Status { get; set; }
    }
}
