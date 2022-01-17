using Carter;

namespace Dotify.Api.Startup
{
    public static class CarterRegistration
    {
        public static IServiceCollection AddCarterInt(this IServiceCollection services, string swaggerTitle = "Swagger")
        {
            services.AddCarter();

            return services;
        }

        public static IApplicationBuilder UseCarter(this IApplicationBuilder app, bool withSwagger = true, string swaggerTitle = "Swagger")
        {
            app.UseRouting();
            app.UseEndpoints(builder => builder.MapCarter());
            // Configure the HTTP request pipeline.
            if (withSwagger)
            {
                app.UseSwaggerUI(opt =>
                {
                    opt.RoutePrefix = "openapi/ui";
                    opt.SwaggerEndpoint("/openapi", swaggerTitle);
                });
            }

            return app;
        }
    }
}
