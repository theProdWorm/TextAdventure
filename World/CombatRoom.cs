using TextAdventure.Characters;
using TextAdventure.Items.Items;
using TextAdventure.Items.Loot;
using TextAdventure.States;

namespace TextAdventure.World;

public class CombatRoom : Room
{
    private List<Character> _enemies;
    public List<Character> Enemies { get => _enemies; }

    private LootHoard _lootHoard;
    
    public CombatRoom(LootHoard lootHoard, List<Character> enemies)
    {
        _lootHoard = lootHoard;
        _enemies = enemies;
    }

    public override void Update(Player player)
    {
        TextHandler.PrettyWrite("You enter a combat encounter! \n");
        TextHandler.PrettyWrite($"Facing you {(_enemies.Count > 1 ? "are" : "is")} {_enemies.Count} {(_enemies.Count > 1 ? "enemies" : "enemy")}. \n");
        bool isPlayerTurn = true;
        while (_enemies.Count > 0)
        {
            if (player.IsDead)
                return;
            if (isPlayerTurn)
                isPlayerTurn = CombatPlayerTurn(ref _enemies, player);
            else
                CombatEnemyTurn(_enemies, player);

            isPlayerTurn = !isPlayerTurn;
            
            Thread.Sleep(1000);
            Console.Clear();
        }
        
        player.ReceiveReward(_lootHoard);
        
        ChooseDoor(player);
    }
    
    /// <returns>Whether the action taken should end the turn</returns>
    private bool CombatPlayerTurn(ref List<Character> enemies, Player player)
    {
        TextHandler.PrettyWrite("It's your turn! \n", TextHandler.TextType.Description);
        player.PrintStats();
        
        const string combatDescription = "What is your next move?";
        string[] combatChoices = ["Attack", "Use item"];

        ChoiceEvent combatChoice = new(combatDescription, combatChoices);
        int choice = combatChoice.GetChoice();
        
        switch (choice)
        {
            case 0:
                const string attackDescription = "Who do you want to attack?";
                string[] attackChoices = new string[enemies.Count];

                for (int i = 0; i < enemies.Count; i++)
                {
                    attackChoices[i] = enemies[i].GetCombatPrint();
                }

                ChoiceEvent attackChoice = new(attackDescription, attackChoices);
                int enemyIndex = attackChoice.GetChoice();
                
                player.Attack(enemies[enemyIndex]);

                if(enemies[enemyIndex].IsDead)
                    enemies.RemoveAt(enemyIndex);
                
                return true;
            case 1:
                if (player.IsInventoryEmpty())
                {
                    TextHandler.PrettyWrite("You have no items!\n", TextHandler.TextType.Bad);
                    return false;
                }
                
                const string useItemDescription = "What item do you want to use?";
                List<string> useItemChoices = [];
                //useItemChoices.AddRange(player.Inventory.OfType<Item>().Select(item => item.Name));
                for (int i = 0; i < player.Inventory.Length; i++)
                {
                    useItemChoices.Add(player.Inventory[i] != null ? player.Inventory[i].Name : "Empty");
                }
                //useItemChoices = (from item in _player.Inventory select item.Name).ToList();
                
                ChoiceEvent useItemChoice = new(useItemDescription, useItemChoices.ToArray());
                int itemIndex = useItemChoice.GetChoice();
                
                return player.UseItem(itemIndex);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CombatEnemyTurn(List<Character> enemies, Player player)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            var enemy = enemies[i];
            
            
            int rolledValue = Game.random.Next(10);

            switch (rolledValue)
            {
                case 0: // Attack ally (10%)
                    int enemyIndex = Game.random.Next(enemies.Count);
                    enemy.Attack(enemies[enemyIndex]);
                    
                    if(enemy.IsDead)
                        enemies.RemoveAt(enemyIndex);
                    break;
                case 1: // Do nothing (10%)
                    TextHandler.PrettyWrite($"{enemy.Name} skips their turn.\n", TextHandler.TextType.Description);
                    break;
                default: // Attack player (80%)
                    enemy.Attack(player);
                    break;
            }
        }
    }

    public override string ToString()
    {
        return $"Reward: {(_lootHoard.Item is not null ? _lootHoard.Item.ToString() : "Heaps of gold")}";
    }
}