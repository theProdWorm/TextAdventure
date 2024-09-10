using TextAdventure.Characters;

namespace TextAdventure.Items.Items;

public abstract class Item(string name, Action<Character> use)
{
    public string Name { get; } = name;

    public Action<Character> Use = use;
}
