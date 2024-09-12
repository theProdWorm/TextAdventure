using TextAdventure.Characters;

namespace TextAdventure.World;

public class NextFloorRoom : Room
{
    private Action _nextFloor;

    public NextFloorRoom(Action nextFloor)
    {
        _nextFloor = nextFloor;
    }
    public override void Update(Player player)
    {
        _nextFloor();
    }

    public override string ToString()
    {
        return "This stairwell leads to the next floor";
    }
}