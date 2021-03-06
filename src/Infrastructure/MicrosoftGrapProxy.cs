using Azure.Identity;
using Microsoft.Graph;
using POC_MGrap.Services.Interfaces;

// ReSharper disable once IdentifierTypo
namespace POC_MGrap.Infrastructure;

// ReSharper disable once IdentifierTypo
internal class MicrosoftGrapProxy : IGatewayData {
    private readonly string? _tenantId;
    private readonly string? _clientId;
    private readonly string? _clientSecret;
    private readonly string[]? _scopes;
    protected GraphServiceClient? GraphServiceClient { get; private set; }

    protected MicrosoftGrapProxy(IConfiguration configuration) {
        _scopes = configuration["AzureServicePrincipalSettings:Scopes"]?.Split(",");
        _tenantId = configuration["AzureServicePrincipalSettings:TenantID"];
        _clientId = configuration["AzureServicePrincipalSettings:ClientID"];
        _clientSecret = configuration["AzureServicePrincipalSettings:ClientSecret"];
        Connect();
    }

    public void Connect() {
        if (GraphServiceClient != null) return;
        // using Azure.Identity;
        var options = new TokenCredentialOptions {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        // https://docs.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
        var clientSecretCredential = new ClientSecretCredential(_tenantId, _clientId, _clientSecret, options);

        GraphServiceClient = new GraphServiceClient(clientSecretCredential, _scopes);
    }
}
