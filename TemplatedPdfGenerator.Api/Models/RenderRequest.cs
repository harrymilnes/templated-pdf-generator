using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TemplatedPdfGenerator.Api.Models;

public class RenderRequest
{
    [Required]
    public string? TemplateName { get; set; }
    
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? PlaceholderData { get; set; }
}