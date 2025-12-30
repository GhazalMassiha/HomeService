using Core_HomeService.Domain.Core.CityAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.ProvinceAgg.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City>? Cities { get; set; }
        public List<ApplicationUser>? Users { get; set; }
        public List<Request>? Requests {  get; set; }
    }
}
