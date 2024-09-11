using TextAdventure.Factories;
using TextAdventure.Items.Armors;

namespace TextAdventure.Characters;
using TextAdventure.Items.Weapons;

public abstract class Character(string name, int health)
{
    public string Name { get; } = name;

    private readonly int _maxHealth = health;
    private int _currentHealth = health;
    protected Weapon _weapon = WeaponFactory.DefaultWeapon;
    protected Armor _armor = ArmorFactory.DefaultArmor;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
    public void Heal(int healAmount)
    {
        int realAmountHealed = healAmount;
        
        if(_currentHealth + healAmount > _maxHealth)
        {
            _currentHealth = _maxHealth;
            realAmountHealed = _maxHealth - _currentHealth;
        }
        else
        {
            _currentHealth += healAmount;
        }
        
        TextHandler.PrettyWrite($"{Name} healed {realAmountHealed}");
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