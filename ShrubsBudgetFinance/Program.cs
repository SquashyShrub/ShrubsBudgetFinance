using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Syncfusion.Blazor;

using ShrubsBudgetFinance.Components;
using ShrubsBudgetFinance.Components.Account;
using ShrubsBudgetFinance.Data;
using ShrubsBudgetFinance.Models;
using ShrubsBudgetFinance.Services;
using ShrubsBudgetFinance.Controllers;

namespace ShrubsBudgetFinance
{
	public class Program
    {
        public static void Main(string[] args)
        {
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf0x3Q3xbf1x1ZFFMYVhbRnNPIiBoS35RckRhWHhfdnVRRGdfUkNx");
			var builder = WebApplication.CreateBuilder(args);
            var dataConfigContext = new ConfigContext();

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
            builder.Services.AddDbContext<ConfigContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConfigConnection")));
			//Register Config services
			builder.Services.AddScoped<IncomeBreakdownService>();
            builder.Services.AddScoped<AccountNamesService>();
            builder.Services.AddScoped<AssetNameService>();
			//Syncfusion
			builder.Services.AddSyncfusionBlazor();
			//Controller Connection
			builder.Services.AddControllers();
			builder.Services.AddScoped<IConfigService<IncomeBreakdown>, IncomeController>();
            builder.Services.AddScoped<IConfigService<AccountNames>, AccountController>();
            builder.Services.AddScoped<IConfigService<AssetName>, AssetController>();
			///END OF ADDED SERVICES

			builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("ConfigConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
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
            Data.Data.dataConfigContext = new ConfigContext();

            //Data.Data.dataConfigContext.Database.EnsureDeleted();
			Data.Data.dataConfigContext.Database.EnsureCreated();
            Data.Data.dataConfigContext.Set<Config>().Load();
            Data.Data.dataConfigContext.Set<IncomeBreakdown>().Load();
            Data.Data.dataConfigContext.Set<AccountNames>().Load();
            Data.Data.dataConfigContext.Set<AssetName>().Load();

			// Add additional endpoints required by the Identity /Account Razor components.
			app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
