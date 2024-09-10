namespace TextAdventure.Items.Armor;

public static class ArmorFactory
{
    private static List<ArmorComponent> prefixes =
    [
    ];

    private static List<ArmorComponent> armorTypes = 
    [
    ];

    private static List<ArmorComponent> suffixes =
    [
    ];
    
    public static Armor GenerateArmor()
    {
        throw new NotImplementedException();
    }
    
    public static Armor GetDefaultArmor()
    {
        ArmorComponent prefix = new("", 0, 0);
        ArmorComponent armorType = new("Sword", 3, 0.8f);
        ArmorComponent suffix = new("", 0, 0);

        Armor armor = new(prefix, armorType, suffix);

        return armor;
    }
}