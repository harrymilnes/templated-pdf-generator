namespace TemplatedPdfGenerator.Services.Interfaces;

public interface IPdfRenderer
{
    Task<Stream> RenderAsync(string templateContent);
}