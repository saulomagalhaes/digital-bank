using DigitalBank.API.Filters;
using DigitalBank.Application.Services.Automapper;
using DigitalBank.Infra.Context;
using Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DataBase
var connectionString = builder.Configuration.GetConnectionString("DigitalBank");
builder.Services.AddDbContext<DigitalBankContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add Infra
builder.Services.AddInfra(builder.Configuration);

// Add Services
builder.Services.AddServices(builder.Configuration);

// Add Automapper
builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(config =>
{
    config.AddProfile(new AutomapperConfig());
}).CreateMapper());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Filter Exceptions
builder.Services.AddMvc(options => options.Filters.Add(typeof(FilterExceptions)));

// Add route lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
https://help.openai.com/en/collections/3742473-chatgpt
app.MapControllers();

app.Run();
