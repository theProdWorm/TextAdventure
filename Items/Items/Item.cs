using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public abstract class Item(string name)
{
    public enum ItemType
    {
        Healing,
        Key,
        Weapon,
        Armor
    }
    
    public string Name { get; } = name;
    public ItemType Type { get; } = ItemType.Healing;
}
