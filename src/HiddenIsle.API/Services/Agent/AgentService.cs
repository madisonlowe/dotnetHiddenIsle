using HiddenIsle.API.Data;
using HiddenIsle.API.Models;
using HiddenIsle.API.Models.DTOs.Agent;
using Microsoft.EntityFrameworkCore;

namespace HiddenIsle.API.Services;

public class AgentService : IAgentService
{
    private readonly AppDbContext _db;

    public AgentService(AppDbContext db)
    {
        _db = db;
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

        await _db.Agents.AddAsync(agent, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return new AgentResponseDto
        {
            Id = agent.Id,
            Class = agent.Class,
            AgentLevel = agent.AgentLevel,
            Name = agent.Name,
            Age = agent.Age,
            Culture = agent.Culture,
            Look = agent.Look,
            AbilitySuits = agent.AbilitySuits,
            Inventory = agent.Inventory,
            Abilities = agent.Abilities,
            AbilityTrackXP = agent.AbilityTrackXP,
            MagicalProficiencies = agent.MagicalProficiencies,
            MagicalSources = agent.MagicalSources,
            Notes = agent.Notes,
            Contacts = agent.Contacts,
            Burdens = agent.Burdens,
            Vices = agent.Vices,
            Virtues = agent.Virtues,
            Ideals = agent.Ideals,
            CoreSelf = agent.CoreSelf
        };
    }

    public async Task<List<Agent>> GetAllAgentsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _db.Agents.ToListAsync(cancellationToken);
    }

    public async Task<Agent?> GetAgentByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        return await _db.Agents.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }
}