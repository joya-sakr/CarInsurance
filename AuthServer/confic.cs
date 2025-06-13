using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("claim-api", "Claim Microservice"),
                new ApiScope("policy-api", "Policy Microservice")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
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
                    ClientId = "swagger-client",
                    ClientName = "Swagger UI for Policy and Claim APIs",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris =
                    {
                        "http://localhost:5172/swagger/oauth2-redirect.html",  // claim-api Swagger
                        "http://localhost:5286/swagger/oauth2-redirect.html"
                        //"http://localhost:5288/swagger/oauth2-redirect.html"// policy-api Swagger
                    },

                    PostLogoutRedirectUris =
                    {
                        "http://localhost:5172/swagger/",
                        "http://localhost:5286/swagger/"
                    },

                    AllowedCorsOrigins =
                    {
                        "http://localhost:5172",
                        "http://localhost:5286"
                        //"http://localhost:5288"
                    },

                    AllowedScopes = { "openid", "profile", "claim-api", "policy-api" },

                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600, // 1 hour token lifetime
                    AccessTokenType = AccessTokenType.Jwt
                }
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims =
                    {
                        new Claim("name", "Alice Smith"),
                        new Claim("email", "alice@example.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims =
                    {
                        new Claim("name", "Bob Johnson"),
                        new Claim("email", "bob@example.com")
                    }
                }
            };
    }
}
