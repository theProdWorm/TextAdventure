using TextAdventure;

TextHandler.PrettyWrite("What's your name? (Default: Player)", TextHandler.TextType.Description, true);
string playerName = Console.ReadLine()!;
if (String.IsNullOrEmpty(playerName))
    playerName = "Player";

Console.Clear();

Game game = new Game(playerName, 3);
game.Run();