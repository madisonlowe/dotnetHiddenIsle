namespace HiddenIsle.API.Models.DTOs.Agents;

public record AgentResponseDto(
    Guid Id,
    Class Class,
    int AgentLevel,
    string Name,
    string Age,
    string Culture,
    string Look,
    List<AbilitySuits> AbilitySuits,
    Inventory Inventory,
    List<Ability> Abilities,
    int AbilityTrackXP,
    List<MagicalProficiency> MagicalProficiencies,
    List<MagicalSource> MagicalSources,
    string Notes,
    List<Contact> Contacts,
    List<string> Burdens,
    List<string> Vices,
    List<string> Virtues,
    List<string> Ideals,
    CoreSelf CoreSelf
)
{
    public AgentResponseDto(Agent agent) : this(
        agent.Id,
        agent.Class,
        agent.AgentLevel,
        agent.Name,
        agent.Age,
        agent.Culture,
        agent.Look,
        agent.AbilitySuits,
        agent.Inventory,
        agent.Abilities,
        agent.AbilityTrackXP,
        agent.MagicalProficiencies,
        agent.MagicalSources,
        agent.Notes,
        agent.Contacts,
        agent.Burdens,
        agent.Vices,
        agent.Virtues,
        agent.Ideals,
        agent.CoreSelf
    )
    {
    }
}