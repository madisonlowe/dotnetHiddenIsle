using HiddenIsle.API.Models;
using HiddenIsle.API.Models.DTOs.Agents;
using HiddenIsle.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace HiddenIsle.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentController : ControllerBase
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpPost]
    public async Task<ActionResult<AgentResponseDto>> CreateAgent(
        [FromBody] CreateAgentRequestDto request,
        CancellationToken cancellationToken = default)
    {

        if (request is null)
        {
            return BadRequest();
        }

        var createdAgent = await _agentService.CreateAgentAsync(request, cancellationToken);

        return CreatedAtAction(
            nameof(GetAgentById),
            new { id = createdAgent.Id },
            createdAgent
        );
    }

    [HttpGet]
    public async Task<ActionResult<List<AgentResponseDto>>> GetAllAgents(
        CancellationToken cancellationToken = default)
    {
        var agents = await _agentService.GetAllAgentsAsync(cancellationToken);
        return Ok(agents);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AgentResponseDto>> GetAgentById(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        var agent = await _agentService.GetAgentByIdAsync(id, cancellationToken);

        return Ok(agent);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<AgentResponseDto>> UpdateAgent(
        Guid id,
        [FromBody] UpdateAgentRequestDto request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            return BadRequest();
        }

        var updatedAgent = await _agentService.UpdateAgentAsync(id, request, cancellationToken);

        return Ok(updatedAgent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAgent(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await _agentService.DeleteAgentAsync(id, cancellationToken);
        return NoContent();
    }
    
}
