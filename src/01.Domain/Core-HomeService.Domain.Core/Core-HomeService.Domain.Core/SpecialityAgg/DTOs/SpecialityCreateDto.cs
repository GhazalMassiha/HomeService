namespace Core_HomeService.Domain.Core.SpecialityAgg.DTOs
{
    public class SpecialityCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int CategoryId { get; set; }
    }
}
