using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneNumber.Application;
using PhoneNumber.Application.Interfaces;
using PhoneNumber.Application.Services;
using PhoneNumber.Extensions;
using PhoneNumber.Infrastructure;
using PhoneNumber.Infrastructure.Contexts;
using PhoneNumber.Infrastructure.Services;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("PhoneApiDb"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddApiVersioningExtension();
builder.Services.AddSwaggerExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();
builder.Services.AddOptions();

builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();


// Configure Serilog for logging
Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File("logs/PhoneNumber-.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Error seeding database");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

app.UseSwaggerExtension();
app.MapControllers();

app.Run();