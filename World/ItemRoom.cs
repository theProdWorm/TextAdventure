using TextAdventure.Characters;
using TextAdventure.Items.Items;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public class ItemRoom(LootHoard lootHoard) : Room(lootHoard)
{
    public override void RewardPlayer(Player player)
    {
        base.RewardPlayer(player);
        // TODO: Prompt the player to pick up their reward or discard it
        // TODO: If they want it, give the player their fancy new item
    }
}