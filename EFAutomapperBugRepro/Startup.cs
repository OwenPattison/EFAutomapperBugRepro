using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFAutomapperBugRepro
{
    using AutoMapper;
    using Microsoft.AspNet.OData.Extensions;

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
            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkSqlServer();
            services.AddSingleton<IMapper>(this.CreateMapper());
            services.AddDbContext<ReproContext>();
        }

        private IMapper CreateMapper()
        {

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Thing, ThingModel>();
                cfg.CreateMap<Thing, ThingWithoutTypeModel>();
                cfg.CreateMap<ThingModel, Thing>();
                cfg.CreateMap<ThingType, ThingTypeModel>();
                cfg.CreateMap<ThingTypeModel, ThingType>();
            });

            return mapperConfiguration.CreateMapper();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.EnableDependencyInjection();
            });
        }
    }
}
