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

    public async Task<Stream> GenerateAsync(string pdfTemplateName, object bodyContent)
    {
        var template = await _templateRepository.GetTemplateAsync(pdfTemplateName);
        if (template == null)
        {
            throw new FileNotFoundException("Template not found", pdfTemplateName);
        }

        var parsedTemplate = await _templateEngine.ParseTemplateAsync(template, bodyContent);
        var renderedPdf = await _pdfRenderer.RenderAsync(parsedTemplate);
        return renderedPdf;
    }
}