using IdentityModel;

using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace eCommerce.Authentication.Web.Infrastructure.Identity
{
    public class ResourceStore : IResourceStore
    {
        private static readonly IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        private static readonly IEnumerable<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource("ecommerce", "eCommerce API")
            {
                Scopes = { "api" },
                UserClaims = new List<string>
                {
                    JwtClaimTypes.Name
                }
            }
        };

        private static readonly IEnumerable<ApiScope> Scopes = new List<ApiScope>
        {
            new ApiScope("api")
        };

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var resources = IdentityResources.Where(e => scopeNames.Any(x => x == e.Name));

            return Task.FromResult(resources);
        }

        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            return Task.FromResult(Scopes.Where(e => scopeNames.Contains(e.Name)));
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return Task.FromResult(ApiResources);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var apiResources = ApiResources.Where(e => apiResourceNames.Contains(e.Name));

            return Task.FromResult(apiResources);
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var resources = new Resources(IdentityResources, ApiResources, Scopes);

            return Task.FromResult(resources);
        }
    }
}
