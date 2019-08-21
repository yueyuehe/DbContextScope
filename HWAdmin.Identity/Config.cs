﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace HWAdmin.Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {

            var apiResource = new ApiResource("api1", "My API");
            return new List<ApiResource>
            {
                apiResource
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        new Client
        {
            ClientId = "client",
            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            // scopes that client has access to
            AllowedScopes = { "api1" }
        }
    };
        }


        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
        {
        new TestUser
        {
            SubjectId = "1",
            Username = "alice",
            Password = "password"
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password"
        }
    };
        }

    }
}
