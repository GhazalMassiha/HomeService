using AppService_HomeService.Domain.AppService.AppServices;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CategoryAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CityAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.CityAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.CommentAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.ImageAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.OfferAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.ProvinceAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.RequestAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.AppServiceContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.ServiceContracts;
using Core_HomeService.Domain.Core.SpecialityAgg.Contracts.RepositoryContracts;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.AccountContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.WalletContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.RepositoryContracts.WalletContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ExpertContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.WalletContract;
using Core_HomeService.Domain.Core.UserAgg.Entities;
using Core_HomeService.Infrastructure.Persistence;
using HomeService.Infra.Repo.EFCore.Repositories;
using HomeService.Infra.SqlServer.EFCore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service_HomeService.Domain.Service.Services;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
);


builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = false;
})
.AddRoles<IdentityRole<int>>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestImageRepository, RequestImageRepository>();
builder.Services.AddScoped<ISpecialityRepository, SpecialityRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();


builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestImageService, RequestImageService>();
builder.Services.AddScoped<ISpecialityService, SpecialityService>();
builder.Services.AddScoped<IWalletService, WalletService>();


builder.Services.AddScoped<IAccountAppService, AccountAppService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICityAppService, CityAppService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<IExpertAppService, ExpertAppService>();
builder.Services.AddScoped<IOfferAppService, OfferAppService>();
builder.Services.AddScoped<IProvinceAppService, ProvinceAppService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestImageAppService, RequestImageAppService>();
builder.Services.AddScoped<ISpecialityAppService, SpecialityAppService>();
builder.Services.AddScoped<IWalletAppService, WalletAppService>();


builder.Services.AddControllersWithViews();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
