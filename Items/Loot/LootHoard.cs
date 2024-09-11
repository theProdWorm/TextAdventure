using TextAdventure.Items.Items;

namespace TextAdventure.Items.Loot;

public struct LootHoard(int gold, Item item)
{
    public int Gold = gold;
    public Item Item = item;
}