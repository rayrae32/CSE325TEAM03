namespace ServeHub.Application.DTOs.Opportunities;

public class ServiceOpportunityDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsUserSignedUp { get; set; }
    public int CreatorUserId { get; set; }
}
