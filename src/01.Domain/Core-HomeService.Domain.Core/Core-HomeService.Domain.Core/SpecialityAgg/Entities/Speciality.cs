using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Entities;

namespace Core_HomeService.Domain.Core.SubCategoryAgg.Entities
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<ExpertSpeciality>? ExpertSpecialities { get; set; }
        public List<Request>? Requests { get; set; }
    }
}
