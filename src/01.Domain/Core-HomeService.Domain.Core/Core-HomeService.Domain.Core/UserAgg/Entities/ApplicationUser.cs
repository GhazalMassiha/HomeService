using Core_HomeService.Domain.Core.CityAgg.Entities;
using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core_HomeService.Domain.Core.UserAgg.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public decimal AccountBalance { get; set; }
        public string? ImageUrl { get; set; }

        public City? City { get; set; }
        public Province? Province { get; set; }
        public Customer? Customer { get; set; }
        public Expert? Expert { get; set; }
    }
}
