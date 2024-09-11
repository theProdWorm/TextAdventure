using TextAdventure.Characters;

namespace TextAdventure.World;

public class Room
{
    public List<Character> Enemies { get; private set; }

    private readonly int _rewardGold;

    public Room(int rewardGold)
    {
        // TODO: Generate gold instead?
        
        Enemies = new List<Character>();
        _rewardGold = rewardGold;
    }

    public virtual void RewardPlayer(Player player)
    {
        player.AddGold(_rewardGold);
    }
}