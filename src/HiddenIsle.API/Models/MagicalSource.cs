public class MagicalSource // can only have one of each type of source
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public MagicalSourceType SourceType { get; set; } = MagicalSourceType.Ambient;
    public string SourceName { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}