using HiddenIsle.API.Data;
using HiddenIsle.API.Models;
using HiddenIsle.API.Models.DTOs.Agents;
using Microsoft.EntityFrameworkCore;

namespace HiddenIsle.API.Services;

public class AgentService(AppDbContext context) : IAgentService
{
    private static IQueryable<Agent> IncludeAgentRelationships(IQueryable<Agent> agents)
    {
        return agents
            .Include(agent => agent.AbilitySuits)
                .ThenInclude(suit => suit.Skills)
            .Include(agent => agent.Abilities)
            .Include(agent => agent.MagicalProficiencies)
            .Include(agent => agent.MagicalSources)
            .Include(agent => agent.Contacts);
    }

    public async Task<AgentResponseDto> CreateAgentAsync(
        CreateAgentRequestDto request, 
        CancellationToken cancellationToken = default)
    {
        var agent = new Agent
        {
            Id = Guid.NewGuid(),
            Class = request.Class,
            AgentLevel = request.AgentLevel,
            Name = request.Name,
            Age = request.Age,
            Culture = request.Culture,
            Look = request.Look,
            AbilitySuits = request.AbilitySuits,
            Inventory = new Inventory
            {
                Load = request.Inventory.Load,
                Items = request.Inventory.Items
            },
            Abilities = request.Abilities,
            AbilityTrackXP = request.AbilityTrackXP,
            MagicalProficiencies = request.MagicalProficiencies,
            MagicalSources = request.MagicalSources,
            Notes = request.Notes,
            Contacts = request.Contacts
                .Select(contact => new Contact
                {
                    Affection = contact.Affection,
                    Name = contact.Name,
                    Description = contact.Description,
                    Card = contact.Card,
                    Land = contact.Land,
                    Distance = contact.Distance
                })
                .ToList(),
            Burdens = request.Burdens,
            Vices = request.Vices,
            Virtues = request.Virtues,
            Ideals = request.Ideals,
            CoreSelf = new CoreSelf
            {
                ChildSelf = request.CoreSelf.ChildSelf,
                AdultSelf = request.CoreSelf.AdultSelf,
                FulfilledVirtues = request.CoreSelf.FulfilledVirtues
            }
        };

        await context.Agents.AddAsync(agent, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new AgentResponseDto(agent);
    }

    public async Task<List<AgentResponseDto>> GetAllAgentsAsync(
        CancellationToken cancellationToken = default)
    {
        var agents = await IncludeAgentRelationships(context.Agents)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return agents.Select(agent => new AgentResponseDto(agent)).ToList();
    }

    public async Task<AgentResponseDto> GetAgentByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        var agent = await IncludeAgentRelationships(context.Agents)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (agent is null) throw new KeyNotFoundException($"Agent with {id} not found");
        return new AgentResponseDto(agent);
    }

    public async Task<AgentResponseDto> UpdateAgentAsync(
        Guid id,
        UpdateAgentRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var agent = await context.Agents
            .FirstOrDefaultAsync(agent => agent.Id == id, cancellationToken);

        if (agent is null)
        {
            throw new KeyNotFoundException($"Agent with ID {id} not found.");
        }

        agent.Class = request.Class;
        agent.AgentLevel = request.AgentLevel;
        agent.Name = request.Name;
        agent.Age = request.Age;
        agent.Culture = request.Culture;
        agent.Look = request.Look;
        agent.Inventory.Load = request.Inventory.Load;
        agent.Inventory.Items = request.Inventory.Items;
        agent.AbilityTrackXP = request.AbilityTrackXP;
        agent.Notes = request.Notes;
        agent.Burdens = request.Burdens;
        agent.Vices = request.Vices;
        agent.Virtues = request.Virtues;
        agent.Ideals = request.Ideals;
        agent.CoreSelf.ChildSelf = request.CoreSelf.ChildSelf;
        agent.CoreSelf.AdultSelf = request.CoreSelf.AdultSelf;
        agent.CoreSelf.FulfilledVirtues = request.CoreSelf.FulfilledVirtues;

        await context.SaveChangesAsync(cancellationToken);

        return new AgentResponseDto(agent);
    }

    // delete agent by id
    public async Task DeleteAgentAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        var agent = await context.Agents.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        if (agent == null)
        {
            throw new KeyNotFoundException($"Agent with ID {id} not found.");
        }

        context.Agents.Remove(agent);
        await context.SaveChangesAsync(cancellationToken);
    }
}