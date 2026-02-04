using ServeHub.Application.DTOs.History;
using ServeHub.Application.DTOs.Opportunities;

namespace ServeHub.Application.Interfaces;

public interface IOpportunityService
{
    Task<List<ServiceOpportunityListDto>> GetAllAsync();
    Task<ServiceOpportunityDetailDto?> GetByIdAsync(int id, int? userId = null);
    Task<ServiceOpportunityDetailDto> CreateAsync(CreateServiceOpportunityDto dto, int creatorUserId);
    Task<ServiceOpportunityDetailDto> UpdateAsync(int id, UpdateServiceOpportunityDto dto, int userId);
    Task DeleteAsync(int id, int userId);
    Task SignUpAsync(int opportunityId, int userId);
    Task CompleteServiceAsync(int opportunityId, int userId);
    Task<List<ServiceHistoryDto>> GetUserHistoryAsync(int userId);
}
