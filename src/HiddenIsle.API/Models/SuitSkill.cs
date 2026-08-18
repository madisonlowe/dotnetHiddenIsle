public class SuitSkill
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int XP { get; set; } = 1;
    public string Harm { get; set; } = string.Empty;
}