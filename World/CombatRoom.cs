using TextAdventure.Characters;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public class CombatRoom : Room
{
    private readonly List<Character> _enemies;
    public List<Character> Enemies { get => _enemies; }

    private LootHoard _lootHoard;
    
    public CombatRoom(LootHoard lootHoard, List<Character> enemies)
    {
        _lootHoard = lootHoard;
        _enemies = enemies;
    }

    public override void Update(Player player)
    {
        //TODO: combat logic
        //TODO: Prompt player to pick up loot
    }

    public override string ToString()
    {
        return $"Clearing this room will grant you {_lootHoard.Gold} gold and {(_lootHoard.Item is not null ? _lootHoard.Item.ToString() : "no item")}";
    }
}