using System.Text.Json;

namespace TemplatedPdfGenerator.Services.Interfaces;

public interface IPdfRenderService
{
    Task<Stream> GenerateAsync(string templateName, Dictionary<string, JsonElement> placeholderData);
}