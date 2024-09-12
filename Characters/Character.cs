using TextAdventure.Factories;
using TextAdventure.Items.Armors;

namespace TextAdventure.Characters;
using TextAdventure.Items.Weapons;

public class Character
{
    public string Name { get; }

    private readonly int _maxHealth;
    public int EffectiveMaxHealth { get => _maxHealth + _armor.Health; }
    private int _currentHealth;
    protected Weapon _weapon;
    protected Armor _armor;

    public Character(string name, int health, Weapon weapon, Armor armor)
    {
        Name = name;
        _maxHealth = health;
        _currentHealth = EffectiveMaxHealth;
        _weapon = weapon;
        _armor = armor;
    }

    public bool IsDead => _currentHealth <= 0;
    
    /// <returns>Whether the target is still alive</returns>
    public void Attack(Character target)
    {
        TextHandler.PrettyWrite(
            $"{Name} is trying to attack {(target == this ? "itself" :target.Name)} using {_weapon.Name}!",
            TextHandler.TextType.Description);
        Thread.Sleep(400);
        
        target.ReceiveAttack(_weapon.Damage, _weapon.Accuracy);
    }
    
    /// <returns>Whether the character is still alive</returns>
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