using TextAdventure.Characters;
using TextAdventure.World;

namespace TextAdventure;

public class Game
{
    private Player _player;
    private List<Floor> _floors;
    private Floor _currentFloor;

    public Game(Player player)
    {
        _player = player;
    }
}