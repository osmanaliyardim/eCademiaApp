using Autofac;
using Autofac.Extensions.DependencyInjection;
using eCademiaApp.Business.DependencyResolvers.Autofac;
using eCademiaApp.Core.DependencyResolvers;
using eCademiaApp.Core.Extensions;
using eCademiaApp.Core.Utilities.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware(); // eCademiaApp.Core.Extensions

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();