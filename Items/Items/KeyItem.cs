namespace TextAdventure.Items.Items;

public class KeyItem : Item
{
    public KeyItem() : base("Key")
    {
        Type = ItemType.Key;
    }
    
    public override string ToString()
    {
        return Name;
    }
}