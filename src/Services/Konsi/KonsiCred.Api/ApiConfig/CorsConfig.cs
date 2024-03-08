namespace KonsiCred.Api.ApiConfig
{
    public static class CorsConfig
    {
        public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Development", builder =>
                            builder
                                .WithOrigins("https://localhost:7279")
                                .AllowAnyMethod()
                                .AllowAnyHeader());

                options.AddPolicy("Production", builder =>
                            builder
                                .WithOrigins("https://localhost:7171")
                                .WithMethods("POST")
                                .AllowAnyHeader());
            });

            return builder;
        }
    }
}
