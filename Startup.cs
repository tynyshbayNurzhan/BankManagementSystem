using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Abstractions;
using BankManagementSystem.Data;
using BankManagementSystem.Hubs;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagementSystem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            services.AddDbContext<BankContext>(options =>
            {
                options.UseSqlite("Filename=bank.db");
            });

            services.AddIdentity<Users, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<BankContext>();

            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddScoped<UsersService>();
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddSignalR();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //app.UseRouting();
            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });
            app.UseSession();
            
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });

        }
    }
}
