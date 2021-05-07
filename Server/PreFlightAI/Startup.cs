using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PreFlightAI.Areas.Identity;
using PreFlightAI.Data;
using PreFlightAI.Api.Models;
using PreFlightAI.Server.Services;
using PreFlight.AI.Server.Http.Services;

namespace PreFlightAI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            services.AddScoped<ICountryRepository, CountryRepository>();            
            services.AddScoped<IUserRepository, UserRepository>();            
            services.AddScoped<MessageModel>();

            

            services.AddHttpClient<ICountryDataService, CountryDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/");  })
                .AddHttpMessageHandler(handler => new RetryPolicy(2, TimeSpan.FromSeconds(20)));

            services.AddHttpClient<IUserDataService, UserDataService>(client =>
            { client.BaseAddress = new Uri("https://localhost:44336/");  })
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
                endpoints.MapBlazorHub();
                endpoints.MapHub<ChatHub>("/Chat");
                endpoints.MapFallbackToPage("/_Host");
               
            });
            
        }
    }
}
