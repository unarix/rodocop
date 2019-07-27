using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using rodocop.Hubs;

namespace rodocop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddMvc();
            //services.AddSignalR();
            services.AddSignalR().AddAzureSignalR("Endpoint=https://a2k.service.signalr.net;AccessKey=5Z9orfXe/d9gQEv0rC8Qd0zxXY0vVfV0cD9xwsqL3+s=;Version=1.0;");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            
            // app.UseMvc(routes => {
            // routes.MapRoute(
            // name: "default",
            // template: "{controller=snap}/{action=Index}/{id?}");
            // });

            // Singal IR SAS en Azure
            // Azure SignalR service
            app.UseFileServer();
            app.UseAzureSignalR(routes =>
            {
                routes.MapHub<Chat>("/chat");
            });

            app.UseDefaultFiles();
            //app.UseStaticFiles();

            //app.UseMvc();
        }
    }
}
