using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Venly.Sample.API;

namespace Venly.Sample
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //######## Context Accessor, allow accessing HTTPContext ############
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //######### Add Controllers, Default JSON Settings ##################
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 1073741824; // 1.0 GB
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            //######### Logging #################################################
            services.AddLogging(
                builder =>
                {
                    builder.AddConsole()
                    .AddFilter("HTTPRequest", LogLevel.Information).AddConsole()
                    .AddFilter("Microsoft.AspNetCore.Hosting.Internal", LogLevel.Error).AddConsole()
                    .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Error).AddConsole()
                    .AddFilter("Microsoft.EntityFrameworkCore.Model.Validation", LogLevel.Error).AddConsole();
                });

            //####### Swagger and other Options #################################
            services.AddSwaggerDocumentation();
            services.AddRouting(o => o.LowercaseUrls = true);
            services.AddSingleton<HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseCors("AllowAllOrigins");
            app.UseForwardedHeaders();
            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();


                endpoints.MapControllerRoute(
                    "area_proxy",
                    "proxy/{*url}",
                    new { controller = "Proxy", action = "Get" }
                );

            });
        }
    }
}
