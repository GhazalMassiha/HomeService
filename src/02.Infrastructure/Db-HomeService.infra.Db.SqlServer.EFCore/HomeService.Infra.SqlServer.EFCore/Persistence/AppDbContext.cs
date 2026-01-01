using Core_HomeService.Domain.Core.CategoryAgg.Entities;
using Core_HomeService.Domain.Core.CityAgg.Entities;
using Core_HomeService.Domain.Core.CommentAgg.Entities;
using Core_HomeService.Domain.Core.ImageAgg.Entities;
using Core_HomeService.Domain.Core.OfferAgg.Entities;
using Core_HomeService.Domain.Core.ProvinceAgg.Entities;
using Core_HomeService.Domain.Core.RequestAgg.Entities;
using Core_HomeService.Domain.Core.SubCategoryAgg.Entities;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using HomeService.Infra.SqlServer.EFCore.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Core_HomeService.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<ExpertSpeciality> ExpertSpecialities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RequestImage> RequestImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<City>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Province>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Speciality>().HasQueryFilter(sc => !sc.IsDeleted);
            modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Request>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<Offer>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<RequestImage>().HasQueryFilter(i => !i.IsDeleted);
            modelBuilder.Entity<Customer>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Expert>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ExpertSpeciality>().HasQueryFilter(es => es.ExpertId == null || !es.Speciality.IsDeleted);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
