using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.ImageAgg.Entities
{
    public class RequestImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int RequestId { get; set; }


        public Request? Request { get; set; }
    }
}
