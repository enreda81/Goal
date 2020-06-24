using GoalSystems.InventoryManager.Api.Model.Auth;
using GoalSystems.InventoryManager.Api.Model.Error;
using GoalSystems.InventoryManager.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoalSystems.InventoryManager.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Registro de los servicios de dominio
            RegistrationService.AddDomainServices(services);

            // Registro del servicio de seguridad
            services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();            


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
            app.UseMvc();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        }
    }
}
