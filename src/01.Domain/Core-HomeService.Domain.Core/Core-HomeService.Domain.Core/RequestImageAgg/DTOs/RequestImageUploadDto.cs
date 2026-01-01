using Microsoft.AspNetCore.Http;

namespace Core_HomeService.Domain.Core.ImageAgg.DTOs
{
    public class RequestImageUploadDto
    {
        public int RequestId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
