using Core_HomeService.Domain.Core.CommentAgg.Entities;
using Core_HomeService.Domain.Core.OfferAgg.Entities;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;

namespace Core_HomeService.Domain.Core.UserAgg.Entities
{
    public class Expert
    {
        public int Id { get; set; }
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
