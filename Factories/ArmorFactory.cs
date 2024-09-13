using TextAdventure.Items.Armors;
using TextAdventure.Items.Loot;

namespace TextAdventure.Factories;

public class ArmorFactory : Factory
{
    // public static readonly Armor DefaultArmor = new(
    //     new("Old", 0, 0.0f),
    //     new("Garments", 2, 0.0f),
    //     new("the Apprentice", 0, 0.0f));

    private Dictionary<string, WeightedElement<ArmorComponent>> _prefixes = [];
    private Dictionary<string, WeightedElement<ArmorComponent>> _armorTypes = [];
    private Dictionary<string, WeightedElement<ArmorComponent>> _suffixes = [];

    public ArmorFactory()
    {
        // _prefixes.Add(new(10, new("", 0, 0)));
        // _suffixes.Add(new(10, new("", 0, 0)));
    }

    public void RegisterPrefix(string key, int weight, ArmorComponent prefix)
    {
        _prefixes.Add(key, new(weight, prefix));
    }
    public void RegisterArmorType(string key, int weight, ArmorComponent armorType)
    {
        _armorTypes.Add(key, new(weight, armorType));
    }
    public void RegisterSuffix(string key, int weight, ArmorComponent suffix)
    {
        _suffixes.Add(key, new(weight, suffix));
    }


    public Armor GenerateArmor()
    {
        return new Armor(GetRandomElementByWeight(_prefixes.Values.ToList()), 
                         GetRandomElementByWeight(_armorTypes.Values.ToList()),
                         GetRandomElementByWeight(_suffixes.Values.ToList()));
    }

    public Armor GenerateArmor(string prefix, string armorType, string suffix)
    {
        return new Armor(_prefixes[prefix].Element, _armorTypes[armorType].Element, _suffixes[suffix].Element);
    }
    
    public Armor GenerateGoodArmor()
    {
        var prefixes = GetListWithInvertedWeights(_prefixes.Values.ToList());
        var armorTypes = GetListWithInvertedWeights(_armorTypes.Values.ToList());
        var suffixes = GetListWithInvertedWeights(_suffixes.Values.ToList());
        
        return new Armor(GetRandomElementByWeight(prefixes), 
            GetRandomElementByWeight(armorTypes),
            GetRandomElementByWeight(suffixes));
    }
}