using System.ComponentModel;
using TextAdventure.Factories;
using TextAdventure.Items.Items;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Weapons;

namespace TextAdventure.Items.Loot;

public class LootFactory(ArmorFactory armorFactory, WeaponFactory weaponFactory) : Factory
{
    
    private ArmorFactory _armorFactory = armorFactory;
    private WeaponFactory _weaponFactory = weaponFactory;
    
    private readonly List<Item> _items = [];

    private readonly List<WeightedElement<LootType>> _lootWeights = [];

    public void RegisterItem(string key, int weight, Item item)
    {
        throw new NotImplementedException();
    }

    public void RegisterLootWeight(int weight, LootType lootType)
    {
        _lootWeights.Add(new WeightedElement<LootType>(weight, lootType));
    }
    
    public LootHoard GenerateLoot()
    {
        LootType lootType = GetRandomElementByWeight(_lootWeights);
        Item? item = null;

        switch (lootType)
        {
            case LootType.Weapon:
                item = _weaponFactory.GenerateWeapon();
                break;
            case LootType.Armor:
                item = _armorFactory.GenerateArmor();
                break;
            case LootType.Item:
                //TODO: Get random item from _items (make weighted)
                break;
            default:
                break;
        }
        int gold = Game.random.Next(5, 30);
        return new LootHoard(gold, lootType, item);
    }
    /*public LootHoard GenerateItemLoot()
    {
        int gold = Game.random.Next(5, 30);
        
        // TODO: Generate a random item (or assortment of items)
        
        //LootHoard loot = new(gold, item)
        
        throw new NotImplementedException();
    }

    public LootHoard GenerateArmorLoot()
    {
        int gold = Game.random.Next(5, 30);
        Armor armor = _armorFactory.GenerateArmor();

        LootHoard loot = new(gold, LootType.Armor, armor);

        return loot;
    }

    public LootHoard GenerateWeaponLoot()
    {
        int gold = Game.random.Next(5, 30);
        Weapon weapon = _weaponFactory.GenerateWeapon();

        LootHoard loot = new(gold, LootType.Weapon, weapon);

        return loot;
    }

    public LootHoard GenerateGoldLoot()
    {
        int gold = Game.random.Next(50, 80);
        LootHoard loot = new(gold, LootType.Gold);

        return loot;
    }*/
}