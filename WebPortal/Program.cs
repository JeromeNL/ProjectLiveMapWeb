using System.Globalization;
using DataAccess;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using WebPortal.Services;

var builder = WebApplication.CreateBuilder(args);

// Allow cors from all domains. Hotfix.
// TODO: remove this and fix in a better way
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(7);
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContextPool<LiveMapDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LivemapDB"))
        .AddInterceptors(new SoftDeleteInterceptor()));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new[] { new CultureInfo("nl") };
        options.DefaultRequestCulture = new RequestCulture("nl");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IResortService, ResortService>();

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

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();