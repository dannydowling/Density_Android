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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgery();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<AppDbContext>();

            //the error parameter cannot be null is from the version of .Net.Authorization being 5.0  ... 5/10/21 
            services.AddRazorPages();

            services.AddScoped<ICountryRepository, CountryRepository>();            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<MessageModel>();

            services.AddHttpClient<ICountryDataService, CountryDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/");  })
                .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<IUserDataService, UserDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/");  })
                .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<ILocationDataService, LocationDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/"); })
              .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<MessageModel>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/");  })
                .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

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
