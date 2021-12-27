using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Venly.Sample.API
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Venly API SDK Sample",
                    Version = "v1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Tim Cadenbach - Twitter",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/timcadenbach"),

                    }
                });
                c.DescribeAllParametersInCamelCase();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"venly.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
                c.OrderActionsBy(p => p.GroupName);
                c.DocInclusionPredicate((name, api) => true);

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(o => {
                o.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Structure Api v1");
                c.EnableDeepLinking();
                c.ShowCommonExtensions();
                c.ShowExtensions();
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
