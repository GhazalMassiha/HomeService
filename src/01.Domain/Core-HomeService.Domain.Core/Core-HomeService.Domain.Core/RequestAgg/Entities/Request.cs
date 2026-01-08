using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.CityAgg.Entities;
using Core_HomeService.Domain.Core.CommentAgg.Entities;
using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Core_HomeService.Domain.Core.OfferAgg.Entities;
using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Enums;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.RequestAgg.Entities
{
    public class Request : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatusEnum Status { get; set; } = RequestStatusEnum.Pending;
        public DateTime? ScheduledAt { get; set; }
        public int CategoryId { get; set; }
        public int SpecialityId { get; set; }

        public Customer? Customer { get; set; }
        public Province? Province { get; set; }
        public City? City { get; set; }
        public Category? Category { get; set; }
        public Speciality? Speciality { get; set; }
        public List<Offer>? Offers { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<RequestImage>? Images { get; set; }
    }
}
