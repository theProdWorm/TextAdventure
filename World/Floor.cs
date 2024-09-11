namespace TextAdventure.World;

public class Floor
{
    private List<Room> _rooms = new List<Room>();

    public Room CurrentRoom { get; private set; }

    public Floor()
    {
        // TODO: Generate a set of rooms and add to _rooms
    }
}