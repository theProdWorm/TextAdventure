using TextAdventure.Characters;
using TextAdventure.Items.Items;

namespace TextAdventure.World;

public class ItemRoom : Room
{
    private Item _rewardItem;

    public ItemRoom(Item rewardItem, int rewardGold) : base(rewardGold)
    {
        _rewardItem = rewardItem;
    }

    public override void RewardPlayer(Player player)
    {
        base.RewardPlayer(player);
        // TODO: Prompt the player to pick up their reward or discard it
        // TODO: If they want it, give the player their fancy new item
    }
}