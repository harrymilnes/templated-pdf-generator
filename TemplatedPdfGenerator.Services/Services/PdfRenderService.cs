using System.Text.Json;
using TemplatedPdfGenerator.Infrastructure.Repositories;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatedPdfGenerator.Services.Services;

public class PdfRenderService : IPdfRenderService
{
    private readonly ITemplateRepository _templateRepository;
    private readonly ITemplateEngine _templateEngine;
    private readonly IPdfRenderer _pdfRenderer;

    public PdfRenderService(ITemplateRepository templateRepository, ITemplateEngine templateEngine, IPdfRenderer pdfRenderer)
    {
        _templateRepository = templateRepository;
        _templateEngine = templateEngine;
        _pdfRenderer = pdfRenderer;
    }

    public async Task<Stream> GenerateAsync(string templateName, Dictionary<string, JsonElement> placeholderData)
    {
        var template = await _templateRepository.GetTemplateAsync(templateName);
        if (template == null)
        {
            throw new FileNotFoundException("Template not found", templateName);
        }

        var parsedTemplate = await _templateEngine.ParseTemplateAsync(template, placeholderData);
        var renderedPdf = await _pdfRenderer.RenderAsync(parsedTemplate);
        return renderedPdf;
    }
}