using System.ComponentModel;
using TextAdventure.Characters;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public abstract class Room
{
    public List<Character> Enemies { get; protected set; }

    protected LootHoard _lootHoard;
    
    public Room(LootHoard lootHoard)
    {
        _lootHoard = lootHoard;
        
        Enemies = new List<Character>();
    }

    public void Populate(List<Character> enemyList, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Game.random.Next(enemyList.Count);
            Character enemy = enemyList[randomIndex];
            Enemies.Add(enemy);
        }
    }
    
    public virtual void RewardPlayer(Player player)
    {
        player.AddGold(_lootHoard.Gold);
    }
}