namespace TemplatedPdfGenerator.Services.Interfaces;

public interface IPdfRenderService
{
    Task<Stream> GenerateAsync(string pdfTemplateName, object bodyContent);
}