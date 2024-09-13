using TextAdventure.Factories;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;
using TextAdventure.States;

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

    private int _nRooms;
    private List<Room> _rooms;
    private bool _generateBonusRoom;
    private int _enemyCounts;
    private Room _currentRoom;
    public Room CurrentRoom { get => _currentRoom; }

    private Action _nextFloor;
    
    public Floor(WeaponFactory weaponFactory, ArmorFactory armorFactory, EnemyFactory enemyFactory, LootFactory lootFactory, int rooms, int enemyCounts, Action nextFloor, bool generateBonusRoom = false)
    {
        _weaponFactory = weaponFactory;
        _armorFactory = armorFactory;
        _enemyFactory = enemyFactory;
        _lootFactory = lootFactory;
        
        _nRooms = rooms;
        _rooms = [];
        _generateBonusRoom = generateBonusRoom;
        _enemyCounts = enemyCounts;
        _nextFloor = nextFloor;
        
        _roomFactory = new RoomFactory(_enemyFactory, _lootFactory, _nextFloor);
        GenerateRooms();
        _currentRoom = _rooms.First();
    }

    private void GenerateRooms()
    {
        int effectiveEnemyCount = _enemyCounts;
        _rooms.Add(_roomFactory.GenerateCombatRoom(effectiveEnemyCount));
        for (int i = 1; i < _nRooms; i++)
        {
            if (i == _nRooms - 1)
            {
                effectiveEnemyCount++;
            }
            Room room1 = _roomFactory.GenerateCombatRoom(effectiveEnemyCount);
            Room room2 = _roomFactory.GenerateCombatRoom(effectiveEnemyCount);

            Door door1 = new Door(room1, EnterRoom);
            Door door2 = new Door(room2, EnterRoom);
            
            _rooms[^1].AddDoor(door1);
            _rooms[^1].AddDoor(door2);
            if (_rooms.Count > 1)
            {
                _rooms[^2].AddDoor(door1);
                _rooms[^2].AddDoor(door2);
            }
            _rooms.Add(room1);
            _rooms.Add(room2);
        }
        
        Room shopRoom = _roomFactory.GenerateShopRoom();
        Door shopDoor = new Door(shopRoom, EnterRoom);
        _rooms[^1].AddDoor(shopDoor);
        _rooms[^2].AddDoor(shopDoor);

        Room nextFloorRoom = _roomFactory.GenerateNextFloorRoom();
        Door nextFloorDoor = new Door(nextFloorRoom, EnterRoom);
        _rooms[^1].AddDoor(nextFloorDoor);
        _rooms[^2].AddDoor(nextFloorDoor);

        if (_generateBonusRoom)
        {
            Room bonusRoom = _roomFactory.GenerateBonusRoom();
            Door bonusDoor = new Door(bonusRoom, EnterRoom);
            _rooms[^1].AddDoor(bonusDoor);
            _rooms[^2].AddDoor(bonusDoor);
            shopRoom.AddDoor(bonusDoor);
            bonusRoom.AddDoor(shopDoor);
            _rooms.Add(bonusRoom);
        }
        _rooms.Add(shopRoom);
        _rooms.Add(nextFloorRoom);
    }

    private void EnterRoom(Room room)
    {
        _currentRoom = room;
    }
}