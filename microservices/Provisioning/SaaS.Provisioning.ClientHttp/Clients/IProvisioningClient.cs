using SaaS.Provisioning.Shared.DTOs;

namespace SaaS.Provisioning.ClientHttp.Clients;

public interface IProvisioningClient
{
    Task<TenantStatusDto?> GetTenantStatusAsync(Guid tenantId, CancellationToken cancellationToken = default);
}
