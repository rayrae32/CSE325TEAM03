using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServeHub.API.Extensions;
using ServeHub.Application.DTOs.Opportunities;
using ServeHub.Application.Interfaces;

namespace ServeHub.API.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
// 
public class OpportunitiesController : ControllerBase
{
    private readonly IOpportunityService _opportunityService;

    public OpportunitiesController(IOpportunityService opportunityService)
    {
        _opportunityService = opportunityService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServiceOpportunityListDto>>> GetAll()
    {
        var opportunities = await _opportunityService.GetAllAsync();
        return Ok(opportunities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceOpportunityDetailDto>> GetById(int id)
    {
        var userId = User.GetUserIdOrNull();
        var opportunity = await _opportunityService.GetByIdAsync(id, userId);
        
        if (opportunity == null)
            throw new KeyNotFoundException("Opportunity not found");

        return Ok(opportunity);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ServiceOpportunityDetailDto>> Create([FromBody] CreateServiceOpportunityDto dto)
    {
        var userId = User.GetUserIdOrNull();
        if (!userId.HasValue)
            return Unauthorized();

        var opportunity = await _opportunityService.CreateAsync(dto, userId.Value);
        return CreatedAtAction(nameof(GetById), new { id = opportunity.Id }, opportunity);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceOpportunityDetailDto>> Update(int id, [FromBody] UpdateServiceOpportunityDto dto)
    {
        var userId = User.GetUserIdOrNull();
        if (!userId.HasValue)
            return Unauthorized();

        var opportunity = await _opportunityService.UpdateAsync(id, dto, userId.Value);
        return Ok(opportunity);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var userId = User.GetUserIdOrNull();
        if (!userId.HasValue)
            return Unauthorized();

        await _opportunityService.DeleteAsync(id, userId.Value);
        return NoContent();
    }

    [Authorize]
    [HttpPost("{id}/signup")]
    public async Task<ActionResult> SignUp(int id)
    {
        var userId = User.GetUserIdOrNull();
        if (!userId.HasValue)
            return Unauthorized();

        await _opportunityService.SignUpAsync(id, userId.Value);
        return Ok(new { message = "Successfully signed up" });
    }

    [Authorize]
    [HttpPost("{id}/complete")]
    public async Task<ActionResult> Complete(int id)
    {
        var userId = User.GetUserIdOrNull();
        if (!userId.HasValue)
            return Unauthorized();

        await _opportunityService.CompleteServiceAsync(id, userId.Value);
        return Ok(new { message = "Service marked as completed" });
    }
}
