using TextAdventure.Characters;

namespace TextAdventure.World;

public class ShopRoom : Room
{
    public override void Update(Player player)
    {

        _doors.First().TryEnter();
    }

    public override string ToString()
    {
        return "Entering this room will allow you to stock up on consumables";
    }
}