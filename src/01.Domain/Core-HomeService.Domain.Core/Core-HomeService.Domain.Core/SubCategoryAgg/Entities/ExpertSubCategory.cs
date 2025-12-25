using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.SubCategoryAgg.Entities
{
    public class ExpertSubCategory
    {
        public int ExpertId { get; set; }
        public Expert? Expert { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
    }
}
