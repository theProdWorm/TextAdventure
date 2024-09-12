using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public abstract class Item(string name)
{
    public enum ItemType
    {
        Healing,
        Key
    }
    
    public string Name { get; } = name.Trim();
    public ItemType Type { get; } = ItemType.Healing;

    public virtual void Print()
    {
        TextHandler.PrettyWrite(Name, TextHandler.TextType.Description);
    }
    
    public new abstract string ToString();
}
