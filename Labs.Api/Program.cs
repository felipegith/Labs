using Labs.Domain.Comand;
using Labs.Infra.Database;
using Labs.Ioc;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Infra();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("MongoDatabase"));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AddNewMarkComand>());

builder.Services.AddRateLimiter(r => r.AddFixedWindowLimiter(policyName: "fixed", options =>
{
    options.Window = TimeSpan.FromSeconds(10);
    options.PermitLimit = 5;
    options.QueueLimit = 5;
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}).RejectionStatusCode = 429);
var app = builder.Build();

app.UseRateLimiter();

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
