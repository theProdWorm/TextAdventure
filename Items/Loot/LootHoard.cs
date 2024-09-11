using TextAdventure.Items.Items;

namespace TextAdventure.Items;

public struct LootHoard(int gold, Item item)
{
    public int Gold = gold;
    public Item Item = item;
}