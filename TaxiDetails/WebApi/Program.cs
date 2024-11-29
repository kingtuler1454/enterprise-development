using TaxiDetails;
using TaxiDetails.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaxiDetails.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateConverter());
});

builder.Services.AddSingleton<IRepository<User, int>, UserRepository>();
builder.Services.AddSingleton<IRepository<Driver, int>, DriverRepository>();
builder.Services.AddSingleton<IRepository<Car, int>, CarRepository>();
builder.Services.AddSingleton<IRepository<Travel, int>, TravelRepository>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
