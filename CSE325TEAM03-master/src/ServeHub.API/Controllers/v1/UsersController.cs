using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServeHub.API.Extensions;
using ServeHub.Application.DTOs.History;
using ServeHub.Application.Interfaces;

namespace ServeHub.API.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IOpportunityService _opportunityService;

    public UsersController(IOpportunityService opportunityService)
    {
        _opportunityService = opportunityService;
    }

    [HttpGet("me/history")]
    public async Task<ActionResult<List<ServiceHistoryDto>>> GetMyHistory()
    {
        var userId = User.GetUserIdOrNull();
        if (!userId.HasValue)
            return Unauthorized();

        var history = await _opportunityService.GetUserHistoryAsync(userId.Value);
        
        return Ok(history);
    }
}
