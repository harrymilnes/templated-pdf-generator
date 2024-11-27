using Microsoft.Extensions.DependencyInjection;
using TemplatedPdfGenerator.Services.Interfaces;
using TemplatedPdfGenerator.Services.Services;

namespace TemplatedPdfGenerator.Services;

public static class Setup
{
    public static void SetupServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IPdfRenderService, PdfRenderService>();
    }
}