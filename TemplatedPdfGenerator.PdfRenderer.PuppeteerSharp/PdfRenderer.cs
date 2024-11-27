using PuppeteerSharp;
using PuppeteerSharp.BrowserData;
using PuppeteerSharp.Media;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatedPdfGenerator.PdfRenderer.PuppeteerSharp;

public class PdfRenderer : IPdfRenderer
{
    public async Task<Stream> RenderAsync(string parsedTemplate)
    {
        var initialisedBrowser = await InitialiseBrowserAsync();
        
        var pdfOptions = new PdfOptions
        {
            Format = PaperFormat.A4
        };

        var launchedBrowser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            ExecutablePath = initialisedBrowser.GetExecutablePath()
        });
        
        await using var browserPage = await launchedBrowser.NewPageAsync();
        await browserPage.SetContentAsync(parsedTemplate, new NavigationOptions());
        return await browserPage.PdfStreamAsync(pdfOptions);
    }
    
    private static async Task<InstalledBrowser> InitialiseBrowserAsync()
    {
        var browserPath = Path.Combine(Path.GetTempPath());
        var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions { Path = browserPath });
        var browser = await browserFetcher.DownloadAsync(Chrome.DefaultBuildId);
        return browser;
    }
}