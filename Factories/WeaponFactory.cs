using TextAdventure.Items.Weapons;

namespace TextAdventure.Factories;

public class WeaponFactory : Factory
{

    private readonly Dictionary<string, WeightedElement<WeaponComponent>> _prefixes = [];
    private readonly Dictionary<string, WeightedElement<WeaponComponent>> _weaponTypes = [];
    private readonly Dictionary<string, WeightedElement<WeaponComponent>> _suffixes = [];

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
    
    public Weapon GenerateGoodArmor()
    {
        var prefixes = GetListWithInvertedWeights(_prefixes.Values.ToList());
        var armorTypes = GetListWithInvertedWeights(_weaponTypes.Values.ToList());
        var suffixes = GetListWithInvertedWeights(_suffixes.Values.ToList());
        
        return new Weapon(GetRandomElementByWeight(prefixes), 
            GetRandomElementByWeight(armorTypes),
            GetRandomElementByWeight(suffixes));
    }
}