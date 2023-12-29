
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ePollApp.Server
{
    public class startup
    {
        // Startup.cs
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            

            app.UseRouting();

            
        }



    }
}
