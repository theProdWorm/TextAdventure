using TextAdventure.Characters;
using TextAdventure.Items;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public class RoomFactory(EnemyFactory enemyFactory, LootFactory lootFactory)
{
    private EnemyFactory _enemyFactory = enemyFactory;
    private LootFactory _lootFactory = lootFactory;
    
    private Dictionary<string, Room> _roomArchetypes = [];
    
    public void RegisterRoomArchetype(string index, Room room)
    {
        _roomArchetypes.Add(index, room);
    }
    
    public Room GenerateRoom(int floor, int roomNumber)
    {
        throw new NotImplementedException();
        // TODO: Generate enemies
        // TODO: Generate type of loot
    }
}