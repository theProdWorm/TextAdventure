namespace TextAdventure.Characters;
using TextAdventure.Items.Weapons;
using TextAdventure.Items.Armor;

public abstract class Character(string name, int health)
{
    public string Name { get; } = name;
    
    protected readonly int _maxHealth = health;
    protected int _currentHealth = health;
    protected Weapon _weapon = WeaponFactory.GetDefaultWeapon();
    protected Armor _armor = ArmorFactory.GetDefaultArmor();

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