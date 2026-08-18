namespace HiddenIsle.API.Models;

public class Agent
{
    public Guid Id { get; set; }
    public Class Class { get; set; } = new();
    public int AgentLevel { get; set; } = 1;

    public string Name { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public string Look { get; set; } = string.Empty;

    public List<AbilitySuits> AbilitySuits { get; set; } = new();
    public Inventory Inventory { get; set; } = new();

    public List<Ability> Abilities { get; set; } = new();
    public int AbilityTrackXP { get; set; } = 0; // max of 9 then resets to 0, increasing unlocked ability count each time

    public List<MagicalProficiency> MagicalProficiencies { get; set; } = new();
    public List<MagicalSource> MagicalSources { get; set; } = new();

    public string Notes { get; set; } = string.Empty;
    public List<Contact> Contacts { get; set; } = new();

    public List<string> Burdens { get; set; } = new(); // +1 to challenge cards
    public List<string> Vices { get; set; } = new(); // +1 to challenge cards
    public List<string> Virtues { get; set; } = new(); // +3 to card numerals
    public List<string> Ideals { get; set; } = new(); // -1 to challenge cards, +3 to card numerals

    public CoreSelf CoreSelf { get; set; } = new();
}