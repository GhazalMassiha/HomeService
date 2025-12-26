using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;

namespace Core_HomeService.Domain.Core.CategoryAgg.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public List<SubCategory>? SubCategories { get; set; }

    }
}
