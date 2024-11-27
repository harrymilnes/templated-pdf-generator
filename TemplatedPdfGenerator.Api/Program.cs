using TemplatedPdfGenerator.Infrastructure;
using TemplatedPdfGenerator.PdfRenderer.PuppeteerSharp;
using TemplatedPdfGenerator.Services;
using TemplatePdfGenerator.TemplateEngine.Scriban;

namespace TemplatedPdfGenerator.Api;

internal class Program
{
    public static void Main(string[] args)
    {
        var webApplicationBuilder = CreateWebApplicationBuilder(args);
        var webApplication = BuildAndConfigureApplication(webApplicationBuilder);
        webApplication.Run();
    }

    private static WebApplicationBuilder CreateWebApplicationBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddMvc();
        
        builder.Services.SetupServices();
        builder.Services.SetupRepositories();
        builder.Services.SetupScribanTemplateEngine();
        builder.Services.SetupPuppeteerSharpPdfRenderer();
        return builder;
    }

    private static WebApplication BuildAndConfigureApplication(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.Run();
        
        return app;
    }
}