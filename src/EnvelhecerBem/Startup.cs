using System.ComponentModel;
using System.Data;
using System.Globalization;
using EnvelhecerBem.Core.Data;
using EnvelhecerBem.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EnvelhecerBem
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
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");
            services.AddLogging()
                    .AddControllersWithViews()
                    .AddRazorRuntimeCompilation()
                    .AddAppModule(Configuration);
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

            app.UseStaticFiles()
               .UseAuthorization()
               .UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class AppModule
    {
        public static IMvcBuilder AddAppModule(this IMvcBuilder builder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            builder.AddApplicationPart(typeof(AppModule).Assembly);

            builder.Services
                   .AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString))
                   .AddScoped<IDbConnection>(c => new SqlConnection(connectionString))
                   .AddScoped<IUnitOfWork, EfCoreUnitOfWork>()
                   .AddScoped<IParceiroRepository, ParceiroRepository>()
                   .AddScoped<IClienteRepository, ClienteRepository>()
                   .AddScoped<ParceiroApplicationService>()
                   .AddScoped<ClienteApplicationService>();

            return builder;
        }
    }
}
