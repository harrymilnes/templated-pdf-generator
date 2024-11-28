using System.Text.Json;

namespace TemplatedPdfGenerator.Services.Interfaces;

public interface ITemplateEngine
{
    Task<string> ParseTemplateAsync(string templateContent, Dictionary<string, JsonElement> placeholderData);
}