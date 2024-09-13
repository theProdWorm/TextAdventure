using System.ComponentModel;
using TextAdventure.Factories;
using TextAdventure.Items.Items;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Weapons;

namespace TextAdventure.Items.Loot;

public class LootFactory(WeaponFactory weaponFactory, ArmorFactory armorFactory) : Factory
{
    private WeaponFactory _weaponFactory = weaponFactory;
    private ArmorFactory _armorFactory = armorFactory;
    
    private readonly Dictionary<string, WeightedElement<Item>> _items = [];

    private readonly List<WeightedElement<LootType>> _lootWeights = [];

    public void RegisterItem(string key, int weight, Item item)
    {
        _items.Add(key, new WeightedElement<Item>(weight, item));
    }

    public void RegisterLootWeight(int weight, LootType lootType)
    {
        _lootWeights.Add(new WeightedElement<LootType>(weight, lootType));
    }
    
    public LootHoard GenerateLoot(LootType lootType = LootType.Random)
    {
        if(lootType == LootType.Random)
            lootType = GetRandomElementByWeight(_lootWeights);
        
        Item? item = null;

        int gold = Game.random.Next(5, 30);
        switch (lootType)
        {
            case LootType.Weapon:
                item = _weaponFactory.GenerateWeapon();
                break;
            case LootType.Armor:
                item = _armorFactory.GenerateArmor();
                break;
            case LootType.Item:
                item = GetRandomElementByWeight(_items.Values.ToList());
                break;
            default:
                gold += Game.random.Next(5, 30);
                break;
        }
        return new LootHoard(gold, lootType, item);
    }

    public Item GenerateItem()
    {
        LootType lootType = GetRandomElementByWeight(_lootWeights);
        Item item;
        switch (lootType)
        {
            case LootType.Weapon:
                item = _weaponFactory.GenerateWeapon();
                break;
            case LootType.Armor:
                item = _armorFactory.GenerateArmor();
                break;
            default:
                item = GetRandomElementByWeight(_items.Values.ToList());
                break;
        }

        return item;
    }
}