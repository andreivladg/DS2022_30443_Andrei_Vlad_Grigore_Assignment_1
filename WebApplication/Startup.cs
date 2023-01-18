using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Implementations;
using Logic.Interfaces;
using Logic.Implementations;
using WebApplication.Services;
using WebApplication.HostedServices;
using Microsoft.AspNetCore.WebSockets;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading;
using System.Text;
using WebApplication.Hubs;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    options=>options.EnableRetryOnFailure()));
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IDeviceLogic, DeviceLogic>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IRabbitConsumer, RabbitConsumer>();
            services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
            services.AddScoped<IConsumptionLogic, ConsumptionLogic>();
            services.AddHostedService<MessageReader>();
            services.AddHostedService<ChatService>();
            services.AddSingleton<NotificationsHub>();
            services.AddSingleton<ChatHub>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var wsOptions = new WebSocketOptions() { KeepAliveInterval = TimeSpan.FromSeconds(120) };
            app.UseWebSockets(wsOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<NotificationsHub>("/notifyHub");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
      
           
        }

    }
}
