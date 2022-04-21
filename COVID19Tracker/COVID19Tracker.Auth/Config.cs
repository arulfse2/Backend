using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace COVID19Tracker.Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources =>
         new List<IdentityResource>
         {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource(
                    "roles",
                    "User role(s)",
                    new List<string>() { "role" })
         };
        public static IEnumerable<ApiResource> GetApiResources =>
         new List<ApiResource>
            {
                new ApiResource("userAPI","User API",new List<string> { "role", "admin", "user"})
                {
                    ApiSecrets =
                    {
                        new Secret("userAPISecret".Sha256())
                    },
                    Scopes =
                    {
                        "userAPIScope"
                    }
                },
                new ApiResource("geographicAPI","Geographic API",new List<string> { "role", "admin", "user"})
                {
                    ApiSecrets =
                    {
                        new Secret("geographicAPISecret".Sha256())
                    },
                    Scopes =
                    {
                        "geographicAPIScope"
                    }
                },
                new ApiResource("covidTrackerAPI","CovidTracker API",new List<string> { "role", "admin", "user"})
                {
                    ApiSecrets =
                    {
                        new Secret("covidTrackerAPISecret".Sha256())
                    },
                    Scopes =
                    {
                        "covidTrackerAPIScope"
                    }
                },
                new ApiResource("adminAPI","Admin API",new List<string> { "role", "admin" })
                {
                    ApiSecrets =
                    {
                        new Secret("adminAPISecret".Sha256())
                    },
                    Scopes =
                    {
                        "adminAPIScope"
                    }
                }
            };
        public static IEnumerable<ApiScope> GetApiScopes =>
         new List<ApiScope>
            {
                new ApiScope
                {
                    Name = "userAPIScope",
                    DisplayName = "Scope for the user ApiResource",
                    UserClaims = { "role", "admin", "user" }
                },
                new ApiScope
                {
                    Name = "geographicAPIScope",
                    DisplayName = "Scope for the geographic ApiResource",
                    UserClaims = { "role", "admin", "user" }
                },
                new ApiScope
                {
                    Name = "covidTrackerAPIScope",
                    DisplayName = "Scope for the covidTracker ApiResource",
                    UserClaims = { "role", "admin", "user" }
                },
                new ApiScope
                {
                    Name = "adminAPIScope",
                    DisplayName = "Scope for the admin ApiResource",
                    UserClaims = { "role", "admin" }
                }
            };
        public static IEnumerable<Client> GetClients =>
         new List<Client>
            {
                new Client
                {
                    ClientName = "CovidTrackerClient",
                    ClientId = "237AE313-02A3-447F-AF60-02DF65CAF982",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 3600,
                    IdentityTokenLifetime = 3600,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    SlidingRefreshTokenLifetime = 30,
                    AllowOfflineAccess = true,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    AlwaysSendClientClaims = true,
                    Enabled = true,
                    RedirectUris = new List<string>()
                       {
                           "https://localhost:5001/signin-oidc"
                       },
                    PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5001/signout-callback-oidc"
                       },
                    ClientSecrets=  new List<Secret> { new Secret("ClientSecret".Sha256()) },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "userAPIScope",
                        "geographicAPIScope",
                        "covidTrackerAPIScope",
                        "adminAPIScope",
                        "roles"
                    }
                }
            };
    }
}
