namespace Core_HomeService.Domain.Core._common
{
    public class PaginationResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int Page {  get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
