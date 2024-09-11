using TextAdventure.Factories;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public class Floor
{
    #region FACTORIES
    public WeaponFactory WeaponFactory { get; }
    public ArmorFactory ArmorFactory { get; }
    public EnemyFactory EnemyFactory { get; }
    public RoomFactory RoomFactory { get; }
    public LootFactory LootFactory { get; }
    #endregion FACTORIES

    private List<Room> _rooms = [];
    private int _currentRoomIndex = 0;

    public Floor(WeaponFactory weaponFactory, ArmorFactory armorFactory, EnemyFactory enemyFactory)
    {
        WeaponFactory = weaponFactory;
        ArmorFactory = armorFactory;
        EnemyFactory = enemyFactory;
        
        LootFactory = new LootFactory(ArmorFactory, WeaponFactory);
        
        RoomFactory = new RoomFactory(EnemyFactory, LootFactory);
    }

    public Room CurrentRoom => _rooms[_currentRoomIndex];

    public Room GenerateRoom()
    {
        throw new NotImplementedException();
        
    }
}