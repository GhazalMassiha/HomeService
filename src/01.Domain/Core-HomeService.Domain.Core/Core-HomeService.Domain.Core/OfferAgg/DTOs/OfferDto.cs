using Core_HomeService.Domain.Core.OfferAgg.Enums;

namespace Core_HomeService.Domain.Core.OfferAgg.DTOs
{
    public class OfferDto
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
        public OfferStatusEnum Status { get; set; }
    }
}
