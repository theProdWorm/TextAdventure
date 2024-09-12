using TextAdventure.Items.Loot;
using TextAdventure.World;
using TextAdventure.Characters;

namespace TextAdventure.Factories;

public class RoomFactory(EnemyFactory enemyFactory, LootFactory lootFactory, Action nextFloor) : Factory
{
    private EnemyFactory _enemyFactory = enemyFactory;
    private LootFactory _lootFactory = lootFactory;

    private Action _nextFloor = nextFloor;
    
    public Room GenerateCombatRoom(int enemyCount)
    {
        // TODO: Generate type of room
        // TODO: If it's a combat room, generate enemies and loot
        LootHoard loot = _lootFactory.GenerateLoot();
        
        List<Character> enemies = new List<Character>();
        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(_enemyFactory.GenerateEnemy());
        }

        return new CombatRoom(loot, enemies);
    }

    public Room GenerateShopRoom()
    {
        return new ShopRoom();
    }

    public Room GenerateBonusRoom()
    {
        return new BonusRoom();
    }

    public Room GenerateNextFloorRoom()
    {
        return new NextFloorRoom(_nextFloor);
    }
}