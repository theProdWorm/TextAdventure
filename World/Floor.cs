namespace TextAdventure.World;

public class Floor
{
    private RoomFactory _roomFactory;
    private List<Room> _rooms = new List<Room>();
    
    private Room _currentRoom;
    public Room CurrentRoom { get => _currentRoom; }

    public Floor(RoomFactory roomFactory)
    {
        
    }
}