namespace ServeHub.Domain.Entities;

public class ServiceOpportunity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset Date { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    
    public int CreatorUserId { get; set; }
    public User Creator { get; set; } = null!;
}
