namespace TextAdventure.Items.Armor;

public class Armor(ArmorComponent prefix, ArmorComponent armorType, ArmorComponent suffix)
{
    private readonly ArmorComponent _prefix = prefix;
    private readonly ArmorComponent _armorType = armorType;
    private readonly ArmorComponent _suffix = suffix;
    
    public string Name => $"{_prefix.Name} {_armorType.Name} of {_suffix.Name}";
    public int Health => _prefix.Health + _armorType.Health + _suffix.Health;
    public float Evasion => _prefix.Evasion + _armorType.Evasion + _suffix.Evasion;
}