using TextAdventure.Items.Items;

namespace TextAdventure.Items.Armors;

public class Armor(ArmorComponent prefix, ArmorComponent armorType, ArmorComponent suffix) : Item(
    $"{prefix.Name} {armorType.Name} of {suffix.Name}")
{
    private readonly ArmorComponent _prefix = prefix;
    private readonly ArmorComponent _armorType = armorType;
    private readonly ArmorComponent _suffix = suffix;
    
    public new string Name => $"{_prefix.Name} {_armorType.Name} of {_suffix.Name}";
    public int Health => _prefix.Health + _armorType.Health + _suffix.Health;
    public float Evasion => _prefix.Evasion + _armorType.Evasion + _suffix.Evasion;
}