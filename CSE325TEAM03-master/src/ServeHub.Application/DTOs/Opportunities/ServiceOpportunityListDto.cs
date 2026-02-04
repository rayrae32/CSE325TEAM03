namespace ServeHub.Application.DTOs.Opportunities;

public class ServiceOpportunityListDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}
