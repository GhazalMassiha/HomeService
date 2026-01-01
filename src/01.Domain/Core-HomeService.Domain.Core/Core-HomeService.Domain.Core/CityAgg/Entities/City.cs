using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.CityAgg.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        public Province? Province { get; set; }
        public List<ApplicationUser>? Users { get; set; }
    }
}
