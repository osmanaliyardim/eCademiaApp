using Autofac;
using Autofac.Extensions.DependencyInjection;
using eCademiaApp.Business.DependencyResolvers.Autofac;
using eCademiaApp.Core.DependencyResolvers;
using eCademiaApp.Core.Extensions;
using eCademiaApp.Core.Utilities.IoC;
using eCademiaApp.Core.Utilities.Security.Encryption;
using eCademiaApp.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:5500",
                                              "http://www.ecademia.com",
                                              "http://ecademia.com").AllowAnyHeader().AllowAnyMethod();
                      });
});

// Autofac Middleware
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Swagger Middleware
builder.Services.AddSwaggerGen();

// JWT Token Configurations
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.ConfigureCustomExceptionMiddleware(); // eCademiaApp.Core.Extensions

app.UseHttpsRedirection();

app.UseRouting();

// Cors to allow anyheader from specific domains:ports
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();