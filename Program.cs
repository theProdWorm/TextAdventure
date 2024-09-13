using TextAdventure;
using TextAdventure.States;

bool run = true;

Action currentState = MainMenu;

while (run)
{
    currentState();
}

void MainMenu()
{
    TextHandler.PrettyWrite("DUNGEON DELVER\n", TextHandler.TextType.Description);
    TextHandler.PrettyWrite("A roguelike by Emma Fast and Emil Rohlén\n\n", TextHandler.TextType.Description);
    
    ChoiceEvent choiceEvent = new ChoiceEvent("Main Menu", ["New Game", "Exit"]);
    int choice = choiceEvent.GetChoice();
    currentState = choice switch
    {
        0 => NewGame,
        _ => ExitGame
    };
}

void NewGame()
{
    TextHandler.PrettyWrite("What's your name? (Default: Player)", TextHandler.TextType.Description, true);
    string playerName = Console.ReadLine()!;
    if (String.IsNullOrEmpty(playerName))
        playerName = "Player";

    Console.Clear();
    
    string[] difficulties =
    [
        "Easy",
        "Medium",
        "Hard",
        "Super easy"
    ];
    string[] weapons =
    [
        "Dagger",
        "Sword",
        "Hammer"
    ];
    ChoiceEvent difficultyChoice = new("Pick a difficulty", difficulties);
    ChoiceEvent weaponChoice = new("Pick a starting weapon", weapons);
    
    Difficulty chosenDifficulty = (Difficulty) difficultyChoice.GetChoice();
    string chosenWeapon = weapons[weaponChoice.GetChoice()];
    
    Game game = new Game(playerName, 6, MainMenu, ExitGame, chosenDifficulty, chosenWeapon);
    game.Run();
}

void ExitGame()
{
    run = false;
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    SuperEasy
}
