using System.ComponentModel.DataAnnotations;

namespace TemplatedPdfGenerator.Api.Models;

public class RenderRequest
{
    [Required]
    public string? TemplateName { get; set; }
    
    [Required]
    public object? Content { get; set; }
}