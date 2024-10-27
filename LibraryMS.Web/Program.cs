using LibraryMS.Web.Services.IServices;
using LibraryMS.Web.Services;
using LibraryMS.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// add HttpClient, HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

// service http clients
builder.Services.AddHttpClient<IAuthService, AuthService>();

// service lifetime added
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// URLs initialized
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.CatalogAPIBase = builder.Configuration["ServiceUrls:CatalogAPI"];
SD.LoanAPIBase = builder.Configuration["ServiceUrls:LoanAPI"];
SD.MembershipAPIBase = builder.Configuration["ServiceUrls:MembershipAPI"];

// adding authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    }
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// adding pipeline for authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
