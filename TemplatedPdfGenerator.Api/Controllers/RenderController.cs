using Microsoft.AspNetCore.Mvc;
using TemplatedPdfGenerator.Api.Models;
using TemplatedPdfGenerator.Services.Interfaces;

namespace TemplatedPdfGenerator.Api.Controllers;

[Route("api")]
[ApiController]
public class RenderController : ControllerBase
{
    private readonly IPdfRenderService _pdfRenderService;

    public RenderController(IPdfRenderService pdfRenderService)
    {
        _pdfRenderService = pdfRenderService;
    }

    [HttpPost("render")]
    public async Task<IActionResult> RenderAsync([FromBody] RenderRequest renderRequest)
    {
        if (renderRequest.TemplateName == null || renderRequest.PlaceholderData == null)
            return BadRequest();
        
        var content = await _pdfRenderService.GenerateAsync(renderRequest.TemplateName, renderRequest.PlaceholderData);
        return File(content, "application/pdf");
    }
}