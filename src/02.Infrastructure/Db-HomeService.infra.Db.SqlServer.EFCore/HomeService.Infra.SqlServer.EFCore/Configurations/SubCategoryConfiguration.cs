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

            builder.Property(sc => sc.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(o => o.BasePrice)
                   .HasPrecision(18, 2)
                   .IsRequired();


            builder.HasData(
            new SubCategory { Id = 1, Name = "بنایی", CategoryId = 1, Description = "انجام عملیات بنایی و ساخت دیوار، آجرکاری و تسطیح سطوح", BasePrice = 500000 },
            new SubCategory { Id = 2, Name = "دکوراسیون", CategoryId = 1, Description = "طراحی و اجرای دکوراسیون داخلی، نصب دیوارپوش و عناصر تزئینی", BasePrice = 700000 },
            new SubCategory { Id = 3, Name = "نقاشی ساختمان", CategoryId = 1, Description = "رنگ‌آمیزی سطوح داخلی و خارجی با رنگ‌های باکیفیت", BasePrice = 400000 },
            new SubCategory { Id = 4, Name = "درب و پنجره", CategoryId = 1, Description = "نصب و تعمیر انواع درب و پنجره با دقت و آب‌بندی مناسب", BasePrice = 600000 },
            new SubCategory { Id = 5, Name = "آهنگری و جوشکاری", CategoryId = 1, Description = "انجام کارهای فلزی، جوشکاری و ساخت نرده و حفاظ", BasePrice = 800000 },
            new SubCategory { Id = 6, Name = "باغبانی", CategoryId = 1, Description = "طراحی و نگهداری فضای سبز و چمن‌کاری", BasePrice = 300000 },

            new SubCategory { Id = 7, Name = "سرمایش و گرمایش", CategoryId = 2, Description = "نصب و سرویس سیستم‌های کولر و بخاری", BasePrice = 900000 },
            new SubCategory { Id = 8, Name = "لوله کشی", CategoryId = 2, Description = "نصب و تعمیر لوله‌های آب و فاضلاب", BasePrice = 650000 },
            new SubCategory { Id = 9, Name = "برق و الکترونیک", CategoryId = 2, Description = "خدمات برق‌کشی و نصب تجهیزات الکتریکی", BasePrice = 550000 },
            new SubCategory { Id = 10, Name = "تلفن و سانترال", CategoryId = 2, Description = "نصب و راه‌اندازی سیستم‌های تلفن و سانترال", BasePrice = 750000 },

            new SubCategory { Id = 11, Name = "خودرو", CategoryId = 3, Description = "تعمیر و سرویس خودروهای سبک و سنگین", BasePrice = 1000000 },

            new SubCategory { Id = 12, Name = "اسباب کشی", CategoryId = 4, Description = "حمل ایمن اسباب و بسته‌بندی وسایل", BasePrice = 1200000 },
            new SubCategory { Id = 13, Name = "حمل بار", CategoryId = 4, Description = "حمل بار شهری با تجهیزات مناسب", BasePrice = 800000 },

            new SubCategory { Id = 14, Name = "لوازم آشپزخانه", CategoryId = 5, Description = "نصب و تعمیر لوازم آشپزخانه", BasePrice = 600000 },
            new SubCategory { Id = 15, Name = "لوازم شست و شو و نظافت", CategoryId = 5, Description = "تعمیر تجهیزات شستشو و نظافتی", BasePrice = 550000 },
            new SubCategory { Id = 16, Name = "لوازم صوتی و تصویری", CategoryId = 5, Description = "نصب و تعمیر سیستم‌های صوتی و تصویری", BasePrice = 650000 },

            new SubCategory { Id = 17, Name = "ماشین اداری", CategoryId = 6, Description = "خدمات تعمیر و نگهداری ماشین‌های اداری", BasePrice = 700000 },
            new SubCategory { Id = 18, Name = "مبلمان اداری", CategoryId = 6, Description = "نصب و تعمیر مبلمان و تجهیزات اداری", BasePrice = 900000 },

            new SubCategory { Id = 19, Name = "نظافت", CategoryId = 7, Description = "نظافت حرفه‌ای منزل و محل کار", BasePrice = 400000 },
            new SubCategory { Id = 20, Name = "خشکشویی و قالیشویی", CategoryId = 7, Description = "شستشوی حرفه‌ای فرش و مبلمان", BasePrice = 500000 },
            new SubCategory { Id = 21, Name = "قالیشویی و مبل شویی", CategoryId = 7, Description = "شستشو و پاکسازی فرش و مبل تهیه‌شده", BasePrice = 600000 },
            new SubCategory { Id = 22, Name = "سمپاشی", CategoryId = 7, Description = "سمپاشی حرفه‌ای برای دفع آفات", BasePrice = 450000 },

            new SubCategory { Id = 23, Name = "موبایل و تبلت", CategoryId = 8, Description = "تعمیر موبایل و تبلت با قطعات استاندارد", BasePrice = 700000 },
            new SubCategory { Id = 24, Name = "خدمات کامپیوتری", CategoryId = 8, Description = "نصب و راه‌اندازی کامپیوتر و شبکه", BasePrice = 650000 },
            new SubCategory { Id = 25, Name = "امنیت و شبکه", CategoryId = 8, Description = "پیاده‌سازی و پشتیبانی شبکه و امنیت", BasePrice = 1200000 },

            new SubCategory { Id = 26, Name = "پزشکی", CategoryId = 9, Description = "خدمات پزشکی اولیه در محل", BasePrice = 1500000 }
        );
        }
    }
}
