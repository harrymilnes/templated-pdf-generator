using Microsoft.Extensions.DependencyInjection;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatedPdfGenerator.PdfRenderer.PuppeteerSharp;

public static class Setup
{
    public static void SetupPuppeteerSharpPdfRenderer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IPdfRenderer,PdfRenderer>();
    }
}