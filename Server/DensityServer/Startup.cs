using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DensityServer.Areas.Identity;
using DensityServer.Data;
using DensityServer.Api.Models;
using DensityServer.Server.Services;
using DensityServer.AI.Server.Http.Services;
using DensityServer.Shared;
using DensityServer.Services.Email;
using DensityServer.Services;
using Microsoft.Extensions.Options;
using System.Net.Http;
using DensityServer.Services.GameInvitation;
using System.Globalization;
using DensityServer.Services.Localizer;
using DensityServer.ModelsandRepositories.User;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;

namespace DensityServer
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        private EmployeeModel employeeConfigOptions;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)

        {
            services.AddControllers();

            services.AddAntiforgery();

            services.AddLocalization(options => options.ResourcesPath = "Localization");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => options.ResourcesPath = "Languages");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                      new CultureInfo("en"),
                      new CultureInfo("de"),
                      new CultureInfo("fr"),
                      new CultureInfo("es"),
                      new CultureInfo("ru"),
                      new CultureInfo("ja"),
                      new CultureInfo("ar"),
                      new CultureInfo("zh"),
                      new CultureInfo("en-GB")
    };
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddAuthentication();

                       //these are overridden in their onconfiguring methods.
            services.AddDbContext<UserModelsDbContext>();
            services.AddDbContext<AirportsDbContext>();
            services.AddDbContext<GamesDbContext>();

            services.AddMvc();

            services.Configure<EmployeeModel>(Configuration.GetSection("Employee"));
            IOptions<EmployeeModel> employeeConfig = (IOptions<EmployeeModel>)employeeConfigOptions;

            services.AddAuthorization(options =>
            options.AddPolicy("CheckPassword", policy => policy.RequireAssertion
                (x => x.User.HasClaim(x => x.Value == employeeConfig.Value.Password))));

            services.AddAuthorization(options =>
            options.AddPolicy("CheckFirstName", policy => policy.RequireAssertion
                (x => x.User.HasClaim(x => x.Value == employeeConfig.Value.FirstName))));

            services.AddAuthorization(options =>
            options.AddPolicy("CheckLastName", policy => policy.RequireAssertion
                (x => x.User.HasClaim(x => x.Value == employeeConfig.Value.LastName))));


            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<UserModelsDbContext>();

            services.AddRazorPages();

            services.AddTransient<ApplicationUserManager>();

            services.AddSingleton<ILocationDataService, LocationDataService>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddSingleton<IEmployeeDataService, EmployeeDataService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddSignalR();
            services.AddScoped<MessageModel>();

            services.AddHttpClient<ILocationDataService, LocationDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/locations/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)))
              .ConfigurePrimaryHttpMessageHandler(handler => new HttpClientHandler()
              { AutomaticDecompression = System.Net.DecompressionMethods.GZip });

            services.AddHttpClient<IGameDataService, GameModelDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/games/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)))
              .ConfigurePrimaryHttpMessageHandler(handler => new HttpClientHandler()
              { AutomaticDecompression = System.Net.DecompressionMethods.GZip });

            services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/employees/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<MessageModel>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/chat/"); })
                .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.Configure<EmailServiceOptions>(Configuration.GetSection("Email"));
            services.AddSingleton<IEmailService, EmailService>();
             
            services.AddSingleton<IGameInvitationService, GameInvitationService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseAuthentication();
            app.UseAuthorization();

            var userProfileInformation = app.ApplicationServices.GetService<IOptions<IdentityUser>>().Value;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>($"{userProfileInformation.SecurityStamp}/Chat");
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
