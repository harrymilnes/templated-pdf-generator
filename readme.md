# templated-pdf-generator
`templated-pdf-generator` is a **proof-of-concept** API designed for generating PDF documents by parsing pre-defined templates and replacing placeholders with requested data.

## Features
- **Template Parsing**: Parses templates stored in the `Templates` directory, replacing placeholders with dynamic data.
- **PDF Generation**: Dynamically convert parsed templates into PDFs.
- **Extensible Design**:
  - Template Engine Interface: `ITemplateEngine` (default implementation: [Scriban](https://github.com/scriban/scriban)).
  - PDF Renderer Interface: `IPdfRenderer` (default implementation: [IronPDF](https://ironpdf.com/)).
- **Customisable**: Easily swap out the default template engine or PDF renderer with alternatives.
  
## How It Works

### Interfaces

#### `ITemplateEngine`
The `ITemplateEngine` interface is responsible for parsing templates and replacing placeholders with dynamic data.

#### `IPdfRenderer`
The `IPdfRenderer` interface handles rendering the parsed template content into a PDF.

### Default Implementations
- **Template Engine**: The default implementation uses [Scriban](https://github.com/scriban/scriban) for template parsing.
- **PDF Renderer**: The default implementation uses [IronPDF](https://ironpdf.com/) for rendering PDFs.

### Directory Structure
Templates should be stored in the following directory `TemplatedPdfGenerator.Infrastructure\Templates`

### Template Example
```html
<html>
    <body>
        <div class="letter-container">
            <h1>{{ header }}</h1>
            <p>Dear {{ recipient_name }},</p>
            <p>{{ content }}</p>
            <p>Best Regards,</p>
            <p>{{ company_name }}</p>
        </div>
    </body>
</html>
```

### Render Request Example
Send POST request to `https://localhost:7106/api/render`
```json
{
  "templateName": "example",
   "title": "Exciting News",
   "recipientName": "Jane Smith",
   "content": "Hello world!",
   "senderName": "MilnesDotOrg"
}
```

## Alternative Engines and Renderers

### ViewEngines
If you wish to use a different template engine, consider these popular alternatives:
- [RazorEngine](https://github.com/Antaris/RazorEngine): Razor-based templating for .NET.
- [Fluid](https://github.com/sebastienros/fluid): A lightweight, Liquid-based templating engine.
- [Cottle](https://github.com/Cottle/Cottle): A fast, extensible template engine.

### PDF Renderers
If you want to replace the default PDF renderer, here are some alternative options:
- [Puppeteer.NET](https://github.com/hardkoded/puppeteer-sharp): A .NET port of the popular Puppeteer library for headless browser rendering.
- [WKHtmlToPdf](https://github.com/wkhtmltopdf/wkhtmltopdf): A command-line tool that uses WebKit to render HTML to PDF.

## Recommended Improvements

- **Store Templates Via Object Storage**: Store templates somewhere they can be easily and dynamically amended.
- **White Labeling**: Most PDF renderers, including IronPDF, allow you to define custom headers and footers, making it possible to create branded PDF documents. Implementing white-labeling via partial templates would allow content reuse.
 - **White Labeling**: Implement headers and footers for branded PDF generation.
- **Add Rate Limiting**: Implement Rate Limiting: Prevent API throttling by limiting excessive requests. Possibly improve further by implementing a queueing system or a similar.