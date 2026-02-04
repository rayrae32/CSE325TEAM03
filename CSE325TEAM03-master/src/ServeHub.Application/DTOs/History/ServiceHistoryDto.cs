namespace ServeHub.Application.DTOs.History;

public class ServiceHistoryDto
{
    public string Title { get; set; } = string.Empty;
    public DateTimeOffset Date { get; set; }
    public DateTimeOffset CompletionDate { get; set; }
}
