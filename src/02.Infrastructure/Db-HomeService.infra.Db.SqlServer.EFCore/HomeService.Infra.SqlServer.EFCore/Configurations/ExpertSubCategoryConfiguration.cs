using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{

    public class ExpertSubCategoryConfiguration : IEntityTypeConfiguration<ExpertSubCategory>
    {
        public void Configure(EntityTypeBuilder<ExpertSubCategory> builder)
        {
            builder.HasKey(x => new { x.ExpertId, x.SubCategoryId });

            builder.HasOne(x => x.Expert)
                   .WithMany(e => e.ExpertSubCategories)
                   .HasForeignKey(x => x.ExpertId);

            builder.HasOne(x => x.SubCategory)
                   .WithMany(sc => sc.ExpertSubCategories)
                   .HasForeignKey(x => x.SubCategoryId);
        }
    }
}
