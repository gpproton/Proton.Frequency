namespace Proton.Frequency.Api.Status;

public class StatusModule : IModule
{
    public IServiceCollection RegisterApiModule(IServiceCollection services)
    {
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }
}
