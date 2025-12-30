namespace Core_HomeService.Domain.Core.SubCategoryAgg.DTOs
{
    public class SpecialityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int CategoryId { get; set; }
    }
}
