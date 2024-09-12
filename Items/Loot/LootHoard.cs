using TextAdventure.Items.Items;

namespace TextAdventure.Items.Loot;

public struct LootHoard(int gold, Item? item = null)
{
    public int Gold = gold;
    public Item? Item = item;
}