using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{

    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasData(
              new SubCategory { Id = 1, Name = "بنایی", CategoryId = 1},

              new SubCategory { Id = 2, Name = "دکوراسیون", CategoryId = 1 },

              new SubCategory { Id = 3, Name = "نقاشی ساختمان", CategoryId = 1 },

              new SubCategory { Id = 4, Name = "درب و پنجره", CategoryId = 1 },

              new SubCategory { Id = 5, Name = "آهنگری و جوشکاری", CategoryId = 1 },

              new SubCategory { Id = 6, Name = "باغبانی", CategoryId = 1 },

              new SubCategory { Id = 7, Name = "سرمایش و گرمایش", CategoryId = 2 },

              new SubCategory { Id = 8, Name = "لوله کشی", CategoryId = 2 },

              new SubCategory { Id = 9, Name = "برق و الکترونیک", CategoryId = 2 },

              new SubCategory { Id = 10, Name = "تلفن و سانترال", CategoryId = 2 },

              new SubCategory { Id = 11, Name = "خودرو", CategoryId = 3 },

              new SubCategory { Id = 12, Name = "اسباب کشی", CategoryId = 4 },

              new SubCategory { Id = 13, Name = "حمل بار", CategoryId = 4 },

              new SubCategory { Id = 14, Name = "لوازم آشپزخانه", CategoryId = 5 },

              new SubCategory { Id = 15, Name = "لوازم شست و شو و نظافت", CategoryId = 5 },

              new SubCategory { Id = 16, Name = "لوازم صوتی و تصویری", CategoryId = 5 },

              new SubCategory { Id = 17, Name = "ماشین اداری", CategoryId = 6 },

              new SubCategory { Id = 18, Name = "مبلمان اداری", CategoryId = 6 },

              new SubCategory { Id = 19, Name = "نظافت", CategoryId = 7 },

              new SubCategory { Id = 20, Name = "خشکشویی و قالیشویی", CategoryId = 7 },

              new SubCategory { Id = 21, Name = "قالیشویی و مبل شویی", CategoryId = 7 },

              new SubCategory { Id = 22, Name = "سمپاشی", CategoryId = 7 },

              new SubCategory { Id = 23, Name = "موبایل و تبلت", CategoryId = 8 },

              new SubCategory { Id = 24, Name = "خدمات کامپیوتری", CategoryId = 8 },

              new SubCategory { Id = 25, Name = "امنیت و شبکه", CategoryId = 8 },

              new SubCategory { Id = 26, Name = "پزشکی", CategoryId = 9 }
              );
        }
    }
}
