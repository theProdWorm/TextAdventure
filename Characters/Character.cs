namespace TextAdventure.Characters;
using TextAdventure.Items.Weapons;
using TextAdventure.Items.Armor;

public abstract class Character(int health)
{
    protected int _maxHealth = health;
    protected int _currentHealth = health;
    protected Weapon? _weapon;
    protected Armor? _armor;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
    }

    public void Equip(Weapon weapon)
    {
        _weapon = weapon;
    }
    public void Equip(Armor armor)
    {
        _armor = armor;
    }
}