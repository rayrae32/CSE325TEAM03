using System.ComponentModel.DataAnnotations;

namespace ServeHub.Application.DTOs.Opportunities;

public class UpdateServiceOpportunityDto
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(2000, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTimeOffset Date { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Location { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Category { get; set; } = string.Empty;
}
