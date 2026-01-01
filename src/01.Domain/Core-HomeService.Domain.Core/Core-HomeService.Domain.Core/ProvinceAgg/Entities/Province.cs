using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CityAgg.Entities;

namespace Core_HomeService.Domain.Core.ProvinceAgg.Entities
{
    public class Province : BaseEntity
    {
        public string Name { get; set; }

        public List<City>? Cities { get; set; }
    }
}
