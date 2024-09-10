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
        //TODO: Give Player their fancy new item
    }
}