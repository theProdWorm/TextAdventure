namespace TextAdventure.Items.Weapons;

public class Weapon(WeaponComponent prefix, WeaponComponent weaponType, WeaponComponent suffix)
{
    private readonly WeaponComponent prefix = prefix;
    private readonly WeaponComponent weaponType = weaponType;
    private readonly WeaponComponent suffix = suffix;
    
    public string Name => $"{prefix.Name} {weaponType.Name} of {suffix.Name}";
    public int Damage => prefix.Damage + weaponType.Damage + suffix.Damage;
    public float Accuracy => prefix.Accuracy + weaponType.Accuracy + suffix.Accuracy;
}