using TextAdventure.Items.Items;

namespace TextAdventure.Characters;
using TextAdventure.Items;

public class Player(string name, int health) : Character(name, health)
{
    public int Gold { get; private set; }

    public readonly Item?[] Inventory = new Item?[3];

    public void ItemPurchased()
    {
        
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }
    
    public void UseItem(int index)
    {
        var item = Inventory[index];
        switch (item!.Type)
        {
            case Item.ItemType.Healing:
                Heal((item as HealthPotion)!.HealAmount);
                break;
            case Item.ItemType.Key:
                TextHandler.PrettyWrite("The enemy doesn't seem to have a keyhole!", isLastLine: true);
                break;
            default:
                TextHandler.PrettyWrite("Item is not usable.", TextHandler.TextType.Bad, true);
                break;
        }
    }
}