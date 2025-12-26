using Core_HomeService.Domain.Core.OfferAgg.Enums;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.OfferAgg.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public decimal Price { get; set; }
        public string Text { get; set; }
        public OfferStatusEnum Status { get; set; } = OfferStatusEnum.Pending;
        public DateTime CreatedAt { get; set; }

        public Expert? Expert { get; set; }
        public Request? Request { get; set; }
    }
}
