using TextAdventure;
using TextAdventure.Characters;

TextHandler.PrettyWrite("What's your name?", TextHandler.TextType.Description, true);
string playerName = Console.ReadLine()!;
if (String.IsNullOrEmpty(playerName))
    playerName = "Player";

Console.Clear();

Game game = new Game(playerName, 3);
game.Run();