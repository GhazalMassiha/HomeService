using Core_HomeService.Domain.Core.SpecialityAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{

    public class ExpertSpecialityConfiguration : IEntityTypeConfiguration<ExpertSpeciality>
    {
        public void Configure(EntityTypeBuilder<ExpertSpeciality> builder)
        {
            builder.HasKey(x => new { x.ExpertId, x.SpecialityId });

            builder.HasOne(x => x.Expert)
                   .WithMany(e => e.ExpertSpecialities)
                   .HasForeignKey(x => x.ExpertId)
                   .IsRequired(false);

            builder.HasOne(x => x.Speciality)
                   .WithMany(sc => sc.ExpertSpecialities)
                   .HasForeignKey(x => x.SpecialityId)
                   .IsRequired(false);
        }
    }
}
