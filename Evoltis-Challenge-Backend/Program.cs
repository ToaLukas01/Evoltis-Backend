using FluentValidation;
using Models;
using Repository.Interfaces;
using Repository.Repository;
using Services.Interfaces;
using Services.Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string assemblyName = typeof(EvoltisContext).Namespace;
var connectionString = Environment.GetEnvironmentVariable("CS") ?? builder.Configuration.GetConnectionString("CS");;

builder.Services.AddDbContext<EvoltisContext>(options =>
{
    //options.UseMySql(connectionString,
    //    ServerVersion.AutoDetect(connectionString),
    //    optionsBuilder => optionsBuilder.MigrationsAssembly(assemblyName));
    options.UseSqlServer(connectionString);
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IProducts, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<Mapeo>();
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder => 
    {
        builder.WithOrigins("http://localhost:4200");
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.WithExposedHeaders("*");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<EvoltisContext>();
    var pendingMigrations = context.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
        context.Database.Migrate();
    }
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
