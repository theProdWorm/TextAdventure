using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public abstract class Consumable(string name, Action<Character> use) : Item(name, use)
{
    public virtual void Consume()
    {
        throw new NotImplementedException();
    }
}