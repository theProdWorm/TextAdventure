using TextAdventure.Items.Items;

namespace TextAdventure.Items.Loot;

public enum LootType
{
    Weapon,
    Armor,
    Item,
    Gold,
    Random
}

public struct LootHoard(int gold, LootType type, Item? item = null)
{
    public int Gold = gold;
    public Item? Item = item;
    
    public LootType Type;
}