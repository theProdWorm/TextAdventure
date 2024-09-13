using TextAdventure.Characters;
using TextAdventure.Items.Items;
using TextAdventure.Items.Loot;
using TextAdventure.States;

namespace TextAdventure.World;

public class ShopRoom : Room
{
    private LootFactory _lootFactory;

    private readonly List<Item> _items = [];

    public ShopRoom(LootFactory lootFactory, int itemCount = 5)
    {
        _lootFactory = lootFactory;
        GenerateItems(itemCount);
    }
    
    public override void Update(Player player)
    {
        TextHandler.PrettyWrite("You enter the shop! \n");

        while (true)
        {
            player.PrintStats();
            TextHandler.PrettyWrite($"You currently have {(!player.IsInventoryFull() ? player.EmptyInventorySpaces() : "no")} empty inventory slots. \n");
            string[] choices = new string[_items.Count + 1];
            for (int i = 0; i < _items.Count; i++)
            {
                choices[i] = $"[{_items[i].Value} gold] Buy {_items[i].ToString()}";
            }

            choices[^1] = "Leave";
            ChoiceEvent choiceEvent = new ChoiceEvent("What would you like to do? ", choices);
            int choice;
            choice = choiceEvent.GetChoice();
            bool leave = choice == choices.Length - 1;
            if (leave)
                break;
            Item item = _items[choice];
            if (!player.TryPurchaseItem(item, item.Value))
            {
                TextHandler.PrettyWrite("Insufficient gold \n");
            }
            else
            {
                _items.Remove(item);
            }
            Console.Clear();
        }
        
        ChooseDoor();
    }

    private void GenerateItems(int itemCount)
    {
        for (var i = 0; i < itemCount; i++)
        {
            _items.Add(_lootFactory.GenerateItem());
        }
    }

    public override string ToString()
    {
        return "[Shop]";
    }
}