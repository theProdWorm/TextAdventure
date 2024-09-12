using System.ComponentModel;
using TextAdventure.Characters;
using TextAdventure.Items.Loot;
using TextAdventure.States;

namespace TextAdventure.World;

public abstract class Room
{
    protected List<Door> _doors;

    public Room()
    {
        _doors = new List<Door>();
    }

    public abstract void Update(Player player);
    
    public void AddDoor(Door door)
    {
        _doors.Add(door);
    }

    protected void ChooseDoor()
    {
        string[] choices = new string[_doors.Count];
        for (int i = 0; i < _doors.Count; i++)
        {
            choices[i] = _doors[i].ToString();
        }
        ChoiceEvent choiceEvent = new ChoiceEvent($"Facing you are {_doors.Count} doors. Which will you enter? ", choices);
        while (!_doors[choiceEvent.GetChoice()].TryEnter()) {}
    }
    
    public new abstract string ToString();
}