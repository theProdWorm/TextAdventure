using System.ComponentModel;
using TextAdventure.Factories;
using TextAdventure.Items.Items;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Weapons;

namespace TextAdventure.Items.Loot;

public class LootFactory(ArmorFactory armorFactory, WeaponFactory weaponFactory)
{
    private ArmorFactory _armorFactory = armorFactory;
    private WeaponFactory _weaponFactory = weaponFactory;
    
    private List<Item> _items = [];
    
    public LootHoard GenerateItemLoot()
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

        LootHoard loot = new(gold, armor);

        return loot;
    }

    public LootHoard GenerateWeaponLoot()
    {
        int gold = Game.random.Next(5, 30);
        Weapon weapon = _weaponFactory.GenerateWeapon();

        LootHoard loot = new(gold, weapon);

        return loot;
    }

    public LootHoard GenerateGoldLoot()
    {
        int gold = Game.random.Next(50, 80);
        LootHoard loot = new(gold);

        return loot;
    }
}