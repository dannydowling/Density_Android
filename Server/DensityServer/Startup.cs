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
using Serilog;
using Serilog.Events;
using System.Net.Http;
using DensityServer.Services.GameInvitation;

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

        private Employee employeeConfigOptions;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)

        {
            services.AddAntiforgery();

            services.AddAuthentication();

            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<Employee>(Configuration.GetSection("Employee"));
            // need to find a way to compare the employee's to the list of user claims.

            IOptions<Employee> employeeConfig = (IOptions<Employee>)employeeConfigOptions;

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
               .AddEntityFrameworkStores<AppDbContext>();

            //the error parameter configure cannot be null is from the version of .Net.Authorization being 5.0  ... 5/10/21 
            services.AddRazorPages();

            services.AddSingleton<ILocationDataService, LocationDataService>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddSingleton<IEmployeeDataService, EmployeeDataService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddSignalR();
            services.AddScoped<MessageModel>();

            services.AddHttpClient<ILocationDataService, LocationDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)))
              .ConfigurePrimaryHttpMessageHandler(handler => new HttpClientHandler()
              { AutomaticDecompression = System.Net.DecompressionMethods.GZip });

            services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<MessageModel>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/"); })
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/Chat");
                endpoints.MapFallbackToPage("/_Host");

            });

        }
    }
}
