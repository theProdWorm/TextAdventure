using TextAdventure.Factories;
using TextAdventure.Items.Armors;

namespace TextAdventure.Characters;
using TextAdventure.Items.Weapons;

public class Character
{
    private static readonly float _damageDeviation = 0.2f;
    
    public string Name { get; }

    protected int _baseMaxHealth;
    protected int EffectiveMaxHealth => _baseMaxHealth + _armor?.Health ?? _baseMaxHealth;
    protected int _currentHealth;
    protected Weapon? _weapon;
    protected Armor? _armor;

    public Character(string name, int health)
    {
        Name = name;
        _baseMaxHealth = health;
        _currentHealth = health;
    }

    public bool IsDead => _currentHealth <= 0;
    
    /// <returns>Whether the target is still alive</returns>
    public void Attack(Character target)
    {
        TextHandler.PrettyWrite(
            $"{Name} is trying to attack {(target == this ? "itself" :target.Name)} using {_weapon!.Name}!\n",
            TextHandler.TextType.Description);
        Thread.Sleep(400);

        target.ReceiveAttack(_weapon.Damage, _weapon.Accuracy, Game.random.NextSingle() <= _weapon.CritChance);
    }
    
    /// <returns>Whether the character is still alive</returns>
    protected virtual void ReceiveAttack(int damage, float accuracy, bool isCrit)
    {
        float effectiveAccuracy = accuracy * (1 - _armor!.Evasion);
        
        float rolledValue = Game.random.NextSingle();
        bool isHit = rolledValue <= effectiveAccuracy;

        if (isHit)
        {
            float deviation = 1 - (Game.random.NextSingle() * _damageDeviation - _damageDeviation * 0.5f);
            int realDamage = (int) MathF.Round(damage * deviation * (isCrit ? 2 : 1));
            
            _currentHealth -= realDamage;
            
            if(isCrit)
                TextHandler.PrettyWrite("It's a critical hit!\n");
            
            TextHandler.PrettyWrite(
                $"{Name} got hit for {realDamage} damage!" +
                (IsDead ? $"\n{Name} died. \n" : $" They now have {_currentHealth} health.\n"),
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
        
        if(_currentHealth + healAmount > EffectiveMaxHealth)
        {
            realAmountHealed = EffectiveMaxHealth - _currentHealth;
            _currentHealth = EffectiveMaxHealth;
        }
        else
        {
            _currentHealth += healAmount;
        }
        
        TextHandler.PrettyWrite($"{Name} healed for {realAmountHealed} health!\n");
    }

    public void Equip(Weapon weapon) => _weapon = weapon;
    public void Equip(Armor armor)
    {
        int damageTaken = 0;
        if (_currentHealth < _baseMaxHealth)
            damageTaken = _baseMaxHealth - _currentHealth;
        
        _armor = armor;
        _currentHealth = EffectiveMaxHealth - damageTaken;
    }

    public string GetCombatPrint()
    {
        return $"{Name}, {_currentHealth} / {EffectiveMaxHealth} health" +
               $"\n\t\tEquipped armor: {_armor!.ToString()}" +
               $"\n\t\tEquipped weapon: {_weapon!.ToString()}";
    }
}