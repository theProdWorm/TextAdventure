using TextAdventure.Characters;
using TextAdventure.Items.Armors;
using TextAdventure.Items.Weapons;

namespace TextAdventure.Factories;

public class EnemyFactory(WeaponFactory weaponFactory, ArmorFactory armorFactory) : Factory
{
    private readonly WeaponFactory _weaponFactory = weaponFactory;
    private readonly ArmorFactory _armorFactory = armorFactory;
    
    private readonly Dictionary<string, WeightedElement<(string, int)>> _enemyTypes = new();

    public void RegisterEnemyType(int weight, (string, int) nameAndHealth)
    {
        _enemyTypes.Add(nameAndHealth.Item1, new WeightedElement<(string, int)>(weight, nameAndHealth));
    }

    public Character GenerateEnemy()
    {
        var values = GetRandomElementByWeight(_enemyTypes.Values.ToList());
        Character enemy = new Character(values.Item1, values.Item2);
        enemy.Equip(_weaponFactory.GenerateWeapon());
        enemy.Equip(_armorFactory.GenerateArmor());

        return enemy;
    }
}