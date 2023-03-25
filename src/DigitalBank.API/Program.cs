using DigitalBank.Infra.Context;
using Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DataBase.
var connectionString = builder.Configuration.GetConnectionString("DigitalBank");
builder.Services.AddDbContext<DigitalBankContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add Infra
builder.Services.AddInfra(builder.Configuration);

// Add Services
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
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
https://help.openai.com/en/collections/3742473-chatgpt
app.MapControllers();

app.Run();
