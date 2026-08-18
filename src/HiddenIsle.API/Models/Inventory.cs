public class Inventory
{
    public int Load { get; set; } = 0; // max of 5

    public List<string> Items { get; set; } = new();
}