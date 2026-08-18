public class MagicalProficiency
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string SchoolName { get; set; } = string.Empty;
    public MasteryLevel CurrentRank { get; set; } = MasteryLevel.Novice;
    public int ClockSegmentsFilled { get; set; }
    public int MaxClockSegments { get; set; } = 4;
}