
using ShopsRU.Application.Validators;
using ShopsRU.Host.Attributes;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using FluentValidation.AspNetCore;
using ShopsRU.Persistence.Bootstrapper;
using Asp.Versioning;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
            .AddFluentValidation(configuration => configuration
                .RegisterValidatorsFromAssemblyContaining<ProductValidator>())
            .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(x =>
{
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.DefaultApiVersion = ApiVersion.Default;
    x.ReportApiVersions = true;
    x.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader()
        );
}).AddApiExplorer(x =>
{
    x.GroupNameFormat = "'v'V";
    x.SubstituteApiVersionInUrl = true;
});

builder.Services.AddOpenTelemetry().WithTracing(configuration =>
{

    configuration.ConfigureResource(x =>
    {
        x.AddService("ShopsRU.Host", serviceVersion: "1.0.0");
    });
    configuration.AddOtlpExporter(otlpOptions =>
    {
        otlpOptions.Endpoint = new Uri("http://localhost:4317");
    });
    configuration.AddAspNetCoreInstrumentation(options =>
    {
        options.Filter = (req) => !req.Request.Path.StartsWithSegments("/swagger");
    });

});
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

































































 