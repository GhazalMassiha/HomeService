namespace Core_HomeService.Domain.Core.CommentAgg.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; } 
        public int RequestId { get; set; }
        public int ExpertId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public bool IsApproved { get; set; }
    }
}
