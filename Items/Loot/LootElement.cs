namespace TextAdventure.Items.Loot;

public class LootElement<T>(int weight, T Loot)
{
    public int Weight { get; }
    public T Loot { get; }
}