using System.ComponentModel.DataAnnotations;

public class Inventory
{
    [Range(0, 5, ErrorMessage = "Load must be between 0 and 5.")]
    public int Load { get; set; } = 0; // max of 5

    public List<string> Items { get; set; } = new();
}