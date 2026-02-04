using Microsoft.Extensions.Logging;
using ServeHub.Application.DTOs.History;
using ServeHub.Application.DTOs.Opportunities;
using ServeHub.Application.Interfaces;
using ServeHub.Domain.Entities;

namespace ServeHub.Application.Services;

public class OpportunityService : IOpportunityService
{
    private readonly IOpportunityRepository _opportunityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<OpportunityService> _logger;

    public OpportunityService(IOpportunityRepository opportunityRepository, IUnitOfWork unitOfWork, ILogger<OpportunityService> logger)
    {
        _opportunityRepository = opportunityRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<List<ServiceOpportunityListDto>> GetAllAsync()
    {
        var opportunities = await _opportunityRepository.GetAllAsync();
        
        return opportunities.Select(o => new ServiceOpportunityListDto
        {
            Id = o.Id,
            Title = o.Title,
            Date = o.Date,
            Location = o.Location,
            Category = o.Category
        }).ToList();
    }

    public async Task<ServiceOpportunityDetailDto?> GetByIdAsync(int id, int? userId = null)
    {
        var opportunity = await _opportunityRepository.GetByIdAsync(id);
        
        if (opportunity == null)
            return null;

        bool isUserSignedUp = false;
        if (userId.HasValue)
        {
            isUserSignedUp = await _opportunityRepository.IsUserSignedUpAsync(userId.Value, id);
        }

        return new ServiceOpportunityDetailDto
        {
            Id = opportunity.Id,
            Title = opportunity.Title,
            Description = opportunity.Description,
            Date = opportunity.Date,
            Location = opportunity.Location,
            Category = opportunity.Category,
            IsUserSignedUp = isUserSignedUp,
            CreatorUserId = opportunity.CreatorUserId
        };
    }

    public async Task<ServiceOpportunityDetailDto> CreateAsync(CreateServiceOpportunityDto dto, int creatorUserId)
    {
        var opportunity = new ServiceOpportunity
        {
            Title = dto.Title,
            Description = dto.Description,
            Date = dto.Date,
            Location = dto.Location,
            Category = dto.Category,
            CreatorUserId = creatorUserId
        };

        await _opportunityRepository.CreateAsync(opportunity);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Opportunity created: {OpportunityId} by {UserId}", opportunity.Id, creatorUserId);

        return new ServiceOpportunityDetailDto
        {
            Id = opportunity.Id,
            Title = opportunity.Title,
            Description = opportunity.Description,
            Date = opportunity.Date,
            Location = opportunity.Location,
            Category = opportunity.Category,
            CreatorUserId = opportunity.CreatorUserId,
            IsUserSignedUp = false
        };
    }

    public async Task<ServiceOpportunityDetailDto> UpdateAsync(int id, UpdateServiceOpportunityDto dto, int userId)
    {
        var opportunity = await _opportunityRepository.GetByIdAsync(id);
        
        if (opportunity == null)
            throw new KeyNotFoundException("Opportunity not found");

        if (opportunity.CreatorUserId != userId)
            throw new UnauthorizedAccessException("Only the creator can update this opportunity");

        opportunity.Title = dto.Title;
        opportunity.Description = dto.Description;
        opportunity.Date = dto.Date;
        opportunity.Location = dto.Location;
        opportunity.Category = dto.Category;

        await _opportunityRepository.UpdateAsync(opportunity);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Opportunity updated: {OpportunityId} by {UserId}", opportunity.Id, userId);

        return new ServiceOpportunityDetailDto
        {
            Id = opportunity.Id,
            Title = opportunity.Title,
            Description = opportunity.Description,
            Date = opportunity.Date,
            Location = opportunity.Location,
            Category = opportunity.Category,
            CreatorUserId = opportunity.CreatorUserId,
            IsUserSignedUp = await _opportunityRepository.IsUserSignedUpAsync(userId, id)
        };
    }

    public async Task DeleteAsync(int id, int userId)
    {
        var opportunity = await _opportunityRepository.GetByIdAsync(id);
        
        if (opportunity == null)
            throw new KeyNotFoundException("Opportunity not found");

        if (opportunity.CreatorUserId != userId)
            throw new UnauthorizedAccessException("Only the creator can delete this opportunity");

        await _opportunityRepository.DeleteAsync(opportunity);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Opportunity deleted: {OpportunityId} by {UserId}", opportunity.Id, userId);
    }

    public async Task SignUpAsync(int opportunityId, int userId)
    {
        var opportunity = await _opportunityRepository.GetByIdAsync(opportunityId);
        
        if (opportunity == null)
            throw new KeyNotFoundException("Opportunity not found");

        if (await _opportunityRepository.IsUserSignedUpAsync(userId, opportunityId))
            throw new InvalidOperationException("User already signed up for this opportunity");

        var signUp = new SignUp
        {
            UserId = userId,
            OpportunityId = opportunityId,
            // Store UTC to keep timestamps consistent across time zones.
            SignupDate = DateTimeOffset.UtcNow
        };

        await _opportunityRepository.SignUpAsync(signUp);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("User {UserId} signed up for opportunity {OpportunityId}", userId, opportunityId);
    }

    public async Task CompleteServiceAsync(int opportunityId, int userId)
    {
        var opportunity = await _opportunityRepository.GetByIdAsync(opportunityId);
        
        if (opportunity == null)
            throw new KeyNotFoundException("Opportunity not found");

        if (!await _opportunityRepository.IsUserSignedUpAsync(userId, opportunityId))
            throw new InvalidOperationException("User must be signed up to complete the service");

        if (await _opportunityRepository.IsServiceCompletedAsync(userId, opportunityId))
            throw new InvalidOperationException("Service already completed");

        var completedService = new CompletedService
        {
            UserId = userId,
            OpportunityId = opportunityId,
            // Store UTC to keep timestamps consistent across time zones.
            CompletionDate = DateTimeOffset.UtcNow
        };

        await _opportunityRepository.CompleteServiceAsync(completedService);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("User {UserId} completed opportunity {OpportunityId}", userId, opportunityId);
    }

    public async Task<List<ServiceHistoryDto>> GetUserHistoryAsync(int userId)
    {
        var completedServices = await _opportunityRepository.GetUserHistoryAsync(userId);

        return completedServices.Select(c => new ServiceHistoryDto
        {
            Title = c.Opportunity.Title,
            Date = c.Opportunity.Date,
            CompletionDate = c.CompletionDate
        }).ToList();
    }
}
