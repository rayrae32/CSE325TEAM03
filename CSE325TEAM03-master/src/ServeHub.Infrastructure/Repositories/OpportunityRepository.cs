using Microsoft.EntityFrameworkCore;
using ServeHub.Application.Interfaces;
using ServeHub.Domain.Entities;
using ServeHub.Infrastructure.Data;

namespace ServeHub.Infrastructure.Repositories;

public class OpportunityRepository : IOpportunityRepository
{
    private readonly AppDbContext _context;

    public OpportunityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServiceOpportunity>> GetAllAsync()
    {
        return await _context.ServiceOpportunities
            .Include(o => o.Creator)
            .OrderByDescending(o => o.Date)
            .ToListAsync();
    }

    public async Task<ServiceOpportunity?> GetByIdAsync(int id)
    {
        return await _context.ServiceOpportunities
            .Include(o => o.Creator)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<ServiceOpportunity> CreateAsync(ServiceOpportunity opportunity)
    {
        _context.ServiceOpportunities.Add(opportunity);
        return opportunity;
    }

    public async Task<ServiceOpportunity> UpdateAsync(ServiceOpportunity opportunity)
    {
        _context.ServiceOpportunities.Update(opportunity);
        return opportunity;
    }

    public async Task DeleteAsync(ServiceOpportunity opportunity)
    {
        _context.ServiceOpportunities.Remove(opportunity);
    }

    public async Task<bool> IsUserSignedUpAsync(int userId, int opportunityId)
    {
        return await _context.SignUps
            .AnyAsync(s => s.UserId == userId && s.OpportunityId == opportunityId);
    }

    public async Task<SignUp> SignUpAsync(SignUp signUp)
    {
        _context.SignUps.Add(signUp);
        return signUp;
    }

    public async Task<CompletedService> CompleteServiceAsync(CompletedService completedService)
    {
        _context.CompletedServices.Add(completedService);
        return completedService;
    }

    public async Task<bool> IsServiceCompletedAsync(int userId, int opportunityId)
    {
        return await _context.CompletedServices
            .AnyAsync(c => c.UserId == userId && c.OpportunityId == opportunityId);
    }

    public async Task<List<CompletedService>> GetUserHistoryAsync(int userId)
    {
        return await _context.CompletedServices
            .Include(c => c.Opportunity)
            .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.CompletionDate)
            .ToListAsync();
    }
}
