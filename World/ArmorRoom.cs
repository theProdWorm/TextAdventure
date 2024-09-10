using TextAdventure.Characters;
using TextAdventure.Items.Armor;

namespace TextAdventure.World;

public class ArmorRoom : Room
{
    private Armor _rewardArmor;

    public ArmorRoom(Armor rewardArmor, int rewardGold) : base(rewardGold)
    {
        _rewardArmor = rewardArmor;
    }

    public override void RewardPlayer(Player player)
    {
        base.RewardPlayer(player);
        //TODO: Give player their shiny new armor
    }
}