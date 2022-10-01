using Proton.Frequency.Api;
using Proton.Frequency.Services.ConfigOptions;

namespace Proton.Frequency.Services;

internal static class MapEndpoints
{
    internal static WebApplication RegisterEndpoints(this WebApplication app)
    {
        var logger = Initializer.GetLogger<WebApplication>();
        var defaultOptions = new DefaultOptions();
        app.Configuration.GetSection(DefaultOptions.SectionKey).Bind(defaultOptions);
        app.RegisterMqttEndpoints();

        if (!defaultOptions.Api)
        {
            logger.LogInformation("API endpoints are disabled...");
            return app;
        }
        logger.LogInformation("Starting API endpoints...");
        app.MapControllers();
        app.RegisterApiEndpoints();

        if (!app.Environment.IsDevelopment())
            return app;
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{defaultOptions.Name}");
        });

        return app;
    }
}
