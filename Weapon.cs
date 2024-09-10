namespace TextAdventure;

public class Weapon
{
    private WeaponComponent prefix;
    private WeaponComponent weaponType;
    private WeaponComponent suffix;
    
    public string Name => $"{prefix.Name} {weaponType.Name} {suffix.Name}";
    public int Damage => prefix.Damage + weaponType.Damage + suffix.Damage;
    public float Accuracy => prefix.Accuracy + weaponType.Accuracy + suffix.Accuracy;
    
    
}