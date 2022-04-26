using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace COVID19Tracker.Auth
{
    public static class ServerConfig
    {
        public static IEnumerable<ApiScope> Scopes =>
            new List<ApiScope> {
                new ApiScope("userapi", "Full access to user api"),
                new ApiScope("geographicapi", "Full access to geographic api"),
                new ApiScope("covidtrackerapi", "Full access to covidtracker api"),
                new ApiScope("adminapi", "Full access to admin api")
            };
        public static IEnumerable<ApiResource> Apis =>
           new List<ApiResource>
           {
                new ApiResource("userapi", "User API")
                {
                    ApiSecrets =
                    {
                        new Secret("userapiclientsecret".Sha256())
                    },
                    Scopes = {
                        "userapi"
                    }
                },
                new ApiResource("geographicapi", "Geographic API")
                {
                    ApiSecrets =
                    {
                        new Secret("geographicapiclientsecret".Sha256())
                    },
                    Scopes = {
                        "geographicapi"
                    }
                },
                new ApiResource("covidtrackerapi", "CovidTracker API")
                {
                    ApiSecrets =
                    {
                        new Secret("covidtrackerapiclientsecret".Sha256())
                    },
                    Scopes = {
                        "covidtrackerapi"
                    }
                },
                new ApiResource("adminapi", "Admin API")
                {
                    ApiSecrets =
                    {
                        new Secret("adminapiclientsecret".Sha256())
                    },
                    Scopes = {
                        "adminapi"
                    }
                }
           };
        public static IEnumerable<IdentityResource> Resources =>
        new List<IdentityResource>
        {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
        };
        public static IEnumerable<Client> Clients =>
           new List<Client>
           {
                new Client
                {
                    ClientId = "covidtrackerui_client",
                    ClientName = "CovidTracker UI",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    RequirePkce = false,
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
                    RequireClientSecret = true,
                    ClientSecrets=  new List<Secret>
                    {
                        new Secret("userapiclientsecret".Sha256()),
                        new Secret("geographicapiclientsecret".Sha256()),
                        new Secret("covidtrackerapiclientsecret".Sha256()),
                        new Secret("adminapiclientsecret".Sha256())
                    },

                    AllowedCorsOrigins = {"https://localhost:6001"},
                    RedirectUris = {"https://localhost:6001/swagger/oauth2-redirect.html"},
                    AllowedScopes = {
                        "userapi",
                        "geographicapi",
                        "covidtrackerapi",
                        "adminapi"
                    }
                }
           };
        public static List<TestUser> GetUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "user",
                    Password = "user",
                    Claims = new[]
                    {
                        new Claim("role", "user")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "admin",
                    Password = "admin",
                    Claims = new[]
                    {
                        new Claim("role", "admin")
                    }
                }
            };
    }
}
