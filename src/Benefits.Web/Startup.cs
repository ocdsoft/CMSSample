using Benefits.Shared;
using Benefits.Shared.Configuration;
using Benefits.Shared.Infrastructure;
using Benefits.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Benefits.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment Env;

        public Startup(IHostingEnvironment env)
        {
            Env = env;

            // In this fluent API order is important, as latter values overwrite earlier ones.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add DbContext for Entity Framework - connection string value depends on appsetting environment.
            services.AddDbContext<CISOregonContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("CISOregon")));

            // Add scoped services.
            services.AddScoped<ICISOregonRepository, CISOregonRepository>();
            services.AddScoped<IDocumentManagementRepository, DocLocRepository>();

            // Add singleton services.            
            services.AddSingleton<IUIHelpers, UIHelpers>();
            services.AddSingleton<ICache, Cache>();
            services.AddSingleton<IDynamicNavigationBuilder, DynamicNavigationBuilder>();

            // Add additional configuration services from appsettings.
            services.Configure<Constants>(Configuration.GetSection("Constants"));
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            // Require SSL.
            if (!Env.IsDevelopment())
            {
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            // Configure logging.
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                // Log errors silently then display user-friendly error page.
                app.UseExceptionHandler("/Home/Error");
            }

            // Add services using format: app.Use{MiddleWareComponentName}.
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Error",
                    template: "Error/{action}",
                    defaults: new { controller = "Error", action = "Index" });

                // Pass entire url to CustomRoute controller to lookup CMS entry in database
                routes.MapRoute(
                    name: "CustomRoute",
                    template: "{*url}",
                    defaults: new { controller = "CustomRoute", action = "RenderPage" });
            });

            StaticServiceProvider.Instance = app.ApplicationServices;
        }
    }
}