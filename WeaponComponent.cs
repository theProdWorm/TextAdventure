namespace TextAdventure;

public class WeaponComponent
{
    public string Name { get; }
    
    public int Damage { get; }
    public float Accuracy { get; }

    public WeaponComponent(string name, int damage, float accuracy)
    {
        Name = name;
        Damage = damage;
        Accuracy = accuracy;
    }
}