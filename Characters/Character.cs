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

    public void Attack(Character target)
    {
        TextHandler.PrettyWrite($"{Name} is trying to attack {target.Name} using {_weapon.Name}!");
        Thread.Sleep(400);
        target.ReceiveAttack(_weapon.Damage, _weapon.Accuracy);
    }
    
    private void ReceiveAttack(int damage, float accuracy)
    {
        float effectiveAccuracy = accuracy * (1 - _armor.Evasion);
        
        float rolledValue = Game.random.NextSingle();
        bool isHit = rolledValue <= effectiveAccuracy;

        if (isHit)
        {
            _currentHealth -= damage;
            TextHandler.PrettyWrite(
                $"{Name} got hit for {damage} damage! They now have {_currentHealth} health.",
                TextHandler.TextType.Bad);
        }
        else
        {
            TextHandler.PrettyWrite($"{Name} evaded the attack!");
        }
    }
    
    protected void Heal(int healAmount)
    {
        int realAmountHealed = healAmount;
        
        if(_currentHealth + healAmount > _maxHealth)
        {
            realAmountHealed = _maxHealth - _currentHealth;
            _currentHealth = _maxHealth;
        }
        else
        {
            _currentHealth += healAmount;
        }
        
        TextHandler.PrettyWrite($"{Name} healed for {realAmountHealed} health!");
    }

    public void Equip(Weapon weapon) => _weapon = weapon;
    public void Equip(Armor armor) => _armor = armor;

    public string GetCombatPrint()
    {
        return $"{Name}, {_currentHealth} / {_maxHealth} health";
    }
}