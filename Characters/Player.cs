using TextAdventure.Items.Armors;
using TextAdventure.Items.Items;
using TextAdventure.Items.Weapons;

namespace TextAdventure.Characters;
using TextAdventure.Items;

public class Player(string name, int health, Weapon weapon, Armor armor) : Character(name, health, weapon, armor)
{
    public int Gold { get; private set; }

    public readonly Item?[] Inventory = new Item?[3];

    public bool IsInventoryEmpty() => Inventory.All(x => x == null);
    
    public void ItemPurchased()
    {
        
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }
    
    public bool UseItem(int index)
    {
        var item = Inventory[index];
        switch (item!.Type)
        {
            case Item.ItemType.Healing:
                Heal((item as HealthPotion)!.HealAmount);
                Inventory[index] = null;
                return true;
                break;
            case Item.ItemType.Key:
                TextHandler.PrettyWrite("The enemy doesn't seem to have a keyhole!", isLastLine: true);
                return false;
                break;
            default:
                TextHandler.PrettyWrite("Item is not usable.", TextHandler.TextType.Bad, true);
                return false;
                break;
        }
    }
}