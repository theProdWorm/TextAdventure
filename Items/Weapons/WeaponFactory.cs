namespace TextAdventure.Items.Weapons;

public static class WeaponFactory
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

    public static Weapon GetDefaultWeapon()
    {
        WeaponComponent prefix = new("", 0, 0);
        WeaponComponent weaponType = new("Sword", 3, 0.8f);
        WeaponComponent suffix = new("", 0, 0);

        Weapon weapon = new(prefix, weaponType, suffix);

        return weapon;
    }
}