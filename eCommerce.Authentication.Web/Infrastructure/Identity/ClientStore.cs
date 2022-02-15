using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace eCommerce.Authentication.Web.Infrastructure.Identity
{
    public class ClientStore : IClientStore
    {
        private static readonly IEnumerable<Client> Clients = new List<Client>
        {
            new Client
            {
                ClientId = "ecommerce",
                ClientName = "ecommerce",
                AllowedGrantTypes = GrantTypes.Implicit,
                ClientSecrets = new List<Secret>
                {
                    new Secret("e7e73014-bcfb-4026-80b6-f473c8862cc4")
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "api"
                },
                RedirectUris = { "https://localhost:44438" },
                AllowedCorsOrigins = { "https://localhost:44438" },
                PostLogoutRedirectUris = { "https://localhost:44438" },
                AllowAccessTokensViaBrowser = true,
                AccessTokenLifetime = 3600
            }
        };

        public Task<Client?> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(Clients.FirstOrDefault(e => e.ClientId == clientId));
        }
    }
}
