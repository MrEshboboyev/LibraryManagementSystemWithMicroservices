using LibraryMS.Web.Services.IServices;
using LibraryMS.Web.Services;
using LibraryMS.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// add HttpClient, HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

// service lifetime added
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

// URLs initialized
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.CatalogAPIBase = builder.Configuration["ServiceUrls:CatalogAPI"];
SD.LoanAPIBase = builder.Configuration["ServiceUrls:LoanAPI"];
SD.MembershipAPIBase = builder.Configuration["ServiceUrls:MembershipAPI"];

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
