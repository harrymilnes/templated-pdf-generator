namespace TemplatedPdfGenerator.Services.Interfaces;

public interface ITemplateEngine
{
    Task<string> ParseTemplateAsync(string templateContent, object templatePlaceholderData);
}