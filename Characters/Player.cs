using TextAdventure.Items.Armors;
using TextAdventure.Items.Items;
using TextAdventure.Items.Loot;
using TextAdventure.Items.Weapons;
using TextAdventure.States;

namespace TextAdventure.Characters;
using TextAdventure.Items;

public class Player : Character
{
    public int Gold { get; private set; }

    public readonly Item?[] Inventory = new Item?[3];

    public Player(string name, int health, Weapon weapon, Armor armor) : base(name, health)
    {
        Equip(weapon);
        Equip(armor);
    }
    
    public bool IsInventoryEmpty() => Inventory.All(x => x == null);
    
    public bool IsInventoryFull() => Inventory.All(x => x != null);
    
    public int EmptyInventorySpaces() => Inventory.Where(x => x == null).Count();
    
    public void ItemPurchased()
    {
        
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        TextHandler.PrettyWrite($"You gained {amount} gold! \n");
    }

    public bool TryPurchaseItem(Item item, int cost)
    {
        if (Gold < cost) 
            return false;
        Gold -= cost;
        RecieveItem(item, false);
        return true;
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

    public void ReceiveReward(LootHoard loot)
    {
        AddGold(loot.Gold);
        
        if (loot.Item != null)
        {
            RecieveItem(loot.Item);
        }

        Console.Clear();
    }

    private void RecieveItem(Item item, bool prompt = true)
    {
        switch (item)
        {
            case Weapon weapon:
                EquipWeapon(weapon, prompt);
                break;
            case Armor armor:
                EquipArmor(armor, prompt);
                break;
            default:
                PickUpItem(item, prompt);
                break;
        }
    }

    private void EquipWeapon(Weapon weapon, bool prompt)
    {
        bool replace = true;
        if (prompt)
        {
            TextHandler.PrettyWrite($"You received {weapon.ToString()}! \n");
            TextHandler.PrettyWrite($"You're currently using {_weapon.ToString()}! \n");
            ChoiceEvent choiceEvent = new ChoiceEvent("Replace current weapon? ", ["Yes", "No"]);
            replace = choiceEvent.GetChoice() == 0;
        }
        if (replace)
        {
            Equip(weapon);
            TextHandler.PrettyWrite($"You equipped {_weapon.ToString()}! \n");
        }
    }

    private void EquipArmor(Armor armor, bool prompt)
    {
        bool replace = true;
        if (prompt)
        {
            TextHandler.PrettyWrite($"You received {armor.ToString()}! \n");
            TextHandler.PrettyWrite($"You're currently using {_armor.ToString()}! \n");
            ChoiceEvent choiceEvent = new ChoiceEvent("Replace current armor? ", ["Yes", "No"]);
            replace = choiceEvent.GetChoice() == 0;
        }
        if (replace)
        {
            Equip(armor);
            TextHandler.PrettyWrite($"You equipped {_armor.ToString()}! \n");
        }
    }

    private void PickUpItem(Item item, bool prompt)
    {
        bool pickUp = true;
        if (prompt)
        {
            TextHandler.PrettyWrite($"You received {item.ToString()}! \n");
            TextHandler.PrettyWrite(
                $"You currently have {(IsInventoryFull() ? "no" : EmptyInventorySpaces())} empty spaces \n");
            ChoiceEvent choiceEvent = new ChoiceEvent("Pick up item? ", ["Yes", "No"]);
            pickUp = choiceEvent.GetChoice() == 0;
        }
        if (pickUp)
        {
            // if (IsInventoryFull())
            // {
            //     string[] choices = Inventory.Select(x => x.ToString()).ToArray();
            //     ChoiceEvent discardEvent = new ChoiceEvent("Choose an item to discard", choices);
            //     int discardIndex = discardEvent.GetChoice();
            //     Inventory[discardIndex] = null;
            // }
            string[] choices = new string[Inventory.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                if (Inventory[i] == null)
                    choices[i] = "Empty";
                else
                    choices[i] = Inventory[i].ToString();
            }
            ChoiceEvent choiceEvent = new ChoiceEvent("Choose a slot to place the item in", choices);
            while (!TryPlaceInInventory(item, choiceEvent.GetChoice())) {}
        }
    }

    private bool TryPlaceInInventory(Item item, int index)
    {
        if (Inventory[index] != null)
        {
            ChoiceEvent choiceEvent = new ChoiceEvent($"Replace {Inventory[index].ToString()}?", ["Yes", "No"]);
            bool replace = choiceEvent.GetChoice() == 0;
            if (!replace)
            {
                Console.Clear();
                return false;
            }
        }
        Inventory[index] = item;
        TextHandler.PrettyWrite($"Placed {item.ToString()} in inventory! \n");
        return true;
    }

    public void PrintStats()
    {
        TextHandler.PrettyWrite($@"Health: {_currentHealth} / {EffectiveMaxHealth}
Equipped Weapon: {_weapon!.ToString()}
Equipped Armor: {_armor!.ToString()}
Gold: {Gold}
", TextHandler.TextType.Good, printFast: true);
    }
}