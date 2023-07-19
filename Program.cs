using LibraryMgmt.WebApp.MVC.Helper;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);  
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ApiHttpClient>((serviceProvider, httpClient) =>
{
    var configuration = serviceProvider.GetService<IConfiguration>();
    var baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
    httpClient.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth",options=>
{
    options.Cookie.Name = "MyCookieAuth";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOrLibrarian", policy =>
            policy.RequireRole("Admin", "Librarian"));
    options.AddPolicy("AdminOnly", policy =>
            policy.RequireRole("Admin"));
});

var app = builder.Build();

app.UseStaticFiles();
//app.MapDefaultControllerRoute();
app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");
});

app.Run();
