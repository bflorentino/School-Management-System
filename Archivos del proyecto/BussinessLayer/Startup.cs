using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ServicesLayer.Bussiness;
using ServicesLayer;
using ServicesLayer.Services;
using ServicesLayer.Services.StudentServices;
using ServicesLayer.Services.TeachersServices;
using ServicesLayer.Services.SubjectServices;
using ServicesLayer.Services.NoticesServices;
using Data;

namespace BussinessLayer
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
            services.AddCors(options => options.AddPolicy("AllowWebApp", builder =>
                                                                                 builder
                                                                                 .AllowAnyHeader()
                                                                                  .AllowAnyOrigin()   
                                                                                 .AllowAnyMethod()));
            services.AddControllers();

            services.AddScoped<ISeccionesCrud, SeccionesCrud >();
            services.AddScoped<IEstudiantesCrud, EstudiantesCrud>();
            services.AddScoped<IMaestrosCrud, MaestrosCrud>();
            services.AddScoped<IMateriasCrud, MateriasCrud>();
            services.AddScoped<IAdminNoticesCrud, AdminNoticesCrud>();
            services.AddSingleton<School_Manage_SystemContext>();

            // Configuration for automapper
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowWebApp");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}