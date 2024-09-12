namespace TextAdventure.World;

public class Door
{
    private Room _room;
    private Action<Room> _enter;
    private bool _isLocked;

    public Door(Room room, Action<Room> enter, bool isLocked = false)
    {
        _room = room;
        _enter = enter;
        _isLocked = isLocked;
    }

    public bool TryEnter()
    {
        if (!_isLocked)
        {
            _enter(_room);
            return true;
        }

        // TODO: check for key
        return false;
    }

    public string ToString()
    {
        return _room.ToString();
    }
}