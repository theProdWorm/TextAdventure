using TextAdventure.Items.Loot;
using TextAdventure.World;
using TextAdventure.Characters;

namespace TextAdventure.Factories;

public class RoomFactory(EnemyFactory enemyFactory, LootFactory lootFactory) : Factory
{
    private EnemyFactory _enemyFactory = enemyFactory;
    private LootFactory _lootFactory = lootFactory;
    
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
        throw new NotImplementedException();
    }

    public Room GenerateBonusRoom()
    {
        throw new NotImplementedException();
    }
}