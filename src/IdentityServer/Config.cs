﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
                new ApiResource("resource_product"){Scopes={ "product_permission"}},
                  new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
           };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        //new IdentityResources.Email(),
                        //  new IdentityResources.OpenId(),
                        //    new IdentityResources.Profile(),
                        //      new IdentityResource(){Name="roles",DisplayName="Roles",Description="User Roles",UserClaims=new[]{"role"}}
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("product_permission","product api permission"),
                  new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName="Public",
                    ClientId="WebClient",
                    ClientSecrets={ new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "product_permission", IdentityServerConstants.LocalApi.ScopeName }
                }
            };
    }
}