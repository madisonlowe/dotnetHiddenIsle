using HiddenIsle.API.Models;
using HiddenIsle.API.Models.DTOs.Agent;

namespace HiddenIsle.API.Services;

public interface IAgentService
{
    Task<AgentResponseDto> CreateAgentAsync(
        CreateAgentRequestDto request,
        CancellationToken cancellationToken = default);

    Task<List<AgentResponseDto>> GetAllAgentsAsync(
        CancellationToken cancellationToken = default);

    Task<Agent?> GetAgentByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<AgentResponseDto> UpdateAgentAsync(
        Guid id,
        UpdateAgentRequestDto request,
        CancellationToken cancellationToken = default);
    
    Task DeleteAgentAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}