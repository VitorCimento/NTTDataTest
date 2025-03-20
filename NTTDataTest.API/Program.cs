using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Context;
using NTTDataTest.ORM.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("PGSQL");

// Database connections
builder.Services.AddDbContext<NTTContext>(options =>
    options.UseNpgsql(connStr, opts => opts.MigrationsAssembly("NTTDataTest.Domain")));

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AddressRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
