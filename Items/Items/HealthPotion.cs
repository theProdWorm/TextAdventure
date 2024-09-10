using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public class HealthPotion(string name, Character character, int healAmount)
    : Item(name, _ => { character.Heal(healAmount); });