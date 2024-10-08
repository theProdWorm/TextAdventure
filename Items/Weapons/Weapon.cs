using TextAdventure.Items.Items;

namespace TextAdventure.Items.Weapons;

public class Weapon(WeaponComponent prefix, WeaponComponent weaponType, WeaponComponent suffix) : Item($"{prefix.Name} {weaponType.Name} {suffix.Name}", 50)
{
    private readonly WeaponComponent _prefix = prefix;
    private readonly WeaponComponent _weaponType = weaponType;
    private readonly WeaponComponent _suffix = suffix;
    
    public int Damage => _prefix.Damage + _weaponType.Damage + _suffix.Damage;
    public float Accuracy => _prefix.Accuracy + _weaponType.Accuracy + _suffix.Accuracy;
    public float CritChance => _prefix.CritChance + _weaponType.CritChance + _suffix.CritChance;

    public override string ToString()
    {
        int accuracyPercent = (int) MathF.Round(Accuracy * 100);
        int critChancePercent = (int) MathF.Round(CritChance * 100);
        
        return $"{Name} [{Damage} Damage] [{accuracyPercent}% Accuracy] [{critChancePercent}% Crit Chance]";
    }
}