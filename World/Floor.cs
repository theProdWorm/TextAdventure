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

    private int _nRoomsOnFloor;
    private List<List<Room>> _rooms;
    private bool _generateBonusRoom;
    private int _enemyCounts;
    private Room _currentRoom;
    public Room CurrentRoom { get => _currentRoom; }

    private Action _nextFloor;
    
    public Floor(WeaponFactory weaponFactory, ArmorFactory armorFactory, EnemyFactory enemyFactory, LootFactory lootFactory, int roomsOnFloor, int enemyCounts, Action nextFloor, bool generateBonusRoom = false)
    {
        _weaponFactory = weaponFactory;
        _armorFactory = armorFactory;
        _enemyFactory = enemyFactory;
        _lootFactory = lootFactory;
        
        _nRoomsOnFloor = roomsOnFloor;
        _rooms = [];
        _generateBonusRoom = generateBonusRoom;
        _enemyCounts = enemyCounts;
        _nextFloor = nextFloor;
        
        _roomFactory = new RoomFactory(_enemyFactory, _lootFactory, _nextFloor);
        GenerateRooms();
        _currentRoom = _rooms.First().First();
    }

    private void GenerateRooms()
    {
        _rooms.Add([_roomFactory.GenerateCombatRoom(_enemyCounts)]);

        for (int i = 1; i < _nRoomsOnFloor; i++)
        {
            int roomsToGenerate = Game.random.Next(2, 4);
            List<Room> rooms = [];
            for (int j = 0; j < roomsToGenerate; j++)
            {
                rooms.Add(_roomFactory.GenerateCombatRoom(_enemyCounts));
            }

            foreach (Room previousRoom in _rooms[^1])
            {
                foreach (Room currentRoom in rooms)
                {
                    previousRoom.AddDoor(new Door(currentRoom, EnterRoom));
                }
            }
            _rooms.Add(rooms);
        }
        List<Room> endRooms = [];

        Room shopRoom = _roomFactory.GenerateShopRoom();
        Door shopDoor = new Door(shopRoom, EnterRoom);
        //_rooms[^1].AddDoor(shopDoor);
        //_rooms[^2].AddDoor(shopDoor);
        foreach (Room room in _rooms[^1])
        {
            room.AddDoor(shopDoor);
        }
        endRooms.Add(shopRoom);

        Room nextFloorRoom = _roomFactory.GenerateNextFloorRoom();
        Door nextFloorDoor = new Door(nextFloorRoom, EnterRoom);
        //_rooms[^1].AddDoor(nextFloorDoor);
        //_rooms[^2].AddDoor(nextFloorDoor);
        foreach (Room room in _rooms[^1])
        {
            room.AddDoor(nextFloorDoor);
        }
        shopRoom.AddDoor(nextFloorDoor);

        if (_generateBonusRoom)
        {
            Room bonusRoom = _roomFactory.GenerateBonusRoom();
            Door bonusDoor = new Door(bonusRoom, EnterRoom);
            //_rooms[^1].AddDoor(bonusDoor);
            //_rooms[^2].AddDoor(bonusDoor);
            
            foreach (Room room in _rooms[^1])
            {
                room.AddDoor(bonusDoor);
            }
            shopRoom.AddDoor(bonusDoor);
            bonusRoom.AddDoor(shopDoor);
            //_rooms.Add(bonusRoom);
            endRooms.Add(bonusRoom);
        }
        endRooms.Add(nextFloorRoom);
        _rooms.Add(endRooms);
        //_rooms.Add(shopRoom);
        //_rooms.Add(nextFloorRoom);
    }

    private void EnterRoom(Room room)
    {
        _currentRoom = room;
    }
}