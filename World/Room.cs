using System.ComponentModel;
using TextAdventure.Characters;
using TextAdventure.Items.Loot;

namespace TextAdventure.World;

public abstract class Room
{

    public abstract void Update(Player player);
    
    public new abstract string ToString();
}