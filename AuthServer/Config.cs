﻿using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace AuthServer
{
    public static class Config
    {
        //Bu sayede Idenitity Server Hangi apiler için hangi izinleri oldugunu yazdık.
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
               new ApiResource("resource_api1"){
                   Scopes={ "api1.read","api1.write","api1.update"} },
               new ApiResource("resource_api2"){
                   Scopes={ "api2.read","api2.write","api2.update"} },
            };
        }
        public static IEnumerable<ApiScope> GetApiScopers()
        {
            return new List<ApiScope>() {

            new ApiScope("api1.read","API 1 için okuma izni"),
            new ApiScope("api1.write", "API 1 için yazma izni"),
            new ApiScope("api1.update", "API 1  için güncelleme izni"),
            new ApiScope("api2.read","API 2 için okuma izni"),
            new ApiScope("api2.write", "API 2 için yazma izni"),
            new ApiScope("api2.update", "API 2 için güncelleme izni")
        };

        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
             new Client()
             {
                 ClientId="Client1",
                 ClientName="Client 1 app uygulaması",
                 ClientSecrets=new[]{new Secret("secret".Sha256())},
                 AllowedGrantTypes=GrantTypes.ClientCredentials,
                 AllowedScopes={"api1.read"}
             },
                 new Client()
             {
                 ClientId="Client2",
                 ClientName="Client 2 app uygulaması",
                 ClientSecrets=new[]{new Secret("secret".Sha256())},
                 AllowedGrantTypes=GrantTypes.ClientCredentials,
                 AllowedScopes={"api1.read","api1.update","api2.write","api2.update"}
             }
             };
        }
    }
}
