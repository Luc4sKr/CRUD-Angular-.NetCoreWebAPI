using CrudAPI.Application.Service.SQLServerServices;
using CrudAPI.Domain.Interfaces.IRepositories;
using CrudAPI.Domain.Interfaces.IServices;
using CrudAPI.Infra.Data.Repository.Context;
using CrudAPI.Infra.Data.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:7110");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

// # Independency Injection
// Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Services
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
