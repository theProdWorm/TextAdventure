using TextAdventure.Items.Items;

namespace TextAdventure.Items.Armors;

public class Armor(ArmorComponent prefix, ArmorComponent armorType, ArmorComponent suffix) : Item(
    $"{prefix.Name} {armorType.Name} {suffix.Name}")
{
    private readonly ArmorComponent _prefix = prefix;
    private readonly ArmorComponent _armorType = armorType;
    private readonly ArmorComponent _suffix = suffix;
    
    public int Health => _prefix.Health + _armorType.Health + _suffix.Health;
    public float Evasion => _prefix.Evasion + _armorType.Evasion + _suffix.Evasion;

    public override void Print()
    {
        TextHandler.PrettyWrite(Name + "\n", TextHandler.TextType.Description);
        TextHandler.PrettyWrite(@$"Stats:
Health: {Health}
Evasion: {Evasion}
", TextHandler.TextType.Good);
    }

    public override string ToString()
    {
        return $"{Name} [+{Health} Health] [{Evasion} Evasion]";
    }
}