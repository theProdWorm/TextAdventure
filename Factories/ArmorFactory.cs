using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;

namespace TextAdventure.Factories;

public class ArmorFactory : Factory
{
    public static readonly Armor DefaultArmor = new(
        new("Old", 0, 0.0f),
        new("Garments", 2, 0.0f),
        new("the Apprentice", 0, 0.0f));

    private List<WeightedElement<ArmorComponent>> _prefixes = [];
    private List<WeightedElement<ArmorComponent>> _armorTypes = [];
    private List<WeightedElement<ArmorComponent>> _suffixes = [];

    public ArmorFactory()
    {
        _prefixes.Add(new(10, new("", 0, 0)));
        _suffixes.Add(new(10, new("", 0, 0)));
    }

    public void RegisterPrefix(int weight, ArmorComponent prefix) =>
            _prefixes.Add(new(weight, prefix));
    public void RegisterArmorType(int weight, ArmorComponent armorType) =>
            _armorTypes.Add(new(weight, armorType));
    public void RegisterSuffix(int weight, ArmorComponent suffix) =>
            _suffixes.Add(new(weight, suffix));


    public Armor GenerateArmor()
    {
        
        
        throw new NotImplementedException();
    }
}