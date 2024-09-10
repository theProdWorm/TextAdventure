using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public class HealthPotion(string name, Character character, int healAmount) : Consumable(name, character =>
{
    character.Heal(healAmount);
})
{
    public override void Consume()
    {
        
    }
}