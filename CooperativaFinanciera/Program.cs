using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Service;
using CooperativaFinanciera.Infrastructure.Contexts;
using CooperativaFinanciera.Infrastructure.Domain;
using CooperativaFinanciera.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbCooperativaContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    );

//Services
builder.Services.AddScoped<IClienteService, ClienteService>();


//Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("CooperativaFinanciera.Application")));


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
