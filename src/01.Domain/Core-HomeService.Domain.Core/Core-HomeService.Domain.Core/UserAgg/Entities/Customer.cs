using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CommentAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Entities;

namespace Core_HomeService.Domain.Core.UserAgg.Entities
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public string Address { get; set; }

        public ApplicationUser? User { get; set; }
        public List<Request>? Requests { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
