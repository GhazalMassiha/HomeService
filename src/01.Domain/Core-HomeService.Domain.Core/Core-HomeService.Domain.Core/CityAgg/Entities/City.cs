using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.CityAgg.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        public Province? Province { get; set; }
        public List<ApplicationUser>? Users { get; set; }
        public List<Request>? Requests { get; set; }
    }
}
