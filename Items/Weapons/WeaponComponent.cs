namespace TextAdventure.Items.Weapons;

public class WeaponComponent(string name, int damage, float accuracy)
{
    public string Name { get; } = name;

    public int Damage { get; } = damage;
    public float Accuracy { get; } = accuracy;
}