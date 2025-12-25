using Core_HomeService.Domain.Core.CategoryAgg.Entities;

namespace Core_HomeService.Domain.Core.SubCategoryAgg.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<ExpertSubCategory>? ExpertSubCategories { get; set; }
    }
}
