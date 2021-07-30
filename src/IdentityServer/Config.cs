﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]
           {
                new ApiResource("resource_product"){Scopes={ "product_permission"}},
                  new ApiResource("resource_basket"){Scopes={ "basket_permission"}},
                    new ApiResource("resource_discount"){Scopes={ "discount_permission"}},
                      new ApiResource("resource_order"){Scopes={ "order_permission"}},
                        new ApiResource("resource_gateway"){Scopes={ "gateway_permission"}},
                          new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
           };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.Email(),
                          new IdentityResources.OpenId(),
                            new IdentityResources.Profile(),
                              new IdentityResource(){Name="roles",DisplayName="Roles",Description="User Roles",UserClaims=new[]{"role"}}
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("product_permission","product api permission"),
                  new ApiScope("basket_permission","basket api permission"),
                    new ApiScope("discount_permission","discount api permission"),
                      new ApiScope("order_permission","order api permission"),
                        new ApiScope("gateway_permission","gateway permission"),
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
                    AllowedScopes = { "product_permission", "gateway_permission",
                        IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                    ClientName="User",
                    ClientId="WebClientForUser",
                    AllowOfflineAccess = true,
                    ClientSecrets={ new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = {"basket_permission","discount_permission","order_permission","gateway_permission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId, 
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,"roles"},
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
    }
}