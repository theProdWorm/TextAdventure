using System.Reflection.Metadata.Ecma335;
using TextAdventure.Characters;
using TextAdventure.Factories;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Items;
using TextAdventure.Items.Loot;
using TextAdventure.Items.Weapons;
using TextAdventure.States;
using TextAdventure.World;

namespace TextAdventure;

public class Game
{
    public static readonly Random random = new();

    private readonly Dictionary<string, WeaponComponent> _weaponPrefixes = new();
    private readonly Dictionary<string, WeaponComponent> _weaponTypes = new();
    private readonly Dictionary<string, WeaponComponent> _weaponSuffixes = new();

    private readonly WeaponFactory _weaponFactory1 = new();
    private readonly WeaponFactory _weaponFactory2 = new();
    private readonly WeaponFactory _weaponFactory3 = new();
    
    private readonly Dictionary<string, ArmorComponent> _armorPrefixes = new();
    private readonly Dictionary<string, ArmorComponent> _armorTypes = new();
    private readonly Dictionary<string, ArmorComponent> _armorSuffixes = new();
    
    private readonly Dictionary<string, (string, int)> _enemyTypes = new();
    
    private readonly Dictionary<string, Item> _items = new();

    private LootFactory _lootFactory1;
    private LootFactory _lootFactory2;
    private LootFactory _lootFactory3;

    private readonly ArmorFactory _armorFactory1 = new();
    private readonly ArmorFactory _armorFactory2 = new();
    private readonly ArmorFactory _armorFactory3 = new();
    
    private readonly EnemyFactory _enemyFactory1;
    private readonly EnemyFactory _enemyFactory2;
    private readonly EnemyFactory _enemyFactory3;

    private Player _player;
    
    private readonly List<Floor> _floors = [];
    private int _currentFloorIndex = 0;

    private bool _isGameRunning = true;
    
    private Action _currentState;
    
    public Game(string playerName, int roomsPerFloor)
    {
        InstantiateWeaponLists();
        InstantiateWeaponFactories();
        
        InstantiateArmorLists();
        InstantiateArmorFactories();

        _enemyFactory1 = new EnemyFactory(_weaponFactory1, _armorFactory1);
        _enemyFactory2 = new EnemyFactory(_weaponFactory2, _armorFactory2);
        _enemyFactory3 = new EnemyFactory(_weaponFactory3, _armorFactory3);
    
        _enemyFactory1 = new(_weaponFactory1, _armorFactory1);
        _enemyFactory2 = new(_weaponFactory2, _armorFactory2);
        _enemyFactory3 = new(_weaponFactory3, _armorFactory3);

        InstantiateEnemyFactories();

        InstantiateEnemyList();
        InstantiateEnemyFactories();

        _lootFactory1 = new LootFactory(_weaponFactory1, _armorFactory1);
        _lootFactory2 = new LootFactory(_weaponFactory2, _armorFactory2);
        _lootFactory3 = new LootFactory(_weaponFactory3, _armorFactory3);
        
        InstantiateItemList();
        InstantiateLootFactories();
        
        InstantiateFloors(roomsPerFloor);
        
        _player = new Player(playerName, 20, 
                            _weaponFactory1.GenerateWeapon("Rusty", "Sword", "Clumsy"), 
                            _armorFactory1.GenerateArmor("Rusty", "Chain", "Clumsy"));

        _currentState = HandleCombat;
    }
    
    public void Run()
    {
        Introduction();
        while (_isGameRunning)
        {
            _floors[_currentFloorIndex].CurrentRoom.Update(_player);
            
        }
    }

    #region Game Logic

    private void Introduction()
    {
        
    }
    
    private void HandleCombat()
    {
        List<Character> enemies = (_floors[_currentFloorIndex].CurrentRoom as CombatRoom)!.Enemies;

        bool isPlayerTurn = true;
        while (enemies.Count > 0)
        {
            if (isPlayerTurn)
                isPlayerTurn = CombatPlayerTurn(ref enemies);
            else
                CombatEnemyTurn(enemies);

            isPlayerTurn = !isPlayerTurn;
            
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    private void HandleLoot()
    {
        Room room = _floors[_currentFloorIndex].CurrentRoom;

        
    }
    
    private void HandleShop()
    {
        
    }

    private void NextFloor()
    {
        _currentFloorIndex++;
        TextHandler.PrettyWrite("You arrive on the next floor of the dungeon. Who knows what challenges await you here? ", TextHandler.TextType.Description);
        Console.WriteLine("Not implemented yet");
        Console.ReadLine();

        int amountOfRooms = random.Next(3) + 2;
        List<Room> rooms = new List<Room>();

        // Create rooms to choose from
        for (int i = 0; i < amountOfRooms; i++)
        {
        }
        
        string description = "Before you are multiple pathways, each leading to a different room. Which path do you choose?";
        
        //ChoiceEvent choice = new(description, )
    }

    /// <returns>Whether the action taken should end the turn</returns>
    private bool CombatPlayerTurn(ref List<Character> enemies)
    {
        const string combatDescription = "It's your turn! What is your next move?";
        string[] combatChoices = ["Attack", "Use item"];

        ChoiceEvent combatChoice = new(combatDescription, combatChoices);
        int choice = combatChoice.GetChoice();
        
        switch (choice)
        {
            case 1:
                const string attackDescription = "Who do you want to attack?";
                string[] attackChoices = new string[enemies.Count];

                for (int i = 0; i < enemies.Count; i++)
                {
                    attackChoices[i] = enemies[i].GetCombatPrint();
                }

                ChoiceEvent attackChoice = new(attackDescription, attackChoices);
                int enemyIndex = attackChoice.GetChoice() - 1;
                
                _player.Attack(enemies[enemyIndex]);

                if(enemies[enemyIndex].IsDead)
                    enemies.RemoveAt(enemyIndex);
                
                return true;
            case 2:
                if (_player.IsInventoryEmpty())
                {
                    TextHandler.PrettyWrite("You have no items!\n", TextHandler.TextType.Bad);
                    return false;
                }
                
                const string useItemDescription = "What item do you want to use?";
                List<string> useItemChoices = [];
                useItemChoices.AddRange(_player.Inventory.OfType<Item>().Select(item => item.Name));

                //useItemChoices = (from item in _player.Inventory select item.Name).ToList();
                
                ChoiceEvent useItemChoice = new(useItemDescription, useItemChoices.ToArray());
                int itemIndex = useItemChoice.GetChoice() - 1;
                
                return _player.UseItem(itemIndex);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CombatEnemyTurn(List<Character> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            
            
            int rolledValue = random.Next(10);

            switch (rolledValue)
            {
                case 0: // Attack ally (10%)
                    int enemyIndex = random.Next(enemies.Count);
                    enemy.Attack(enemies[enemyIndex]);
                    
                    if(enemy.IsDead)
                        enemies.RemoveAt(enemyIndex);
                    break;
                case 1: // Do nothing (10%)
                    TextHandler.PrettyWrite($"{enemy.Name} skips their turn.\n", TextHandler.TextType.Description);
                    break;
                default: // Attack player (80%)
                    enemy.Attack(_player);
                    break;
            }
        }
    }
    
    #endregion

    #region Item Instantiation
    private void InstantiateWeaponLists()
    {
        _weaponPrefixes.Add("Rusty", new WeaponComponent("Rusty", -2, 0f));
        _weaponPrefixes.Add("Blunt", new WeaponComponent("Blunt", -1, 0f));
        _weaponPrefixes.Add("Normal", new WeaponComponent("", 0, 0f));
        _weaponPrefixes.Add("Sharp", new WeaponComponent("Sharp", 1, 0f));
        _weaponPrefixes.Add("Mighty", new WeaponComponent("Mighty", 2, 0f));
        
        _weaponTypes.Add("Dagger", new WeaponComponent("Dagger", 3, 1.0f));
        _weaponTypes.Add("Sword", new WeaponComponent("Sword", 5, 0.9f));
        _weaponTypes.Add("Hammer", new WeaponComponent("War Hammer", 7, 0.7f));
        
        _weaponSuffixes.Add("Clumsy", new WeaponComponent("of Clumsiness", 0, -0.2f));
        _weaponSuffixes.Add("Unwieldy", new WeaponComponent("of Unwieldiness", 0, -0.1f));
        _weaponSuffixes.Add("Normal", new WeaponComponent("", 0, 0f));
        _weaponSuffixes.Add("Truestrike", new WeaponComponent("of True Strike", 0, 0.1f));
        _weaponSuffixes.Add("Divine", new WeaponComponent("of Divine Retribution", 0, 0.2f));
    }

    private void InstantiateArmorLists()
    {
        _armorPrefixes.Add("Rusty", new ArmorComponent("Rusty", -2, 0f));
        _armorPrefixes.Add("Old", new ArmorComponent("Old", -1, 0f));
        _armorPrefixes.Add("Normal", new ArmorComponent("", 0, 0f));
        _armorPrefixes.Add("Craftsmans", new ArmorComponent("Craftsmans'", 1, 0f));
        _armorPrefixes.Add("Mighty", new ArmorComponent("Mighty", 2, 0f));
        
        _armorTypes.Add("Leather", new ArmorComponent("Leather Armor", 1, 0.3f));
        _armorTypes.Add("Chain", new ArmorComponent("Chainmail", 3, 0.2f));
        _armorTypes.Add("Plate", new ArmorComponent("Plate Armor", 5, 0.1f));
        
        _armorSuffixes.Add("Clumsy", new ArmorComponent("of Clumsiness", 0, -0.2f));
        _armorSuffixes.Add("Unwieldy", new ArmorComponent("of Unwieldiness", 0, -0.1f));
        _armorSuffixes.Add("Normal", new ArmorComponent("", 0, 0f));
        _armorSuffixes.Add("Swift", new ArmorComponent("of Swiftness", 0, 0.1f));
        _armorSuffixes.Add("Divine", new ArmorComponent("of Divine Protection", 0, 0.2f));
    }

    private void InstantiateWeaponFactories()
    {
        _weaponFactory1.RegisterPrefix("Rusty", 5, _weaponPrefixes["Rusty"]);
        _weaponFactory1.RegisterPrefix("Blunt", 3, _weaponPrefixes["Blunt"]);
        _weaponFactory1.RegisterPrefix("Normal", 2, _weaponPrefixes["Normal"]);
        
        _weaponFactory1.RegisterWeaponType("Dagger", 1, _weaponTypes["Dagger"]);
        _weaponFactory1.RegisterWeaponType("Sword", 1, _weaponTypes["Sword"]);
        _weaponFactory1.RegisterWeaponType("Hammer", 1, _weaponTypes["Hammer"]);
        
        _weaponFactory1.RegisterSuffix("Clumsy", 5, _weaponSuffixes["Clumsy"]);
        _weaponFactory1.RegisterSuffix("Unwieldy", 3, _weaponSuffixes["Unwieldy"]);
        _weaponFactory1.RegisterSuffix("Normal", 2, _weaponSuffixes["Normal"]);

        
        
        _weaponFactory2.RegisterPrefix("Blunt", 5, _weaponPrefixes["Blunt"]);
        _weaponFactory2.RegisterPrefix("Normal", 3, _weaponPrefixes["Normal"]);
        _weaponFactory2.RegisterPrefix("Sharp", 2, _weaponPrefixes["Sharp"]);
        
        _weaponFactory2.RegisterWeaponType("Dagger", 1, _weaponTypes["Dagger"]);
        _weaponFactory2.RegisterWeaponType("Sword", 1, _weaponTypes["Sword"]);
        _weaponFactory2.RegisterWeaponType("Hammer", 1, _weaponTypes["Hammer"]);
        
        _weaponFactory2.RegisterSuffix("Unwieldy", 5, _weaponSuffixes["Unwieldy"]);
        _weaponFactory2.RegisterSuffix("Normal", 3, _weaponSuffixes["Normal"]);
        _weaponFactory2.RegisterSuffix("Truestrike", 2, _weaponSuffixes["Truestrike"]);

        
        
        _weaponFactory3.RegisterPrefix("Normal", 5, _weaponPrefixes["Normal"]);
        _weaponFactory3.RegisterPrefix("Sharp", 3, _weaponPrefixes["Sharp"]);
        _weaponFactory3.RegisterPrefix("Mighty", 2, _weaponPrefixes["Mighty"]);
        
        _weaponFactory3.RegisterWeaponType("Dagger", 1, _weaponTypes["Dagger"]);
        _weaponFactory3.RegisterWeaponType("Sword", 1, _weaponTypes["Sword"]);
        _weaponFactory3.RegisterWeaponType("Hammer", 1, _weaponTypes["Hammer"]);
        
        _weaponFactory3.RegisterSuffix("Normal", 5, _weaponSuffixes["Clumsy"]);
        _weaponFactory3.RegisterSuffix("Truestrike", 3, _weaponSuffixes["Truestrike"]);
        _weaponFactory3.RegisterSuffix("Divine", 2, _weaponSuffixes["Divine"]);
    }
    
    private void InstantiateArmorFactories()
    {
        _armorFactory1.RegisterPrefix("Rusty", 5, _armorPrefixes["Rusty"]);
        _armorFactory1.RegisterPrefix("Old", 3, _armorPrefixes["Old"]);
        _armorFactory1.RegisterPrefix("Normal", 2, _armorPrefixes["Normal"]);
        
        _armorFactory1.RegisterArmorType("Leather", 1, _armorTypes["Leather"]);
        _armorFactory1.RegisterArmorType("Chain", 1, _armorTypes["Chain"]);
        _armorFactory1.RegisterArmorType("Plate", 1, _armorTypes["Plate"]);
        
        _armorFactory1.RegisterSuffix("Clumsy", 5, _armorSuffixes["Clumsy"]);
        _armorFactory1.RegisterSuffix("Unwieldy", 3, _armorSuffixes["Unwieldy"]);
        _armorFactory1.RegisterSuffix("Normal", 2, _armorSuffixes["Normal"]);
        
        
        
        _armorFactory2.RegisterPrefix("Old", 5, _armorPrefixes["Old"]);
        _armorFactory2.RegisterPrefix("Normal", 3, _armorPrefixes["Normal"]);
        _armorFactory2.RegisterPrefix("Craftsmans", 2, _armorPrefixes["Craftsmans"]);
        
        _armorFactory2.RegisterArmorType("Leather", 1, _armorTypes["Leather"]);
        _armorFactory2.RegisterArmorType("Chain", 1, _armorTypes["Chain"]);
        _armorFactory2.RegisterArmorType("Plate", 1, _armorTypes["Plate"]);
        
        _armorFactory2.RegisterSuffix("Unwieldy", 5, _armorSuffixes["Unwieldy"]);
        _armorFactory2.RegisterSuffix("Normal", 3, _armorSuffixes["Normal"]);
        _armorFactory2.RegisterSuffix("Swift", 2, _armorSuffixes["Swift"]);
        
        
        
        _armorFactory3.RegisterPrefix("Normal", 5, _armorPrefixes["Normal"]);
        _armorFactory3.RegisterPrefix("Craftsmans", 3, _armorPrefixes["Craftsmans"]);
        _armorFactory3.RegisterPrefix("Mighty", 2, _armorPrefixes["Mighty"]);
        
        _armorFactory3.RegisterArmorType("Leather", 1, _armorTypes["Leather"]);
        _armorFactory3.RegisterArmorType("Chain", 1, _armorTypes["Chain"]);
        _armorFactory3.RegisterArmorType("Plate", 1, _armorTypes["Plate"]);
        
        _armorFactory3.RegisterSuffix("Normal", 5, _armorSuffixes["Normal"]);
        _armorFactory3.RegisterSuffix("Swift", 3, _armorSuffixes["Swift"]);
        _armorFactory3.RegisterSuffix("Divine", 2, _armorSuffixes["Divine"]);
    }

    private void InstantiateEnemyList()
    {
        _enemyTypes.Add("Skeleton", new ("Skeleton", 3));
        _enemyTypes.Add("Goblin", new ("Goblin", 4));
        _enemyTypes.Add("Ogre", new ("Ogre", 5));
        _enemyTypes.Add("Undead", new ("Undead", 6));
        _enemyTypes.Add("UndeadKnight", new ("Undead Knight", 7));
    }

    private void InstantiateEnemyFactories()
    {
        _enemyFactory1.RegisterEnemyType(5, _enemyTypes["Skeleton"]);
        _enemyFactory1.RegisterEnemyType(3, _enemyTypes["Goblin"]);
        _enemyFactory1.RegisterEnemyType(2, _enemyTypes["Ogre"]);
        
        _enemyFactory2.RegisterEnemyType(5, _enemyTypes["Goblin"]);
        _enemyFactory2.RegisterEnemyType(3, _enemyTypes["Ogre"]);
        _enemyFactory2.RegisterEnemyType(2, _enemyTypes["Undead"]);
        
        _enemyFactory3.RegisterEnemyType(5, _enemyTypes["Ogre"]);
        _enemyFactory3.RegisterEnemyType(3, _enemyTypes["Undead"]);
        _enemyFactory3.RegisterEnemyType(2, _enemyTypes["UndeadKnight"]);
    }

    private void InstantiateItemList()
    {
        _items.Add("HealthPotion", new HealthPotion("Health Potion", 5));
    }

    private void InstantiateLootFactories()
    {
        _lootFactory1.RegisterItem("HealthPotion", 8, _items["HealthPotion"]);
        
        _lootFactory1.RegisterLootWeight(3, LootType.Weapon);
        _lootFactory1.RegisterLootWeight(3, LootType.Armor);
        _lootFactory1.RegisterLootWeight(2, LootType.Item);
        _lootFactory1.RegisterLootWeight(2, LootType.Gold);
        
        _lootFactory2.RegisterItem("HealthPotion", 8, _items["HealthPotion"]);
        
        _lootFactory2.RegisterLootWeight(3, LootType.Weapon);
        _lootFactory2.RegisterLootWeight(3, LootType.Armor);
        _lootFactory2.RegisterLootWeight(2, LootType.Item);
        _lootFactory2.RegisterLootWeight(2, LootType.Gold);
        
        _lootFactory3.RegisterItem("HealthPotion", 8, _items["HealthPotion"]);
        
        _lootFactory3.RegisterLootWeight(3, LootType.Weapon);
        _lootFactory3.RegisterLootWeight(3, LootType.Armor);
        _lootFactory3.RegisterLootWeight(2, LootType.Item);
        _lootFactory3.RegisterLootWeight(2, LootType.Gold);
    }
    #endregion

    private void InstantiateFloors(int roomsPerFloor)
    {
        Floor floor1 = new Floor(_weaponFactory1, _armorFactory1, _enemyFactory1, _lootFactory1, roomsPerFloor, 1, NextFloor);
        Floor floor2 = new Floor(_weaponFactory2, _armorFactory2, _enemyFactory2, _lootFactory2, roomsPerFloor, 2, NextFloor, true);
        Floor floor3 = new Floor(_weaponFactory3, _armorFactory3, _enemyFactory3, _lootFactory3, roomsPerFloor, 3, NextFloor);
        _floors.AddRange([floor1, floor2, floor3]);
    }
}