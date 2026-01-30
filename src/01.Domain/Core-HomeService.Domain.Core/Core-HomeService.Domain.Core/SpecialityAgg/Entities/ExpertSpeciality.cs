using Core_HomeService.Domain.Core.UserAgg.Entities;

namespace Core_HomeService.Domain.Core.SpecialityAgg.Entities
{
    public class ExpertSpeciality
    {
        public int ExpertId { get; set; }
        public Expert? Expert { get; set; }

        public int SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }
    }
}
