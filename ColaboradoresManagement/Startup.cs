using AutoMapper;
using ColaboradoresManagement.CrossCutting.DependencyInjection;
using ColaboradoresManagement.CrossCutting.Utis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColaboradoresManagement
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
            ConfigurationRepository configurationRepository =
                Configuration.GetSection("ConfigurationRepository").Get<ConfigurationRepository>();

            DependencyInjectionService.AddDependecyInjectionService(services);
            DependencyInjectionRepository.AddDependencyInjectionRepository(services, configurationRepository);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ColaboradoresManagementAutoMapperProfile>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);  
            
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Colaboradores Management", Version = "v1," }));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

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
