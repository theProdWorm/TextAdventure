using TextAdventure.Characters;

namespace TextAdventure.World;

public class RoomFactory
{
    private EnemyFactory _enemyFactory;
    //TODO: Add Loot Factory
    
    private Dictionary<string, Room> _roomArchetypes;

    public RoomFactory(EnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
        _roomArchetypes = new Dictionary<string, Room>();
    }

    public void RegisterRoomArchetype(string index, Room room)
    {
        _roomArchetypes.Add(index, room);
    }

    public Room GenerateRoom(int floor, int roomNumber)
    {
        throw new NotImplementedException();
    }
}