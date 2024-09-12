using TextAdventure.Characters;

namespace TextAdventure.World;

public class BonusRoom : Room
{
    public override void Update(Player player)
    {


        _doors.First().TryEnter();
    }

    public override string ToString()
    {
        return "This locked room is a treasure chamber! Who knows what rewards it may yield? ";
    }
}