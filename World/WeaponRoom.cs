using TextAdventure.Characters;
using TextAdventure.Items.Loot;
using TextAdventure.Items.Weapons;
using TextAdventure.States;

namespace TextAdventure.World;

public class WeaponRoom(LootHoard lootHoard) : Room(lootHoard)
{
    public override void RewardPlayer(Player player)
    {
        base.RewardPlayer(player);

        if (_lootHoard.Item is not Weapon lootWeapon)
            throw new Exception();

        lootWeapon.Print();
        
        const string description = "Switch your equipped weapon?";
        string[] choices = ["Yes (discard equipped weapon)", "No"];
        ChoiceEvent weaponChoice = new(description, choices);
        
        int choice = weaponChoice.GetChoice();

        switch (choice)
        {
            case 1:
                player.Equip(lootWeapon);
                break;
            case 2:
                break;
        }
    }
}