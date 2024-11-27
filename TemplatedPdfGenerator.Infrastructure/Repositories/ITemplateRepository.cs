namespace TemplatedPdfGenerator.Infrastructure.Repositories;

public interface ITemplateRepository
{
    Task<string> GetTemplateAsync(string templateName);
}