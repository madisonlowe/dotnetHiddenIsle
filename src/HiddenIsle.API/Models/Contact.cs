using System.ComponentModel.DataAnnotations;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Range(0, 6, ErrorMessage = "Affection must be between 0 and 6.")]
    public int Affection { get; set; } = 6; // max of 6

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Card { get; set; } = string.Empty;

    public string Land { get; set; } = string.Empty;

    [Range(0, 3, ErrorMessage = "Distance must be between 0 and 3.")]
    public int Distance { get; set; } = 0; // max of 3

}