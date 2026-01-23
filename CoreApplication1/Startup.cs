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

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if(env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            {
                //app.UseExceptionHandler("/Error");
            }

                DefaultFilesOptions dFO = new DefaultFilesOptions();
            dFO.DefaultFileNames.Clear();
            dFO.DefaultFileNames.Add("home.html");
            app.UseDefaultFiles(dFO);
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response
                    .WriteAsync($"Hosting Env: {env.EnvironmentName}");
           
            });
        }
    }
}






