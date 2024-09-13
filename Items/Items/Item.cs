using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public abstract class Item(string name, int value = 20)
{
    public enum ItemType
    {
        Healing,
        Key
    }
    
    public string Name { get; } = name.Trim();
    public ItemType Type { get; protected init; } = ItemType.Healing;

    public int Value { get; } = value;

    public virtual void Print()
    {
        TextHandler.PrettyWrite(Name, TextHandler.TextType.Description);
    }
    
    public new abstract string ToString();
}
