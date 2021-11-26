using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Obilet.Web.Models.Settings;
using Obilet.Web.Services.Abstract;
using Obilet.Web.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obilet.Web
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
           
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                            .AddDataAnnotationsLocalization();
           
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration.GetConnectionString("Redis");
                option.InstanceName = "Obilet";
            });

            services.Configure<RedisSettings>(Configuration.GetSection("RedisSettings"));
            services.AddSingleton<IRedisSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<RedisSettings>>().Value;
            });

            services.Configure<ObiletApiSettings>(Configuration.GetSection("ObiletApiSettings"));
            services.AddSingleton<IObiletApiSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<ObiletApiSettings>>().Value;
            });

            services.TryAddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddTransient<IObiletService, ObiletService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
