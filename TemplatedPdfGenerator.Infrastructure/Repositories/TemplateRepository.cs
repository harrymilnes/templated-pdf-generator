using System.Reflection;

namespace TemplatedPdfGenerator.Infrastructure.Repositories;

public class TemplateRepository : ITemplateRepository
{
    public async Task<string> GetTemplateAsync(string templateName)
    {
        var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var filePath = Path.Combine(executableLocation ?? throw new InvalidOperationException(), $"Templates/{templateName}.html");
        using StreamReader streamReader = new(filePath);
        return await streamReader.ReadToEndAsync();
    }
}