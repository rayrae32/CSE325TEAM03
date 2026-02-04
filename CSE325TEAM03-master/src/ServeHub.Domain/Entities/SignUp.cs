namespace ServeHub.Domain.Entities;

public class SignUp
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OpportunityId { get; set; }
    public DateTimeOffset SignupDate { get; set; }
    
    public User User { get; set; } = null!;
    public ServiceOpportunity Opportunity { get; set; } = null!;
}
