﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class TokenConfigExtension
    {
        public static void ConfigurarValidacaoToken(this IServiceCollection services)
        {
            byte[] key = Encoding.ASCII.GetBytes("SegredoeCommerceTheShape");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidAudience = "http://localhost",
                    ValidIssuer = "eCommerceTheShape"
                };
            });
        }
    }
}
