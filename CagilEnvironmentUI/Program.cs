using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var services = builder.Services;
services.AddTransient<IServiceService, ServiceManager>();
services.AddTransient<IServiceDal, EfServiceDal>();
services.AddTransient<ITeamService, TeamManager>();
services.AddTransient<ITeamDal, EfTeamDal>();
services.AddTransient<INewsService, NewsManager>();
services.AddTransient<INewsDal, EfNewsDal>();
services.AddTransient<IImageService, ImageManager>();
services.AddTransient<IImageDal, EfImageDal>();
services.AddTransient<IAddressService, AddressManager>();
services.AddTransient<IAddressDal, EfAddressDal>();
services.AddTransient<IContactService, ContactManager>();
services.AddTransient<IContactDal, EfContactDal>();
services.AddTransient<ISocialMediaService, SocialMediaManager>();
services.AddTransient<ISocialMediaDal, EfSocialMediaDal>();
services.AddTransient<IAboutService, AboutManager>();
services.AddTransient<IAboutDal, EfAboutDal>();
services.AddTransient<IAdminService, AdminManager>();
services.AddTransient<IAdminDal, EfAdminDal>();

services.AddDbContext<CagilEnvironmentContext>();

services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CagilEnvironmentContext>();

services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

services.AddMvc();
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index/";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
