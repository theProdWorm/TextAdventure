using TextAdventure.Characters;

namespace TextAdventure.World;

public class Room
{
    private List<Character> _enemies;
    public List<Character> Enemies { get => _enemies; }

    private int _rewardGold;

    public Room(int rewardGold)
    {
        _enemies = new List<Character>();
        _rewardGold = rewardGold;
    }

    public virtual void RewardPlayer(Player player)
    {
        player.AddGold(_rewardGold);
    }
}