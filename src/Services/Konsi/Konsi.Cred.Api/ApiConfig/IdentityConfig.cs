using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AssetTrack.Patrimony.Api.ApiConfig
{
    public static class IdentityConfig
    {
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "http://teste-dev-api-dev-140616584.us-east-1.elb.amazonaws.com/api/v1";
                options.Audience = "KonsiCred.Api"; // Substitua pelo nome da sua API
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                  
                };
                options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "http://teste-dev-api-dev-140616584.us-east-1.elb.amazonaws.com/api/v1";
                   options.Audience = "KonsiCred.Api";
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };
               });
            return builder;
        }
    }
}
