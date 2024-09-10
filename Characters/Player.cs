using TextAdventure.Items.Items;

namespace TextAdventure.Characters;

public class Player(string name, int health) : Character(name, health)
{
    public int Gold { get; private set; }
    
    private readonly List<Item> _items = new(3);

    public void ItemPurchased()
    {
        
    }

    public void AcquireGold(int amount)
    {
        
    }
    
    public void UseItem(int index)
    {
        var item = _items[index];
        switch (item.Type)
        {
            case Item.ItemType.Healing:
                Heal((item as HealthPotion)!.HealAmount);
                break;
            case Item.ItemType.Key:
                TextHandler.PrettyWrite("What would that do?", isLastLine: true);
                break;
            default:
                TextHandler.PrettyWrite("Item is not usable.", TextHandler.TextType.Bad, true);
                break;
        }
    }
}