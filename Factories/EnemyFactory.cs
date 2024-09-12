using TextAdventure.Characters;

namespace TextAdventure.Factories;

public class EnemyFactory : Factory
{
    private readonly Dictionary<string, WeightedElement<Character>> _enemyTypes = new();

    public void RegisterEnemyType(string key, int weight, Character enemy)
    {
        _enemyTypes.Add(key, new WeightedElement<Character>(weight, enemy));
    }

    public Character GenerateEnemy()
    {
        return GetRandomElementByWeight(_enemyTypes.Values.ToList());
    }
}