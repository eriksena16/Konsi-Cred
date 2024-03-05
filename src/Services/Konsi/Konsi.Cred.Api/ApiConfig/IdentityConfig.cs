using Microsoft.AspNetCore.Authentication.JwtBearer;

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
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.Authority = "http://teste-dev-api-dev-140616584.us-east-1.elb.amazonaws.com/api/v1/token";
                options.Audience = "KonsiCred.Api";
            });

            return builder;
        }
    }
}
