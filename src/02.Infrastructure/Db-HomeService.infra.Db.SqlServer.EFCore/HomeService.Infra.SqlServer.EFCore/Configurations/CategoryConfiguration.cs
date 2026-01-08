using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeService.Infra.SqlServer.EFCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.ImageUrl)
                   .HasMaxLength(500);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(r => r.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAdd();

            builder.HasMany(c => c.Specialities)
                   .WithOne(sc => sc.Category)
                   .HasForeignKey(sc => sc.CategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Requests)
                   .WithOne(sc => sc.Category)
                   .HasForeignKey(sc => sc.CategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(
               new Category { Id = 1, Name = "دکوراسیون ساختمان" },

               new Category { Id = 2, Name = "تاسیسات ساختمان" },

               new Category { Id = 3, Name = "وسایل نقلیه" },

               new Category { Id = 4, Name = "اسباب کشی و باربری" },

               new Category { Id = 5, Name = "لوازم خانگی" },

               new Category { Id = 6, Name = "خدمات اداری" },

               new Category { Id = 7, Name = "نظافت و بهداشت" },

               new Category { Id = 8, Name = "دیجیتال و نرم افزار" },

               new Category { Id = 9, Name = "پزشکی و سلامت" }
               );
        }
    }
}
