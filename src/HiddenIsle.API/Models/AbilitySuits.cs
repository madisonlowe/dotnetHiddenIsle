public class AbilitySuits
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public List<SuitSkill> Skills { get; set; } = new();

    /*
    - ABILITY SUITS: 
    - Skirmish, Convince, Study, XP, Harm
    - Unleash, Perform, Channel, XP, Harm
    - Slip, Soothe, Mingle, XP, Harm
    - Finesse, Bargain, Survey, XP, Harm
    */
}