using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasMany(p => p.Cities)
                   .WithOne(c => c.Province)
                   .HasForeignKey(c => c.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new Province { Id = 1, Name = "تهران" },

                    new Province { Id = 2, Name = "اصفهان" },

                    new Province { Id = 3, Name = "خراسان رضوی" },

                    new Province { Id = 4, Name = "فارس" },

                    new Province { Id = 5, Name = "خوزستان" },

                    new Province { Id = 6, Name = "مازندران" },

                    new Province { Id = 7, Name = "گیلان" },

                    new Province { Id = 8, Name = "گلستان" },

                    new Province { Id = 9, Name = "آذربایجان شرقی" },

                    new Province { Id = 10, Name = "کردستان" },

                    new Province { Id = 11, Name = "کرمان" },

                    new Province { Id = 12, Name = "یزد" }
           ); 
        }
    }
}
