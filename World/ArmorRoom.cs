using TextAdventure.Characters;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;
using TextAdventure.States;

namespace TextAdventure.World;

public class ArmorRoom(LootHoard lootHoard) : Room(lootHoard)
{
    public override void RewardPlayer(Player player)
    {
        base.RewardPlayer(player);
        
        if (_lootHoard.Item is not Armor lootArmor)
            throw new Exception();

        lootArmor.Print();
        
        const string description = "Switch your equipped armor?";
        string[] choices = ["Yes (discard equipped armor)", "No"];
        ChoiceEvent armorChoice = new(description, choices);
        
        int choice = armorChoice.GetChoice();

        switch (choice)
        {
            case 1:
                player.Equip(lootArmor);
                break;
            case 2:
                break;
        }
    }
}