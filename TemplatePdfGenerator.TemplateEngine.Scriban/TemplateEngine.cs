using Scriban;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatePdfGenerator.TemplateEngine.Scriban;

public class TemplateEngine : ITemplateEngine
{
    public async Task<string> ParseTemplateAsync(string templateContent, object templatePlaceholderData)
    {
        var parsedTemplate = Template.Parse(templateContent);
        return await parsedTemplate.RenderAsync(templatePlaceholderData);
    }
}