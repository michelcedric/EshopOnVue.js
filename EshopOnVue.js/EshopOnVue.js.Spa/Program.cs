using EshopOnVue.js.Infrastructure.Data;
using MinimalApi.Endpoint.Configurations.Extensions;
using MinimalApi.Endpoint.Extensions;
using MinimalApi.Endpoint.SwaggerGen.Extensions;
using System.Reflection;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfigurationFile("appsettings.int.json");
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpoints();
builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Eshop on web",
        Version = "v1"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.CustomEndpointOperationIds();
});

EshopOnVue.js.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseSpaStaticFiles();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eshop on web Api V1");
});

var seedOnStartup = false;
if (builder.Configuration["SeedOnStartup"] != null)
{
    seedOnStartup = bool.Parse(builder.Configuration["SeedOnStartup"]);
}
if (seedOnStartup)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<EshopContext>();
        CatalogItemSeed.Seed(context);
    }
}

app.UseSpa(spa =>
{
    if (app.Environment.IsDevelopment())
        spa.Options.SourcePath = "ClientApp/";
    else
        spa.Options.SourcePath = "ClientApp/dist";

    if (app.Environment.IsDevelopment())
    {
        spa.UseVueCli(npmScript: "serve");
    }

});

app.MapEndpoints();

app.Run();

public partial class Program { }