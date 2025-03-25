using Microsoft.EntityFrameworkCore;
using MyTestSalesApi.Validations;
using SalesApi.Events;
using SalesApi.Infrastructure.Data;
using SalesApi.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://+:8090");

var connectionString = builder.Configuration.GetConnectionString("SalesApiDb");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<IEventPublisher, ConsoleEventPublisher>();

builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
