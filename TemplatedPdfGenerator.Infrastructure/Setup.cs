using Microsoft.Extensions.DependencyInjection;
using TemplatedPdfGenerator.Infrastructure.Repositories;

namespace TemplatedPdfGenerator.Infrastructure;

public static class Setup
{
    public static void SetupRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ITemplateRepository, TemplateRepository>();
    }
}