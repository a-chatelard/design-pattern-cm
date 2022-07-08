using System.Reflection;
using CM.API.Controllers.Converters;
using CM.API.Modules;
using CM.Application;
using MediatR;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(AddSwaggerDocumentation);


builder.Services.AddMediatR(typeof(ApplicationEntryPoint).Assembly);

builder.Services.AddDatabaseModule(builder.Configuration);

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

static void AddSwaggerDocumentation(SwaggerGenOptions o)
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}