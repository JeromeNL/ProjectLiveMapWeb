using System.Globalization;
using DataAccess;
using DataAccess.Models;
using DataAccess.Models.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using WebPortal.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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

        // Identity
        builder.Services.AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<LiveMapDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 10;
            options.Password.RequiredUniqueChars = 0;
        });

        // Default setup: User must be logged in to access all web pages.
        builder.Services.AddAuthorizationBuilder()
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(RoleExtension.getRolesWithWebPortalAccess())
                .Build());

        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.Configure<RequestLocalizationOptions>(
            options =>
            {
                var supportedCultures = new[] { new CultureInfo("nl") };
                options.DefaultRequestCulture = new RequestCulture("nl");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

        builder.Services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true; // Make sure the cookie is always created
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Always use secure cookies
            options.Cookie.SameSite = SameSiteMode.Strict; // Enforce strict same site rules

            options.LoginPath = "/auth/login";
            options.AccessDeniedPath = "/auth/accessdenied";
            options.SlidingExpiration = false; // No sliding expiration, session-based cookies

            // Do not set options.ExpireTimeSpan here to use session cookies
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
    }
}