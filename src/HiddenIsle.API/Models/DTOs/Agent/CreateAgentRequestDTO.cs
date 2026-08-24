using System.ComponentModel.DataAnnotations;

namespace HiddenIsle.API.Models.DTOs.Agent;


public class CreateContactDTO
{
    [Range(0, 6, ErrorMessage = "Affection must be between 0 and 6.")]
    public int Affection { get; set; } = 6;

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Card { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;

    [Range(0, 3, ErrorMessage = "Distance must be between 0 and 3.")]
    public int Distance { get; set; }
}

public class CreateCoreSelfDTO
{
    public string ChildSelf { get; set; } = string.Empty;
    public string AdultSelf { get; set; } = string.Empty;
    public List<string> FulfilledVirtues { get; set; } = new();
}

public class CreateInventoryDTO
{
    [Range(0, 5, ErrorMessage = "Load must be between 0 and 5.")]
    public int Load { get; set; }

    public List<string> Items { get; set; } = new();
}

public class CreateAgentRequestDto
{
    public Class Class { get; set; } = new();
    public int AgentLevel { get; set; } = 1;

    public string Name { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public string Look { get; set; } = string.Empty;

    public List<AbilitySuits> AbilitySuits { get; set; } = new();
    public CreateInventoryDTO Inventory { get; set; } = new();

    public List<Ability> Abilities { get; set; } = new();

    [Range(0, 9, ErrorMessage = "AbilityTrackXP must be between 0 and 9.")]
    public int AbilityTrackXP { get; set; } = 0;

    public List<MagicalProficiency> MagicalProficiencies { get; set; } = new();
    public List<MagicalSource> MagicalSources { get; set; } = new();

    public string Notes { get; set; } = string.Empty;
    public List<CreateContactDTO> Contacts { get; set; } = new();

    public List<string> Burdens { get; set; } = new();
    public List<string> Vices { get; set; } = new();
    public List<string> Virtues { get; set; } = new();
    public List<string> Ideals { get; set; } = new();

    public CreateCoreSelfDTO CoreSelf { get; set; } = new();
}