using ServeHub.Domain.Entities;

namespace ServeHub.Application.Interfaces;

public interface IOpportunityRepository
{
    Task<List<ServiceOpportunity>> GetAllAsync();
    Task<ServiceOpportunity?> GetByIdAsync(int id);
    Task<ServiceOpportunity> CreateAsync(ServiceOpportunity opportunity);
    Task<ServiceOpportunity> UpdateAsync(ServiceOpportunity opportunity);
    Task DeleteAsync(ServiceOpportunity opportunity);
    Task<bool> IsUserSignedUpAsync(int userId, int opportunityId);
    Task<SignUp> SignUpAsync(SignUp signUp);
    Task<CompletedService> CompleteServiceAsync(CompletedService completedService);
    Task<bool> IsServiceCompletedAsync(int userId, int opportunityId);
    Task<List<CompletedService>> GetUserHistoryAsync(int userId);
}
