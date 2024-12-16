using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShrubsBudgetFinance.Components;
using ShrubsBudgetFinance.Components.Account;
using ShrubsBudgetFinance.Data;
using ShrubsBudgetFinance.Data.Config;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Services;

namespace ShrubsBudgetFinance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var incomeContext = new ConfigContext();

			// Add services to the container.
			builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            ///ADDED SERVICES
            //Server Connection
            builder.Services.AddScoped(http => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!) });
            builder.Services.AddDbContext<ConfigContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("IncomeBreakdownConnection")));
            //Controller Connection
            builder.Services.AddControllers();
            builder.Services.AddScoped<IncomeBreakdownService>();
			///END OF ADDED SERVICES

			builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("IncomeBreakdownConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            var app = builder.Build();
            
            ///ADDED
			app.MapControllers();
            ///END ADDED

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            //Database and Table Creation
            Data.Data.incomeContext = new ConfigContext();

            Data.Data.incomeContext.Database.EnsureDeleted();
			Data.Data.incomeContext.Database.EnsureCreated();
            Data.Data.incomeContext.Set<Config>().Load();
            Data.Data.incomeContext.Set<IncomeBreakdown>().Load();

			// Add additional endpoints required by the Identity /Account Razor components.
			app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
