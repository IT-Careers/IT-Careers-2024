public class Item
{
    public Item(string name, int weight, int value)
    {
        this.Name = name;
        this.Weight = weight;
        this.Value = value;
    }

    public string Name { get; set; }

    public int Weight { get; set; }

    public int Value { get; set; }
}