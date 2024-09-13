namespace TextAdventure.Items.Weapons;

public class WeaponComponent(string name, int damage, float accuracy, float critChance)
{
    public string Name { get; } = name;

    public int Damage { get; } = damage;
    public float Accuracy { get; } = accuracy;

    public float CritChance { get; } = critChance;
}