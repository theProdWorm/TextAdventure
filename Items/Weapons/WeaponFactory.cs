namespace TextAdventure.Items.Weapons;

public class WeaponFactory
{
    private static List<WeaponComponent> prefixes =
    [
        new("Rusty", -1, 0),
        new("Legendary", 3, 1.0f)
    ];

    private static List<WeaponComponent> weaponTypes =
    [
        new("Sword", 3, 0.8f)
    ];

    private static List<WeaponComponent> suffixes =
    [
        new("Divine Retribution", 5, 0.2f)
    ];

    public static Weapon GenerateWeapon()
    {
        throw new NotImplementedException();
    }
}