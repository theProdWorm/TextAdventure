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
    public Room CurrentRoom { get => _rooms.Last(); }

    private Action _nextFloor;
    
    public Floor(WeaponFactory weaponFactory, ArmorFactory armorFactory, EnemyFactory enemyFactory, int rooms, int enemyCounts, Action nextFloor, bool generateBonusRoom = false)
    {
        _weaponFactory = weaponFactory;
        _armorFactory = armorFactory;
        _enemyFactory = enemyFactory;
        
        _lootFactory = new LootFactory(_armorFactory, _weaponFactory);
        // TODO: Register item loot
        
        _roomFactory = new RoomFactory(_enemyFactory, _lootFactory);
        // TODO: Register room archetypes
        
        _nRooms = rooms;
        _rooms = [];
        _generateBonusRoom = generateBonusRoom;
        _enemyCounts = enemyCounts;
        
        _nextFloor = nextFloor;
    }


    public void PromptRoomChoice()
    {
        if (_rooms.Count < _nRooms)
        {
            if (_rooms.Count == _nRooms - 1)
                _enemyCounts++;
            List<Room> rooms =
            [
                _roomFactory.GenerateCombatRoom(_enemyCounts),
                _roomFactory.GenerateCombatRoom(_enemyCounts)
            ];

            ChoiceEvent choiceEvent = new ChoiceEvent("Facing you are two doors. Which room will you enter? ",
                [rooms[0].ToString(), rooms[1].ToString()]);
            Room room = rooms[choiceEvent.GetChoice()];
            
            _rooms.Add(room);
        }
        else
        {
            List<Room?> rooms =
            [
                _roomFactory.GenerateShopRoom(),
                null
            ];
            List<string> choices = ["This door leads to a shop", "This door leads to the next floor"];
            if (_generateBonusRoom)
            {
                rooms.Add(_roomFactory.GenerateBonusRoom());
                choices.Add("This locked door leads to a treasure chamber");
            }
            
            
            ChoiceEvent choiceEvent = new ChoiceEvent(
                $"Facing you are {rooms.Count} doors. Which door will you enter? ",
                choices.ToArray());
            Room? room = rooms[choiceEvent.GetChoice()];

            if (room is null)
            {
                _nextFloor();
                return;
            }
            
            _rooms.Add(room);
        }
    }
}