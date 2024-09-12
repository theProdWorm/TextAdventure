using TextAdventure.Factories;
using TextAdventure.Items.Armors;

namespace TextAdventure.Characters;
using TextAdventure.Items.Weapons;

public class Character
{
    public string Name { get; }

    private readonly int _baseMaxHealth;
    private int EffectiveMaxHealth => _baseMaxHealth + _armor.Health;
    private int _currentHealth;
    private Weapon _weapon;
    private Armor _armor;

    public Character(string name, int health, Weapon weapon, Armor armor)
    {
        Name = name;
        _baseMaxHealth = health;
        _armor = armor;
        _weapon = weapon;
        
        _currentHealth = EffectiveMaxHealth;
    }

    public bool IsDead => _currentHealth <= 0;
    
    /// <returns>Whether the target is still alive</returns>
    public void Attack(Character target)
    {
        TextHandler.PrettyWrite(
            $"{Name} is trying to attack {(target == this ? "itself" :target.Name)} using {_weapon.Name}!\n",
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
                $"{Name} got hit for {damage} damage! They now have {_currentHealth} health.\n",
                TextHandler.TextType.Bad);
        }
        else
        {
            TextHandler.PrettyWrite($"{Name} evaded the attack!\n");
        }
    }
    
    protected void Heal(int healAmount)
    {
        int realAmountHealed = healAmount;
        
        if(_currentHealth + healAmount > _baseMaxHealth)
        {
            realAmountHealed = _baseMaxHealth - _currentHealth;
            _currentHealth = _baseMaxHealth;
        }
        else
        {
            _currentHealth += healAmount;
        }
        
        TextHandler.PrettyWrite($"{Name} healed for {realAmountHealed} health!\n");
    }

    public void Equip(Weapon weapon) => _weapon = weapon;
    public void Equip(Armor armor) => _armor = armor;

    public string GetCombatPrint()
    {
        return $"{Name}, {_currentHealth} / {EffectiveMaxHealth} health" + 
               $"\t\tEquipped armor: {_armor.Name}" + 
               $"\t\tEquipped weapon: {_weapon.Name}";
    }
}