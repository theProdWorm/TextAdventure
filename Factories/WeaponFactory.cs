using TextAdventure.Items.Weapons;

namespace TextAdventure.Factories;

public class WeaponFactory : Factory
{
    // public static readonly Weapon DefaultWeapon = new(
    //     new("Clunky", 0, 0),
    //     new("Sword", 3, 0.8f),
    //     new("the Rookie", 0, 0));

    private Dictionary<string, WeightedElement<WeaponComponent>> _prefixes = [];
    private Dictionary<string, WeightedElement<WeaponComponent>> _weaponTypes = [];
    private Dictionary<string, WeightedElement<WeaponComponent>> _suffixes = [];

    public WeaponFactory()
    {
        // _prefixes.Add(new(10, new("", 0, 0)));
        // _suffixes.Add(new(10, new("", 0, 0)));
    }

    public void RegisterPrefix(string key, int weight, WeaponComponent prefix)
    {
        _prefixes.Add(key, new(weight, prefix));
    }
    public void RegisterWeaponType(string key, int weight, WeaponComponent armorType)
    {
        _weaponTypes.Add(key, new(weight, armorType));
    }
    public void RegisterSuffix(string key, int weight, WeaponComponent suffix)
    {
        _suffixes.Add(key, new(weight, suffix));
    }


    public Weapon GenerateWeapon()
    {
        return new Weapon(GetRandomElementByWeight<WeaponComponent>(_prefixes.Values.ToList()),
                          GetRandomElementByWeight(_weaponTypes.Values.ToList()),
                          GetRandomElementByWeight(_suffixes.Values.ToList()));
    }

    public Weapon GenerateWeapon(string prefix, string weaponType, string suffix)
    {
        return new Weapon(_prefixes[prefix].Element, _weaponTypes[weaponType].Element, _suffixes[suffix].Element);
    }
}