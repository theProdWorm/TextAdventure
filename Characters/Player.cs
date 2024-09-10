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
}