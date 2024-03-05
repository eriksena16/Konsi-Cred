using KonsiCred.Api.ApiConfig;

var builder = WebApplication.CreateBuilder(args);


builder
    .AddApiConfig()
    .AddCorsConfig()
    .AddSwaggerConfig()
    //.AddIdentityConfig()
    .AddVersioningConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCors("Development");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
