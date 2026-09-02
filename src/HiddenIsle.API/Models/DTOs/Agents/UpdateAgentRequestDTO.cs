using System.ComponentModel.DataAnnotations;
using HiddenIsle.API.Models;

namespace HiddenIsle.API.Models.DTOs.Agents;

public record UpdateAgentRequestDto
{
    public Class Class { get; init; }
    public int AgentLevel { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Age { get; init; } = string.Empty;
    public string Culture { get; init; } = string.Empty;
    public string Look { get; init; } = string.Empty;

    public CreateInventoryDTO Inventory { get; init; } = new();

    [Range(0, 9)]
    public int AbilityTrackXP { get; init; }

    public string Notes { get; init; } = string.Empty;

    public List<string> Burdens { get; init; } = new();
    public List<string> Vices { get; init; } = new();
    public List<string> Virtues { get; init; } = new();
    public List<string> Ideals { get; init; } = new();

    public CreateCoreSelfDTO CoreSelf { get; init; } = new();
}