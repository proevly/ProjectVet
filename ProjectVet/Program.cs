using Microsoft.EntityFrameworkCore;
using ProjectVet.Areas.Admin.Services;
using ProjectVet.EfCore;
using ProjectVet.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectVet.Areas.Kullanici.Services;
using ProjectVet.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var str = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<KlinikContext>(x => x.UseSqlServer(str));
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Login";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddScoped<AddPetsService>();



// Add RandevuService to DI container
builder.Services.AddScoped<IRandevuService, RandevuService>();
builder.Services.AddScoped<IKullaniciRandevuService, KullaniciRandevuService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<KlinikContext>();
builder.Services.AddScoped<IKullaniciRandevuService, KullaniciRandevuService>();
builder.Services.AddScoped<IKullaniciRandevuService>(provider =>
{
    var context = provider.GetService<KlinikContext>();
    var httpContextAccessor = provider.GetService<IHttpContextAccessor>();   //Decorator Manuel Eklendi
    var originalService = new KullaniciRandevuService(context, httpContextAccessor);
    return new LoggingKullaniciRandevuServiceDecorator(originalService);
}); builder.Services.AddScoped<IAdminService>(provider => AdminService.GetInstance(provider.GetService<KlinikContext>()));
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IProjectVetFacade, ProjectVetFacade>();
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IKullaniciService, KullaniciService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();