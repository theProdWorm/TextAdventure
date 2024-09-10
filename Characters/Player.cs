using TextAdventure.Items.Items;

namespace TextAdventure.Characters;
using TextAdventure.Items;

public class Player(int health) : Character(health)
{
    public int Gold { get; private set; }
    
    private List<Item> _items = new(2);

    public void ItemPurchased()
    {
        
    }

    public void AddGold(int amount)
    {
        Gold += amount;
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