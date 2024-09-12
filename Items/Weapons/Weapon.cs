using TextAdventure.Items.Items;

namespace TextAdventure.Items.Weapons;

public class Weapon(WeaponComponent prefix, WeaponComponent weaponType, WeaponComponent suffix)
:Item($"{prefix.Name} {weaponType.Name} {suffix.Name}")
{
    private readonly WeaponComponent prefix = prefix;
    private readonly WeaponComponent weaponType = weaponType;
    private readonly WeaponComponent suffix = suffix;
    
    public int Damage => prefix.Damage + weaponType.Damage + suffix.Damage;
    public float Accuracy => prefix.Accuracy + weaponType.Accuracy + suffix.Accuracy;
    
    public override void Print()
    {
        TextHandler.PrettyWrite(Name + "\n", TextHandler.TextType.Description);
        TextHandler.PrettyWrite(@$"Stats:
Damage: {Damage}
Accuracy: {Accuracy}
", TextHandler.TextType.Good);
    }
}