
using ePollApp.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ePollApp.Server
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            
            /*services.AddScoped<IPollService, PollService>();
            services.AddHttpContextAccessor();*/ // Ended up being unnecessary?
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }



    }
}
