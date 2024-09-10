namespace TextAdventure;

public class WeaponFactory
{
    private List<WeaponComponent> prefixes = new()
    {
        new("Rusty", -1, 0),
        new("Legendary", 3, 1.0f)
    };

    private List<WeaponComponent> weaponTypes = new()
    {
        new("Sword", 3, 0.8f)
    };

    private List<WeaponComponent> suffixes = new()
    {
        new("Divine Retribution", 5, 0.2f)
    };

    public Weapon GenerateWeapon()
    {
        throw new NotImplementedException();
    }
}