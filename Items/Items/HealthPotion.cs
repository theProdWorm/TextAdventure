using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public class HealthPotion(string name, int healAmount)
    : Item(name)
{
    public int HealAmount => healAmount;

    public override string ToString()
    {
        return $"{Name} [Restore {healAmount} Health]";
    }
}