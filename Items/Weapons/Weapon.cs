using TextAdventure.Items.Items;

namespace TextAdventure.Items.Weapons;

public class Weapon(WeaponComponent prefix, WeaponComponent weaponType, WeaponComponent suffix) : Item($"{prefix.Name} {weaponType.Name} {suffix.Name}")
{
    private readonly WeaponComponent _prefix = prefix;
    private readonly WeaponComponent _weaponType = weaponType;
    private readonly WeaponComponent _suffix = suffix;
    
    public int Damage => _prefix.Damage + _weaponType.Damage + _suffix.Damage;
    public float Accuracy => _prefix.Accuracy + _weaponType.Accuracy + _suffix.Accuracy;
    public float CritChance => _prefix.CritChance + _weaponType.CritChance + _suffix.CritChance;
    
    public override void Print()
    {
        TextHandler.PrettyWrite(Name + "\n", TextHandler.TextType.Description);
        TextHandler.PrettyWrite(@$"Stats:
Damage: {Damage}
Accuracy: {Accuracy}
", TextHandler.TextType.Good);
    }

    public override string ToString()
    {
        return $"{Name} [{Damage} Damage] [{Accuracy} Accuracy]";
    }
}