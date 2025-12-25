using Core_HomeService.Domain.Core.CityAgg.Entities;

namespace Core_HomeService.Domain.Core.ProvinceAgg.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City>? Cities { get; set; }
    }
}
