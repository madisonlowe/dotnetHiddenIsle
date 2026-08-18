public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Affection { get; set; } = 6; // max of 6
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Card { get; set; } = string.Empty;
    public string Land { get; set; } = string.Empty;
    public int Distance { get; set; } = 0; // max of 3

}