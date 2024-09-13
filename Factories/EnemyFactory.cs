using TextAdventure.Characters;

namespace TextAdventure.Factories;

public class EnemyFactory : Factory
{
    private WeaponFactory _weaponFactory;
    private ArmorFactory _armorFactory;
    
    private readonly Dictionary<string, WeightedElement<(string, int)>> _enemyTypes = new();

    public EnemyFactory(WeaponFactory weaponFactory, ArmorFactory armorFactory)
    {
        _weaponFactory = weaponFactory;
        _armorFactory = armorFactory;
    }

    public void RegisterEnemyType(string key, int weight, (string, int) enemyValues)
    {
        _enemyTypes.Add(key, new WeightedElement<(string, int)>(weight, enemyValues));
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