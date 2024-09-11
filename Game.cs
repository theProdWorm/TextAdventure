using TextAdventure.Characters;
using TextAdventure.World;

namespace TextAdventure;

public class Game(Player player)
{
    public static Random random = new();
    
    private Player _player = player;
    private List<Floor> _floors = [];
    private Floor _currentFloor;

    private bool _isGameRunning = true;
    
    private Action _currentState;

    public void Loop()
    {
        _currentState = HandlePickingRoom;
        
        while (_isGameRunning)
        {
            _currentState();
        }
    }

    private void HandleCombat()
    {
        
    }

    private void HandleShop()
    {
        
    }

    private void HandlePickingRoom()
    {
        
    }
}