using Core_HomeService.Domain.Core.CityAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasOne(c => c.Province)
                   .WithMany(p => p.Cities)
                   .HasForeignKey(c => c.ProvinceId);

            builder.HasMany(c => c.Users)
                   .WithOne(u => u.City)
                   .HasForeignKey(u => u.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new City { Id = 1, Name = "تهران", ProvinceId = 1 },
                    new City { Id = 2, Name = "اسلامشهر", ProvinceId = 1 },
                    new City { Id = 3, Name = "ری", ProvinceId = 1 },

                    new City { Id = 4, Name = "اصفهان", ProvinceId = 2 },
                    new City { Id = 5, Name = "کاشان", ProvinceId = 2 },
                    new City { Id = 6, Name = "نجف‌آباد", ProvinceId = 2 },

                    new City { Id = 7, Name = "مشهد", ProvinceId = 3 },
                    new City { Id = 8, Name = "نیشابور", ProvinceId = 3 },
                    new City { Id = 9, Name = "سبزوار", ProvinceId = 3 },

                    new City { Id = 10, Name = "شیراز", ProvinceId = 4 },
                    new City { Id = 11, Name = "مرودشت", ProvinceId = 4 },
                    new City { Id = 12, Name = "جهرم", ProvinceId = 4 },

                    new City { Id = 13, Name = "اهواز", ProvinceId = 5 },
                    new City { Id = 14, Name = "آبادان", ProvinceId = 5 },
                    new City { Id = 15, Name = "دزفول", ProvinceId = 5 },

                    new City { Id = 16, Name = "ساری", ProvinceId = 6 },
                    new City { Id = 17, Name = "بابل", ProvinceId = 6 },
                    new City { Id = 18, Name = "آمل", ProvinceId = 6 },

                    new City { Id = 19, Name = "رشت", ProvinceId = 7 },
                    new City { Id = 20, Name = "انزلی", ProvinceId = 7 },
                    new City { Id = 21, Name = "لاهیجان", ProvinceId = 7 },

                    new City { Id = 22, Name = "گرگان", ProvinceId = 8 },
                    new City { Id = 23, Name = "گنبد کاووس", ProvinceId = 8 },
                    new City { Id = 24, Name = "آق‌قلا", ProvinceId = 8 },

                    new City { Id = 25, Name = "تبریز", ProvinceId = 9 },
                    new City { Id = 26, Name = "مراغه", ProvinceId = 9 },
                    new City { Id = 27, Name = "میانه", ProvinceId = 9 },

                    new City { Id = 28, Name = "سنندج", ProvinceId = 10 },
                    new City { Id = 29, Name = "قروه", ProvinceId = 10 },
                    new City { Id = 30, Name = "بانه", ProvinceId = 10 },

                    new City { Id = 31, Name = "کرمان", ProvinceId = 11 },
                    new City { Id = 32, Name = "سیرجان", ProvinceId = 11 },
                    new City { Id = 33, Name = "بم", ProvinceId = 11 },

                    new City { Id = 34, Name = "یزد", ProvinceId = 12 },
                    new City { Id = 35, Name = "میبد", ProvinceId = 12 },
                    new City { Id = 36, Name = "اردکان", ProvinceId = 12 }
                );
        }
    }
}
