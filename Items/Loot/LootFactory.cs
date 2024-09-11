using System.ComponentModel;
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

    public LootHoard GenerateArmorLoot(ArmorFactory armorFactory)
    {
        int gold = Game.random.Next(5, 30);
        Armor armor = armorFactory.GenerateArmor();

        LootHoard loot = new(gold, armor);

        return loot;
    }
}