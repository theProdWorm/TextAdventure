namespace TextAdventure.Items.Armors;

public class ArmorComponent(string name, int health, float evasion)
{
    public string Name { get; } = name;
    public int Health { get; } = health;
    public float Evasion { get; } = evasion;
}