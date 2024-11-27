using Microsoft.Extensions.DependencyInjection;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatePdfGenerator.TemplateEngine.Scriban;

public static class Setup
{
    public static void SetupScribanTemplateEngine(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ITemplateEngine, TemplateEngine>();
    }
}