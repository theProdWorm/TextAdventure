using TextAdventure.Characters;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;
using TextAdventure.Items.Weapons;
using TextAdventure.States;

namespace TextAdventure.World;

public class BonusRoom(LootHoard armorChest, LootHoard weaponChest, LootHoard goldChest) : Room
{
    private readonly LootHoard _armorChest = armorChest;
    private readonly LootHoard _weaponChest = weaponChest;
    private readonly LootHoard _goldChest = goldChest;

    public override void Update(Player player)
    {
        List<string> choices =
        [
            (_armorChest.Item as Armor)!.ToString(),
            (_weaponChest.Item as Weapon)!.ToString(),
            $"A boatload of gold ({_goldChest.Gold})"
        ];
        
        ChoiceEvent chestChoice = new ChoiceEvent("""
                                                  Before you are multiple treasure chests.
                                                  It would seem you may only pick one to open.
                                                  Which do you choose?
                                                  """, choices.ToArray());

        player.ReceiveReward(chestChoice.GetChoice() switch
        {
            1 => _armorChest,
            2 => _weaponChest,
            3 => _goldChest,
            _ => _goldChest
        });
        
        ChooseDoor(player);
    }

    public override string ToString()
    {
        return "This locked room is a treasure chamber! Who knows what rewards it may yield?";
    }
}