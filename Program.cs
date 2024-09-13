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
    switch (choice)
    {
        case 0:
            currentState = NewGame;
            break;
        default:
            currentState = ExitGame;
            break;
    }
}

void NewGame()
{
    

    TextHandler.PrettyWrite("What's your name? (Default: Player)", TextHandler.TextType.Description, true);
    string playerName = Console.ReadLine()!;
    if (String.IsNullOrEmpty(playerName))
        playerName = "Player";

    Console.Clear();

    Game game = new Game(playerName, 6, MainMenu, ExitGame);
    game.Run();
}

void ExitGame()
{
    run = false;
}