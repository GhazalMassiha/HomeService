using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.Entities;
using Core_HomeService.Domain.Core.OfferAgg.Entities;
using Core_HomeService.Domain.Core.SpecialityAgg.Entities;

namespace Core_HomeService.Domain.Core.UserAgg.Entities
{
    public class Expert : BaseEntity
    {
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public string Biography { get; set; }
        public double Rating { get; set; } = 0;

        public ApplicationUser? User { get; set; }
        public List<Offer>? Offers { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<ExpertSpeciality> ExpertSpecialities { get; set; }
    }
}
