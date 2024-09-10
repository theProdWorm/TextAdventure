using TextAdventure.Characters;
using TextAdventure.Items.Weapons;

namespace TextAdventure.World;

public class WeaponRoom : Room
{
    private Weapon _rewardWeapon;

    public WeaponRoom(Weapon rewardWeapon, int rewardGold) : base(rewardGold)
    {
        _rewardWeapon = rewardWeapon;
    }

    public override void RewardPlayer(Player player)
    {
        base.RewardPlayer(player);
        //TODO: give player their cool new weapon
    }
}