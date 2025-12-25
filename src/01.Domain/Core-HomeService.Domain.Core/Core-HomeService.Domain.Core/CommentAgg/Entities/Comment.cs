using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.CommentAgg.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public Expert? Expert { get; set; }
        public Customer? Customer { get; set; }
        public Request? Request { get; set; }
    }
}
