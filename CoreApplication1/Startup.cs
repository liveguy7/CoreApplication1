using CoreApplication1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CoreApplication1
{
    public class Startup
    {
        IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
                                  options.UseSqlServer(
                                     _config.GetConnectionString("DefaultConnectionString")));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;

            }).AddEntityFrameworkStores<AppDbContext>();

            services.AddMvc(options =>
                options.EnableEndpointRouting = false);
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
               routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


            //app.Run(async (context) =>
            //{
            //    await context.Response
            //        .WriteAsync($"Error Found Using Env.. {env.EnvironmentName}");
           
            //});
        }
    }
}







