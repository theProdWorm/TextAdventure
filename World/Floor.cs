using TextAdventure.Factories;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public class Floor
{
    #region FACTORIES
    private WeaponFactory _weaponFactory { get; }
    private ArmorFactory _armorFactory { get; }
    private EnemyFactory _enemyFactory { get; }
    private RoomFactory _roomFactory { get; }
    private LootFactory _lootFactory { get; }
    #endregion FACTORIES

    private List<Room> _rooms = [];
    private int _currentRoomIndex = 0;

    public Floor(WeaponFactory weaponFactory, ArmorFactory armorFactory, EnemyFactory enemyFactory)
    {
        _weaponFactory = weaponFactory;
        _armorFactory = armorFactory;
        _enemyFactory = enemyFactory;
        
        _lootFactory = new LootFactory(_armorFactory, _weaponFactory);
        // TODO: Register item loot
        
        _roomFactory = new RoomFactory(_enemyFactory, _lootFactory);
        // TODO: Register room archetypes
        
    }

    public Room CurrentRoom => _rooms[_currentRoomIndex];

    public Room GenerateRoom() => _roomFactory.GenerateRoom();
}