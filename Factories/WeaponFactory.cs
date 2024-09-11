using TextAdventure.Items.Weapons;

namespace TextAdventure.Factories;

public class WeaponFactory : Factory
{
    public static readonly Weapon DefaultWeapon = new(
        new("Clunky", 0, 0),
        new("Sword", 3, 0.8f),
        new("the Rookie", 0, 0));

    private List<WeightedElement<WeaponComponent>> _prefixes = [];
    private List<WeightedElement<WeaponComponent>> _armorTypes = [];
    private List<WeightedElement<WeaponComponent>> _suffixes = [];

    public WeaponFactory()
    {
        _prefixes.Add(new(10, new("", 0, 0)));
        _suffixes.Add(new(10, new("", 0, 0)));
    }

    public void RegisterPrefix(int weight, WeaponComponent prefix) =>
        _prefixes.Add(new(weight, prefix));
    public void RegisterWeaponType(int weight, WeaponComponent armorType) =>
        _armorTypes.Add(new(weight, armorType));
    public void RegisterSuffix(int weight, WeaponComponent suffix) =>
        _suffixes.Add(new(weight, suffix));


    public Weapon GenerateWeapon()
    {
        throw new NotImplementedException();
    }
}