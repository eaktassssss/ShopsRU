 
 
using ShopsRU.Application.Validators;
using ShopsRU.Host.Attributes;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using FluentValidation.AspNetCore;
using ShopsRU.Persistence.Bootstrapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
            .AddFluentValidation(configuration => configuration
                .RegisterValidatorsFromAssemblyContaining<ProductValidator>())
            .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);


builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shops RU", Version = "v1" });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shops RU V1");
        c.DocumentTitle = "Shops RU V1 Docs";
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        c.InjectStylesheet("/assets/css/swagger-ui.css");
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger();
app.UseStaticFiles();
app.MapControllers();
app.Run();
