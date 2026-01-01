using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;

namespace Core_HomeService.Domain.Core.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public List<Speciality>? Specialities { get; set; }

    }
}
