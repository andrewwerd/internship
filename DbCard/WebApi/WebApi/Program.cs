using System.Reflection;
using WebApi.Configuration;
using WebApi.Infrastructure.Extensions;
using WebApi.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAppDbContext()
    .AddAppAuthentication(builder.Configuration)
    .AddAppServices()
    .AddAppRepository()
    .AddAutoMapper(Assembly.GetExecutingAssembly())
    .AddAppControllers()
    .AddAppSwagger();

var app = builder.Build();
await app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
}

app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
