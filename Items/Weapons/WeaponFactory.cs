using TextAdventure.Items.Loot;

namespace TextAdventure.Items.Weapons;

public class WeaponFactory
{
    public static readonly Weapon DefaultWeapon = new(
        new("Clunky", 0, 0),
        new("Sword", 3, 0.8f),
        new("the Rookie", 0, 0));

    private List<LootElement<WeaponComponent>> prefixes = new();
    private List<LootElement<WeaponComponent>> armorTypes = new();
    private List<LootElement<WeaponComponent>> suffixes = new();

    public WeaponFactory()
    {
        prefixes.Add(new(10, new("", 0, 0)));
        suffixes.Add(new(10, new("", 0, 0)));
    }

    public void RegisterPrefix(int weight, WeaponComponent prefix) =>
        prefixes.Add(new(weight, prefix));
    public void RegisterArmorType(int weight, WeaponComponent armorType) =>
        armorTypes.Add(new(weight, armorType));
    public void RegisterSuffix(int weight, WeaponComponent suffix) =>
        suffixes.Add(new(weight, suffix));


    public Weapon GenerateWeapon()
    {
        throw new NotImplementedException();
    }
}