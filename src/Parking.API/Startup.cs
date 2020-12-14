using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parking.Domain.CommandHandlers.Handlers;
using Parking.Domain.IRespositories;
using Parking.Infra.Repositories;

namespace Parking.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlDataContractSerializerFormatters();
            this.InjetarDependecia(services);
            this.CompactarRespostaJson(services);
        }

        private void InjetarDependecia(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyVehicleRepository, CompanyVehicleRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<CompanyCommandHandler>();
            services.AddScoped<CompanyVehicleCommandHandler>();
            services.AddScoped<VehicleCommandHandler>();
        }
        private void CompactarRespostaJson(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(
                 options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

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
            app.UseCors(option => option.DisallowCredentials().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
