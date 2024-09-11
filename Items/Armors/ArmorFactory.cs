using TextAdventure.Items.Loot;

namespace TextAdventure.Items.Armors;

public class ArmorFactory
{
    public static readonly Armor DefaultArmor = new(
        new("Old", 0, 0.0f),
        new("Garments", 2, 0.0f),
        new("the Apprentice", 0, 0.0f));

    private List<LootElement<ArmorComponent>> prefixes = new();
    private List<LootElement<ArmorComponent>> armorTypes = new();
    private List<LootElement<ArmorComponent>> suffixes = new();

    public ArmorFactory()
    {
        prefixes.Add(new(10, new("", 0, 0)));
        suffixes.Add(new(10, new("", 0, 0)));
    }

    public void RegisterPrefix(int weight, ArmorComponent prefix) =>
            prefixes.Add(new(weight, prefix));
    public void RegisterArmorType(int weight, ArmorComponent armorType) =>
            armorTypes.Add(new(weight, armorType));
    public void RegisterSuffix(int weight, ArmorComponent suffix) =>
            suffixes.Add(new(weight, suffix));


    public Armor GenerateArmor()
    {
        throw new NotImplementedException();
    }
}