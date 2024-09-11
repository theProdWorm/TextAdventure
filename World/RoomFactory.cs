using TextAdventure.Characters;
using TextAdventure.Items.Armor;

namespace TextAdventure.World;

public static class RoomFactory
{
    private static Dictionary<string, Room> _roomArchetypes = new()
    {
        {
            "Armor", new ArmorRoom(ArmorFactory.GetDefaultArmor(), 20)
        },
        {
            "Gold", new Room(80)
        }
    };

    public static Room GenerateRoom(int floor, int roomNumber)
    {
        throw new NotImplementedException();
        // TODO: Generate enemies
        // TODO: Generate type of loot
    }
}