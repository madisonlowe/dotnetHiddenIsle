using HiddenIsle.API.Models;
using HiddenIsle.API.Models.DTOs.Agent;
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
        CancellationToken cancellationToken)
    {
        var created = await _agentService.CreateAgentAsync(request, cancellationToken);

        return CreatedAtAction(
            nameof(GetAgentById),
            new { id = created.Id },
            created
        );
    }

    // READ ALL AGENTS
    [HttpGet]
    public async Task<ActionResult<List<Agent>>> GetAllAgents()
    {
        var agents = await _agentService.GetAllAgentsAsync(cancellationToken: default);
        return Ok(agents);
    }

    // READ AGENT BY ID
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Agent>> GetAgentById(Guid id)
    {
        var agent = await _agentService.GetAgentByIdAsync(id, cancellationToken: default);
        if (agent is null) return NotFound();
        return Ok(agent);
    }

    // UPDATE AGENT

    // DELETE AGENT
}
