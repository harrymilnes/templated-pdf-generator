using System.Text.Json;
using Scriban;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatePdfGenerator.TemplateEngine.Scriban;

public class TemplateEngine : ITemplateEngine
{
    public async Task<string> ParseTemplateAsync(string templateContent, Dictionary<string, JsonElement> placeholderData)
    {
        var parsedTemplate = Template.Parse(templateContent);
        return await parsedTemplate.RenderAsync(placeholderData);
    }
}