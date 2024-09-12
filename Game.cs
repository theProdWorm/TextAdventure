using TextAdventure.Characters;
using TextAdventure.Factories;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Weapons;
using TextAdventure.World;

namespace TextAdventure;

public class Game
{
    public static readonly Random random = new();
    
    private Player _player;
    
    private List<Floor> _floors = [];
    private int _currentFloorIndex = 0;

    private bool _isGameRunning = true;
    
    private Action _currentState;

    public Game(Player player)
    {
        _player = player;
        _currentState = HandlePickingRoom;

        #region Register first floor
        // WEAPON REGISTRY
        WeaponFactory weaponFactory1 = new();
        weaponFactory1.RegisterPrefix(20, new WeaponComponent("", 0, 0));
        weaponFactory1.RegisterPrefix(10, new WeaponComponent("Pointy", 2, 0.0f));
        weaponFactory1.RegisterPrefix(7, new WeaponComponent("Sharp", 4, 0.0f));
        weaponFactory1.RegisterPrefix(4, new WeaponComponent("Mighty", 6, 0.0f));
        weaponFactory1.RegisterPrefix(1, new WeaponComponent("True", 0, 1.0f));
        
        weaponFactory1.RegisterWeaponType(5, new WeaponComponent("Sword", 5, 1.0f));
        weaponFactory1.RegisterWeaponType(3, new WeaponComponent("Axe", 8, 0.8f));
        weaponFactory1.RegisterWeaponType(8, new WeaponComponent("Dagger", 3, 1.2f));
        weaponFactory1.RegisterWeaponType(1, new WeaponComponent("Hammer", 10, 0.6f));
        
        weaponFactory1.RegisterSuffix(25, new WeaponComponent("", 0, 0));
        weaponFactory1.RegisterSuffix(15, new WeaponComponent("of Steel", 2, 0.0f));
        weaponFactory1.RegisterSuffix(10, new WeaponComponent("of Royalty", 4, 0.05f));
        weaponFactory1.RegisterSuffix(8, new WeaponComponent("of the Blade Dancer", 2, 0.2f));
        weaponFactory1.RegisterSuffix(1, new WeaponComponent("of Divine Retribution", 10, 0.0f));
        
        // ARMOR REGISTRY
        ArmorFactory armorFactory1 = new();
        armorFactory1.RegisterPrefix(30, new ArmorComponent("", 0, 0));
        armorFactory1.RegisterPrefix(16, new ArmorComponent("Heavy", 20, -0.5f));
        armorFactory1.RegisterPrefix(15, new ArmorComponent("Light", 0, 0.3f));
        armorFactory1.RegisterPrefix(8, new ArmorComponent("Shiny", 2, 0.4f));
        armorFactory1.RegisterPrefix(1, new ArmorComponent("Master", 20, 0.5f));
        
        armorFactory1.RegisterArmorType(25, new ArmorComponent("Leather Armor", 5, 0.2f));
        armorFactory1.RegisterArmorType(10, new ArmorComponent("Garments", 0, 0.5f));
        armorFactory1.RegisterArmorType(5, new ArmorComponent("Plate mail", 20, -0.5f));
        armorFactory1.RegisterArmorType(2, new ArmorComponent("Chainmail", 10, 0.2f));
        
        armorFactory1.RegisterSuffix(25, new ArmorComponent("", 0, 0));
        armorFactory1.RegisterSuffix(16, new ArmorComponent("of Lesser Evasion", 0, 0.1f));
        armorFactory1.RegisterSuffix(10, new ArmorComponent("of Evasion", 0, 0.3f));
        armorFactory1.RegisterSuffix(4, new ArmorComponent("of Greater Evasion", 0, 0.5f));
        armorFactory1.RegisterSuffix(20, new ArmorComponent("of Lesser Toughness", 2, 0));
        armorFactory1.RegisterSuffix(12, new ArmorComponent("of Toughness", 5, 0));
        armorFactory1.RegisterSuffix(6, new ArmorComponent("of Greater Toughness", 10, 0));
        
        // ENEMY REGISTRY
        EnemyFactory enemyFactory1 = new();
        //TODO: Register enemy entries

        Floor floor1 = new(weaponFactory1, armorFactory1, enemyFactory1);
        #endregion
        
        #region Register second floor
        // I don't want to
        #endregion
    }
    
    public void Loop()
    {
        while (_isGameRunning)
        {
            _currentState();
        }
    }

    private void HandleCombat()
    {
        
    }

    private void HandleShop()
    {
        
    }

    private void HandlePickingRoom()
    {
        Console.WriteLine("Not implemented yet");
        Console.ReadLine();

        int amountOfRooms = random.Next(3) + 2;
        List<Room> rooms = new List<Room>();

        // Create rooms to choose from
        for (int i = 0; i < amountOfRooms; i++)
        {
            Room room = _floors[_currentFloorIndex].GenerateRoom();
        }
        
        string description = "Before you are multiple pathways, each leading to a different room. Which path do you choose?";
        
        //ChoiceEvent choice = new(description, )
    }
}