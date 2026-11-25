using Microsoft.Extensions.Configuration;
using SaaS.Provisioning.ClientHttp.Clients;
using SaaS.Provisioning.ClientHttp.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class ProvisioningClientExtensions
{
    public static IServiceCollection AddProvisioningClient(this IServiceCollection services, IConfiguration configuration)
    {
        var confSection = configuration.GetSection(ProvisioningClientOptions.SectionName);
        var options = confSection.Get<ProvisioningClientOptions>() ?? new();

        services.AddHttpClient<IProvisioningClient, ProvisioningClient>(o =>
        {
            o.BaseAddress = new Uri(options.BaseAddress);
            o.Timeout = TimeSpan.FromSeconds(30);
        });

        return services;
    }
}
